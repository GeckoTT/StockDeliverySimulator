using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Configuration
{
    /// <summary>
    /// Class which implements the ConfigurationGetRequest Mosaic message.
    /// </summary>
    public class ConfigurationGetRequest : MosaicMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationGetRequest"/> class.
        /// </summary>
        public ConfigurationGetRequest()
            : base(MessageType.ConfigurationGetRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationGetRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ConfigurationGetRequest(IConverterStream converterStream)
            : base(MessageType.ConfigurationGetRequest, converterStream)
        {
        }
    }
}
