using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using System.Xml;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Configuration
{
    /// <summary>
    /// Class which represents the WWKS 2.0 ConfigurationGetResponse message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class ConfigurationGetResponseEnvelope : EnvelopeBase, IMessageConversion
    {
        [XmlElement]
        public ConfigurationGetResponse ConfigurationGetResponse { get; set; }

        /// <summary>
        /// Translates this object instance into a Mosaic message.
        /// </summary>
        /// <param name="converterStream">The converter stream instance which request the message conversion.</param>
        /// <returns>
        /// The Mosaic message representation of this object.
        /// </returns>
        public MosaicMessage ToMosaicMessage(IConverterStream converterStream)
        {
            return this.ConfigurationGetResponse.ToMosaicMessage(converterStream);
        }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 ConfigurationGetResponse message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class ConfigurationGetResponse : MessageBase, IMessageConversion
    {
        #region Properties

        [XmlIgnore]
        public string RawContent { get; set; }
        
        [XmlElement(ElementName = "Configuration")]
        public XmlCDataSection XmlConfiguration
        {
            get
            {
                if (string.IsNullOrEmpty(this.RawContent))
                {
                    return null;
                }

                XmlDocument doc = new XmlDocument();
                return doc.CreateCDataSection(this.RawContent);
            }

            set
            {
                if (value == null)
                {
                    this.RawContent = string.Empty;
                }
                else
                {
                    this.RawContent = value.Value;
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationGetResponse"/> class.
        /// </summary>
        public ConfigurationGetResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationGetResponse"/> class.
        /// </summary>
        /// <param name="message">The message to use for initialization.</param>
        public ConfigurationGetResponse(MosaicMessage message)
        {
            var response = (Interfaces.Messages.Configuration.ConfigurationGetResponse)message;

            this.Id = response.ID;
            this.Source = response.Source;
            this.Destination = response.Destination;
            this.RawContent = response.Configuration;
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
            var response = new Interfaces.Messages.Configuration.ConfigurationGetResponse(converterStream);

            response.ID = this.Id;
            response.Source = this.Source;
            response.Destination = this.Destination;
            response.Configuration = (this.RawContent != null) ? this.RawContent : string.Empty;

            return response;
        }
    }
}
