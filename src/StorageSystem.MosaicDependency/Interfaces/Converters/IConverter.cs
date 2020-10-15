using System;
using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Interfaces.Converters
{
    /// <summary>
    /// Interface of a converter which is able to create converter stream instances of a specific type. 
    /// </summary>
    public interface IConverter : IComponent
    {
        #region Methods

        /// <summary>
        /// Initializes the connector with the specified configuration.
        /// </summary>
        /// <param name="converterID">The identifier of the converter.</param>
        /// <param name="configurationValueList">The list of configuration values, assigned to this converter.</param>
        /// <returns><c>true</c> if initialization was successful; <c>false</c> otherwise.</returns>
        bool Initialize(int converterID, List<ConfigurationValue> configurationValueList);

        /// <summary>
        /// Creates a new converter stream instance which is bound to the specified connection.
        /// </summary>
        /// <param name="connection">The connection which is used by the converter to read and write messages.</param>
        /// <returns>Newly created converter stream instance if successful; <c>null</c> otherwise.</returns>
        IConverterStream CreateStream(IConnection connection);

        #endregion
    }
}
