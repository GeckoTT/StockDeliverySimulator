using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Input;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Input
{
    /// <summary>
    /// Class which represents the WWKS 2.0 InitiateInputMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class InitiateInputMessageEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public InitiateInputMessage InitiateInputMessage { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.InitiateInputMessage.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 InitiateInputMessage message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class InitiateInputMessage : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public Details Details { get; set; }

        [XmlElement]
        public Article[] Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateInputMessage"/> class.
        /// </summary>
        public InitiateInputMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateInputMessage"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public InitiateInputMessage(MosaicMessage message)
        {
            var msg = (InitiateStockInputMessage)message;

            this.Id = msg.ID;
            this.Destination = msg.Destination;
            this.Source = msg.Source;
            this.Details = new Types.Details() 
            { 
                InputSource = msg.InputSource.ToString(),
                InputPoint = msg.InputPoint.ToString(),
                Status = (msg.Status == InitiateStockInputState.InProgress) ?
                         InitiateStockInputState.Accepted.ToString() : msg.Status.ToString()
            };

            if (msg.Articles.Count == 0)
            {
                return;
            }

            int packIndex = 0;
            this.Article = new Article[msg.Articles.Count];

            for (int i = 0; i < this.Article.Length; ++i)
            {
                this.Article[i] = new Article() 
                {
                    Id = TextConverter.EscapeInvalidXmlChars(msg.Articles[i].Code),
                    Name = TextConverter.EscapeInvalidXmlChars(msg.Articles[i].Name),
                    PackagingUnit = TextConverter.EscapeInvalidXmlChars(msg.Articles[i].PackagingUnit),
                    DosageForm = TextConverter.EscapeInvalidXmlChars(msg.Articles[i].DosageForm),
                    MaxSubItemQuantity = msg.Articles[i].MaxSubItemQuantity.ToString()
                };

                if ((string.IsNullOrEmpty(this.Article[i].Id)) &&
                    (string.IsNullOrEmpty(this.Article[i].Name)) &&
                    (string.IsNullOrEmpty(this.Article[i].PackagingUnit)) &&
                    (string.IsNullOrEmpty(this.Article[i].DosageForm)) &&
                    (msg.Articles[i].MaxSubItemQuantity == 0))
                {
                    this.Article[i].Id = null;
                    this.Article[i].Name = null;
                    this.Article[i].PackagingUnit = null;
                    this.Article[i].DosageForm = null;
                    this.Article[i].MaxSubItemQuantity = null;
                }

                foreach (var pack in msg.Packs)
                {
                    if (pack.RobotArticleID == msg.Articles[i].ID)
                    {
                        if (this.Article[i].Pack == null)
                        {
                            this.Article[i].Pack = new List<Types.Pack>();
                        }

                        var packError = msg.PackErrors.ContainsKey(pack) ? msg.PackErrors[pack] : null;
                        this.Article[i].Pack.Add(new Types.Pack() 
                        {
                            Index = packIndex.ToString(),
                            Id = ((ulong)pack.ID).ToString(),
                            DeliveryNumber = TextConverter.EscapeInvalidXmlChars(pack.DeliveryNumber),
                            BatchNumber = TextConverter.EscapeInvalidXmlChars(pack.BatchNumber),
                            ExternalId = TextConverter.EscapeInvalidXmlChars(pack.ExternalID),
                            ExpiryDate = TypeConverter.ConvertDateNull(pack.ExpiryDate),
                            StockInDate = TypeConverter.ConvertDateNull(msg.Packs[i].StockInDate),
                            ScanCode = TextConverter.EscapeInvalidXmlChars(msg.Packs[i].ScanCode),
                            SubItemQuantity = pack.SubItemQuantity.ToString(),
                            Depth = pack.Depth.ToString(),
                            Width = pack.Width.ToString(),
                            Height = pack.Height.ToString(),
                            Shape = pack.Shape.ToString(),
                            StockLocationId = TextConverter.EscapeInvalidXmlChars(pack.StockLocationID),
                            MachineLocation = TextConverter.EscapeInvalidXmlChars(pack.MachineLocation),
                            State = ((pack.IsAvailable == false) || (pack.IsBlocked == true)) ? "NotAvailable" : "Available",
                            IsInFridge = pack.IsInFridge.ToString(),
                            Error = (packError == null) ? 
                                    null : 
                                    new Error() 
                                    { 
                                        Type = packError.Type.ToString(),
                                        Text = TextConverter.EscapeInvalidXmlChars(packError.Description)
                                    }
                        });

                        packIndex++;
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
            var message = new InitiateStockInputMessage(converterStream);

            message.ID = this.Id;
            message.Destination = this.Destination;
            message.Source = this.Source;
            message.InputSource = (this.Details != null) ? TypeConverter.ConvertInt(this.Details.InputSource) : 0;
            message.InputPoint = (this.Details != null) ? TypeConverter.ConvertInt(this.Details.InputPoint) : 0;
            message.Status = (this.Details != null) ?
                              TypeConverter.ConvertEnum<InitiateStockInputState>(this.Details.Status, InitiateStockInputState.Rejected) :
                              InitiateStockInputState.Rejected;
            if (this.Article != null)
            {
                foreach (var article in this.Article)
                {
                    message.Articles.Add(new Interfaces.Types.Articles.RobotArticle() 
                    { 
                        Code = TextConverter.UnescapeInvalidXmlChars(article.Id),
                        Name = TextConverter.UnescapeInvalidXmlChars(article.Name),
                        PackagingUnit = TextConverter.UnescapeInvalidXmlChars(article.PackagingUnit),
                        DosageForm = TextConverter.UnescapeInvalidXmlChars(article.DosageForm),
                        MaxSubItemQuantity = TypeConverter.ConvertInt(article.MaxSubItemQuantity)
                    });

                    if (article.Pack != null)
                    {
                        foreach (var pack in article.Pack)
                        {
                            var msgPack = new Interfaces.Types.Packs.RobotPack() 
                            {
                                ID = (long)TypeConverter.ConvertULong(pack.Id),
                                DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(pack.DeliveryNumber),
                                BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                                ExternalID = TextConverter.EscapeInvalidXmlChars(pack.ExternalId),
                                ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate),
                                StockInDate = TypeConverter.ConvertDate(pack.StockInDate),
                                ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode),
                                SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity),
                                Depth = TypeConverter.ConvertInt(pack.Depth),
                                Width = TypeConverter.ConvertInt(pack.Width),
                                Height = TypeConverter.ConvertInt(pack.Height),
                                Shape = TypeConverter.ConvertEnum<PackShape>(pack.Shape, PackShape.Cuboid),
                                StockLocationID = string.IsNullOrEmpty(pack.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId),
                                MachineLocation = string.IsNullOrEmpty(pack.MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.MachineLocation),
                                IsAvailable = (string.Compare(pack.State, "Available") == 0),
                                IsInFridge = TypeConverter.ConvertBool(pack.IsInFridge)
                            };

                            message.Packs.Add(msgPack);

                            if (pack.Error != null)
                            {
                                var msgError = new StockInputError() 
                                               {
                                                   Type = TypeConverter.ConvertEnum<StockInputErrorType>(pack.Error.Type, StockInputErrorType.Rejected),
                                                   Description  = TextConverter.UnescapeInvalidXmlChars(pack.Error.Text)
                                               };

                                message.PackErrors.Add(msgPack, msgError);
                            }
                        }
                    }
                }
            }

            return message;
        }
    }
}
