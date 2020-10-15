using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System;
using System.Collections.Generic;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the InitiateStockInputResponse Mosaic message.
    /// this message is used to answer to a InitiateStockInputRequest.
    /// </summary>
    public class InitiateStockInputResponse : MosaicMessage, ICloneable
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

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the flag whether the input should belong to a delivery input.
        /// </summary>
        public bool IsDeliveryInput { get; set; }

        /// <summary>
        /// Gets or sets the flag whether the picking indicator should be set for the articles of the initiated input.
        /// </summary>
        public bool SetPickingIndicator { get; set; }

        /// <summary>
        /// Gets or sets the input source to use for the initiated input.
        /// </summary>
        public int InputSource { get; set; }

        /// <summary>
        /// Gets or sets the input point to use for the initiated input.
        /// </summary>
        public int InputPoint { get; set; }

        /// <summary>
        /// Gets or sets the status of the initiated input.
        /// </summary>
        public InitiateStockInputState Status { get; set; }

        /// <summary>
        /// Gets or sets the pack neutral error details of the initiated input.
        /// </summary>
        public StockInputError Error { get; set; }

        /// <summary>
        /// Gets the list of articles that were processed during the initiated input.
        /// </summary>
        public List<RobotArticle> Articles { get { return _articleList; } }

        /// <summary>
        /// Gets the list of packs that are waiting for input.
        /// </summary>
        public List<RobotPack> Packs { get { return _packList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateStockInputResponse"/> class.
        /// </summary>
        public InitiateStockInputResponse()
            : base(MessageType.InitiateStockInputResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateStockInputResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public InitiateStockInputResponse(IConverterStream converterStream)
            : base(MessageType.InitiateStockInputResponse, converterStream)
        {
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            var clone = new InitiateStockInputResponse(this.ConverterStream);

            clone._articleList.AddRange(_articleList);
            clone._packList.AddRange(_packList);
            clone.ConverterData = this.ConverterData;
            clone.Destination = this.Destination;
            clone.ID = this.ID;
            clone.InputSource = this.InputSource;
            clone.InputPoint = this.InputPoint;
            clone.IsDeliveryInput = this.IsDeliveryInput;
            clone.SetPickingIndicator = this.SetPickingIndicator;
            clone.Source = this.Source;
            clone.Status = this.Status;
            clone.Error = this.Error;
            clone.TenantID = this.TenantID;

            return clone;
        }
    }
}
