using System.Xml.Serialization;
using CareFusion.Mosaic.Interfaces.Messages.Input;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Handling datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class Handling
    {
        [XmlAttribute]
        public StockInputHandlingType Input { get; set; }

        [XmlAttribute]
        public string Text { get; set; }
    }
}
