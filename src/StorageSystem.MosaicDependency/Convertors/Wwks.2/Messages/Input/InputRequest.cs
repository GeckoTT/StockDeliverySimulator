using System.Collections.Generic;
using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Input;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Input
{
    /// <summary>
    /// Class which represents the WWKS 2.0 InputRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class InputRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public InputRequest InputRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.InputRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 InputRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class InputRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string IsNewDelivery { get; set; }

        [XmlAttribute]
        public string SetPickingIndicator { get; set; }

        [XmlElement]
        public Article Article { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="InputRequest"/> class.
        /// </summary>
        public InputRequest()
        {             
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public InputRequest(MosaicMessage message)
        {
            StockInputRequest request = (StockInputRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;
            this.IsNewDelivery = request.IsDeliveryInput.ToString();
            this.SetPickingIndicator = request.SetPickingIndicator.ToString();

            this.Article = new Article();
            this.Article.Pack = new List<Pack>();

            for (int i = 0; i < request.Packs.Count; ++i)
            {
                this.Article.Pack.Add(new Pack() 
                { 
                    Index = i.ToString(),
                    ScanCode = TextConverter.EscapeInvalidXmlChars(request.Packs[i].ScanCode),
                    BatchNumber = TextConverter.EscapeInvalidXmlChars(request.Packs[i].BatchNumber),
                    ExternalId = TextConverter.EscapeInvalidXmlChars(request.Packs[i].ExternalID),
                    DeliveryNumber = (request.IsDeliveryInput) ? TextConverter.EscapeInvalidXmlChars(request.Packs[i].DeliveryNumber) : null,
                    ExpiryDate = TypeConverter.ConvertDateNull(request.Packs[i].ExpiryDate),
                    SubItemQuantity = request.Packs[i].SubItemQuantity.ToString(),
                    StockLocationId = TextConverter.EscapeInvalidXmlChars(request.Packs[i].StockLocationID),
                    MachineLocation = TextConverter.EscapeInvalidXmlChars(request.Packs[i].MachineLocation)
                });
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
            StockInputRequest request = new StockInputRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;
            request.IsDeliveryInput = TypeConverter.ConvertBool(this.IsNewDelivery);
            request.SetPickingIndicator = TypeConverter.ConvertBool(this.SetPickingIndicator);

            if ((this.Article == null) || (this.Article.Pack == null))
            {
                return request;
            }

            foreach (var pack in this.Article.Pack)
            {
                request.Packs.Add(new Interfaces.Types.Packs.RobotPack() 
                { 
                    ScanCode = TextConverter.UnescapeInvalidXmlChars(pack.ScanCode),
                    BatchNumber = TextConverter.UnescapeInvalidXmlChars(pack.BatchNumber),
                    ExternalID = TextConverter.UnescapeInvalidXmlChars(pack.ExternalId),
                    DeliveryNumber = TextConverter.UnescapeInvalidXmlChars(pack.DeliveryNumber),
                    ExpiryDate = TypeConverter.ConvertDate(pack.ExpiryDate),
                    SubItemQuantity = TypeConverter.ConvertInt(pack.SubItemQuantity),
                    StockLocationID = string.IsNullOrEmpty(pack.StockLocationId) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.StockLocationId),
                    MachineLocation = string.IsNullOrEmpty(pack.MachineLocation) ? string.Empty : TextConverter.UnescapeInvalidXmlChars(pack.MachineLocation)
                });
            }

            return request;
        }
    }
}
