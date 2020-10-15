using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    public class PriceInformation
    {
        [XmlAttribute]
        public string Category { get; set; }

        [XmlAttribute]
        public string Description { get; set; }

        [XmlAttribute]
        public string Quantity { get; set; }

        [XmlAttribute]
        public string Price { get; set; }

        [XmlAttribute]
        public string BasePrice { get; set; }

        [XmlAttribute]
        public string BasePriceUnit { get; set; }
    }
}
