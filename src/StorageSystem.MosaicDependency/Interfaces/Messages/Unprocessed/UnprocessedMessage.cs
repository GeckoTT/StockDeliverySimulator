using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using MosaicDependency.Convertors.Wwks2.Types;

namespace MosaicDependency.Interfaces.Messages.Unprocessed
{
    /// <summary>
    /// Class which implements the UnprocessedMessage Mosaic message.
    /// </summary>
    public class UnprocessedMessage : MosaicMessage
    {
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnprocessedMessage"/> class.
        /// </summary>
        public UnprocessedMessage() : base(MessageType.UnprocessedMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnprocessedMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream.</param>
        public UnprocessedMessage(IConverterStream converterStream) : base(MessageType.UnprocessedMessage, converterStream)
        {
        }
    }
}
