using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the StockInfoRequest Mosaic message.
    /// This request is used to request the stock information of a storage system.
    /// </summary>
    public class StockInfoRequest : MosaicMessage
    {
        #region Members

        /// <summary>
        /// List of criterias to use when filtering the results.
        /// </summary>
        private List<StockInfoCriteria> _criteriaList = new List<StockInfoCriteria>();

        #endregion

        #region Properties

        /// <summary>
        /// Defines whether the StockInfoResponse should also include the pack details.
        /// </summary>
        public bool IncludePacks { get; set; }

        /// <summary>
        /// Defines whether the StockInfoResponse should also include article details details.
        /// </summary>
        public bool IncludeArticleDetails { get; set; }

        /// <summary>
        /// Defines the criterias to filter for.
        /// </summary>
        public List<StockInfoCriteria> Criteria { get { return _criteriaList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoRequest"/> class.
        /// </summary>
        public StockInfoRequest()
            : base(MessageType.StockInfoRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockInfoRequest(IConverterStream converterStream)
            : base(MessageType.StockInfoRequest, converterStream)
        {
        }
    }
}
