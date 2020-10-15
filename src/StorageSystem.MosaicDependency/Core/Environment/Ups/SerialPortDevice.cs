using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace CareFusion.Mosaic.Devices.Ups
{
    abstract class SerialPortDevice 
    {
        #region Non-public fields

        private Thread m_ControlThread;
        protected SerialPort m_SerialPort;
        protected DateTime m_TimeStamp;

        #endregion


        #region Constructors/destructors

        public SerialPortDevice(int port, int baudRate)
        {
            Port = port;
            m_SerialPort = new SerialPort("COM" + Port, baudRate, Parity.None, 8, StopBits.One);
            m_SerialPort.Handshake = Handshake.None;

        }



        #endregion


        #region Methods

        protected virtual bool Connect()
        {
            try
            {
                ////Log.Communication(this, "Opening serial port COM{0}", Port);
                m_TimeStamp = DateTime.Now;
                m_SerialPort.Open();
                m_SerialPort.DiscardInBuffer();
                m_SerialPort.DiscardOutBuffer();
                return true;
            }
            catch (Exception)
            {
                ////Log.HandleException(this, ex);
                return false;
            }
        }


        protected abstract void Init();

        protected abstract void ReadWriteData();

        #endregion


        #region Public properties

        public delegate void OnSerialThreadTerminateEvent(Object sender);
        public event OnSerialThreadTerminateEvent OnSerialThreadTerminate;
        public int Port { get; private set; }

        #endregion
    }
}
