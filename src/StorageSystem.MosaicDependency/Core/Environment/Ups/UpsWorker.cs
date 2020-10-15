using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFusion.Mosaic.Devices.Ups
{
    static class UpsWorker
    {
        static private SystemUps sysUps = null;
        static private SerialUps serUps = null;
        static private bool bDoUsb = true;
        public static void Init()
        {
            sysUps = new SystemUps();
        }
        public static void Init(int port)
        {
            serUps = new SerialUps(port);
            bDoUsb = false;
        }
        public static void Update()
        {
            if (bDoUsb)
            {
                if (sysUps == null) return;
                sysUps.UpdateUpsStatus();
            }
            else
            {
                if (serUps == null) return;
                serUps.UpdateStatus();
            }
        }
        public static UpsState GetState()
        {
            UpsState State;
            if (bDoUsb)
            {
                if (sysUps == null)
                    return UpsState.Unknown;
                State = sysUps.State;
            }
            else
            {
                if (serUps == null)
                    return UpsState.Unknown;
                State = serUps.State;
            }
            return State;
        }

        public static bool IsLowPower()
        {
            bool b = false;
            UpsState State = GetState();
            if (State == UpsState.BattLow )
            {
                b = true;
            }
            return b;
        }

        public static bool IsPowerFailure()
        {
            bool b = false;
            UpsState State = GetState();
            if ((State == UpsState.PowerFailure) || (State == UpsState.BattLow))
            {
                b = true;
            }
            return b;
        }

        public static bool IsPower()
        {
            bool b = true;
            UpsState State = GetState();
            if ((State == UpsState.PowerFailure) || (State == UpsState.BattLow))
            {
                b = false;
            }
            return b;
        }
    }
}
