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
    /// Class which represents the WWKS 2.0 InitiateInputResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class InitiateInputResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public InitiateInputResponse InitiateInputResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.InitiateInputResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 InitiateInputResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class InitiateInputResponse : MessageBase, IMessageConversion
    {
        #region Properties
        
        [XmlAttribute]
        public string IsNewDelivery { get; set; }

        [XmlAttribute]
        public string SetPickingIndicator { get; set; }

        [XmlElement]
        public Details Details { get; set; }

        [XmlElement]
        public Article[] Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateInputResponse"/> class.
        /// </summary>
        public InitiateInputResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateInputResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public InitiateInputResponse(MosaicMessage message)
        {
            var response = (InitiateStockInputResponse)message;

            this.Id = response.ID;
            this.Destination = response.Destination;
            this.Source = response.Source;
            this.IsNewDelivery = response.IsDeliveryInput.ToString();
            this.SetPickingIndicator = response.SetPickingIndicator.ToString();

            this.Details = new Types.Details() 
            { 
                InputSource = response.InputSource.ToString(),
                InputPoint = response.InputPoint.ToString(),
                Status = (response.Status == InitiateStockInputState.InProgress) ? 
                         InitiateStockInputState.Accepted.ToString() : response.Status.ToString()
            };

            if (response.Articles.Count == 0)
            {
                return;
            }

            int packIndex = 0;
            this.Article = new Article[response.Articles.Count];

            for (int i = 0; i < this.Article.Length; ++i)
            {
                if (string.IsNullOrEmpty(response.Articles[i].Code))
                {
                    this.Article[i] = new Article();
                }
                else
                {
                    this.Article[i] = new Article()
                    {
                        Id = TextConverter.EscapeInvalidXmlChars(response.Articles[i].Code),
                        Name = TextConverter.EscapeInvalidXmlChars(response.Articles[i].Name),
                        PackagingUnit = TextConverter.EscapeInvalidXmlChars(response.Articles[i].PackagingUnit),
                        DosageForm = TextConverter.EscapeInvalidXmlChars(response.Articles[i].DosageForm),
                        MaxSubItemQuantity = response.Articles[i].MaxSubItemQuantity.ToString()
                    };

                    if ((string.IsNullOrEmpty(this.Article[i].Id)) &&
                        (string.IsNullOrEmpty(this.Article[i].Name)) &&
                        (string.IsNullOrEmpty(this.Article[i].PackagingUnit)) &&
                        (string.IsNullOrEmpty(this.Article[i].DosageForm)) &&
                        (response.Articles[i].MaxSubItemQuantity == 0))
                    {
                        this.Article[i].Id = null;
                        this.Article[i].Name = null;
                        this.Article[i].PackagingUnit = null;
                        this.Article[i].DosageForm = null;
                        this.Article[i].MaxSubItemQuantity = null;
                    }
                }

                foreach (var pack in response.Packs)
                {
                    if (pack.RobotArticleID == response.Articles[i].ID)
                    {
                        if (this.Article[i].Pack == null)
                        {
                            this.Article[i].Pack = new List<Types.Pack>();
                        }

                        this.Article[i].Pack.Add(new Types.Pack() 
                        {
                            Index = packIndex.ToString(),
                            ScanCode = TextConverter.EscapeInvalidXmlChars(pack.ScanCode),
                            DeliveryNumber = TextConverter.EscapeInvalidXmlChars(pack.DeliveryNumber),
                            BatchNumber = TextConverter.EscapeInvalidXmlChars(pack.BatchNumber),
                            ExternalId = TextConverter.EscapeInvalidXmlChars(pack.ExternalID),
                            ExpiryDate = TypeConverter.ConvertDateNull(pack.ExpiryDate),
                            SubItemQuantity = pack.SubItemQuantity.ToString(),
                            Depth = pack.Depth.ToString(),
                            Width = pack.Width.ToString(),
                            Height = pack.Height.ToString(),
                            Shape = pack.Shape.ToString(),
                            StockLocationId = TextConverter.EscapeInvalidXmlChars(pack.StockLocationID)
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
            var response = new InitiateStockInputResponse(converterStream);

            response.ID = this.Id;
            response.Destination = this.Destination;
            response.Source = this.Source;
            response.IsDeliveryInput = TypeConverter.ConvertBool(this.IsNewDelivery);
            response.SetPickingIndicator = TypeConverter.ConvertBool(this.SetPickingIndicator);   
            response.InputSource = (this.Details != null) ? TypeConverter.ConvertInt(this.Details.InputSource) : 0;
            response.InputPoint = (this.Details != null) ? TypeConverter.ConvertInt(this.Details.InputPoint) : 0;
            response.Status = (this.Details != null) ?
                              TypeConverter.ConvertEnum<InitiateStockInputState>(this.Details.Status, InitiateStockInputState.Rejected) :
                              InitiateStockInputState.Rejected;

            if (this.Article == null)
            {
                return response;
            }

            foreach (var article in this.Article)
            {
                response.Articles.Add(new Interfaces.Types.Articles.RobotArticle() 
                {
                    Code = TextConverter.UnescapeInvalidXmlChars(article.Id),
                    Name = TextConverter.UnescapeInvalidXmlChars(article.Name),
                    PackagingUnit = TextConverter.UnescapeInvalidXmlChars(article.PackagingUnit),
                    DosageForm = TextConverter.UnescapeInvalidXmlChars(article.DosageForm),
                    MaxSubItemQuantity = TypeConverter.ConvertInt(article.MaxSubItemQuantity)
                });

                foreach (var pack in article.Pack)
                {
                    response.Packs.Add(new Interfaces.Types.Packs.RobotPack()
                    {
                        ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode),
                        DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(pack.DeliveryNumber),
                        BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                        ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                        ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate),
                        SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity),
                        Depth = TypeConverter.ConvertInt(pack.Depth),
                        Width = TypeConverter.ConvertInt(pack.Width),
                        Height = TypeConverter.ConvertInt(pack.Height),
                        Shape = TypeConverter.ConvertEnum<PackShape>(pack.Shape, PackShape.Cuboid),
                        StockLocationID = string.IsNullOrEmpty(pack.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId)
                    });
                }
            }

            return response;
        }
    }
}
