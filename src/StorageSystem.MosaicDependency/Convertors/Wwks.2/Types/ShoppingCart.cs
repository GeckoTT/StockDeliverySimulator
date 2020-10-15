using System.Xml.Serialization;
using System.Collections.Generic;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    public class ShoppingCart
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Status { get; set; }

        [XmlAttribute]
        public string ViewPointId { get; set; }

        [XmlAttribute]
        public string SalesPointId { get; set; }

        [XmlAttribute]
        public string SalesPersonId { get; set; }

        [XmlAttribute]
        public string CustomerId { get; set; }

        [XmlElement]
        public List<ShoppingCartItem> ShoppingCartItem { get; set; }

    }
}
