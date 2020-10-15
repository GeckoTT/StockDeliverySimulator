using System.Xml.Serialization;

namespace CareFusion.Mosaic.Converters.Wwks2.Types
{
    /// <summary>
    /// Defines the possible results of a shopping cart update request.
    /// </summary>
    public enum UpdateResultStatus
    {
        /// <summary>
        /// The shopping cart has been updated successfully.
        /// </summary>
        Updated,

        /// <summary>
        /// The shopping cart has not been updated.
        /// </summary>
        NotUpdated
    }


    /// <summary>
    /// Class which represents the UpdateResult datatype in the WWKS 2.0 protocol.
    /// </summary>
    public class UpdateResult
    {
        [XmlAttribute]
        public UpdateResultStatus Status { get; set; }

        [XmlAttribute]
        public string Description { get; set; }
    }
}
