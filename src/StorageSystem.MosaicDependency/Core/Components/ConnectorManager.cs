using System;
using System.Collections.Generic;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Core.Components
{
    /// <summary>
    /// Class which manages the initialization and creation of the configured connector components.
    /// </summary>
    public class ConnectorManager : IDisposable
    {
        #region Constants

        /// <summary>
        /// Connection check interval for outbound connectors in milliseconds.
        /// </summary>
        private const int ConnectionCheckInterval = 3000;

        #endregion

        #region Members

        /// <summary>
        /// Holds the reference of the active converter manager to notify in case of newly created connections.
        /// </summary>
        private ConverterManager _converterManager = null;

        /// <summary>
        /// The list of active connector instances.
        /// </summary>
        private List<IConnector> _connectorList = new List<IConnector>();

        /// <summary>
        /// Contains the configured converter -- connector assignments.  
        /// </summary>
        private Dictionary<int, int> _converterAssignments = new Dictionary<int, int>();

        /// <summary>
        /// Number of currently running connector threads.
        /// </summary>
        private int _numRunningThreads = 0;

        /// <summary>
        /// Shutdown event for the connector threads.
        /// </summary>
        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        
        #endregion

        #region Methods

        /// <summary>
        /// Initializes the connector manager with all configured connectors.
        /// </summary>
        /// <param name="dbSet">The set of active Mosaic databases.</param>
        /// <param name="converterManager">The active converter manager to notify about new connections.</param>
        /// <returns><c>true</c> if initialization was successful;<c>false</c> otherwise.</returns>
        public bool Initialize(DatabaseSet dbSet, ConverterManager converterManager)
        {
            if (dbSet == null)
            {
                throw new ArgumentException("Invalid dbSet specified.");
            }

            if (converterManager == null)
            {
                throw new ArgumentException("Invalid converterManager specified.");
            }

            this.Trace("Initializing connector manager...");

            _connectorList.Clear();
            _converterAssignments.Clear();
            _converterManager = converterManager;

            ProcessConfigurationMigration(dbSet.Productive);

            try
            {
                List<Component> componentList = dbSet.Productive.Query<Component>(new CommandFilter("Type", ComponentType.Connector.ToString()));

                foreach (Component component in componentList)
                {
                    if (component.IsActive == false)
                    {
                        continue;
                    }

                    if (component.ConnectedComponentID == 0)
                    {
                        this.Error("No converter has been configured for the connector '{0}' with ID '{1}'.", 
                                    component.Description, component.ID);

                        return false;
                    }

                    this.Info("Initializing connector '{0}' with ID '{1}'.", component.Description, component.ID);
                    IConnector connector = ComponentLoader.LoadInterface<IConnector>(component.Assembly, component.ClassName);

                    if (connector == null)
                    {
                        this.Fatal("Connector '{0}' with ID '{1}' in assembly '{2}' and class '{3}' could not be found.",
                                   component.Description, component.ID, component.Assembly, component.ClassName);
                        return false;
                    }

                    if (connector.Initialize(component.ID, 
                                             dbSet.Productive.Query<ConfigurationValue>(new CommandFilter("ComponentID", component.ID))) == false)
                    {
                        this.Error("Initializing connector '{0}' with ID '{1}' failed.", component.Description, component.ID);
                        return false;
                    }

                    _connectorList.Add(connector);
                    _converterAssignments.Add(connector.ID, component.ConnectedComponentID);
                }

                // finally start connector threads
                foreach (var connector in _connectorList)
                {
                    Interlocked.Increment(ref _numRunningThreads);

                    if (ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessConnector), connector) == false)
                    {
                        Interlocked.Decrement(ref _numRunningThreads);
                        this.Error("Starting connector thread failed.");
                        return false;
                    }                    
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Initializing connectors failed.", ex);
            }

            return false;
        }

        /// <summary>
        /// Cancels all running connector instances.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        public void Cancel()
        {
            this.Trace("Cancel all running connector instances.");

            _shutdownEvent.Set();

            foreach (var connector in _connectorList)
            {
                connector.Cancel();
            }

            while (Interlocked.CompareExchange(ref _numRunningThreads, 0, 0) != 0)
            {
                Thread.Sleep(50);
            }

            this.Trace("All running connector instances have been cancelled.");
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Trace("Cleanup all connector instances...");

            foreach (var connector in _connectorList)
            {
                connector.Dispose();
            }

            _connectorList.Clear();
            _converterAssignments.Clear();
            _shutdownEvent.Dispose();
        }

        /// <summary>
        /// Processes connector related configuration migration steps.
        /// </summary>
        /// <param name="database">The database which contains the configuration to migrate.</param>
        private void ProcessConfigurationMigration(Database database)
        {
            if (database == null)
            {
                throw new ArgumentException("Invalid database specified.");
            }

            UpdateTransportSystemConnectionCategories(database);
        }

        /// <summary>
        /// Updates the existing connection categories from 'Other' to 'TransportSystem'.
        /// </summary>
        /// <param name="database">The database which contains the configuration to update.</param>
        private void UpdateTransportSystemConnectionCategories(Database database)
        {
            this.Trace("Updating transport system related connection categories.");

            var connectors = database.Query<Component>(new CommandFilter("Type", ComponentType.Connector.ToString()));

            foreach (var connector in connectors)
            {
                var configurationValues = database.Query<ConfigurationValue>(new CommandFilter("ComponentID", connector.ID));

                foreach (var configurationValue in configurationValues)
                {
                    if ((string.Compare(configurationValue.Name, "Category") == 0) &&
                        (string.Compare(configurationValue.Value, ConnectionCategory.Other.ToString()) == 0))
                    {
                        configurationValue.Value = ConnectionCategory.TransportSystem.ToString();
                        database.Update(configurationValue);
                    }
                }
            }
        }

        /// <summary>
        /// Processes the required actions for the specified connector instance.
        /// </summary>
        /// <param name="connectorInstance">The connector instance to process.</param>
        private void ProcessConnector(object connectorInstance)
        {
            IConnector connector = connectorInstance as IConnector;

            try
            {
                if (connector is IInboundConnector)
                {
                    ProcessInboundConnector(connector as IInboundConnector);
                }
                else if (connector is IOutboundConnector)
                {
                    ProcessOutboundConnector(connector as IOutboundConnector);
                }
            }
            catch (Exception ex)
            {
                this.Error("Processing connector '{0}'-'{1}' failed.", ex, connector.ID, connector.Description);
            }

            Interlocked.Decrement(ref _numRunningThreads);
            this.Trace("Processor thread for connector '{0}' stopped.", connector.ID);
        }

        /// <summary>
        /// Processes the required actions for an inbound connector.
        /// </summary>
        /// <param name="connector">The inbound connector to process.</param>
        private void ProcessInboundConnector(IInboundConnector connector)
        {
            this.Info("Inbound connector '{0}'-'{1}' is running.",
                      connector.ID, connector.Description);

            while (_shutdownEvent.WaitOne(0) == false)
            {
                IConnection connection = connector.WaitForConnections();

                if (connection != null)
                {
                    this.Trace("Accepted new incomming connection '{0}' from connector '{1}'-'{2}'.",
                               connection.ID, connector.ID, connector.Description);

                    _converterManager.CreateConverterStream(connection, _converterAssignments[connector.ID]);
                }
                else
                {
                    if (_shutdownEvent.WaitOne(0) == false)
                    {
                        this.Error("Waiting for incomming connections from connector '{0}'-'{1}' failed -> process wait and try again.",
                                   connector.ID, connector.Description);

                        Thread.Sleep(1000);
                    }
                }
            }
        }

        /// <summary>
        /// Processes the required actions for an outbount connector.
        /// </summary>
        /// <param name="connector">The outbound connector to process.</param>
        private void ProcessOutboundConnector(IOutboundConnector connector)
        {
            this.Info("Outbound connector '{0}'-'{1}' is running.",
                      connector.ID, connector.Description);

            IConnection connection = null;

            do
            {
                if (connection != null)
                {
                    if (connection.IsConnected == false)
                    {
                        this.Info("Connection '{0}' of connector '{1}'-'{2}' has been closed.",
                                  connection.ID, connector.ID, connector.Description);

                        connection.Dispose();
                        connection = null;
                    }
                }

                if (connection == null)
                {
                    connection = connector.Connect();

                    if (connection != null)
                    {
                        _converterManager.CreateConverterStream(connection, _converterAssignments[connector.ID]);
                    }
                    else
                    {
                        this.Error("Creating outbound connection with connector '{0}'-'{1}' failed.",
                                   connector.ID, connector.Description);
                    }
                }
            }
            while (_shutdownEvent.WaitOne(ConnectionCheckInterval) == false);
        }

        #endregion
    }
}
