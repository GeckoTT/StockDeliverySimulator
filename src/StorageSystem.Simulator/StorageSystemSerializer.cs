using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StorageSystemSimulator.Cores;
using System.Xml;
using System.Runtime.Serialization;
using CareFusion.Mosaic.Interfaces.Types.Components;
using CareFusion.Mosaic.Connectors.Tcp;
using CareFusion.Mosaic.Converters.Wwks2;

namespace StorageSystemSimulator
{
    class StorageSystemSerializer
    {
        public void Save(string fileName, object objectToSave, Type typeOfObjectToSave)
        {
            Stream stream = null;
            try
            {
                stream = File.Open(fileName, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeOfObjectToSave);
                serializer.Serialize(stream, objectToSave);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        public object Load(string fileName, Type typeOfObjectToSave)
        {
            Stream stream = null;
            object result = null;
            try
            {
                if (File.Exists(fileName))
                {
                    stream = File.Open(fileName, FileMode.Open);
                    XmlSerializer serializer = new XmlSerializer(typeOfObjectToSave);
                    result = serializer.Deserialize(stream);
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return result;
        }

        public void SaveWithDataContract(string fileName, object objectToSave, Type typeOfObjectToSave)
        {
            Stream stream = null;
            try
            {
                stream = File.Open(fileName, FileMode.Create);
                DataContractSerializer serializer = new DataContractSerializer(typeOfObjectToSave);
                serializer.WriteObject(stream, objectToSave);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        public object LoadWithDataContract(string fileName, Type typeOfObjectToSave)
        {
            Stream stream = null;
            object result = null;
            try
            {
                if (File.Exists(fileName))
                {
                    stream = File.Open(fileName, FileMode.Open);
                    DataContractSerializer serializer = new DataContractSerializer(typeOfObjectToSave);
                    result = serializer.ReadObject(stream);
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return result;
        }

        public void SaveConnectionInformation(string fileName, 
            List<ConfigurationValue> configurationForTcpInConnector,
            List<ConfigurationValue> configurationForWwksConverter)
        {
            try
            {
                string tcpInConnectorConfig = "";
                foreach (ConfigurationValue configurationValue in configurationForTcpInConnector)
                {
                    tcpInConnectorConfig += configurationValue.Name + ";" + configurationValue.Value + ";";
                }

                string wwksConverterConfig = "";
                foreach (ConfigurationValue configurationValue in configurationForWwksConverter)
                {
                    wwksConverterConfig += configurationValue.Name + ";" + configurationValue.Value + ";";
                }

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(tcpInConnectorConfig);
                    writer.WriteLine(wwksConverterConfig);
                    writer.Close();
                }
            }
            finally
            {
            }
        }

        static public bool LoadConnectionInformation(string fileName,
            TcpInConnectorConfiguration tcpInConnectorConfiguration,
            WwksConverterConfiguration wwksConverterConfiguration)
        {
            try
            {
                string tcpInConnectorConfig = null;
                string wwksConverterConfig = null;

                using (StreamReader reader = new StreamReader(fileName))
                {
                    tcpInConnectorConfig = reader.ReadLine();
                    wwksConverterConfig = reader.ReadLine();
                    reader.Close();
                }

                string[] tcpInfields = tcpInConnectorConfig.Split(';');
                List<ConfigurationValue> configurationForTcpInConnector = new List<ConfigurationValue>();
                for (int i = 0; (i + 1) * 2 < tcpInfields.Length; i++)
                {
                    ConfigurationValue currentConfiguration = new ConfigurationValue();
                    currentConfiguration.Name = tcpInfields[(i * 2)];
                    currentConfiguration.Value = tcpInfields[(i * 2) + 1];
                    configurationForTcpInConnector.Add(currentConfiguration);
                }
                tcpInConnectorConfiguration.Initialize(configurationForTcpInConnector);


                string[] wwksfields = wwksConverterConfig.Split(';');
                List<ConfigurationValue> configurationForWwksConverter = new List<ConfigurationValue>();
                for (int i = 0; (i + 1) * 2 < wwksfields.Length; i++)
                {
                    ConfigurationValue currentConfiguration = new ConfigurationValue();
                    currentConfiguration.Name = wwksfields[(i * 2)];
                    currentConfiguration.Value = wwksfields[(i * 2) + 1];
                    configurationForWwksConverter.Add(currentConfiguration);
                }
                wwksConverterConfiguration.Initialize(configurationForWwksConverter);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}
