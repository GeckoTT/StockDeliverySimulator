
using System.Xml.Serialization;
namespace CareFusion.Mosaic.Interfaces.Types.Configuration
{
    /// <summary>
    /// Class which represents an input point for initiatable input.
    /// </summary>
    public class InputPoint
    {
        /// <summary>
        /// Gets or sets the number that identifies the input point.
        /// </summary>
        [XmlAttribute]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets a flag whether input is allowed via this input point.
        /// </summary>
        [XmlAttribute]
        public bool InputAllowed { get; set; }

        /// <summary>
        /// Flag whether input is allowed via this input point.
        /// </summary>
        [XmlAttribute]
        public bool OutputAllowed { get; set; }
    }
}
