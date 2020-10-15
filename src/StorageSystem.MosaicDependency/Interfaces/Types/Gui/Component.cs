using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Messages.Status;

namespace CareFusion.Mosaic.Interfaces.Types.Gui
{
    /// <summary>
    /// Enum which defines the different types of supported Mosaic components.
    /// </summary>
    public enum ComponentType
    {
        /// <summary>
        /// The element represents Mosaic itself.
        /// </summary>
        Mosaic,

        /// <summary>
        /// The element is a storage system.
        /// </summary>
        StorageSystem,

        /// <summary>
        /// The element is an IT system.
        /// </summary>
        ItSystem,

        /// <summary>
        /// The element is the box system.
        /// </summary>
        BoxSystem,

        /// <summary>
        /// The element is a PLC connection
        /// </summary>
        PlcConnection
    }

    /// <summary>
    /// Class which represents a Mosaic component which is displayed in the GUI.
    /// </summary>
    public class Component
    {
        #region Members

        /// <summary>
        /// Component specific properties.
        /// </summary>
        private Dictionary<string, string> _componentProperties = new Dictionary<string,string>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the component identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the description of the element.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the element.
        /// </summary>
        public ComponentType Type { get; set; }

        /// <summary>
        /// Gets or sets the status of the element.
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// Component related properties.
        /// </summary>
        public Dictionary<string, string> Properties { get { return _componentProperties; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        public Component()
        {
            this.Description = string.Empty;
            this.Type = ComponentType.Mosaic;
            this.Status = StatusType.NotReady;
        }
    }
}
