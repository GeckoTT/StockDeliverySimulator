using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Packs;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the StockInputRequest Mosaic message.
    /// This request is used to request input of one ore more packs.
    /// </summary>
    public class StockInputRequest : MosaicMessage
    {
        #region Members

        /// <summary>
        /// Holds the list of requested packs.
        /// </summary>
        private readonly List<RobotPack> _packList = new List<RobotPack>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the flag whether this input request belongs to a delivery input.
        /// </summary>
        public bool IsDeliveryInput { get; set; }

        /// <summary>
        /// Gets or sets the flag whether the picking indicator should be set for the articles of this input.
        /// </summary>
        public bool SetPickingIndicator { get; set; }
                
        /// <summary>
        /// Gets the list of requested packs.
        /// </summary>
        public List<RobotPack> Packs { get { return _packList; } } 

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInputRequest"/> class.
        /// </summary>
        public StockInputRequest()
            : base(MessageType.StockInputRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInputRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockInputRequest(IConverterStream converterStream)
            : base(MessageType.StockInputRequest, converterStream)
        {
        }
    }
}
