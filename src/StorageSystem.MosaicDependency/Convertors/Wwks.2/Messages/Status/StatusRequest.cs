using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Status
{
    /// <summary>
    /// Class which represents the WWKS 2.0 StatusRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class StatusRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public StatusRequest StatusRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.StatusRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 StatusRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StatusRequest : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlAttribute]
        public string IncludeDetails { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusRequest"/> class.
        /// </summary>
        public StatusRequest()
        {             
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public StatusRequest(MosaicMessage message)
        {
            var request = (Interfaces.Messages.Status.StatusRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;
            this.IncludeDetails = request.IncludeDetails.ToString();
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
            var request = new Interfaces.Messages.Status.StatusRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;
            request.IncludeDetails = TypeConverter.ConvertBool(this.IncludeDetails);

            return request;
        }
    }
}
