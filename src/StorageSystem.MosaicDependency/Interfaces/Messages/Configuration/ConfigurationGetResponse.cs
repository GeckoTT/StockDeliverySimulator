using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Configuration
{
    /// <summary>
    /// Class which implements the ConfigurationGetResponse Mosaic message.
    /// </summary>
    public class ConfigurationGetResponse : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the configuration payload.
        /// </summary>
        public string Configuration { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationGetResponse"/> class.
        /// </summary>
        public ConfigurationGetResponse()
            : base(MessageType.ConfigurationGetResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationGetResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ConfigurationGetResponse(IConverterStream converterStream)
            : base(MessageType.ConfigurationGetResponse, converterStream)
        {
        }
    }
}
