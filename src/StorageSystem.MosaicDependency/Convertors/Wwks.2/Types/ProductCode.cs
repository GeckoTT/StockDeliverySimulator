using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    public class ProductCode
    {
        #region WWKS 2.0 Properties

        [XmlAttribute]
        public string Code { get; set; }

        #endregion
    }
}