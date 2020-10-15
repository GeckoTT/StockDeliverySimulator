using CareFusion.Mosaic.Converters.Wwks2.Messages;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using MosaicDependency.Convertors.Wwks2.Types;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace MosaicDependency.Convertors.Wwks2.Messages.Unprocessed
{
    /// <summary>
    /// Class which represents the WWKS 2.0 UnprocessedMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    [ExcludeFromCodeCoverage]
    public class UnprocessedMessageEnvelope : EnvelopeBase
    {
        [XmlElement]
        public UnprocessedMessage UnprocessedMessage { get; set; }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 UnprocessedMessage message.
    /// </summary>
    public class UnprocessedMessage : MessageBase
    {
        #region Properties

        [XmlAttribute]
        public string Reason { get; set; }

        [XmlAttribute]
        public string Text { get; set; }

        [XmlElement]
        public Message Message { get; set; }

        #endregion Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="UnprocessedMessage"/> class.
        /// </summary>
        /// <param name="message"></param>
        public UnprocessedMessage(MosaicMessage message)
        {
            var msg = (Interfaces.Messages.Unprocessed.UnprocessedMessage)message;

            this.Id = msg.ID;
            this.Source = msg.Source;
            this.Destination = msg.Destination;
            this.Reason = msg.Reason;
            this.Text = msg.Text;
            this.Message = new Message
            {
                RawContent = msg.Message.RawContent
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnprocessedMessage"/> class.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public UnprocessedMessage()
        {
        }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>The Mosaic message representation of this object.</returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var msg = new Interfaces.Messages.Unprocessed.UnprocessedMessage(converterStream);

            msg.ID = this.Id;
            msg.Source = this.Source;
            msg.Destination = this.Destination;
            msg.Reason = this.Reason;
            msg.Text = this.Text;
            msg.Message = new Message
            {
                RawContent = this.Message.RawContent ?? string.Empty
            };

            return msg;
        }
    }
}
