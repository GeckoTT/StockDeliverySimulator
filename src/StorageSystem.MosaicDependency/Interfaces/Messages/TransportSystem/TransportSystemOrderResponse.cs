using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemOrderResponse Mosaic message.
    /// This response is used to answer to the according TransportSystemOrderRequest.
    /// </summary>
    public class TransportSystemOrderResponse : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// The transfer point to get the information for.
        /// </summary>
        public string TransferPoint { get; set; }

        /// <summary>
        /// The identifier of the according output.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// The command that has been executed.
        /// </summary>
        public TransportSystemCommand Command { get; set; }

        /// <summary>
        /// Result of the command that has been executed.
        /// </summary>
        public TransportSystemCommandResult Result { get; set; }

        /// <summary>
        /// In case of a "GenericError" result, the error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// In case of a "GenericError" result, the error text.
        /// </summary>
        public string ErrorText { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemOrderResponse"/> class.
        /// </summary>
        public TransportSystemOrderResponse()
            : base(MessageType.TransportSystemOrderResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemOrderResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemOrderResponse(IConverterStream converterStream)
            : base(MessageType.TransportSystemOrderResponse, converterStream)
        {
        }
    }

}
