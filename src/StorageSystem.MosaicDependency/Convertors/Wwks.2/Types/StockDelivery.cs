using System.Collections.Generic;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the StockDelivery datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class StockDelivery
    {
        [XmlAttribute]
        public string DeliveryNumber { get; set; }

        [XmlElement]
        public List<Article> Article { get; set; }
    }
}
