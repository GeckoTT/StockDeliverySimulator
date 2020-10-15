using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using CareFusion.Mosaic.Interfaces.Types.Stock;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the StockInfoResponse Mosaic message.
    /// This response message is used answer to a StockInfoRequest.
    /// </summary>
    public class StockInfoResponse : MosaicMessage
    {
        #region Members

        /// <summary>
        /// List of criterias that were used when filtering the results.
        /// </summary>
        private List<StockInfoCriteria> _criteriaList = new List<StockInfoCriteria>();

        /// <summary>
        /// List of articles that match the requested filter criteria.
        /// </summary>
        private List<RobotArticle> _articleList = new List<RobotArticle>();

        /// <summary>
        /// List of packs that match the requested filter criteria.
        /// </summary>
        private List<RobotPack> _packList = new List<RobotPack>();
        
        /// <summary>
        /// List of tenants that are referred to by the packs. 
        /// </summary>
        private List<Tenant> _tenantList = new List<Tenant>();

        /// <summary>
        /// List of stock locations that are referred to by the packs. 
        /// </summary>
        private List<StockLocation> _stockLocationList = new List<StockLocation>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of criterias that were used when filtering the results.
        /// </summary>
        public List<StockInfoCriteria> Criteria { get { return _criteriaList; } }

        /// <summary>
        /// Gets the list of articles which match the requested filter.
        /// </summary>
        public List<RobotArticle> Articles { get { return _articleList; } }

        /// <summary>
        /// Gets the list of packs which match the requested filter.
        /// </summary>
        public List<RobotPack> Packs { get { return _packList; } }

        /// <summary>
        /// Gets the list of tenants which match the requested filter.
        /// </summary>
        public List<Tenant> Tenants { get { return _tenantList; } }

        /// <summary>
        /// Gets the list of stock locations which match the requested filter.
        /// </summary>
        public List<StockLocation> StockLocations { get { return _stockLocationList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoResponse"/> class.
        /// </summary>
        public StockInfoResponse()
            : base(MessageType.StockInfoResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockInfoResponse(IConverterStream converterStream)
            : base(MessageType.StockInfoResponse, converterStream)
        {
        }
    }
}
