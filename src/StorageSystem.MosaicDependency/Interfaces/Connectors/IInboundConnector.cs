
namespace CareFusion.Mosaic.Interfaces.Connectors
{
    /// <summary>
    /// Interface of a connector which is able to accept incomming connections.
    /// </summary>
    public interface IInboundConnector : IConnector
    {
        /// <summary>
        /// Starts to wait for incomming connections. This method will block until a new incomming connection 
        /// has been accepted, the connector has been cancelled or an error occurred.
        /// </summary>
        /// <returns>Newly created incomming connection object if successful; <c>null</c> otherwise.</returns>
        IConnection WaitForConnections();
    }
}
