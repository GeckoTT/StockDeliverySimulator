using CareFusion.Lib.StorageSystem.Wwks2.Messages;
using System.Xml;
using System.Xml.Serialization;

namespace CareFusion.Lib.StorageSystem.Wwks2.Types
{
    /// <summary>
    /// Defines the possible reasons for having an unprocessed message.
    /// </summary>
    public enum UnprocessedMessageReason
    {
        /// <summary>
        ///  The message was not processed because the recipient does not support it.
        /// </summary>
        NotSupported,

        /// <summary>
        /// The message was not processed because it is not valid XML or has other syntactical errors.
        /// </summary>
        SyntaxError
    }

    /// <summary>
    /// Class which represents the Message datatype in the WWKS 2.0 protocol.
    /// </summary>
    public class Message
    {
        [XmlIgnore] public string RawContent { get; set; }

        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                if (string.IsNullOrEmpty(this.RawContent))
                {
                    return null;
                }

                var xmlDocument = new XmlDocument();
                return new XmlNode[] {xmlDocument.CreateCDataSection(this.RawContent)};
            }
            set
            {
                if (value == null)
                {
                    this.RawContent = string.Empty;
                }
                else
                {
                    if (value[0] is XmlCDataSection cdata)
                    {
                        this.RawContent = cdata.Data;
                    }
                    else if (value[0] is XmlText text)
                    {
                        this.RawContent = text.InnerText;
                    }
                    else
                    {
                        this.RawContent = string.Empty;
                    }
                }
            }
        }
    }
}
