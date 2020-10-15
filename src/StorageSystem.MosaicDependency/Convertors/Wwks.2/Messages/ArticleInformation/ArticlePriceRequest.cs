using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.ArticleInformation
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ArticlePriceRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ArticlePriceRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ArticlePriceRequest ArticlePriceRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ArticlePriceRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ArticlePriceRequest message.
    /// </summary>
    public class ArticlePriceRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string Currency { get; set; }

        [XmlElement]
        public Article[] Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlePriceRequest"/> class.
        /// </summary>
        public ArticlePriceRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlePriceRequest"/> class.
        /// </summary>
        public ArticlePriceRequest(MosaicMessage message)
        {
            Interfaces.Messages.ArticleInformation.ArticlePriceRequest request = (Interfaces.Messages.ArticleInformation.ArticlePriceRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            this.Currency = request.Currency;
            this.Article = new Article[request.Articles.Length];
            for (int i = 0; i < request.Articles.Length; i++)
            {
                this.Article[i] = request.Articles[i];
            }
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
            var request = new Interfaces.Messages.ArticleInformation.ArticlePriceRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            request.Currency = this.Currency;
            request.Articles = new Article[this.Article.Length];
            for (int i = 0; i < this.Article.Length; i++)
            {
                request.Articles[i] = this.Article[i];
            }

            return request;
        }
    }
}
