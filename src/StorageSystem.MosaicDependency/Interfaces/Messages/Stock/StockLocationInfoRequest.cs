using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the StockLocationInfoRequest Mosaic message.
    /// This request is used to request detailed information about the currently available stock locations.
    /// </summary>
    public class StockLocationInfoRequest : MosaicMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockLocationInfoRequest"/> class.
        /// </summary>
        public StockLocationInfoRequest()
            : base(MessageType.StockLocationInfoRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockLocationInfoRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockLocationInfoRequest(IConverterStream converterStream)
            : base(MessageType.StockLocationInfoRequest, converterStream)
        {
        }
    }
}
