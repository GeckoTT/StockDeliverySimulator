using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Configuration
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ConfigurationGetRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ConfigurationGetRequestEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ConfigurationGetRequest ConfigurationGetRequest { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ConfigurationGetRequest.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ConfigurationGetRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class ConfigurationGetRequest : MessageBase, IMessageConversion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationGetRequest"/> class.
        /// </summary>
        public ConfigurationGetRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationGetRequest"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public ConfigurationGetRequest(MosaicMessage message)
        {
            var request = (Interfaces.Messages.Configuration.ConfigurationGetRequest)message;

            this.Id = request.ID;
            this.Source = request.Source;
            this.Destination = request.Destination;
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
            var request = new Interfaces.Messages.Configuration.ConfigurationGetRequest(converterStream);

            request.ID = this.Id;
            request.Source = this.Source;
            request.Destination = this.Destination;

            return request;
        }
    }

}
