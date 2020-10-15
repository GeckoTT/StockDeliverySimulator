using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using CareFusion.Mosaic.Interfaces.Types.Stock;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the StockInputMessage Mosaic message.
    /// This message is used to notify about the completed or aborted input of one or more packs.
    /// </summary>
    public class StockInputMessage : MosaicMessage
    {
        #region Members

        /// <summary>
        /// Holds the list of articles according to the requested packs.
        /// </summary>
        private readonly List<RobotArticle> _articleList = new List<RobotArticle>();

        /// <summary>
        /// Holds the list of requested packs.
        /// </summary>
        private readonly List<RobotPack> _packList = new List<RobotPack>();

        /// <summary>
        /// List of tenants that are referred to by the packs. 
        /// </summary>
        private readonly  List<Tenant> _tenantList = new List<Tenant>();

        /// <summary>
        /// List of stock locations that are referred to by the packs. 
        /// </summary>
        private readonly List<StockLocation> _stockLocationList = new List<StockLocation>();

        /// <summary>
        /// Holds the assignments of packs and pack handlings.
        /// </summary>
        private readonly Dictionary<RobotPack, StockInputHandlingType> _packHandlingMap = new Dictionary<RobotPack, StockInputHandlingType>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the IsNewDelivery of the pack input process.
        /// </summary>
        public bool IsNewDelivery { get; set; }

        /// <summary>
        /// Gets the list of articles according to the requested packs.
        /// </summary>
        public List<RobotArticle> Articles { get { return _articleList; } }

        /// <summary>
        /// Gets the list of inputted or aborted packs.
        /// </summary>
        public List<RobotPack> Packs { get { return _packList; } }

        /// <summary>
        /// Gets the list of tenants which match the input packs.
        /// </summary>
        public List<Tenant> Tenants { get { return _tenantList; } }

        /// <summary>
        /// Gets the list of stock locations which match the input packs.
        /// </summary>
        public List<StockLocation> StockLocations { get { return _stockLocationList; } }

        /// <summary>
        /// Gets the dictionary of packs and pack input handlings.
        /// </summary>
        public Dictionary<RobotPack, StockInputHandlingType> Handlings { get { return _packHandlingMap; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInputMessage"/> class.
        /// </summary>
        public StockInputMessage()
            : base(MessageType.StockInputMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInputMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the message.</param>
        public StockInputMessage(IConverterStream converterStream)
            : base(MessageType.StockInputMessage, converterStream)
        {
        }
    }
}
