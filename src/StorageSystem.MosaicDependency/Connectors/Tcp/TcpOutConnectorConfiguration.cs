using System;
using System.Collections.Generic;
using System.ComponentModel;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Connectors.Tcp
{
    /// <summary>
    /// Class which represents the configuration of an outgoing TCP connector.
    /// </summary>
    public class TcpOutConnectorConfiguration : IComponentConfiguration
    {
        #region Properties

        [Category("Connection Settings")]
        [DisplayName("IP Address")]
        [Description("The IP address of the remote host.")]
        public string Address
        {
            get;
            set;
        }

        [Category("Connection Settings")]
        [DisplayName("Port")]
        [Description("The port of the remote host.")]
        public ushort Port
        {
            get;
            set;
        }

        [Category("Connection Settings")]
        [DisplayName("Connect Timeout (s)")]
        [Description("The connect timeout in seconds.")]
        public uint ConnectTimeout
        {
            get;
            set;
        }

        [Category("Connection Settings")]
        [DisplayName("Read Timeout (s)")]
        [Description("The timeout for read operations in seconds. (0) means no timeout.")]
        public uint ReadTimeout
        {
            get;
            set;
        }

        [Category("Connection Settings")]
        [DisplayName("Write Timeout (s)")]
        [Description("The timeout for write operations in seconds. (0) means no timeout.")]
        public uint WriteTimeout
        {
            get;
            set;
        }

        [Category("Connection Settings")]
        [DisplayName("Connection Category")]
        [Description("Defines the category of the connections which are created by this connector.")]
        public ConnectionCategory Category
        {
            get;
            set;
        }
        
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpOutConnectorConfiguration"/> class.
        /// </summary>
        public TcpOutConnectorConfiguration()
        {
            SetDefaultValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpOutConnectorConfiguration"/> class.
        /// </summary>
        /// <param name="configurationValueList">The configuration values to use for initialization.</param>
        public TcpOutConnectorConfiguration(List<ConfigurationValue> configurationValueList)
        {
            Initialize(configurationValueList);
        }

        /// <summary>
        /// (Re)Initializes the configuration object with the specified configuration values.
        /// </summary>
        /// <param name="configurationValueList">The configuration values to use for initialization.</param>
        public void Initialize(List<ConfigurationValue> configurationValueList)
        {
            SetDefaultValues();

            foreach (var configValue in configurationValueList)
            {
                if (configValue.Name == "Port")
                {
                    this.Port = ushort.Parse(configValue.Value);
                }
                else if (configValue.Name == "Address")
                {
                    this.Address = configValue.Value;
                }
                else if (configValue.Name == "ConnectTimeout")
                {
                    this.ConnectTimeout = uint.Parse(configValue.Value);
                }
                else if (configValue.Name == "ReadTimeout")
                {
                    this.ReadTimeout = uint.Parse(configValue.Value);
                }
                else if (configValue.Name == "WriteTimeout")
                {
                    this.WriteTimeout = uint.Parse(configValue.Value);
                }
                else if (configValue.Name == "Category")
                {
                    this.Category = (ConnectionCategory)Enum.Parse(typeof(ConnectionCategory), configValue.Value);
                }
            }      
        }

        /// <summary>
        /// Converts the configuration object into a list of configuration value instances.
        /// </summary>
        /// <returns>
        /// The list of configuration value instances.
        /// </returns>
        public List<ConfigurationValue> ToConfigurationValueList()
        {
            List<ConfigurationValue> resultList = new List<ConfigurationValue>();
            resultList.Add(new ConfigurationValue() { Name = "Port", Value = this.Port.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "Address", Value = this.Address });
            resultList.Add(new ConfigurationValue() { Name = "ConnectTimeout", Value = this.ConnectTimeout.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "ReadTimeout", Value = this.ReadTimeout.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "WriteTimeout", Value = this.WriteTimeout.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "Category", Value = this.Category.ToString() });
            return resultList;
        }

        /// <summary>
        /// (Re)Sets the configuration properties to the default values.
        /// </summary>
        private void SetDefaultValues()
        {
            this.Port = 7000;
            this.ConnectTimeout = 30;
            this.ReadTimeout = 0;
            this.WriteTimeout = 0;
            this.Address = string.Empty;
            this.Category = ConnectionCategory.StorageSystem;
        }
    }
}
