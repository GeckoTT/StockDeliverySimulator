using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemManualOrder Mosaic message.
    /// This message is used to notify the storage system about manually triggered conveyor commands.
    /// </summary>
    public class TransportSystemManualOrderMessage : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// The transfer point which is involved into the manual command.
        /// </summary>
        public string TransferPoint { get; set; }

        /// <summary>
        /// The order number which is affected by the manual command.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// The command that has been triggered manually.
        /// </summary>
        public TransportSystemCommand Command { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemManualOrderMessage"/> class.
        /// </summary>
        public TransportSystemManualOrderMessage()
            : base(MessageType.TransportSystemManualOrderMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemManualOrderMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemManualOrderMessage(IConverterStream converterStream)
            : base(MessageType.TransportSystemManualOrderMessage, converterStream)
        {
        }
    }
}
