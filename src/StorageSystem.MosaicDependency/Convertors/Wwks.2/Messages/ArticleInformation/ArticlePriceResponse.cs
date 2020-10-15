using CareFusion.Mosaic.Converters.Wwks2.Types;
using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.ArticleInformation
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ArticlePriceResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ArticlePriceResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ArticlePriceResponse ArticlePriceResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ArticlePriceResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ArticlePriceResponse message.
    /// </summary>
    public class ArticlePriceResponse : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string Currency { get; set; }

        [XmlElement]
        public Article[] Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleInfoResponse"/> class.
        /// </summary>
        public ArticlePriceResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleInfoResponse"/> class.
        /// </summary>
        public ArticlePriceResponse(MosaicMessage message)
        {
            Interfaces.Messages.ArticleInformation.ArticlePriceResponse response = (Interfaces.Messages.ArticleInformation.ArticlePriceResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;

            this.Currency = response.Currency;
            this.Article = new Article[response.Articles.Length];
            for (int i = 0; i < response.Articles.Length; i++)
            {
                this.Article[i] = response.Articles[i];
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
            var response = new Interfaces.Messages.ArticleInformation.ArticlePriceResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;

            response.Currency = this.Currency;
            response.Articles = new Article[this.Article.Length];
            for (int i = 0; i < this.Article.Length; i++)
            {
                response.Articles[i] = this.Article[i];
            }
            return response;
        }
    }
}
