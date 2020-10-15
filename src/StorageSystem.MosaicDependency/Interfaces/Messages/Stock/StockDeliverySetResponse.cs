using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the StockDeliverySetResponse Mosaic message.
    /// This response is used as answer to the StockDeliverySetRequest.
    /// </summary>
    public class StockDeliverySetResponse : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the result value itself.
        /// </summary>
        public bool SetResult { get; set; }

        /// <summary>
        /// Gets or sets the set result text.
        /// </summary>
        public string SetResultText { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliverySetResponse"/> class.
        /// </summary>
        public StockDeliverySetResponse()
            : base(MessageType.StockDeliverySetResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliverySetResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockDeliverySetResponse(IConverterStream converterStream)
            : base(MessageType.StockDeliverySetResponse, converterStream)
        {
        }
    }
}
