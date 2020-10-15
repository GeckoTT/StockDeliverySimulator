using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rowa.Lib.Log;

namespace CareFusion.Mosaic.Core.Logging
{
    public class WwiLogIntercept : IWwi
    {
        static WwiLogIntercept singleton = null;
        private IWwi baseWwiLog;
        private IWwi secondWwiLog;

        private WwiLogIntercept()
        {
            
        }

        static public WwiLogIntercept GetSingleton()
        {
            if (singleton == null)
            {
                singleton = new WwiLogIntercept();
            }

            return singleton;
        }
        static public void CreateBaseWwiLogger(string description, string remoteAddress, ushort port)
        {
            WwiLogIntercept.GetSingleton().baseWwiLog = LogManager.GetWwi(description, remoteAddress, port);
        }

        static public void SetSecondWwiLogger(IWwi secondWwiLog)
        {
            WwiLogIntercept.GetSingleton().secondWwiLog = secondWwiLog;
        }


        public void Dispose()
        {
            if (this.baseWwiLog != null)
            {
                this.baseWwiLog.Dispose();
            }

            if (this.secondWwiLog != null)
            {
                this.secondWwiLog.Dispose();
            }
        }

        public void LogMessage(byte[] message, bool isIncommingMessage = true)
        {
            if (this.baseWwiLog != null)
            {
                this.baseWwiLog.LogMessage(message, isIncommingMessage);
            }

            if (this.secondWwiLog != null)
            {
                this.secondWwiLog.LogMessage(message, isIncommingMessage);
            }
        }

        public void LogMessage(string message, bool isIncommingMessage = true)
        {
            if (this.baseWwiLog != null)
            {
                this.baseWwiLog.LogMessage(message, isIncommingMessage);
            }

            if (this.secondWwiLog != null)
            {
                this.secondWwiLog.LogMessage(message, isIncommingMessage);
            }
        }

        public void LogMessage(byte[] message, int index, int length, bool isIncommingMessage = true)
        {
            if (this.baseWwiLog != null)
            {
                this.baseWwiLog.LogMessage(message, index, length, isIncommingMessage);
            }

            if (this.secondWwiLog != null)
            {
                this.secondWwiLog.LogMessage(message, index, length, isIncommingMessage);
            }
        }
    }
}
