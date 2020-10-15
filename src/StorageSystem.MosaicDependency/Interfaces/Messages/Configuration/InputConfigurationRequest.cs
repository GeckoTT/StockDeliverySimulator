using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Configuration
{
    /// <summary>
    /// Class which implements the InputConfigurationRequest Mosaic message.
    /// </summary>
    public class InputConfigurationRequest : MosaicMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputConfigurationRequest"/> class.
        /// </summary>
        public InputConfigurationRequest()
            : base(MessageType.InputConfigurationRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputConfigurationRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public InputConfigurationRequest(IConverterStream converterStream)
            : base(MessageType.InputConfigurationRequest, converterStream)
        {
        }
    }
}
