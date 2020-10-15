using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemStatusRequest Mosaic message.
    /// This request is used to request the status of a transport system hand over point.
    /// </summary>
    public class TransportSystemStatusRequest : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// The transfer point to get the status for.
        /// </summary>
        public string TransferPoint { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemStatusRequest"/> class.
        /// </summary>
        public TransportSystemStatusRequest()
            : base(MessageType.TransportSystemStatusRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemStatusRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemStatusRequest(IConverterStream converterStream)
            : base(MessageType.TransportSystemStatusRequest, converterStream)
        {
        }
    }
}
