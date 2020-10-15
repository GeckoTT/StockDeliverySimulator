using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Component datatype in the WWKS 2.0 protocol.
    /// </summary>
    public class Component
    {
        [XmlAttribute]
        public string Type { get; set; }

        [XmlAttribute]
        public string Description { get; set; }

        [XmlAttribute]
        public string State { get; set; }

        [XmlAttribute]
        public string StateText { get; set; }
    }
}
