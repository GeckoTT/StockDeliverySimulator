using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the InitiateStockInputMessage Mosaic message.
    /// This message is used to notify about the completed or aborted initiated input of one or more packs.
    /// </summary>
    public class InitiateStockInputMessage : MosaicMessage
    {
        #region Members

        /// <summary>
        /// List of articles that have been processed during the initiated input.
        /// </summary>
        private readonly List<RobotArticle> _articleList = new List<RobotArticle>();

        /// <summary>
        /// List of packs that have been processed during the initiated input.
        /// </summary>
        private readonly List<RobotPack> _packList = new List<RobotPack>();

        /// <summary>
        /// Holds the assignments of packs and pack errors.
        /// </summary>
        private readonly Dictionary<RobotPack, StockInputError> _packErrorMap = new Dictionary<RobotPack, StockInputError>();      

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the input source that was used during the initiated input.
        /// </summary>
        public int InputSource { get; set; }

        /// <summary>
        /// Gets or sets the input point that was used during the initiated input.
        /// </summary>
        public int InputPoint { get; set; }

        /// <summary>
        /// Gets or sets the final status of the initiated input.
        /// </summary>
        public InitiateStockInputState Status { get; set; }

        /// <summary>
        /// Gets the list of articles that were processed during the initiated input.
        /// </summary>
        public List<RobotArticle> Articles { get { return _articleList; } }
        
        /// <summary>
        /// Gets the list of packs that were processed during the initiated input.
        /// </summary>
        public List<RobotPack> Packs { get { return _packList; } }

        /// <summary>
        /// Gets the dictionary of packs and pack input errors.
        /// </summary>
        public Dictionary<RobotPack, StockInputError> PackErrors { get { return _packErrorMap; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateStockInputMessage"/> class.
        /// </summary>
        public InitiateStockInputMessage()
            : base(MessageType.InitiateStockInputMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateStockInputMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public InitiateStockInputMessage(IConverterStream converterStream)
            : base(MessageType.InitiateStockInputMessage, converterStream)
        {
        }
    }

}
