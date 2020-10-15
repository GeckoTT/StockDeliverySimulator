using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Types.Articles;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Stock
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleMasterSetRequest small set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ArticleMasterSetRequestSmallSetEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ArticleMasterSetRequestSmallSet ArticleMasterSetRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ArticleMasterSetRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleMasterSetRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ArticleMasterSetRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ArticleMasterSetRequest ArticleMasterSetRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ArticleMasterSetRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleMasterSetRequest small set message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class ArticleMasterSetRequestSmallSet : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Article[] Article { get; set; }

        #endregion
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetRequestSmallSet"/> class.
        /// </summary>
        public ArticleMasterSetRequestSmallSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetRequestSmallSet"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public ArticleMasterSetRequestSmallSet(MosaicMessage message)
        {
            var request = (Interfaces.Messages.Stock.ArticleMasterSetRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            if (request.PISArticles.Count == 0)
            {
                return;
            }

            this.Article = new Article[request.PISArticles.Count];

            for (int i = 0; i < this.Article.Length; ++i)
            {
                var article = request.PISArticles[i];

                this.Article[i] = new Article()
                {
                    Id = TextConverter.EscapeInvalidXmlChars(article.Code),
                    Name = TextConverter.EscapeInvalidXmlChars(article.Name),
                    DosageForm = TextConverter.EscapeInvalidXmlChars(article.DosageForm),
                    PackagingUnit = TextConverter.EscapeInvalidXmlChars(article.PackagingUnit),
                };
            }
        }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public virtual MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var request = new Interfaces.Messages.Stock.ArticleMasterSetRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            if (this.Article == null)
            {
                return request;
            }

            foreach (var article in this.Article)
            {
                ArticleTree<PISArticle> currentArticleTree = new ArticleTree<PISArticle>();
                request.ArticleTrees.Add(currentArticleTree);
                LoadPISArticleToRequestSmallSet(request, currentArticleTree, article);
            }

            return request;
        }

        /// <summary>
        /// load article information to ArticleMasterSetRequest Small set
        /// </summary>
        /// <param name="request">ArticleMasterSetRequest to update.</param>
        /// <param name="currentArticleTree">Article tree to update</param>
        /// <param name="article">Article source information.</param>
        private void LoadPISArticleToRequestSmallSet(Interfaces.Messages.Stock.ArticleMasterSetRequest request, ArticleTree<PISArticle> currentArticleTree, Article article)
        {
            PISArticle currentPISArticle = currentArticleTree.GetArticle();
            currentPISArticle.Code = article.Id != null ? TextConverter.UnescapeInvalidXmlChars(article.Id) : string.Empty;
            currentPISArticle.Name = article.Name != null ? TextConverter.UnescapeInvalidXmlChars(article.Name) : string.Empty;
            currentPISArticle.DosageForm = article.DosageForm != null ? TextConverter.UnescapeInvalidXmlChars(article.DosageForm) : string.Empty;
            currentPISArticle.PackagingUnit = article.PackagingUnit != null ? TextConverter.UnescapeInvalidXmlChars(article.PackagingUnit) : string.Empty;
            currentPISArticle.RobotArticleCode = article.Id != null ? TextConverter.UnescapeInvalidXmlChars(article.Id) : string.Empty; // in wwks2, PIS code = robot article code.
            request.PISArticles.Add(currentPISArticle);
            
            // Load current article child Articles.
            foreach (var childArticle in article.ChildArticle)
            {
                ArticleTree<PISArticle> childArticleTree = new ArticleTree<PISArticle>();
                LoadPISArticleToRequestSmallSet(request, childArticleTree, childArticle);
                currentArticleTree.AddChild(childArticleTree);
            }
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ArticleMasterSetRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class ArticleMasterSetRequest : ArticleMasterSetRequestSmallSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetRequest"/> class.
        /// </summary>
        public ArticleMasterSetRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public ArticleMasterSetRequest(MosaicMessage message)
            : base(message)
        {
            var request = (Interfaces.Messages.Stock.ArticleMasterSetRequest)message;

            if (this.Article == null)
            {
                return;
            }

            for (int i = 0; i < this.Article.Length; ++i)
            {
                this.Article[i].RequiresFridge = request.PISArticles[i].Attributes[PisArticleAttribute.RequiredFridge].Value;
                this.Article[i].MaxSubItemQuantity = request.PISArticles[i].MaxSubItemQuantity.ToString();
                this.Article[i].StockLocationId = TextConverter.EscapeInvalidXmlChars(request.PISArticles[i].StockLocationID);
                this.Article[i].MachineLocation = TextConverter.EscapeInvalidXmlChars(request.PISArticles[i].MachineLocation);
                this.Article[i].BatchTracking = request.PISArticles[i].BatchTracking.ToString();
                this.Article[i].SerialTracking = request.PISArticles[i].SerialTracking.ToString();
                this.Article[i].ExpiryTracking = request.PISArticles[i].ExpiryTracking.ToString();
            }
        }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public override MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var request = (Interfaces.Messages.Stock.ArticleMasterSetRequest)base.ToMosaicMessage(converterStream);

            if (this.Article == null)
            {
                return request;
            }

            for (int i = 0; i < this.Article.Length; ++i)
            {
                LoadPISArticleToRequest(request.ArticleTrees[i], this.Article[i]);
            }

            return request;
        }

        /// <summary>
        /// load article information to ArticleMasterSetRequest
        /// </summary>
        /// <param name="currentArticleTree">Article tree to update</param>
        /// <param name="article">Article source information.</param>
        private void LoadPISArticleToRequest(ArticleTree<PISArticle> currentArticleTree, Article article)
        {
            PISArticle currentPISArticle = currentArticleTree.GetArticle();

            currentPISArticle.Attributes[PisArticleAttribute.RequiredFridge].Value = TypeConverter.ConvertBool(article.RequiresFridge).ToString();
            currentPISArticle.ScanCodes.Add(new PisArticleScanCode()
            {
                PisArticleID = currentPISArticle.ID,
                ScanCode = article.Id != null ? TextConverter.UnescapeInvalidXmlChars(article.Id) : string.Empty,
            });

            currentPISArticle.MaxSubItemQuantity = TypeConverter.ConvertInt(article.MaxSubItemQuantity);
            currentPISArticle.StockLocationID = string.IsNullOrEmpty(article.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(article.StockLocationId);
            currentPISArticle.MachineLocation = string.IsNullOrEmpty(article.MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(article.MachineLocation);

            currentPISArticle.BatchTracking = TypeConverter.ConvertBool(article.BatchTracking);
            currentPISArticle.SerialTracking = TypeConverter.ConvertBool(article.SerialTracking);
            currentPISArticle.ExpiryTracking = TypeConverter.ConvertBool(article.ExpiryTracking);

            // Load current article child Articles.
            for (int i = 0; i < article.ChildArticle.Count; ++i)
            {
                LoadPISArticleToRequest(currentArticleTree.GetChildren()[i], article.ChildArticle[i]);
            }
        }
    }
}
