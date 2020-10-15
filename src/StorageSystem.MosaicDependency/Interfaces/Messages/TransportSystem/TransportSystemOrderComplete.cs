using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemOrderComplete Mosaic message.
    /// This message is used to notify about the completion of an output order.
    /// </summary>
    public class TransportSystemOrderComplete : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// The number of the output order that has finished.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// The identifier of the according output that was used by the order.
        /// </summary>
        public string Output { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemOrderComplete"/> class.
        /// </summary>
        public TransportSystemOrderComplete()
            : base(MessageType.TransportSystemOrderComplete)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemOrderComplete"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemOrderComplete(IConverterStream converterStream)
            : base(MessageType.TransportSystemOrderComplete, converterStream)
        {
        }
    }
}
