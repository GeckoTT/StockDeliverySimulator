using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using CareFusion.Mosaic.Interfaces.Types.Stock;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Enum which identifies different types of stock information notifications. 
    /// </summary>
    public enum StockInfoType
    {
        /// <summary>
        /// Stock information is about a general change in the stock (e.g. packs added or removed).
        /// </summary>
        StockChange,

        /// <summary>
        /// Stock information is about a new pack that has been added to the stock.
        /// </summary>
        PackInput,

        /// <summary>
        /// Stock information is about an update in the stock (e.g. properties of existing packs have changed).
        /// </summary>
        StockUpdate
    }

    /// <summary>
    /// Class which implements the StockInfoMessage Mosaic message.
    /// This message is used to notify about stock changes in a storage system or to transmit article master data.
    /// </summary>
    public class StockInfoMessage : MosaicMessage
    {
        #region Members

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
        /// Gets or sets the stock information type.
        /// </summary>
        public StockInfoType StockInfoType { get; set; }

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
        /// Initializes a new instance of the <see cref="StockInfoMessage"/> class.
        /// </summary>
        public StockInfoMessage()
            : base(MessageType.StockInfoMessage)
        {
            this.StockInfoType = StockInfoType.StockChange;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockInfoMessage(IConverterStream converterStream)
            : base(MessageType.StockInfoMessage, converterStream)
        {
            this.StockInfoType = StockInfoType.StockChange;
        }
    }
}
