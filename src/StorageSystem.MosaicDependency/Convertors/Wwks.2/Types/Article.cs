using System.Collections.Generic;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Article datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class Article
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string DosageForm { get; set; }

        [XmlAttribute]
        public string PackagingUnit { get; set; }

        [XmlAttribute]
        public string BatchNumber { get; set; }

        [XmlAttribute]
        public string BatchTracking { get; set; }

        [XmlAttribute]
        public string ExternalId { get; set; }

        [XmlAttribute]
        public string SerialNumber { get; set; }

        [XmlAttribute]
        public string SerialTracking { get; set; }

        [XmlAttribute]
        public string ExpiryDate { get; set; }

        [XmlAttribute]
        public string ExpiryTracking { get; set; }

        [XmlAttribute]
        public string RequiresFridge { get; set; }

        [XmlAttribute]
        public string Quantity { get; set; }

        [XmlAttribute]
        public string MaxSubItemQuantity { get; set; }

        [XmlAttribute]
        public string StockLocationId { get; set; }

        [XmlAttribute]
        public string MachineLocation { get; set; }

        [XmlElement]
        public List<Pack> Pack { get; set; }

        [XmlElement]
        public List<Article> ChildArticle { get; set; }

        [XmlElement]
        public List<Tag> Tags { get; set; }

        [XmlElement]
        public List<PriceInformation> PriceInformation { get; set; }

        [XmlElement]
        public List<Article> CrossSellingArticles { get; set; }

        [XmlElement]
        public List<Article> AlternativeArticles { get; set; }

        [XmlElement]
        public List<Article> AlternativePackSizeArticles { get; set; }

        [XmlAttribute]
        public int Depth { get; set; }

        [XmlAttribute]
        public int Width { get; set; }

        [XmlAttribute]
        public int Height { get; set; }

        [XmlAttribute]
        public int Weight { get; set; }

        [XmlAttribute]
        public string SerialNumberSinceExpiryDate { get; set; }

        [XmlElement]
        public List<ProductCode> ProductCode { get; set; }
    }
}
