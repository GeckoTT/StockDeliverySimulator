using CareFusion.Mosaic.Interfaces.Converters;
using System.Collections.Generic;

namespace StorageSystemSimulator.Cores
{
    public class SimulatorRawXmlCore
    {
        private List<IConverterStream> converterStreamList;

        public SimulatorRawXmlCore()
        {
        }

        public void Initialize(List<IConverterStream> converterStreamList)
        {
            this.converterStreamList = converterStreamList;
        }

        public void SendRaw(byte[] message)
        {
            foreach (IConverterStream stream in this.converterStreamList)
            {
                stream.WriteRaw(message);
            }
        }
    }
}
