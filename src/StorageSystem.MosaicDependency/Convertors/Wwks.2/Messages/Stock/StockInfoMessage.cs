using System.Collections.Generic;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Types.Packs;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Stock
{
    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoMessage small set message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StockInfoMessageSmallSetEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StockInfoMessageSmallSet StockInfoMessage { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StockInfoMessage.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StockInfoMessageEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StockInfoMessage StockInfoMessage { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StockInfoMessage.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoMessage small set message.
    /// <see cref="Documentation\WWKS 2.0\Rowa Interface WWKS v2.0 - Singapur Project.docx"" />
    /// </summary>
    public class StockInfoMessageSmallSet : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Article[] Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoMessageSmallSet"/> class.
        /// </summary>
        public StockInfoMessageSmallSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoMessageSmallSet"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StockInfoMessageSmallSet(MosaicMessage message)
        {
            var msg = (Interfaces.Messages.Stock.StockInfoMessage)message;

            this.Id = msg.ID;
            this.Source = msg.Source;
            this.Destination = msg.Destination;

            if (msg.Articles.Count > 0)
            {
                this.Article = new Article[msg.Articles.Count];
                Dictionary<string, Article> articleMap = new Dictionary<string, Article>(this.Article.Length);

                for (int i = 0; i < this.Article.Length; ++i)
                {
                    var article = msg.Articles[i];
                    this.Article[i] = new Article() 
                    { 
                        Id = TextConverter.EscapeInvalidXmlChars(article.Code),
                    };

                    articleMap.Add(article.Code, this.Article[i]);
                }

                foreach (var pack in msg.Packs)
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
            var message = new Interfaces.Messages.Stock.StockInfoMessage(converterStream);

            message.ID = this.Id;
            message.Source = this.Source;
            message.Destination = this.Destination;

            if (this.Article != null)
            {
                for (int i = 0; i < this.Article.Length; ++i)
                {
                    var article = this.Article[i];
                    var msgArticle = new Interfaces.Types.Articles.RobotArticle()
                    {
                        Code = TextConverter.UnescapeInvalidXmlChars(article.Id),
                        Name = TextConverter.UnescapeInvalidXmlChars(article.Name),
                        DosageForm = TextConverter.UnescapeInvalidXmlChars(article.DosageForm),
                        PackagingUnit = TextConverter.UnescapeInvalidXmlChars(article.PackagingUnit)
                    };

                    foreach (var pack in article.Pack)
                    {
                        message.Packs.Add(new Interfaces.Types.Packs.RobotPack()
                        {
                            ID = (long)TypeConverter.ConvertULong(pack.Id),
                            RobotArticleID = msgArticle.ID,
                            ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode),
                            BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                            ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                            ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate)
                        });
                    }

                    message.Articles.Add(msgArticle);
                }
            }

            return message;
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoMessage message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StockInfoMessage : StockInfoMessageSmallSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoMessage"/> class.
        /// </summary>
        public StockInfoMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoMessage"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StockInfoMessage(MosaicMessage message)
            : base(message)
        {
            var msg = (Interfaces.Messages.Stock.StockInfoMessage)message;

            if (this.Article == null)
            {
                return;
            }

            for (int i = 0; i < this.Article.Length; ++i)
            {
                var article = msg.Articles[i];
                this.Article[i].Name = TextConverter.EscapeInvalidXmlChars(article.Name);
                this.Article[i].DosageForm = TextConverter.EscapeInvalidXmlChars(article.DosageForm);
                this.Article[i].PackagingUnit = TextConverter.EscapeInvalidXmlChars(article.PackagingUnit);
                this.Article[i].MaxSubItemQuantity = article.MaxSubItemQuantity >= 0 ? article.MaxSubItemQuantity.ToString() : null;
            }

            Dictionary<string, Types.Pack> packMap = new Dictionary<string, Types.Pack>(msg.Packs.Count);

            foreach (var article in this.Article)
            {
                if (article.Pack == null)
                {
                    continue;
                }

                foreach (var pack in article.Pack)
                    packMap[pack.Id] = pack;
            }

            foreach (var pack in msg.Packs)
            {
                var msgPack = packMap[((ulong)pack.ID).ToString()];

                msgPack.StockInDate = TypeConverter.ConvertDateNull(pack.StockInDate);
                msgPack.ScanCode = TextConverter.EscapeInvalidXmlChars(pack.ScanCode);
                msgPack.DeliveryNumber = TextConverter.EscapeInvalidXmlChars(pack.DeliveryNumber);
                msgPack.Width = pack.Width.ToString();
                msgPack.Height = pack.Height.ToString();
                msgPack.Depth = pack.Depth.ToString();
                msgPack.Shape = pack.Shape.ToString();
                msgPack.IsInFridge = pack.IsInFridge.ToString();
                msgPack.SubItemQuantity = pack.SubItemQuantity.ToString();
                msgPack.StockLocationId = TextConverter.EscapeInvalidXmlChars(pack.StockLocationID);
                msgPack.MachineLocation = TextConverter.EscapeInvalidXmlChars(pack.MachineLocation);

                msgPack.State = ((pack.IsAvailable == false) || (pack.IsBlocked == true)) ? PackState.NotAvailable.ToString() :
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
            var message = (Interfaces.Messages.Stock.StockInfoMessage)base.ToMosaicMessage(converterStream);
            int packIter = 0;

            if (this.Article != null)
            {
                for (int i = 0; i < this.Article.Length; ++i)
                {
                    var article = this.Article[i];

                    message.Articles[i].MaxSubItemQuantity = TypeConverter.ConvertInt(article.MaxSubItemQuantity);

                    foreach (var pack in article.Pack)
                    {
                        message.Packs[packIter].StockInDate = TypeConverter.ConvertDate(pack.StockInDate);
                        message.Packs[packIter].ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode);
                        message.Packs[packIter].DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(pack.DeliveryNumber);
                        message.Packs[packIter].Width = TypeConverter.ConvertInt(pack.Width);
                        message.Packs[packIter].Height = TypeConverter.ConvertInt(pack.Height);
                        message.Packs[packIter].Depth = TypeConverter.ConvertInt(pack.Depth);
                        message.Packs[packIter].Shape = TypeConverter.ConvertEnum<PackShape>(pack.Shape, PackShape.Cuboid);
                        message.Packs[packIter].IsInFridge = TypeConverter.ConvertBool(pack.IsInFridge);
                        message.Packs[packIter].SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity);
                        message.Packs[packIter].StockLocationID = string.IsNullOrEmpty(pack.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId);
                        message.Packs[packIter].MachineLocation = string.IsNullOrEmpty(pack.MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.MachineLocation);
                        message.Packs[packIter].IsBlocked = (TypeConverter.ConvertEnum<PackState>(pack.State, PackState.Available) != PackState.Available);
                        packIter++;
                    }
                }
            }

            return message;
        }
    }
}
