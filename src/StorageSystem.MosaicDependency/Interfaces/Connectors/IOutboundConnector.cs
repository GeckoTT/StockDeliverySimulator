
namespace CareFusion.Mosaic.Interfaces.Connectors
{
    /// <summary>
    /// Interface of a connector which is able to create outgoing connections.
    /// </summary>
    public interface IOutboundConnector : IConnector
    {
        /// <summary>
        /// Establishes a new outgoing connection. 
        /// This method will block until the connect finished successfully, has been canceled or an error (e.g. Timeout) occurred.
        /// </summary>
        /// <returns>Appropriate connection object if successful; <c>null</c> otherwise.</returns>
        IConnection Connect();
    }
}
