using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Output;
using System;

namespace CareFusion.Mosaic.Interfaces.Messages.Output
{
    /// <summary>
    /// Class which implements the StockOutputRequest Mosaic message.
    /// This request is used to request output of one ore more packs.
    /// </summary>
    public class StockOutputRequest : MosaicMessage, ICloneable
    {
        #region Properties

        /// <summary>
        /// The stock output order which has been issued with this request.
        /// </summary>
        public StockOutputOrder Order { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOutputRequest"/> class.
        /// </summary>
        public StockOutputRequest()
            : base(MessageType.StockOutputRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOutputRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockOutputRequest(IConverterStream converterStream)
            : base(MessageType.StockOutputRequest, converterStream)
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
            return new StockOutputRequest()
            {
                Order = this.Order.Clone(),
                ID = this.ID,
                Source = this.Destination,
                Destination = this.Source,
                TenantID = this.TenantID,
                ConverterData = this.ConverterData,
                ConverterStream = this.ConverterStream
            };
        }
    }
}
