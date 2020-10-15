using System;
using System.Collections.Generic;
using System.ComponentModel;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Connectors.Tcp
{
    /// <summary>
    /// Class which represents the configuration of a TCP inbound connector.
    /// </summary>
    public class TcpInConnectorConfiguration : IComponentConfiguration
    {
        #region Properties

        [Category("TCP Listener Settings")]
        [DisplayName("Listening Port")]
        [Description("The TCP listening port.")]
        public ushort Port
        {
            get;
            set;
        }

        [Category("TCP Listener Settings")]
        [DisplayName("Connection Category")]
        [Description("Defines the category of the connections which are created by this connector.")]
        public ConnectionCategory Category
        {
            get;
            set;
        }

        [Category("TCP Listener Settings")]
        [DisplayName("Maximum Concurrent Connections")]
        [Description("The maximum number of allowed incoming concurrent connections.")]
        public int MaxConcurrentConnections
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpInConnectorConfiguration"/> class.
        /// </summary>
        public TcpInConnectorConfiguration()
        {
            SetDefaultValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpInConnectorConfiguration"/> class.
        /// </summary>
        /// <param name="configurationValueList">The configuration values to use for initialization.</param>
        public TcpInConnectorConfiguration(List<ConfigurationValue> configurationValueList)
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
                else if (configValue.Name == "Category")
                {
                    ConnectionCategory category = ConnectionCategory.ItSystem;

                    if (Enum.TryParse<ConnectionCategory>(configValue.Value, out category))
                    {
                        this.Category = category;
                    }
                    else
                    {
                        this.Category = ConnectionCategory.ItSystem;
                    }
                }
                if (configValue.Name == "MaxConcurrentConnections")
                {
                    this.MaxConcurrentConnections = int.Parse(configValue.Value);
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
            resultList.Add(new ConfigurationValue() { Name = "Category", Value = this.Category.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "MaxConcurrentConnections", Value = this.MaxConcurrentConnections.ToString() });
            
            return resultList;
        }

        /// <summary>
        /// (Re)Sets the configuration properties to the default values.
        /// </summary>
        private void SetDefaultValues()
        {
            this.Port = 6050;
            this.Category = ConnectionCategory.ItSystem;
            this.MaxConcurrentConnections = 10;
        }
    }
}
