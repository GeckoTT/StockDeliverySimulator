using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages
{
    /// <summary>
    /// Class which defines the basic attributes of every WWKS2 message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class MessageBase
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public int Source { get; set; }

        [XmlAttribute]
        public int Destination { get; set; }
    }
}
