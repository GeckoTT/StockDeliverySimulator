using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the StockInputResponse Mosaic message.
    /// This message is used to answer to a StockInputRequest.
    /// </summary>
    public class StockInputResponse : MosaicMessage
    {
        #region Members

        /// <summary>
        /// Holds the list of articles according to the requested packs.
        /// </summary>
        private readonly List<RobotArticle> _articleList = new List<RobotArticle>();

        /// <summary>
        /// List of Trees of PIS articles according to the requested packs.
        /// </summary>
        private readonly List<ArticleTree<RobotArticle>> _articleTrees = new List<ArticleTree<RobotArticle>>();

        /// <summary>
        /// Holds the list of requested packs.
        /// </summary>
        private readonly List<RobotPack> _packList = new List<RobotPack>();

        /// <summary>
        /// Holds the assignments of packs and pack handlings.
        /// </summary>
        private readonly Dictionary<RobotPack, StockInputHandling> _packHandlingMap = new Dictionary<RobotPack, StockInputHandling>();      
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the flag whether this input response belongs to a delivery input.
        /// </summary>
        public bool IsDeliveryInput { get; set; }

        /// <summary>
        /// Gets the list of articles according to the requested packs.
        /// </summary>
        public List<RobotArticle> Articles { get { return _articleList; } }

        /// <summary>
        /// Gets the list of articles according to the requested packs ordered as a tree as provided by PIS.
        /// </summary>
        public List<ArticleTree<RobotArticle>> ArticleTrees { get { return _articleTrees; } }

        /// <summary>
        /// Gets the list of allowed or rejected packs.
        /// </summary>
        public List<RobotPack> Packs { get { return _packList; } }

        /// <summary>
        /// Gets the dictionary of packs and pack input handlings.
        /// </summary>
        public Dictionary<RobotPack, StockInputHandling> Handlings { get { return _packHandlingMap; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInputResponse"/> class.
        /// </summary>
        public StockInputResponse()
            : base(MessageType.StockInputResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInputResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the response.</param>
        public StockInputResponse(IConverterStream converterStream)
            : base(MessageType.StockInputResponse, converterStream)
        {
        }
    }
}
