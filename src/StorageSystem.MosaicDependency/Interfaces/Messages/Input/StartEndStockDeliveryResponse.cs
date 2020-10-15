using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the StartEndStockDeliveryResponse Mosaic message.
    /// This response is used to answer to the according StartInputRequest and EndStockDeliveryRequest.
    /// </summary>
    public class StartEndStockDeliveryResponse : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the OrderNumber of the stock input delivery.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryNumber of the stock input delivery.
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// Gets or sets the IsAccepted flag of the stock input delivery.
        /// </summary>
        public bool IsAccepted { get; set; }

        /// <summary>
        /// Gets or sets the optional reason if a stock delivery start/end is not accepted.
        /// </summary>
        public string RejectReason { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StartEndStockDeliveryResponse"/> class.
        /// </summary>
        public StartEndStockDeliveryResponse()
            : base(MessageType.StartEndStockDeliveryResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StartEndStockDeliveryResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the response.</param>
        public StartEndStockDeliveryResponse(IConverterStream converterStream)
            : base(MessageType.StartEndStockDeliveryResponse, converterStream)
        {
        }
    }
}
