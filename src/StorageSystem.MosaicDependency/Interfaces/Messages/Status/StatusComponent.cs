
namespace CareFusion.Mosaic.Interfaces.Messages.Status
{
    /// <summary>
    /// Class which represents a a component within a StatusResponse or StatusMessage.
    /// </summary>
    public class StatusComponent
    {
        #region Properties

        /// <summary>
        /// Gets or sets the description of the component.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the English type name of the component.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the state of the component.
        /// </summary>
        public StatusType State { get; set; }

        /// <summary>
        /// Gets or sets an optional additional description text of the state of the component.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// Gets or sets the list of subcomponents according to this component.
        /// </summary>
        public StatusComponent[] SubComponents { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusComponent"/> class.
        /// </summary>
        public StatusComponent()
        {
            this.Description = string.Empty;
            this.Type = string.Empty;
            this.StateDescription = string.Empty;
        }
    }
}
