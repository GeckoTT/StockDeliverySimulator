using System.Collections.Generic;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Criteria datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class Criteria
    {
        [XmlAttribute]
        public string ArticleId { get; set; }

        [XmlAttribute]
        public int Quantity { get; set; }

        [XmlAttribute]
        public string SubItemQuantity { get; set; }

        [XmlAttribute]
        public string MinimumExpiryDate { get; set; }

        [XmlAttribute]
        public string BatchNumber { get; set; }

        [XmlAttribute]
        public string SingleBatchNumber { get; set; }        

        [XmlAttribute]
        public string ExternalId { get; set; }

        [XmlAttribute]
        public string SerialNumber { get; set; }

        [XmlAttribute]
        public string PackId { get; set; }

        [XmlAttribute]
        public string StockLocationId { get; set; }

        [XmlAttribute]
        public string MachineLocation { get; set; }

        [XmlElement]
        public List<Label> Label { get; set; }        
    }
}
