using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Connectors.Tcp
{
    /// <summary>
    /// Class which implements a connector that accepts incomming TCP/IP connections.
    /// </summary>
    public class TcpInConnector : IInboundConnector
    {
        #region Members

        /// <summary>
        /// Holds the connector configuration.
        /// </summary>
        private TcpInConnectorConfiguration _configuration = null;

        /// <summary>
        /// TCP listeners to use for accepting incomming connections.
        /// </summary>
        private List<TcpListener> _tcpListenerList = new List<TcpListener>();

        /// <summary>
        /// List of currently outstanding listening operations.
        /// </summary>
        private IAsyncResult[] _listenResultList;

        /// <summary>
        /// Event which is used to cancel pending listen operations.
        /// </summary>
        private ManualResetEvent _cancelEvent = new ManualResetEvent(false);

        /// <summary>
        /// Event which is used to signal the end of a listening operation.
        /// </summary>
        private ManualResetEvent _listenFinishedEvent = new ManualResetEvent(true);

        /// <summary>
        /// The list of currently active TCP connections.
        /// </summary>
        private List<TcpConnection> _activeConnections = new List<TcpConnection>();

        #endregion
        
        #region Properties

        /// <summary>
        /// Gets the identifier of the connector which has been passed to the Initialize method. 
        /// </summary>
        public int ID 
        { 
            get; 
            private set; 
        }

        /// <summary>
        /// Gets an informational English description of the connector (e.g. "TCP/IP Socket Connector").
        /// </summary>
        public string Description
        {
            get { return "TCP/IP Socket Listener"; }
        }

        #endregion

        /// <summary>
        /// Gets an object with public properties which defines a configuration for this connector.
        /// </summary>
        /// <returns>Appropriate configuration object for this connector.</returns>
        public IComponentConfiguration GetConfigurationObject()
        {
            return new TcpInConnectorConfiguration();
        }

        /// <summary>
        /// Initializes the connector with the specified configuration.
        /// </summary>
        /// <param name="connectorID">The identifier of the connector.</param>
        /// <param name="configurationValueList">The list of configuration values, assigned to this connector.</param>
        /// <returns><c>true</c> if initialization was successful; <c>false</c> otherwise.</returns>
        public bool Initialize(int connectorID, List<ConfigurationValue> configurationValueList)
        {
            this.ID = connectorID;
            _configuration = new TcpInConnectorConfiguration(configurationValueList);

            if (_tcpListenerList.Count > 0)
            {
                this.Error("The connector is already initialized.");
                return false;
            }

            try
            {
                var usedAddressList = new List<string>();
                IPAddress[] ipAddressList = Dns.GetHostAddresses(Dns.GetHostName());

                if (ipAddressList == null)
                {
                    this.Error("No network interfaces are available.");
                    return false;
                }

                this.Trace("Starting TCP listener for port '{0}'.", _configuration.Port);

                foreach (IPAddress ipAddress in ipAddressList)
                {
                    if (usedAddressList.Contains(ipAddress.ToString()))
                    {
                        continue;
                    }

                    this.Trace("Starting TCP listener for address '{0}'.", ipAddress.ToString());
                    TcpListener listener = new TcpListener(ipAddress, _configuration.Port);
                    usedAddressList.Add(ipAddress.ToString());
                    _tcpListenerList.Add(listener);
                    listener.Start();
                }

                if (System.Net.Sockets.Socket.OSSupportsIPv4)
                {
                    if (usedAddressList.Contains(IPAddress.Loopback.ToString()) == false)
                    {
                        this.Trace("Starting TCP listener for address '{0}'.", IPAddress.Loopback.ToString());
                        TcpListener listener = new TcpListener(IPAddress.Loopback, _configuration.Port);
                        listener.Start();
                        _tcpListenerList.Add(listener);
                    }
                }

                if (System.Net.Sockets.Socket.OSSupportsIPv6)
                {
                    if (usedAddressList.Contains(IPAddress.IPv6Loopback.ToString()) == false)
                    {
                        this.Trace("Starting TCP listener for address '{0}'.", IPAddress.IPv6Loopback.ToString());
                        TcpListener listener = new TcpListener(IPAddress.IPv6Loopback, _configuration.Port);
                        listener.Start();
                        _tcpListenerList.Add(listener);
                    }
                }

                _listenResultList = new IAsyncResult[_tcpListenerList.Count];
                _listenFinishedEvent.Set();
                return true;
            }
            catch (Exception ex)
            {
                this.Error("Starting TCP listeners for port '{0}' failed.", ex, _configuration.Port);
            }

            return false;
        }

        /// <summary>
        /// Starts to wait for incomming connections. This method will block until a new incomming connection 
        /// has been accepted, the connector has been cancelled or an error occurred.
        /// </summary>
        /// <returns>Newly created incomming connection object if successful; <c>null</c> otherwise.</returns>
        public IConnection WaitForConnections()
        {
            if (_cancelEvent.WaitOne(0))
                return null;

            try
            {
                _listenFinishedEvent.Reset();

                if (WaitForFreeConnectionSlot() == false)
                    return null;
                
                WaitHandle[] waitHandles = new WaitHandle[_listenResultList.Length + 1];

                for (int i = 0; i < _listenResultList.Length; ++i)
                {
                    if (_listenResultList[i] == null)
                        _listenResultList[i] = _tcpListenerList[i].BeginAcceptTcpClient(null, null);
                    
                    waitHandles[i] = _listenResultList[i].AsyncWaitHandle;
                }

                waitHandles[waitHandles.Length - 1] = _cancelEvent;
                int waitResult = WaitHandle.WaitAny(waitHandles);

                if (waitHandles[waitResult] == _cancelEvent)
                {
                    this.Info("Waiting for incomming connections was cancelled.");
                    return null;
                }

                IAsyncResult acceptResult = _listenResultList[waitResult];
                _listenResultList[waitResult] = null;

                TcpClient tcpClient = _tcpListenerList[waitResult].EndAcceptTcpClient(acceptResult);                
                tcpClient.ReceiveTimeout = 0;

                IPEndPoint remoteEndpoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;

                this.Info("Successfully accepted connection from '{0}:{1}'.",
                          remoteEndpoint.Address.ToString(), remoteEndpoint.Port);
                
                var endPoint = string.Format("{0}:{1}", remoteEndpoint.Address.ToString(), _configuration.Port);
                var connection = new TcpConnection(this.ID, _configuration.Category, tcpClient, endPoint);
                connection.Closed += OnConnectionClosed;

                lock (_activeConnections)
                {
                    _activeConnections.Add(connection);
                }

                return connection;
            }
            catch (Exception ex)
            {
                this.Error("Waiting for incomming connections failed.", ex);
            }
            finally
            {
                _listenFinishedEvent.Set();
            }

            return null;
        }

        /// <summary>
        /// Event which is called when a connection has been closed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnConnectionClosed(object sender, EventArgs e)
        {
            lock (_activeConnections)
            {
                _activeConnections.Remove((TcpConnection)sender);
            }
        }

        /// <summary>
        /// Waits until a free slot for a new incoming connection is available.
        /// Connection slots are defined by the maximum number of allowed concurrent connections.
        /// </summary>
        /// <returns><c>true</c> if connection slot has been acquired;<c>false</c> otherwise.</returns>
        private bool WaitForFreeConnectionSlot()
        {
            var writeLog = true;

            do
            {
                var activeConnectionCount = 0;

                lock (_activeConnections)
                {
                    activeConnectionCount = _activeConnections.Count;
                }

                if (activeConnectionCount < _configuration.MaxConcurrentConnections)
                    return true;

                if (writeLog)
                {
                    this.Error("Maximum number of {0} allowed concurrent connections reached -> waiting for connections to be closed!", activeConnectionCount);
                    writeLog = false;
                }
            }
            while (_cancelEvent.WaitOne(50) == false);

            return false;
        }

        /// <summary>
        /// Cancels any pending operations like creating or accepting connections.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        public void Cancel()
        {
            this.Trace("Cancelling all active TCP listeners...");

            _cancelEvent.Set();
            _listenFinishedEvent.WaitOne();

            this.Trace("All active TCP listeners cancelled.");
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Trace("Cleanup all active TCP listeners.");

            foreach (TcpListener tcpListener in _tcpListenerList)
            {
                tcpListener.Stop();
            }

            _listenResultList = null;
            _tcpListenerList.Clear();
            _listenFinishedEvent.Dispose();
            _cancelEvent.Dispose();
        }
    }
}
