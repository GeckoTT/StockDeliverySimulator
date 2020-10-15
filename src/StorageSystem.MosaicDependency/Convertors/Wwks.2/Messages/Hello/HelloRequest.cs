using System.Xml.Serialization;
using CareFusion.Mosaic.Converters.Wwks2.Types;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.Hello
{
    /// <summary>
    /// Class which represents the WWKS 2.0 HelloRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class HelloRequestEnvelope : EnvelopeBase
    {
        [XmlElement]
        public HelloRequest HelloRequest { get; set; }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 HelloRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class HelloRequest
    {
        #region Properties

        [XmlAttribute]
        public int Id { get; set; }

        [XmlElement]
        public Subscriber Subscriber { get; set; }

        #endregion
    }
}
