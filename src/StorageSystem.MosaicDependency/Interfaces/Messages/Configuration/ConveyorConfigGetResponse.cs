using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Configuration;
using System.Collections.Generic;

namespace CareFusion.Mosaic.Interfaces.Messages.Configuration
{
    /// <summary>
    /// Class which implements the ConveyorConfigGetResponse Mosaic message.
    /// </summary>
    public class ConveyorConfigGetResponse : MosaicMessage
    {
        #region Members

        private List<ConveyorSystem> _conveyorSystem = new List<ConveyorSystem>();

        #endregion

        #region Properties

        public List<ConveyorSystem> ConveyorSystems
        {
            get { return _conveyorSystem; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ConveyorConfigGetResponse"/> class.
        /// </summary>
        public ConveyorConfigGetResponse()
            : base(MessageType.ConveyorConfigGetResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConveyorConfigGetResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ConveyorConfigGetResponse(IConverterStream converterStream)
            : base(MessageType.ConveyorConfigGetResponse, converterStream)
        {
        }
    }
}
