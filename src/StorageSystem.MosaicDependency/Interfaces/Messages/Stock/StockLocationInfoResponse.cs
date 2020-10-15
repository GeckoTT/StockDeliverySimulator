using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Stock;
using System.Collections.Generic;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the StockLocationInfoResponse Mosaic message.
    /// This response message is used to answer to a StockLocationInfoRequest.
    /// </summary>
    public class StockLocationInfoResponse : MosaicMessage
    {
        #region Members

        /// <summary>
        /// List of stock locations.
        /// </summary>
        private List<StockLocation> _stockLocations = new List<StockLocation>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of stock locations.
        /// </summary>
        public List<StockLocation> StockLocations { get { return _stockLocations; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockLocationInfoResponse"/> class.
        /// </summary>
        public StockLocationInfoResponse()
            : base(MessageType.StockLocationInfoResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockLocationInfoResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockLocationInfoResponse(IConverterStream converterStream)
            : base(MessageType.StockLocationInfoResponse, converterStream)
        {
        }
    }
}
