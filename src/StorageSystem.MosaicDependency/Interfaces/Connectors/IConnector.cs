using System;
using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Interfaces.Connectors
{
    /// <summary>
    /// Interface which defines the methods for any kind of Mosaic connector.
    /// </summary>
    public interface IConnector : IComponent
    {
        #region Methods

        /// <summary>
        /// Initializes the connector with the specified configuration.
        /// </summary>
        /// <param name="connectorID">The identifier of the connector.</param>
        /// <param name="configurationValueList">The list of configuration values, assigned to this connector.</param>
        /// <returns><c>true</c> if initialization was successful; <c>false</c> otherwise.</returns>
        bool Initialize(int connectorID, List<ConfigurationValue> configurationValueList);

        /// <summary>
        /// Cancels any pending operations like creating or accepting connections.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        void Cancel();

        #endregion
    }
}
