using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Messages.KeepAlive
{
    /// <summary>
    /// Class which represents the WWKS 2.0 KeepAliveRequest message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class KeepAliveRequestEnvelope : EnvelopeBase
    {
        [XmlElement]
        public KeepAliveRequest KeepAliveRequest { get; set; }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 KeepAliveRequest message.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class KeepAliveRequest : MessageBase
    {
    }
}
