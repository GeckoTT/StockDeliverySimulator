
using System.Xml.Serialization;
namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Task datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class Task
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlAttribute]
        public string Status { get; set; }

        [XmlElement]
        public Article[] Article { get; set; }

        [XmlElement]
        public Box[] Box { get; set; }
    }
}
