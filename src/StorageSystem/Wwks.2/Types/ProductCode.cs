using System.Xml.Serialization;

namespace CareFusion.Lib.StorageSystem.Wwks2.Types
{
    public class ProductCode
    {
        #region WWKS 2.0 Properties

        [XmlAttribute]
        public string Code { get; set; }

        #endregion
    }
}
