using CareFusion.Lib.StorageSystem.Wwks2.Types;
using System.Xml;
using System.Xml.Serialization;

namespace CareFusion.Lib.StorageSystem.Wwks2.Messages.Unprocessed
{
    /// <summary>
    /// Class which represents the WWKS 2.0 UnprocessedMessage message envelope.
    /// </summary>
    [XmlType(TypeName = "WWKS")]
    public class UnprocessedMessageEnvelope : EnvelopeBase
    {
        [XmlElement]
        public UnprocessedMessage UnprocessedMessage { get; set; }
    }

    /// <summary>
    /// Class which represents the WWKS 2.0 UnprocessedMessage message.
    /// </summary>
    public class UnprocessedMessage : MessageBase
    {
        #region Properties

        [XmlAttribute]
        public string Reason { get; set; }

        [XmlAttribute]
        public string Text { get; set; }

        [XmlElement]
        public Message Message { get; set; }

        #endregion Properties
    }
}
