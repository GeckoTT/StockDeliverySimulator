using System.Collections.Generic;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Types.Packs;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Stock
{
    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoResponse small set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StockInfoResponseSmallSetEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StockInfoResponseSmallSet StockInfoResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StockInfoResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoResponse full set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StockInfoResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StockInfoResponse StockInfoResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StockInfoResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoResponse message.
    /// <see cref="Documentation\WWKS 2.0\Rowa Interface WWKS v2.0 - Singapur Project.docx" />
    /// </summary>
    public class StockInfoResponseSmallSet : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Article[] Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoResponseSmallSet"/> class.
        /// </summary>
        public StockInfoResponseSmallSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoResponseSmallSet"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StockInfoResponseSmallSet(MosaicMessage message)
        {
            var response = (Interfaces.Messages.Stock.StockInfoResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;

            if (response.Articles.Count > 0)
            {
                this.Article = new Article[response.Articles.Count];
                Dictionary<string, Article> articleMap = new Dictionary<string, Article>(this.Article.Length);

                for (int i = 0; i < this.Article.Length; ++i)
                {
                    var article = response.Articles[i];
                    this.Article[i] = new Article() 
                    { 
                        Id = TextConverter.EscapeInvalidXmlChars(article.Code),
                        Quantity = article.PackCount.ToString() 
                    };

                    articleMap[article.Code] = this.Article[i];
                }

                foreach (var pack in response.Packs)
                {
                    var article = articleMap[pack.RobotArticleCode];

                    if (article.Pack == null)
                    {
                        article.Pack = new List<Types.Pack>();
                    }

                    article.Pack.Add(new Types.Pack()
                    {
                        Id = ((ulong)pack.ID).ToString(),
                        BatchNumber = TextConverter.EscapeInvalidXmlChars(pack.BatchNumber),
                        ExternalId = TextConverter.EscapeInvalidXmlChars(pack.ExternalID),
                        ExpiryDate = TypeConverter.ConvertDateNull(pack.ExpiryDate)
                    });
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
        public virtual MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var response = new Interfaces.Messages.Stock.StockInfoResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;

            if (this.Article != null)
            {
                for (int i = 0; i < this.Article.Length; ++i)
                {
                    var article = this.Article[i];
                    var respArticle = new Interfaces.Types.Articles.RobotArticle()
                    {
                        Code = TextConverter.UnescapeInvalidXmlChars(article.Id)
                    };

                    foreach (var pack in article.Pack)
                    {
                        response.Packs.Add(new Interfaces.Types.Packs.RobotPack()
                        {
                            ID = (long)TypeConverter.ConvertULong(pack.Id),
                            RobotArticleID = respArticle.ID,
                            BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                            ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                            ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate)
                        });
                    }

                    response.Articles.Add(respArticle);
                }
            }

            return response;
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StockInfoResponse : StockInfoResponseSmallSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoResponse"/> class.
        /// </summary>
        public StockInfoResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StockInfoResponse(MosaicMessage message)
            : base (message)
        {
            var response = (Interfaces.Messages.Stock.StockInfoResponse)message;

            if (this.Article == null)
            {
                return;
            }

            for (int i = 0; i < this.Article.Length; ++i)
            {
                var article = response.Articles[i];
                this.Article[i].Name = TextConverter.EscapeInvalidXmlChars(article.Name);
                this.Article[i].DosageForm = TextConverter.EscapeInvalidXmlChars(article.DosageForm);
                this.Article[i].PackagingUnit = TextConverter.EscapeInvalidXmlChars(article.PackagingUnit);
                this.Article[i].MaxSubItemQuantity = article.MaxSubItemQuantity >= 0 ? article.MaxSubItemQuantity.ToString() : null;
            }

            Dictionary<string, Types.Pack> packMap = new Dictionary<string, Types.Pack>(response.Packs.Count);
            
            foreach (var article in this.Article)
            {
                if (article.Pack == null)
                {
                    continue;
                }

                foreach (var pack in article.Pack)
                    packMap[pack.Id] = pack;
            }

            foreach (var pack in response.Packs)
            {
                var respPack = packMap[((ulong)pack.ID).ToString()];

                respPack.StockInDate = TypeConverter.ConvertDateNull(pack.StockInDate);
                respPack.ScanCode = TextConverter.EscapeInvalidXmlChars(pack.ScanCode);
                respPack.DeliveryNumber = TextConverter.EscapeInvalidXmlChars(pack.DeliveryNumber);
                respPack.Width = pack.Width.ToString();
                respPack.Height = pack.Height.ToString();
                respPack.Depth = pack.Depth.ToString();
                respPack.Shape = pack.Shape.ToString();
                respPack.IsInFridge = pack.IsInFridge.ToString();
                respPack.SubItemQuantity = pack.SubItemQuantity.ToString();
                respPack.StockLocationId = TextConverter.EscapeInvalidXmlChars(pack.StockLocationID);
                respPack.MachineLocation = TextConverter.EscapeInvalidXmlChars(pack.MachineLocation);

                respPack.State = ((pack.IsAvailable == false) || (pack.IsBlocked == true)) ? PackState.NotAvailable.ToString() : 
                                                                                             PackState.Available.ToString();
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
            var response = (Interfaces.Messages.Stock.StockInfoResponse)base.ToMosaicMessage(converterStream);
            int packIter = 0;

            if (this.Article != null)
            {
                for (int i = 0; i < this.Article.Length; ++i)
                {
                    var article = this.Article[i];

                    response.Articles[i].Name = TextConverter.UnescapeInvalidXmlChars(article.Name);
                    response.Articles[i].DosageForm = TextConverter.UnescapeInvalidXmlChars(article.DosageForm);
                    response.Articles[i].PackagingUnit = TextConverter.UnescapeInvalidXmlChars(article.PackagingUnit);
                    response.Articles[i].MaxSubItemQuantity = TypeConverter.ConvertInt(article.MaxSubItemQuantity);

                    foreach (var pack in article.Pack)
                    {
                        response.Packs[packIter].StockInDate = TypeConverter.ConvertDate(pack.StockInDate);
                        response.Packs[packIter].ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode);
                        response.Packs[packIter].DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(pack.DeliveryNumber);
                        response.Packs[packIter].Width = TypeConverter.ConvertInt(pack.Width);
                        response.Packs[packIter].Height = TypeConverter.ConvertInt(pack.Height);
                        response.Packs[packIter].Depth = TypeConverter.ConvertInt(pack.Depth);
                        response.Packs[packIter].Shape = TypeConverter.ConvertEnum<PackShape>(pack.Shape, PackShape.Cuboid);
                        response.Packs[packIter].IsInFridge = TypeConverter.ConvertBool(pack.IsInFridge);
                        response.Packs[packIter].SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity);
                        response.Packs[packIter].StockLocationID = string.IsNullOrEmpty(pack.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId);
                        response.Packs[packIter].MachineLocation = string.IsNullOrEmpty(pack.MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.MachineLocation);
                        response.Packs[packIter].IsBlocked = (TypeConverter.ConvertEnum<PackState>(pack.State, PackState.Available) != PackState.Available);
                        packIter++;
                    }
                }
            }

            return response;
        }
    }
}
