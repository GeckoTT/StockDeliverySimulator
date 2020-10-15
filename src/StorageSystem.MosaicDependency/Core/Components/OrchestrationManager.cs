using System;
using System.Collections.Generic;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.BoxSystem;
using CareFusion.Mosaic.Plc;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Messages;
using CareFusion.Mosaic.Interfaces.Orchestration;
using CareFusion.Mosaic.Interfaces.Types.Components;
using CareFusion.Mosaic.Interfaces.VideoCapture;
using CareFusion.Mosaic.Interfaces.Components;

namespace CareFusion.Mosaic.Core.Components
{
    /// <summary>
    /// Class which manages the initialization and creation of the configured orchestration components.
    /// </summary>
    public class OrchestrationManager : IDisposable
    {
        #region Members

        /// <summary>
        /// Number of currently running orchestration threads.
        /// </summary>
        private int _numRunningThreads = 0;

        /// <summary>
        /// Shutdown event for the orchestration threads.
        /// </summary>
        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);

        /// <summary>
        /// The list of active orchestration instances.
        /// </summary>
        private List<IOrchestration> _orchestrationList = new List<IOrchestration>();

        /// <summary>
        /// List of currently active converter stream instances.
        /// </summary>
        private List<IConverterStream> _converterStreamList = new List<IConverterStream>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of currently active orchestrations.
        /// </summary>
        public IOrchestration[] Orchestrations
        {
            get { return _orchestrationList.ToArray(); }
        }

        #endregion

