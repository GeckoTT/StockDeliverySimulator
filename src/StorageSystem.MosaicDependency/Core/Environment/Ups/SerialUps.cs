
using System;
using System.Text;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;

namespace CareFusion.Mosaic.Devices.Ups
{
    class SerialUps : SerialPortDevice
    {
        private StringBuilder m_Buffer = new StringBuilder();
        private bool m_Connected;
        private DateTime m_WriteStamp;

        public SerialUps(int port)
            : base(port, 2400)
        {
            m_SerialPort.NewLine = "\r";
            ////Log.Message(this, "UPS created on port {0}", port);
        }

        #region Methods

        public void UpdateStatus()
        {
            try
            {
                if (m_SerialPort.IsOpen)
                    ReadWriteData();
                else
                {
                    Connect();
                    if(m_SerialPort.IsOpen)
                       ReadWriteData();
                }

            }
            catch (Exception ex)
            {                    
                this.Error("UpdateStatus() failed.", ex);
            }
     
        }

        protected override bool Connect()
        {
            m_Connected = base.Connect();
            if (m_Connected)
                SendInit();
			else
                State = UpsState.UpsFailure;
            return m_Connected;
        }

        private void Disconnect()
        {
            m_Connected = false;
            m_TimeStamp = DateTime.Now;
            State = UpsState.ConnectionLost;
        }

        protected override void Init()
        {
            // Nix
        }

        private void ReadData()
        {
            if (m_SerialPort.BytesToRead > 0)
            {
                m_Buffer.Append(m_SerialPort.ReadExisting());
                int t = 0;
                while (t < m_Buffer.Length)
                {
                    if (m_Buffer[t] == '\r')
                    {
                        if (t > 0)
                            ProcessData(m_Buffer.ToString(0, t));
                        m_Buffer.Remove(0, t + 1);
                        t = -1;
                    }

                    t++;
                }
            }
        }

        protected override void ReadWriteData()
        {
            try
            {
                if (m_Connected)
                {
                    ReadData();

                    SendInquiry();
                }
                else
                    if ((DateTime.Now - m_TimeStamp).TotalSeconds > 10)
                        SendInit();
                
            }
            catch (Exception)
            {
                ////Log.HandleException(this, ex);
            }
        }

        public void PowerOff(int minutes)
        {
            WriteData(string.Format("S{0}", minutes));
        }

        private void ProcessData(string s)
        {
            m_TimeStamp = DateTime.Now;
            if (s.StartsWith("#"))
            {
                ////Log.Communication(this, "Connected to: {0}", s.Substring(1));
                State = UpsState.Connected;
            }
            if (s.StartsWith("(") && s.Length == 46)
                if (s[41] == '1')
                    State = UpsState.UpsFailure;
                else
                    if (s[39] == '1')
                        State = UpsState.BattLow;
                    else
                        if (s[38] == '1')
                            State = UpsState.PowerFailure;
                        else
                            State = UpsState.PowerBack;
        }

        private void SendInit()
        {
            WriteData("I");
        }

        private void SendInquiry()
        {
            WriteData("Q1");
        }

        private void WriteData(string s)
        {
            try
            {
                m_SerialPort.WriteLine(s);
                m_WriteStamp = DateTime.Now;
            }
            catch (Exception)
            {
                ////Log.HandleException(this, ex);
            }
        }

        #endregion


        #region Public properties

        public event UpsStateEvent OnUpsState;

        #region property State
        private UpsState m_State;
        public UpsState State
        {
            get { return m_State; }
            set
            {
                if (m_State != value)
                {
                    var oldvalue = m_State;
                    m_State = value;
                    if (OnUpsState != null)
                        OnUpsState(this, oldvalue, value);
                }
            }
        }
        #endregion

        #endregion
    }
}
