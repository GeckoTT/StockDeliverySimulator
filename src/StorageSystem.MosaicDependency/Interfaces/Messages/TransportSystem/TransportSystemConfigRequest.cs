using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemConfigRequest Mosaic message.
    /// This request is used to request the configuration of a transport system hand over point.
    /// </summary>
    public class TransportSystemConfigRequest : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// The transfer point to get the information for.
        /// </summary>
        public string TransferPoint { get; set; }
        
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemConfigRequest"/> class.
        /// </summary>
        public TransportSystemConfigRequest()
            : base(MessageType.TransportSystemConfigRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemConfigRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemConfigRequest(IConverterStream converterStream)
            : base(MessageType.TransportSystemConfigRequest, converterStream)
        {
        }
    }
}
