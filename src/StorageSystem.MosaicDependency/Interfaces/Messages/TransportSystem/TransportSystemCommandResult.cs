
namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Defines the different results for a transport system related command.
    /// </summary>
    public enum TransportSystemCommandResult
    {
        /// <summary>
        /// Command has been executed successfully.
        /// </summary>
        OK,

        /// <summary>
        /// The specified output is not selected.
        /// </summary>
        NotSelected,

        /// <summary>
        /// The specified output is not ready.
        /// </summary>
        NotReady,

        /// <summary>
        /// The specified output is not operational.
        /// </summary>
        NotOperational,

        /// <summary>
        /// Another error occurred.
        /// </summary>
        GenericError
    }
}
