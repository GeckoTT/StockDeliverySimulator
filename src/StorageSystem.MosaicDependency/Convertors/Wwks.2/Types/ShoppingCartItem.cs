using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    public class ShoppingCartItem
    {
        [XmlAttribute]
        public string ArticleId { get; set; }

        [XmlAttribute]
        public string OrderedQuantity { get; set; }

        [XmlAttribute]
        public string DispensedQuantity { get; set; }

        [XmlAttribute]
        public string PaidQuantity { get; set; }

        [XmlAttribute]
        public string Price { get; set; }

        [XmlAttribute]
        public string Currency { get; set; }
    }
}
