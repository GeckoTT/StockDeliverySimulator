using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Types.Output;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Details datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class Details
    {
        [XmlAttribute]
        public string Priority { get; set; }

        [XmlAttribute]
        public string OutputDestination { get; set; }

        [XmlAttribute]
        public string OutputPoint { get; set; }

        [XmlAttribute]
        public string InputSource { get; set; }

        [XmlAttribute]
        public string InputPoint { get; set; }

        [XmlAttribute]
        public string Status { get; set; }
    }
}
