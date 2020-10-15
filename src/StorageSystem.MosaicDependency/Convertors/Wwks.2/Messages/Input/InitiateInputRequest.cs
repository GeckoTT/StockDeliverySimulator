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
    /// Class which represents the WWKS 2.0 InitiateInputRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class InitiateInputRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public InitiateInputRequest InitiateInputRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.InitiateInputRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 InitiateInputRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class InitiateInputRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string IsNewDelivery { get; set; }

        [XmlAttribute]
        public string SetPickingIndicator { get; set; }

        [XmlElement]
        public Details Details { get; set; }

        [XmlElement]
        public Article Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateInputRequest"/> class.
        /// </summary>
        public InitiateInputRequest()
        {             
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiateInputRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public InitiateInputRequest(MosaicMessage message)
        {
            var request = (InitiateStockInputRequest)message;

            this.Id = request.ID;
            this.Destination = request.Destination;
            this.Source = request.Source;
            this.IsNewDelivery = request.IsDeliveryInput.ToString();
            this.SetPickingIndicator = request.SetPickingIndicator.ToString();
            this.Details = new Types.Details() 
            { 
                InputSource = request.InputSource.ToString(),
                InputPoint = request.InputPoint.ToString()
            };

            this.Article = new Article();

            if (request.Packs.Count > 0)
            {
                this.Article.Pack = new List<Types.Pack>();

                foreach (var pack in request.Packs)
                {
                    this.Article.Pack.Add(new Types.Pack()
                    {
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
                        StockLocationId = TextConverter.EscapeInvalidXmlChars(pack.StockLocationID),
                        MachineLocation = TextConverter.EscapeInvalidXmlChars(pack.MachineLocation)
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
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            var request = new InitiateStockInputRequest(converterStream);

            request.ID = this.Id;
            request.Destination = this.Destination;
            request.Source = this.Source;
            request.IsDeliveryInput = TypeConverter.ConvertBool(this.IsNewDelivery);
            request.SetPickingIndicator = TypeConverter.ConvertBool(this.SetPickingIndicator);
            request.InputSource = (this.Details != null) ? TypeConverter.ConvertInt(this.Details.InputSource) : 0;
            request.InputPoint = (this.Details != null) ? TypeConverter.ConvertInt(this.Details.InputPoint) : 0;

            if ((this.Article != null) && (this.Article.Pack != null))
            {
                foreach (var pack in this.Article.Pack)
                {
                    request.Packs.Add(new Interfaces.Types.Packs.RobotPack()
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
                        StockLocationID = string.IsNullOrEmpty(pack.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId),
                        MachineLocation = string.IsNullOrEmpty(pack.MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.MachineLocation)
                    });
                }
            }

            return request;
        }
    }
}
