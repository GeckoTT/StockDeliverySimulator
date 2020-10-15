using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Output;

namespace CareFusion.Mosaic.Interfaces.Messages.Output
{
    /// <summary>
    /// Class which implements the StockOutputResponse Mosaic message.
    /// This message is used to answer to an according StockOutputRequest.
    /// </summary>
    public class StockOutputResponse : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// The stock output order which has been started with the according StockOutputRequest.
        /// </summary>
        public StockOutputOrder Order { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOutputResponse"/> class.
        /// </summary>
        public StockOutputResponse()
            : base(MessageType.StockOutputResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOutputResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockOutputResponse(IConverterStream converterStream)
            : base(MessageType.StockOutputResponse, converterStream)
        {
        }
    }
}
