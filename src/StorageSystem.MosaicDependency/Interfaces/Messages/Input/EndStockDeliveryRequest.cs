using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the EndStockDeliveryRequest Mosaic message.
    /// This request is used to request the end of a stock input delivery.
    /// </summary>
    public class EndStockDeliveryRequest : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the OrderNumber of the stock input delivery to end.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryNumber of the stock input delivery to end.
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// Gets or sets the BarCode of the stock input delivery end (0000000).
        /// </summary>
        public string BarCode { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="EndStockDeliveryRequest"/> class.
        /// </summary>
        public EndStockDeliveryRequest()
            : base(MessageType.EndStockDeliveryRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EndStockDeliveryRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public EndStockDeliveryRequest(IConverterStream converterStream)
            : base(MessageType.EndStockDeliveryRequest, converterStream)
        {
        }
    }
}
