using System;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages
{
    /// <summary>
    /// Class which defines the envelope for every WWKS2 message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class EnvelopeBase
    {
        #region Properties

        [XmlAttribute]
        public string Version { get; set; }

        [XmlAttribute]
        public string TimeStamp { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvelopeBase"/> class.
        /// </summary>
        public EnvelopeBase()
        { 
            // set defaults
            this.Version = "2.0";
            this.TimeStamp = string.Format("{0:yyyy-MM-ddTHH:mm:ssZ}", DateTime.UtcNow);
        }
    }
}
