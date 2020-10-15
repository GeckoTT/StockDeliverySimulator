using System.Collections.Generic;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Input;
using CareFusion.Mosaic.Interfaces.Types.Articles;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Input
{
    /// <summary>
    /// Class which represents the WWKS 2.0 InputResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class InputResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public InputResponse InputResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.InputResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 InputResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class InputResponse : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string IsNewDelivery { get; set; }

        [XmlElement]
        public List<Article> Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InputResponse"/> class.
        /// </summary>
        public InputResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public InputResponse(MosaicMessage message)
        {
            StockInputResponse response = (StockInputResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;
            this.IsNewDelivery = response.IsDeliveryInput.ToString();

            if ((response.ArticleTrees != null) && (response.ArticleTrees.Count != 0))
            {
                throw new System.Exception("public InputResponse(MosaicMessage message), using ArticleTree not supported.");
            }
            else
            {
                if (response.Articles.Count > 0)
                {
                    this.Article = new List<Article>(response.Articles.Count);

                    foreach (var article in response.Articles)
                    {
                        var a = new Article();
                        a.DosageForm = TextConverter.EscapeInvalidXmlChars(article.DosageForm);
                        a.Id = TextConverter.EscapeInvalidXmlChars(article.Code);
                        a.Name = TextConverter.EscapeInvalidXmlChars(article.Name);
                        a.PackagingUnit = TextConverter.EscapeInvalidXmlChars(article.PackagingUnit);
                        a.MaxSubItemQuantity = article.MaxSubItemQuantity.ToString();
                        a.Pack = new List<Types.Pack>();
                        a.RequiresFridge = article.RequiresFridge.ToString();

                        for (int i = 0; i < response.Packs.Count; ++i)
                        {
                            if (response.Packs[i].RobotArticleCode != article.Code)
                            {
                                continue;
                            }

                            a.Pack.Add(new Types.Pack()
                            {
                                Index = i.ToString(),
                                Id = ((ulong)response.Packs[i].ID).ToString(),
                                ScanCode = TextConverter.EscapeInvalidXmlChars(response.Packs[i].ScanCode),
                                DeliveryNumber = TextConverter.EscapeInvalidXmlChars(response.Packs[i].DeliveryNumber),
                                BatchNumber = TextConverter.EscapeInvalidXmlChars(response.Packs[i].BatchNumber),
                                ExternalId = TextConverter.EscapeInvalidXmlChars(response.Packs[i].ExternalID),
                                ExpiryDate = TypeConverter.ConvertDateNull(response.Packs[i].ExpiryDate),
                                SubItemQuantity = response.Packs[i].SubItemQuantity.ToString(),
                                StockLocationId = TextConverter.EscapeInvalidXmlChars(response.Packs[i].StockLocationID),
                                Handling = new Handling()
                                {
                                    Input = response.Handlings[response.Packs[i]].Handling,
                                    Text = TextConverter.EscapeInvalidXmlChars(response.Handlings[response.Packs[i]].Description)
                                }
                            });
                        }

                        this.Article.Add(a);
                    }
                }
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
            StockInputResponse response = new StockInputResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;
            response.IsDeliveryInput = TypeConverter.ConvertBool(this.IsNewDelivery);

            if (this.Article.Count > 0)
            {
                foreach (var article in this.Article)
                {
                    ArticleTree<RobotArticle> currentArticleTree = new ArticleTree<RobotArticle>();
                    response.ArticleTrees.Add(currentArticleTree);
                    LoadArticleToReponse(response, currentArticleTree, article);
                }
            }

            return response;
        }
        
        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns
        private void LoadArticleToReponse(StockInputResponse response, ArticleTree<RobotArticle> currentArticleTree, Article article)
        {
            // 1) Load current Article information
            RobotArticle robotArticle = currentArticleTree.GetArticle();
            robotArticle.DosageForm = TextConverter.UnescapeInvalidXmlChars(article.DosageForm != null ? article.DosageForm : string.Empty);
            robotArticle.Code = TextConverter.UnescapeInvalidXmlChars(article.Id != null ? article.Id : string.Empty);
            robotArticle.Name = TextConverter.UnescapeInvalidXmlChars(article.Name != null ? article.Name : string.Empty);
            robotArticle.PackagingUnit = TextConverter.UnescapeInvalidXmlChars(article.PackagingUnit != null ? article.PackagingUnit : string.Empty);
            robotArticle.MaxSubItemQuantity = TypeConverter.ConvertInt(article.MaxSubItemQuantity);
            robotArticle.RequiresFridge = TypeConverter.ConvertBool(article.RequiresFridge);

            // 2) Load current article pack information
            foreach (var pack in article.Pack)
            {
                response.Packs.Add(new Interfaces.Types.Packs.RobotPack()
                {
                    ID = (long)TypeConverter.ConvertULong(pack.Id),
                    RobotArticleCode = robotArticle.Code,
                    ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode),
                    DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(pack.DeliveryNumber),
                    BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                    ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                    ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate),
                    SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity),
                    StockLocationID = string.IsNullOrEmpty(pack.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId),
                });

                // only add to the article list, the articles related to pack behing input.
                response.Articles.Add(robotArticle);

                response.Handlings.Add(response.Packs[response.Packs.Count - 1],
                                        new StockInputHandling()
                                        {
                                            Handling = pack.Handling.Input,
                                            Description = string.IsNullOrEmpty(pack.Handling.Text) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.Handling.Text)
                                        });
            }

            // 3) Load current article child Articles.
            foreach (var childArticle in article.ChildArticle)
            {
                ArticleTree<RobotArticle> childArticleTree = new ArticleTree<RobotArticle>();
                LoadArticleToReponse(response, childArticleTree, childArticle);
                currentArticleTree.AddChild(childArticleTree);
            }
        }
    }
}
