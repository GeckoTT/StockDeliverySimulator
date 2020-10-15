using System;
using System.IO;

namespace CareFusion.Mosaic.Interfaces.Connectors
{
    /// <summary>
    /// Interface of a connection that has been created by any kind of connector.
    /// </summary>
    public interface IConnection : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the unique identifier of this connection instance.
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Gets the identifier of the connector that created this connection instance.
        /// </summary>
        int ConnectorID { get; }

        /// <summary>
        /// Gets a description of the connected endpoint (e.g. IP address or COM port).
        /// </summary>
        string EndPoint { get; }

        /// <summary>
        /// Gets the category this connection belongs to.
        /// </summary>
        ConnectionCategory Category { get; }

        /// <summary>
        /// Returns <c>true</c> if the connection is still active; <c>false</c> otherwise. 
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets a stream instance which can be used to read or write data from or to this connection.
        /// </summary>
        Stream ConnectionStream { get; }

        /// <summary>
        /// Provides an optional name of the element that was involved in the last read operation of the connection stream.
        /// The support for element names is connector specific (e.g. file names, table names ...) and may be unavailable at some connectors.
        /// </summary>
        string LastReadElementName { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines a name for the element that is used for the next write operations on the connection stream.
        /// The interpretation of the element name is connector specific (e.g. file names, table names ...) and may be ignored.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        void SetNextWriteElementName(string elementName);

        /// <summary>
        /// Cancels any pending blocking or asynchronous operations of the connection stream.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        void Cancel();

        #endregion
    }
}
