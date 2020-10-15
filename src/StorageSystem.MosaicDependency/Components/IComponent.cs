using System;

namespace CareFusion.Mosaic.Interfaces.Components
{
    /// <summary>
    /// Interface which defines the properties and methods of every Mosaic component implementation.
    /// </summary>
    public interface IComponent : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the identifier of the component which has been passed during initialisation. 
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Gets an informational English description of the component (e.g. "TCP/IP Socket Connector").
        /// </summary>
        string Description { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an object with public properties which defines a configuration for this component.
        /// </summary>
        /// <returns>Appropriate configuration object for this component.</returns>
        IComponentConfiguration GetConfigurationObject();

        #endregion

    }
}
