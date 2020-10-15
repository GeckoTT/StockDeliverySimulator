using System.Collections.Generic;
using System.Xml.Serialization;

namespace CareFusion.Mosaic.Interfaces.Types.Configuration
{
    /// <summary>
    /// Class which represents an input source for initiatable input.
    /// </summary>
    public class InputSource
    {
        #region Members

        /// <summary>
        /// Holds the list of input points which are assigned to this input source.
        /// </summary>
        private List<InputPoint> _inputPoints = new List<InputPoint>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the number that identifies the input source.
        /// </summary>
        [XmlAttribute]
        public int Number { get; set; }

        /// <summary>
        /// Gets the list of input points which belong to this input source.
        /// </summary>
        [XmlArray]
        public List<InputPoint> InputPoints { get { return _inputPoints; } }

        #endregion
    }
}
