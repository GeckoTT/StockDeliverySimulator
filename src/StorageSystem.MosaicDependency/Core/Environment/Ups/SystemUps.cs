using Microsoft.Win32;
using Rowa.Lib.Log;
using System;
using System.Windows.Forms;

namespace CareFusion.Mosaic.Devices.Ups

{
    /// <summary>
    /// USV am Rechner als Systembatterie
    /// </summary>
    public delegate void UpsStateEvent(object sender, UpsState previousState, UpsState state);
    class SystemUps 
    {
        private bool UseCommInterface = false;
        SerialUps serialUps = null;
        #region Constructor / Dispose
        public SystemUps()
        {
            ////Log.Communication(this, "Using system battery information for UPS handling");
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            UpdateUpsStatus();
        }

        public static void Trace(string format)
        {
            LogManager.GetLogger("SystemUps").Debug(format, "");
        }
        private void InitCom(int port)
        {
            serialUps = new SerialUps(port);
        }

        public void Dispose()
        {
            try
            {
                ////Log.Communication(this, "Closing system ups");
            }
            catch (Exception)
            {
                ////Log.HandleException(this, ex);
            }
        }
        #endregion

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            UpdateUpsStatus();
        }

        public void UpdateUpsStatus()
        {
            try
            {
                UpsState StateB = State;
                if (SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.NoSystemBattery)
                    State = UpsState.ConnectionLost;
                else
                {                    
                    switch (SystemInformation.PowerStatus.PowerLineStatus)
                    {
                        case PowerLineStatus.Unknown:
                            State = UpsState.Unknown;
                            break;
                        case PowerLineStatus.Online:
                            State = UpsState.PowerBack;
                            break;
                        case PowerLineStatus.Offline:
                            switch (SystemInformation.PowerStatus.BatteryChargeStatus)
                            {
                                case BatteryChargeStatus.High:
                                    State = UpsState.PowerFailure;
                                    break;
                                case BatteryChargeStatus.Low:
                                case BatteryChargeStatus.Critical:
                                    State = UpsState.BattLow;
                                    break;
                                default:
                                    State = UpsState.UpsFailure;
                                    break;
                            }
                            break;
                        default:
                            State = UpsState.UpsFailure;
                            break;
                    }                    
                }
                if (StateB != State)
                {
                    Trace("SystemUps - Status changed to: " + State.ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("SystemUps").Error("Exception: " , ex.Message);
            }
        }

        public static bool HasSystemUps()
        {
            return SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery && SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.Unknown;
        }

        public void PowerOff(int minutes)
        {
            // Nix (evtl. Shutdown am PC ausführen)
        }

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
    }
}
