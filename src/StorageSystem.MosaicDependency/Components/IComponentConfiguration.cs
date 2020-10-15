using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Interfaces.Components
{
    /// <summary>
    /// Interface which defines the methods of a Mosaic component configuration object.
    /// </summary>
    public interface IComponentConfiguration
    {
        #region Methods

        /// <summary>
        /// (Re)Initializes the configuration object with the specified configuration values.
        /// </summary>
        /// <param name="configurationValueList">The list of configuration values to use for initialization.</param>
        void Initialize(List<ConfigurationValue> configurationValueList);

        /// <summary>
        /// Converts the configuration object into a list of configuration value instances.
        /// </summary>
        /// <returns>The list of configuration value instances.</returns>
        List<ConfigurationValue> ToConfigurationValueList();

        #endregion
    }
}
