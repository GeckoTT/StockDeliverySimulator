using System;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Pack datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class Pack
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Index { get; set; }

        [XmlAttribute]
        public string ScanCode { get; set; }

        [XmlAttribute]
        public string DeliveryNumber { get; set; }

        [XmlAttribute]
        public string BatchNumber { get; set; }

        [XmlAttribute]
        public string ExternalId { get; set; }

        [XmlAttribute]
        public string SerialNumber { get; set; }

        [XmlAttribute]
        public string ExpiryDate { get; set; }

        [XmlAttribute]
        public string StockInDate { get; set; }

        [XmlAttribute]
        public string SubItemQuantity { get; set; }

        [XmlAttribute]
        public string Depth { get; set; }

        [XmlAttribute]
        public string Width { get; set; }

        [XmlAttribute]
        public string Height { get; set; }

        [XmlAttribute]
        public string Shape { get; set; }

        [XmlAttribute]
        public string State { get; set; }

        [XmlAttribute]
        public string IsInFridge { get; set; }

        [XmlAttribute]
        public string BoxNumber { get; set; }

        [XmlAttribute]
        public string OutputDestination { get; set; }

        [XmlAttribute]
        public string OutputPoint { get; set; }

        [XmlAttribute]
        public string LabelStatus { get; set; }

        [XmlAttribute]
        public string StockLocationId { get; set; }

        [XmlAttribute]
        public string MachineLocation { get; set; }

        [XmlElement]
        public Handling Handling { get; set; }

        [XmlElement]
        public Error Error { get; set; }
        
    }
}
     
