
namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Defines the supported transport system releated commands.
    /// </summary>
    public enum TransportSystemCommand
    {
        /// <summary>
        /// Clears the selection of the transfer point.
        /// </summary>
        Clear,

        /// <summary>
        /// Selects a transfer point.
        /// </summary>
        Select,

        /// <summary>
        /// Starts the transport system to move the dispensed packs.
        /// </summary>
        Start
    }
}
