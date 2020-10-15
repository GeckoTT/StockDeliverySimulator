using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the InitiateStockInputRequest Mosaic message.
    /// This request is used to initiate input of one ore more packs.
    /// </summary>
    public class InitiateStockInputRequest : MosaicMessage, ICloneable
    {
        #region Members

        /// <summary>
        /// Holds the list of packs that are waiting for input.
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
        /// Gets the list of packs that are waiting for input.
        /// </summary>
        public List<RobotPack> Packs { get { return _packList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateStockInputRequest"/> class.
        /// </summary>
        public InitiateStockInputRequest()
            : base(MessageType.InitiateStockInputRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateStockInputRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public InitiateStockInputRequest(IConverterStream converterStream)
            : base(MessageType.InitiateStockInputRequest, converterStream)
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
            var clone = new InitiateStockInputRequest(this.ConverterStream);
            clone._packList.AddRange(_packList);
            clone.ConverterData = this.ConverterData;
            clone.Destination = this.Destination;
            clone.ID = this.ID;
            clone.InputSource = this.InputSource;
            clone.InputPoint = this.InputPoint;
            clone.IsDeliveryInput = this.IsDeliveryInput;
            clone.SetPickingIndicator = this.SetPickingIndicator;
            clone.Source = this.Source;
            clone.TenantID = this.TenantID;
            return clone;
        }
    }
}
