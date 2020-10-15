using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Stock
{
    /// <summary>
    /// Class which represents the WWKS 2.0 StockLocationInfoRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StockLocationInfoResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StockLocationInfoResponse StockLocationInfoResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StockLocationInfoResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockLocationInfoResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StockLocationInfoResponse : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlElement]
        public StockLocation[] StockLocation { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockLocationInfoResponse"/> class.
        /// </summary>
        public StockLocationInfoResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockLocationInfoResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StockLocationInfoResponse(MosaicMessage message)
        {
            var request = (Interfaces.Messages.Stock.StockLocationInfoResponse)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;

            if (request.StockLocations.Count > 0)
            {
                this.StockLocation = new StockLocation[request.StockLocations.Count];

                for (int i = 0; i < this.StockLocation.Length; ++i)
                {
                    this.StockLocation[i] = new StockLocation() 
                    {
                        Id = TextConverter.EscapeInvalidXmlChars(request.StockLocations[i].ID),
                        Description = TextConverter.EscapeInvalidXmlChars(request.StockLocations[i].Description),
                    };
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
            var request = new Interfaces.Messages.Stock.StockLocationInfoResponse(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            if (this.StockLocation != null)
            {
                for (int i = 0; i < this.StockLocation.Length; ++i)
                {
                    request.StockLocations.Add(new Interfaces.Types.Stock.StockLocation() 
                    {
                        ID = this.StockLocation[i].Id != null ? TextConverter.UnescapeInvalidXmlChars(this.StockLocation[i].Id) : string.Empty,
                        Description = this.StockLocation[i].Description != null ? TextConverter.UnescapeInvalidXmlChars(this.StockLocation[i].Description) : string.Empty,
                    });
                }
            }

            return request;
        }
    }
}
