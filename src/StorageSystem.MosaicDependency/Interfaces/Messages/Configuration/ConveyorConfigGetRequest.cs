using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Configuration
{
    /// <summary>
    /// Class which implements the ConveyorConfigGetRequest Mosaic message.
    /// </summary>
    public class ConveyorConfigGetRequest : MosaicMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConveyorConfigGetRequest"/> class.
        /// </summary>
        public ConveyorConfigGetRequest()
            : base(MessageType.ConveyorConfigGetRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConveyorConfigGetRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ConveyorConfigGetRequest(IConverterStream converterStream)
            : base(MessageType.ConveyorConfigGetRequest, converterStream)
        {
        }
    }
}
