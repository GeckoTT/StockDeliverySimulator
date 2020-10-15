using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemOrderComplete Mosaic message.
    /// This message is used to notify about the completion of an output order.
    /// </summary>
    public class TransportSystemTransferPointStatus : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the transfer point.
        /// </summary>
        public string TransferPoint { get; set; }

        /// <summary>
        /// Gets or sets the flag whether this transfer point is running in emergency mode.
        /// </summary>
        public bool IsEmergencyModeEnabled { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemTransferPointStatus"/> class.
        /// </summary>
        public TransportSystemTransferPointStatus()
            : base(MessageType.TransportSystemTransferPointStatus)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemTransferPointStatus"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemTransferPointStatus(IConverterStream converterStream)
            : base(MessageType.TransportSystemTransferPointStatus, converterStream)
        {
        }
    }
}
