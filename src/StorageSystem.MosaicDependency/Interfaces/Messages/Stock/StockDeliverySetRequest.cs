using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Input;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the StockDeliverySetRequest Mosaic message.
    /// This request is used to define the stock delivery set for Mosaic.
    /// </summary>
    public class StockDeliverySetRequest : MosaicMessage
    {
        #region Members

        /// <summary>
        /// List of defined stock deliveries.
        /// </summary>
        private List<StockDelivery> _deliveryList = new List<StockDelivery>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of defined stock deliveries.
        /// </summary>
        public List<StockDelivery> StockDeliveries { get { return _deliveryList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliverySetRequest"/> class.
        /// </summary>
        public StockDeliverySetRequest()
            : base(MessageType.StockDeliverySetRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliverySetRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockDeliverySetRequest(IConverterStream converterStream)
            : base(MessageType.StockDeliverySetRequest, converterStream)
        {
        }
    }
}
