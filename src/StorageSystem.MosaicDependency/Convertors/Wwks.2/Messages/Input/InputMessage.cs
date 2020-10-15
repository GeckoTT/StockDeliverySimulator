using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Input;
using CareFusion.Mosaic.Interfaces.Types.Packs;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Input
{
    /// <summary>
    /// Class which represents the WWKS 2.0 InputMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class InputMessageEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public InputMessage InputMessage { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.InputMessage.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 InputMessage message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class InputMessage : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string IsNewDelivery { get; set; }

        [XmlElement]
        public List<Article> Article { get; set; }        

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMessage"/> class.
        /// </summary>
        public InputMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMessage"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public InputMessage(MosaicMessage message)
        {
            StockInputMessage msg = (StockInputMessage)message;

            this.Id = msg.ID;
            this.Source = msg.Source;
            this.Destination = msg.Destination;
            this.IsNewDelivery = msg.IsNewDelivery.ToString();

            var articles = msg.Articles.Distinct();

            if (articles.Count() > 0)
            {
                this.Article = new List<Article>(articles.Count());

                foreach (var article in articles)
                {
                    var a = new Article
                    {
                        DosageForm = TextConverter.EscapeInvalidXmlChars(article.DosageForm),
                        Id = TextConverter.EscapeInvalidXmlChars(article.Code),
                        Name = TextConverter.EscapeInvalidXmlChars(article.Name),
                        PackagingUnit = TextConverter.EscapeInvalidXmlChars(article.PackagingUnit),
                        MaxSubItemQuantity = article.MaxSubItemQuantity > 0 ? article.MaxSubItemQuantity.ToString() : null,
                        Pack = new List<Types.Pack>()
                    };

                    for (int i = 0; i < msg.Packs.Count; ++i)
                    {
                        if (msg.Packs[i].RobotArticleCode != article.Code)
                        {
                            continue;
                        }

                        a.Pack.Add(new Pack()
                        {
                            Index = i.ToString(),
                            Id = ((ulong)msg.Packs[i].ID).ToString(),
                            DeliveryNumber = TextConverter.EscapeInvalidXmlChars(msg.Packs[i].DeliveryNumber),
                            BatchNumber = TextConverter.EscapeInvalidXmlChars(msg.Packs[i].BatchNumber),
                            ExternalId = TextConverter.EscapeInvalidXmlChars(msg.Packs[i].ExternalID),
                            ExpiryDate = TypeConverter.ConvertDateNull(msg.Packs[i].ExpiryDate),
                            StockInDate = TypeConverter.ConvertDateNull(msg.Packs[i].StockInDate),
                            ScanCode = TextConverter.EscapeInvalidXmlChars(msg.Packs[i].ScanCode),
                            Depth = msg.Packs[i].Depth.ToString(),
                            Width = msg.Packs[i].Width.ToString(),
                            Height = msg.Packs[i].Height.ToString(),
                            Shape = msg.Packs[i].Shape.ToString(),
                            State = msg.Packs[i].IsBlocked ? PackState.NotAvailable.ToString() : PackState.Available.ToString(),
                            IsInFridge = msg.Packs[i].IsInFridge.ToString(),
                            SubItemQuantity = msg.Packs[i].SubItemQuantity.ToString(),
                            StockLocationId = TextConverter.EscapeInvalidXmlChars(msg.Packs[i].StockLocationID),
                            MachineLocation = TextConverter.EscapeInvalidXmlChars(msg.Packs[i].MachineLocation),
                            Handling = new Handling() { Input = msg.Handlings[msg.Packs[i]], Text = string.Empty }
                        });                        
                    }

                    this.Article.Add(a);
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
            StockInputMessage message = new StockInputMessage(converterStream);

            message.ID = this.Id;
            message.Source = this.Source;
            message.Destination = this.Destination;
            message.IsNewDelivery = TypeConverter.ConvertBool(this.IsNewDelivery);

            if (this.Article.Count > 0)
            {
                foreach (var article in this.Article)
                {
                    var a = new Interfaces.Types.Articles.RobotArticle();
                    a.DosageForm = TextConverter.UnescapeInvalidXmlChars(article.DosageForm);
                    a.Code = TextConverter.UnescapeInvalidXmlChars(article.Id);
                    a.Name = TextConverter.UnescapeInvalidXmlChars(article.Name);
                    a.PackagingUnit = TextConverter.UnescapeInvalidXmlChars(article.PackagingUnit);
                    a.MaxSubItemQuantity = TypeConverter.ConvertInt(article.MaxSubItemQuantity);
                    message.Articles.Add(a);

                    foreach (var pack in article.Pack)
                    {
                        var p = new RobotPack
                        {
                            ID = (long)TypeConverter.ConvertULong(pack.Id),
                            DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(pack.DeliveryNumber),
                            BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                            ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                            ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate),
                            StockInDate = TypeConverter.ConvertDate(pack.StockInDate),
                            ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode),
                            Depth = TypeConverter.ConvertInt(pack.Depth),
                            Width = TypeConverter.ConvertInt(pack.Width),
                            Height = TypeConverter.ConvertInt(pack.Height),
                            Shape = TypeConverter.ConvertEnum<PackShape>(pack.Shape, PackShape.Cuboid),
                            IsBlocked = (TypeConverter.ConvertEnum<PackState>(pack.State, PackState.Available) != PackState.Available),
                            SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity),
                            StockLocationID = string.IsNullOrEmpty(pack.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId),
                            MachineLocation = string.IsNullOrEmpty(pack.MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.MachineLocation),
                            IsInFridge = TypeConverter.ConvertBool(pack.IsInFridge)
                        };

                        message.Packs.Add(p);
                        message.Handlings.Add(p, pack.Handling.Input);
                    } 
                }
            }

            return message;
        }
    }
}
