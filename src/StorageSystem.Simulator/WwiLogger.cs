using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rowa.Lib.Log;
using CareFusion.Mosaic.Core.Logging;

namespace StorageSystemSimulator
{
    public delegate void WwiMessageEventHandler(object sender, string message, bool isIncommingMessage);

    class WwiLogger : IWwi
    {

        public WwiLogger()
        {
            WwiLogIntercept.SetSecondWwiLogger(this);
        }


        public void Dispose()
        {
        }

        public void LogMessage(byte[] message, bool isIncommingMessage = true)
        {
            if (this.WwiMessage != null)
            {
                string tmp = System.Text.Encoding.UTF8.GetString(message);
                this.WwiMessage(this, tmp, isIncommingMessage);
            }
        }

        public void LogMessage(string message, bool isIncommingMessage = true)
        {
            if (this.WwiMessage != null)
            {
                this.WwiMessage(this, message, isIncommingMessage);
            }
        }

        public void LogMessage(byte[] message, int index, int length, bool isIncommingMessage = true)
        {
            if (this.WwiMessage != null)
            {
                string tmp = System.Text.Encoding.UTF8.GetString(message);
                this.WwiMessage(this, tmp, isIncommingMessage);
            }
        }

        public event WwiMessageEventHandler WwiMessage;
    }
}