        /// <summary>
        /// Initializes the connector manager with all configured connectors.
        /// </summary>
        /// <param name="dbSet">The set of active Mosaic databases.</param>
        /// <param name="packConveyorManager">The currently active pack conveyor module.</param>
        /// <param name="boxSystem">The currently active box system module.</param>
        /// <param name="captureHost">The currently active video capturing host.</param>
        /// <returns>
        ///   <c>true</c> if initialization was successful;<c>false</c> otherwise.
        /// </returns>
        public bool Initialize(DatabaseSet dbSet, PackConveyorManager packConveyorManager, IBoxSystem boxSystem, ICaptureHost captureHost)
        {
            if (dbSet == null)
            {
                throw new ArgumentException("Invalid dbSet specified.");
            }

            this.Trace("Initializing orchestration manager...");

            ProcessConfigurationMigration(dbSet.Productive);

            _orchestrationList.Clear();

            try
            {
                List<Component> componentList = dbSet.Productive.Query<Component>(new CommandFilter("Type", ComponentType.Orchestration.ToString()));

                foreach (Component component in componentList)
                {
                    if (component.IsActive == false)
                    {
                        continue;
                    }

                    this.Info("Initializing orchestration '{0}' with ID '{1}'.", component.Description, component.ID);
                    IOrchestration orchestration = ComponentLoader.LoadInterface<IOrchestration>(component.Assembly, component.ClassName);

                    if (orchestration == null)
                    {
                        this.Fatal("Orchestration '{0}' with ID '{1}' in assembly '{2}' and class '{3}' could not be found.",
                                   component.Description, component.ID, component.Assembly, component.ClassName);
                        return false;
                    }

                    if (orchestration.Initialize(component.ID,
                                                 dbSet.Productive.Query<ConfigurationValue>(new CommandFilter("ComponentID", component.ID)),
                                                 dbSet, 
                                                 packConveyorManager.PackConveyors,
                                                 boxSystem,
                                                 captureHost) == false)
                    {
                        this.Error("Initializing orchestration '{0}' with ID '{1}' failed.", component.Description, component.ID);
                        return false;
                    }

                    _orchestrationList.Add(orchestration);
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Initializing orchestrations failed.", ex);
            }

            return false;
        }

        /// <summary>
        /// Notifies all registered orchestrations about the new converter stream 
        /// and starts a message reader thread for this converter.
        /// </summary>
        /// <param name="converterStream">The converter stream to process.</param>
        public void AddConverterStream(IConverterStream converterStream)
        {
            if (_shutdownEvent.WaitOne(0))
            {
                return;
            }

            this.Info("New converter stream with ID '{0}' and type '{1}' added.",
                      converterStream.ConverterID, converterStream.Connection.Category.ToString());

            try
            {
                lock (_converterStreamList)
                {
                    _converterStreamList.Add(converterStream);
                }

                lock (_orchestrationList)
                {
                    foreach (var orchestration in _orchestrationList)
                    {
                        orchestration.AddConverterStream(converterStream);
                    }
                }

                Interlocked.Increment(ref _numRunningThreads);
                if (ThreadPool.QueueUserWorkItem(new WaitCallback(RunMessageReader), converterStream) == false)
                {
                    Interlocked.Decrement(ref _numRunningThreads);
                    this.Error("Starting message reader thread for converter stream with ID '{0}' and type '{1}' failed.",
                               converterStream.ConverterID, converterStream.Connection.Category.ToString());

                    lock (_orchestrationList)
                    {
                        foreach (var orchestration in _orchestrationList)
                        {
                            orchestration.RemoveConverterStream(converterStream);
                        }
                    }

                    lock (_converterStreamList)
                    {
                        _converterStreamList.Remove(converterStream);
                    }

                    converterStream.Cancel();
                    converterStream.Dispose();
                }
            }
            catch (Exception ex)
            {
                this.Error("Notifying orchestrations about new converter stream with ID '{0}' and type '{1}' failed.",
                           ex, converterStream.ConverterID, converterStream.Connection.Category.ToString());

                lock (_converterStreamList)
                {
                    _converterStreamList.Remove(converterStream);
                }

                converterStream.Cancel();
                converterStream.Dispose();
            }
        }

        /// <summary>
        /// Cancels all running orchestration instances and message reader and processor threads.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        public void Cancel()
        {
            this.Trace("Cancel all running orchestration instances.");

            _shutdownEvent.Set();

            lock (_orchestrationList)
            {
                foreach (var orchestration in _orchestrationList)
                {
                    orchestration.Cancel();
                }
            }

            lock (_converterStreamList)
            {
                foreach (var converterStream in _converterStreamList)
                {
                    converterStream.Cancel();
                }
            }

            while (Interlocked.CompareExchange(ref _numRunningThreads, 0, 0) != 0)
            {
                Thread.Sleep(50);
            }

            this.Trace("All running orchestration instances have been cancelled.");            
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Trace("Cleanup all running orchestration instances...");

            lock (_orchestrationList)
            {
                foreach (var orchestration in _orchestrationList)
                {
                    orchestration.Dispose();
                }
            }

            lock (_converterStreamList)
            {
                foreach (var converterStream in _converterStreamList)
                {
                    converterStream.Dispose();
                }
            }

            _shutdownEvent.Dispose();

            this.Trace("All running orchestration instances have been cleaned up.");
        }

        /// <summary>
        /// Processes orchestration related configuration migration steps.
        /// </summary>
        /// <param name="database">The database which contains the configuration to migrate.</param>
        private void ProcessConfigurationMigration(Database database)
        {
            if (database == null)
            {
                throw new ArgumentException("Invalid database specified.");
            }

            PatchPackConveyorOrchestrationConfiguration(database);
            MigrateTransportSystemOrchestration(database);
        }

        /// <summary>
        /// Patches some errors in the PackConveyorOrchestration configuration.
        /// </summary>
        /// <param name="database">The database which contains the configuration to patch.</param>
        private void PatchPackConveyorOrchestrationConfiguration(Database database)
        {
            this.Trace("Patching pack conveyor orchestration configuration if necessary.");

            var orchestration = database.Get<Component>(new CommandFilter("Type", ComponentType.Orchestration.ToString()),
                                                        new CommandFilter("ClassName", "CareFusion.Mosaic.Orchestrations.PackConveyor.PackConveyorOrchestration"));

            if (orchestration == null)
                return;

            var configurationValues = database.Query<ConfigurationValue>(new CommandFilter("ComponentID", orchestration.ID));

            if (configurationValues.Count == 0)
                return;

            foreach (var configurationValue in configurationValues)
            {
                if ((string.Compare(configurationValue.Name, "ReservationTimeout") == 0) &&
                    (configurationValue.Value.Length > 2))
                {
                    // fix wrong reservation timeout
                    this.Trace("Patching reservation timeout of the pack conveyor orchestration to default value of 60 seconds.");
                    configurationValue.Value = "60";
                    database.Update(configurationValue);
                    break;
                }
            }
        }

        /// <summary>
        /// Migrates the deprecated transport system orchestration to the new pack conveyor orchestration.
        /// </summary>
        /// <param name="database">The database which contains the configuration to migrate.</param>
        private void MigrateTransportSystemOrchestration(Database database)
        {
            this.Trace("Migrating legacy transport system orchestration to new pack conveyor orchestration if necessary.");

            var orchestration = database.Get<Component>(new CommandFilter("Type", ComponentType.Orchestration.ToString()),
                                                        new CommandFilter("ClassName", "CareFusion.Mosaic.Orchestrations.TransportSystem.TransportSystemOrchestration"));

            if (orchestration == null)
                return;

            var configurationValues = database.Query<ConfigurationValue>(new CommandFilter("ComponentID", orchestration.ID));

            if (configurationValues.Count > 0)
                database.Delete(configurationValues.ToArray());

            database.Delete(orchestration);

            var packConveyorOrchestration = new Component()
            {
                ID = (int)database.QueryMaxID<Component>() + 1,
                Type = ComponentType.Orchestration,
                Assembly = string.Empty,
                ClassName = "CareFusion.Mosaic.Orchestrations.PackConveyor.PackConveyorOrchestration",
                Description = "Pack Conveyor Orchestration",
                IsActive = true
            };

            database.Update(packConveyorOrchestration);
        }

        /// <summary>
        /// Runs the thread which reads messages from the specified converter stream and dispatches them.
        /// </summary>
        /// <param name="converterStream">The converter stream to read the messages from.</param>
        private void RunMessageReader(object converterStream)
        {
            IConverterStream stream = (IConverterStream)converterStream;

            this.Trace("Message reader thread for converter stream with ID '{0}' and type '{1}' started.",
                       stream.ConverterID, stream.Connection.Category.ToString());

            try
            {
                while (_shutdownEvent.WaitOne(0) == false)
                {
                    MosaicMessage message = stream.Read();

                    if (message != null)
                    {
                        lock (_orchestrationList)
                        {
                            foreach (var orchestrations in _orchestrationList)
                            {
                                orchestrations.EnqueueMessageForProcessing(message);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }                
            }
            catch (Exception ex)
            {
                this.Error("Processing message reader thread for stream with ID '{0}' and type '{1}' failed.",
                           ex, stream.ConverterID, stream.Connection.Category.ToString());
            }
            finally
            {
                try
                {
                    this.Trace("Message reader thread for converter stream with ID '{0}' and type '{1}' goes down.",
                               stream.ConverterID, stream.Connection.Category.ToString());

                    lock (_orchestrationList)
                    {
                        foreach (var orchestration in _orchestrationList)
                        {
                            orchestration.RemoveConverterStream(stream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Error("Processing removal of converter stream with ID '{0}' and type '{1}' failed.",
                               ex, stream.ConverterID, stream.Connection.Category.ToString());
                }
                
                lock (_converterStreamList)
                {
                    _converterStreamList.Remove(stream);
                }

                stream.Dispose();
            }

            Interlocked.Decrement(ref _numRunningThreads);
        }
    }
}
