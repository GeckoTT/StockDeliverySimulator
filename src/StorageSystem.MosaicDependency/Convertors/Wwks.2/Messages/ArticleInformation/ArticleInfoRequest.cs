using System.Xml.Serialization;
using System;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.ArticleInformation
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleInfoRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ArticleInfoRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ArticleInfoRequest ArticleInfoRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ArticleInfoRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleInfoRequest message.
    /// </summary>
    public class ArticleInfoRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Article[] Article { get; set; }

        [XmlAttribute]
        public bool IncludeCrossSellingArticles { get; set; }

        [XmlAttribute]
        public bool IncludeAlternativeArticles { get; set; }

        [XmlAttribute]
        public bool IncludeAlternativePackSizeArticles { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleInfoRequest"/> class.
        /// </summary>
        public ArticleInfoRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleInfoRequest"/> class.
        /// </summary>
        public ArticleInfoRequest(MosaicMessage message)
        {
            Interfaces.Messages.ArticleInformation.ArticleInfoRequest request = (Interfaces.Messages.ArticleInformation.ArticleInfoRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            this.Article = new Article[request.Articles.Length];
            for (int i = 0; i < request.Articles.Length; i++)
            {
                this.Article[i] = request.Articles[i];
            }
            
            this.IncludeCrossSellingArticles = request.IncludeCrossSellingArticles;
            this.IncludeAlternativeArticles = request.IncludeAlternativeArticles;
            this.IncludeAlternativePackSizeArticles = request.IncludeAlternativePackSizeArticles;

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
            var request = new Interfaces.Messages.ArticleInformation.ArticleInfoRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;
            
            request.Articles = new Article[this.Article.Length];
            for (int i = 0; i < this.Article.Length; i++)
            {
                request.Articles[i] = this.Article[i];
            }

            request.IncludeCrossSellingArticles = this.IncludeCrossSellingArticles;
            request.IncludeAlternativeArticles = this.IncludeAlternativeArticles;
            request.IncludeAlternativePackSizeArticles = this.IncludeAlternativePackSizeArticles;

            return request;
        }
    }
}
