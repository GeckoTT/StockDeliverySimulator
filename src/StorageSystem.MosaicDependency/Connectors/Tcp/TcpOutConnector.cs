using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Connectors.Tcp
{
    /// <summary>
    /// Class which implements a connector that creates outgoing TCP/IP connections.
    /// </summary>
    public class TcpOutConnector : IOutboundConnector
    {
        #region Members

        /// <summary>
        /// Holds the connector configuration.
        /// </summary>
        private TcpOutConnectorConfiguration _configuration;

        /// <summary>
        /// Event which is used to cancel pending connect operations.
        /// </summary>
        private ManualResetEvent _cancelEvent = new ManualResetEvent(false);

        /// <summary>
        /// Event which is used to signal the end of a connect operation.
        /// </summary>
        private ManualResetEvent _connectFinishedEvent = new ManualResetEvent(false);

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
            get { return "TCP/IP Socket Connector"; }
        }

        #endregion

        /// <summary>
        /// Gets an object with public properties which defines a configuration for this connector.
        /// </summary>
        /// <returns>Appropriate configuration object for this connector.</returns>
        public IComponentConfiguration GetConfigurationObject()
        {
            return new TcpOutConnectorConfiguration();
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
            _configuration = new TcpOutConnectorConfiguration(configurationValueList);
            _connectFinishedEvent.Set();
            return true;
        }

        /// <summary>
        /// Establishes a new outgoing connection. 
        /// This method will block until the connect finished successfully, has been canceled or an error (e.g. Timeout) occurred.
        /// </summary>
        /// <returns>Appropriate connection object if successful; <c>null</c> otherwise.</returns>
        public IConnection Connect()
        {
            if (_cancelEvent.WaitOne(0))
            {
                return null;
            }

            try
            {
                _connectFinishedEvent.Reset();
                this.Trace("Connecting to address '{0}' on port '{1}'.", _configuration.Address, _configuration.Port);

                TcpClient tcpClient = new TcpClient();
                IAsyncResult connectResult = tcpClient.BeginConnect(_configuration.Address, _configuration.Port, null, null);
                WaitHandle[] waitHandles = new WaitHandle[] { _cancelEvent, connectResult.AsyncWaitHandle };

                int waitResult = WaitHandle.WaitAny(waitHandles,
                                                    Convert.ToInt32(_configuration.ConnectTimeout * 1000));

                if (waitResult == WaitHandle.WaitTimeout)
                {
                    this.Error("Connecting to address '{0}' on port '{1}' timed out after '{2}' seconds.",
                               _configuration.Address, _configuration.Port, _configuration.ConnectTimeout);

                    tcpClient.Close();
                    return null;
                }

                if (waitHandles[waitResult] == _cancelEvent)
                {
                    this.Info("Connecting to address '{0}' on port '{1}' was cancelled.",
                              _configuration.Address, _configuration.Port);

                    tcpClient.Close();
                    return null;
                }

                tcpClient.EndConnect(connectResult);
                tcpClient.ReceiveTimeout = (int)(_configuration.ReadTimeout * 1000);
                tcpClient.SendTimeout = (int)(_configuration.WriteTimeout * 1000);

                this.Info("Successfully connected to address '{0}' on port '{1}'.",
                          _configuration.Address, _configuration.Port);

                var endPoint = string.Format("{0}:{1}", _configuration.Address, _configuration.Port);
                return new TcpConnection(this.ID, _configuration.Category, tcpClient, endPoint);
            }
            catch (Exception ex)
            {
                this.Error("Connecting to address '{0}' on port '{1}' failed.",
                           ex, _configuration.Address, _configuration.Port);
            }
            finally
            {
                _connectFinishedEvent.Set();
            }

            return null;
        }

        /// <summary>
        /// Cancels any pending operations like creating or accepting connections.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        public void Cancel()
        {
            this.Trace("Cancelling active connect operations...");

            _cancelEvent.Set();
            _connectFinishedEvent.WaitOne();

            this.Trace("Active connect operations cancelled.");
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _cancelEvent.Dispose();
            _connectFinishedEvent.Dispose();
        }
    }
}
