using System;
using System.Collections.Generic;
using System.ComponentModel;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Converters.Wwks2
{
    /// <summary>
    ///  Class which represents the configuration of a WWKS 2.0 converter.
    /// </summary>
    public class WwksConverterConfiguration : IComponentConfiguration
    {
        #region Properties

        [Category("Protocol Settings")]
        [DisplayName("Subscriber ID")]
        [Description("The subscriber identifier of Mosaic which is used for the source and destination values in the WWKS 2.0 messages.")]
        public int SubscriberID 
        { 
            get; 
            set; 
        }

        [Category("Protocol Settings")]
        [DisplayName("Subscriber Type")]
        [Description("The subscriber type of Mosaic which is required for correct protocol handshake.")]
        public SubscriberType Type
        {
            get;
            set;
        }

        [Category("Protocol Settings")]
        [DisplayName("Enable Message Echo")]
        [Description("All received messages except of the HelloRequest are sent back directly after receiving them (Singapur Extension).")]
        public bool EnableMessageEcho 
        { 
            get; 
            set; 
        }

        [Category("Protocol Settings")]
        [DisplayName("Small Message Set")]
        [Description("This enables the WWKS 2.0 small message set which does not contain all specified WWKS 2.0 attributes (Singapur Extension).")]
        public bool SmallMessageSet
        {
            get;
            set;
        }

        [Category("Protocol Settings")]
        [DisplayName("Enable Keep Alive")]
        [Description("This enables WWKS 2.0 keep alive mechanism to detect broken connection streams.")]
        public bool EnableKeepAlive
        {
            get;
            set;
        }

        [Category("Protocol Settings")]
        [DisplayName("Keep Alive Interval (s)")]
        [Description("This defines the WWKS 2.0 keep alive interval in seconds.")]
        public int KeepAliveInterval
        {
            get;
            set;
        }

        [Category("Protocol Settings")]
        [DisplayName("Keep Alive TimeOut (s)")]
        [Description("This defines the WWKS 2.0 keep alive timeout in seconds.")]
        public int KeepAliveTimeOut
        {
            get;
            set;
        }

        [Category("Protocol Settings")]
        [DisplayName("Handshake Timeout (s)")]
        [Description("This defines the WWKS protocol handshake timeout in seconds (0 means no timeout).")]
        public int HandshakeTimeout
        {
            get;
            set;
        }

        [Category("Protocol Settings")]
        [DisplayName("Use ExternalId As SerialNumber")]
        [Description("This enables WWKS 2.0 to use ExternalId as SerialNumber.")]
        public bool UseExternalIdAsSerialNumber
        {
            get;
            set;
        }

        [Category("Debug Settings")]
        [DisplayName("Log Messages")]
        [Description("Enables message trace logs in form of wwi files.")]
        public bool EnableMessageTrace 
        { 
            get; 
            set; 
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="WwksConverterConfiguration"/> class.
        /// </summary>
        public WwksConverterConfiguration()
        {
            SetDefaultValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WwksConverterConfiguration"/> class.
        /// </summary>
        /// <param name="configurationValueList">The configuration value list.</param>
        public WwksConverterConfiguration(List<ConfigurationValue> configurationValueList)
        {
            Initialize(configurationValueList);
        }

        /// <summary>
        /// (Re)Initializes the configuration object with the specified configuration values.
        /// </summary>
        /// <param name="configurationValueList">The list of configuration values to use for initialization.</param>
        public void Initialize(List<ConfigurationValue> configurationValueList)
        {
            SetDefaultValues();

            foreach (var configValue in configurationValueList)
            {
                if (configValue.Name == "SubscriberID")
                {
                    this.SubscriberID = int.Parse(configValue.Value);
                }
                else if (configValue.Name == "Type")
                {
                    this.Type = (SubscriberType)Enum.Parse(typeof(SubscriberType), configValue.Value);
                }
                else if (configValue.Name == "EnableMessageEcho")
                {
                    this.EnableMessageEcho = bool.Parse(configValue.Value);
                }
                else if (configValue.Name == "SmallMessageSet")
                {
                    this.SmallMessageSet = bool.Parse(configValue.Value);
                }
                else if (configValue.Name == "EnableKeepAlive")
                {
                    this.EnableKeepAlive = bool.Parse(configValue.Value);
                }
                else if (configValue.Name == "KeepAliveInterval")
                {
                    this.KeepAliveInterval = int.Parse(configValue.Value);
                }                    
                else if (configValue.Name == "EnableMessageTrace")
                {
                    this.EnableMessageTrace = bool.Parse(configValue.Value);
                }
                else if (configValue.Name == "KeepAliveTimeOut")
                {
                    this.KeepAliveTimeOut = int.Parse(configValue.Value);
                }
                else if (configValue.Name == "HandshakeTimeout")
                {
                    this.HandshakeTimeout = int.Parse(configValue.Value);
                }
                else if (configValue.Name == "UseExternalIdAsSerialNumber")
                {
                    this.UseExternalIdAsSerialNumber = bool.Parse(configValue.Value);
                }
            }        
        }

        /// <summary>
        /// Converts the configuration object into a list of configuration value instances.
        /// </summary>
        /// <returns>
        /// The list of configuration value instances.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<ConfigurationValue> ToConfigurationValueList()
        {
            List<ConfigurationValue> resultList = new List<ConfigurationValue>();
            resultList.Add(new ConfigurationValue() { Name = "SubscriberID", Value = this.SubscriberID.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "Type", Value = this.Type.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "EnableMessageEcho", Value = this.EnableMessageEcho.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "SmallMessageSet", Value = this.SmallMessageSet.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "EnableKeepAlive", Value = this.EnableKeepAlive.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "KeepAliveInterval", Value = this.KeepAliveInterval.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "EnableMessageTrace", Value = this.EnableMessageTrace.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "KeepAliveTimeOut", Value = this.KeepAliveTimeOut.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "HandshakeTimeout", Value = this.HandshakeTimeout.ToString() });
            resultList.Add(new ConfigurationValue() { Name = "UseExternalIdAsSerialNumber", Value = this.UseExternalIdAsSerialNumber.ToString() });
            return resultList;
        }
        
        /// <summary>
        /// (Re)Sets the configuration properties to the default values.
        /// </summary>
        private void SetDefaultValues()
        {
            this.SubscriberID = 999;
            this.Type = SubscriberType.Robot;
            this.EnableMessageEcho = false;
            this.EnableMessageTrace = false;
            this.SmallMessageSet = false;
            this.EnableKeepAlive = false;
            this.KeepAliveInterval = 30;
            this.KeepAliveTimeOut = 60;
            this.HandshakeTimeout = 6;
            this.UseExternalIdAsSerialNumber = false;
        }
    }
}
