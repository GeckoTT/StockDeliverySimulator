using System.Xml;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Class which represents the Label datatype in the WWKS 2.0 protocol.
    /// <see cref="https://portalrowa.carefusion.com/Unternehmen/Entwicklung/TechCom/Writing/P-010-044-B-I-388-DEU.docx" />
    /// </summary>
    public class Label
    {
        [XmlAttribute]
        public string TemplateId { get; set; }

        [XmlIgnore]
        public string RawContent { get; set; }

        [XmlElement(ElementName = "Content")]
        public XmlCDataSection XmlContent
        {
            get
            {
                if (string.IsNullOrEmpty(this.RawContent))
                {
                    return null;
                }

                XmlDocument doc = new XmlDocument();
                return doc.CreateCDataSection(this.RawContent);
            }

            set
            {
                if (value == null)
                {
                    RawContent = string.Empty;
                }
                else
                {
                    RawContent = value.Value;
                }
            }
        }
    }
}
