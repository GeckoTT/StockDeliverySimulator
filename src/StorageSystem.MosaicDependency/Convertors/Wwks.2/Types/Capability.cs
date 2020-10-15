using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Capability datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class Capability
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}
