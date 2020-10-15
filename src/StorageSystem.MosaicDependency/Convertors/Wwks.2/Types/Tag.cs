using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    public class Tag
    {
        [XmlAttribute]
        public string Value { get; set; }
    }
}
