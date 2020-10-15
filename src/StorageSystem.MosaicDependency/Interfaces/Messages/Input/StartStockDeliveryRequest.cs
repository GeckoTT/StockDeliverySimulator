using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Input
{
    /// <summary>
    /// Class which implements the StartStockDeliveryRequest Mosaic message.
    /// This request is used to request the start of a new stock input delivery.
    /// </summary>
    public class StartStockDeliveryRequest : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the OrderNumber of the new stock input delivery.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryNumber of the new stock input delivery.
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// Gets or sets the BarCode of the new stock input delivery (0000000).
        /// </summary>
        public string BarCode { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StartStockDeliveryRequest"/> class.
        /// </summary>
        public StartStockDeliveryRequest()
            : base(MessageType.StartStockDeliveryRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StartStockDeliveryRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StartStockDeliveryRequest(IConverterStream converterStream)
            : base(MessageType.StartStockDeliveryRequest, converterStream)
        {
        }
    }
}
