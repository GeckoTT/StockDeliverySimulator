using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Messages.Stock;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Stock
{
    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StockInfoRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StockInfoRequest StockInfoRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StockInfoRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StockInfoRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StockInfoRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string IncludePacks { get; set; }

        [XmlAttribute]
        public string IncludeArticleDetails { get; set; }

        [XmlElement]
        public Criteria[] Criteria { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoRequest"/> class.
        /// </summary>
        public StockInfoRequest()
        {
            this.IncludePacks = "True";
            this.IncludeArticleDetails = "False";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockInfoRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StockInfoRequest(MosaicMessage message)
        {
            var request = (Interfaces.Messages.Stock.StockInfoRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;
            this.IncludePacks = request.IncludePacks.ToString();
            this.IncludeArticleDetails = request.IncludeArticleDetails.ToString();

            if (request.Criteria.Count > 0)
            {
                this.Criteria = new Criteria[request.Criteria.Count];

                for (int i = 0; i < this.Criteria.Length; ++i)
                {
                    this.Criteria[i] = new Criteria() 
                    { 
                        ArticleId = TextConverter.EscapeInvalidXmlChars(request.Criteria[i].RobotArticleCode),
                        ExternalId = string.IsNullOrEmpty(request.Criteria[i].ExternalID) ? null : TextConverter.EscapeInvalidXmlChars(request.Criteria[i].ExternalID),
                        BatchNumber = string.IsNullOrEmpty(request.Criteria[i].BatchNumber) ? null : TextConverter.EscapeInvalidXmlChars(request.Criteria[i].BatchNumber),
                        StockLocationId = string.IsNullOrEmpty(request.Criteria[i].StockLocationID) ? null : TextConverter.EscapeInvalidXmlChars(request.Criteria[i].StockLocationID),
                        MachineLocation = string.IsNullOrEmpty(request.Criteria[i].MachineLocation) ? null : TextConverter.EscapeInvalidXmlChars(request.Criteria[i].MachineLocation)
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
            var request = new Interfaces.Messages.Stock.StockInfoRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;
            request.IncludePacks = TypeConverter.ConvertBool(this.IncludePacks);
            request.IncludeArticleDetails = TypeConverter.ConvertBool(this.IncludeArticleDetails);

            if (this.Criteria != null)
            {
                foreach (Criteria criteria in this.Criteria)
                {
                    request.Criteria.Add(new StockInfoCriteria() 
                    {
                        PISArticleCode = TextConverter.UnescapeInvalidXmlChars(criteria.ArticleId),
                        BatchNumber = TextConverter.UnescapeInvalidXmlChars(criteria.BatchNumber),
                        ExternalID = TextConverter.UnescapeInvalidXmlChars(criteria.ExternalId),
                        StockLocationID = TextConverter.UnescapeInvalidXmlChars(criteria.StockLocationId),
                        MachineLocation = TextConverter.UnescapeInvalidXmlChars(criteria.MachineLocation)
                    });
                }
            }

            return request;
        }
    }
}
