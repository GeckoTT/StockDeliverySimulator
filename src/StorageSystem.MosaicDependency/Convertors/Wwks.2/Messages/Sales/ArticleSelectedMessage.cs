using CareFusion.Mosaic.Converters.Wwks2.Types;
using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Sales
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleSelectedMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ArticleSelectedMessageEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ArticleSelectedMessage ArticleSelectedMessage { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ArticleSelectedMessage.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleSelectedMessage message.
    /// </summary>
    public class ArticleSelectedMessage : MessageBase, IMessageConversion
    {
        [XmlElement]
        public Article Article { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleSelectedMessage"/> class.
        /// </summary>
        public ArticleSelectedMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleSelectedMessage"/> class.
        /// </summary>
        public ArticleSelectedMessage(MosaicMessage message)
        {
            Interfaces.Messages.Sales.ArticleSelectedMessage msg = (Interfaces.Messages.Sales.ArticleSelectedMessage)message;

            this.Id = msg.ID;
            this.Source = msg.Source;
            this.Destination = msg.Destination;
            this.Article = msg.Article;
        }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var msg = new Interfaces.Messages.Sales.ArticleSelectedMessage(converterStream);

            msg.ID = this.Id;
            msg.Source = this.Source;
            msg.Destination = this.Destination;
            msg.Article = this.Article;
            return msg;
        }
    }
}
