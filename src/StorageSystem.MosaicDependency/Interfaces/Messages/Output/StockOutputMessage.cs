using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Output;

namespace CareFusion.Mosaic.Interfaces.Messages.Output
{
    /// <summary>
    /// Class which implements the StockOutputMessage Mosaic message.
    /// This message is used to notify about the end of a pack output process.
    /// </summary>
    public class StockOutputMessage : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// The stock output order which belongs to this message.
        /// </summary>
        public StockOutputOrder Order { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOutputMessage"/> class.
        /// </summary>
        public StockOutputMessage()
            : base(MessageType.StockOutputMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOutputMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StockOutputMessage(IConverterStream converterStream)
            : base(MessageType.StockOutputMessage, converterStream)
        {
        }
    }
}
