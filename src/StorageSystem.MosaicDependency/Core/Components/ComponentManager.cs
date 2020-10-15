using System;
using System.Collections.Generic;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.BoxSystem;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Types.Components;
using CareFusion.Mosaic.VideoCapture;

namespace CareFusion.Mosaic.Core.Components
{
    /// <summary>
    /// Class which manages all the different types of Mosaic components.
    /// </summary>
    public class ComponentManager : IDisposable
    {
        #region Members

        /// <summary>
        /// Reference to the active Mosaic task scheduler.
        /// </summary>
        private TaskScheduler _taskScheduler = new TaskScheduler();

        /// <summary>
        /// Reference to the video capturing host instance to use.
        /// </summary>
        private CamRecorderClient _captureHost = new CamRecorderClient();

        /// <summary>
        /// Reference to the active pack conveyor manager instance.
        /// </summary>
        private PackConveyorManager _packConveyorManager = new PackConveyorManager();

        /// <summary>
        /// Reference to the currently active box system module.
        /// </summary>
        private IBoxSystem _boxSystem = null;

        /// <summary>
        /// Reference to the instance of the Mosaic orchestration manager.
        /// </summary>
        private OrchestrationManager _orchestrationManager = new OrchestrationManager();

        /// <summary>
        /// Reference to the instance of the Mosaic converter manager.
        /// </summary>
        private ConverterManager _converterManager = new ConverterManager();

        /// <summary>
        /// Reference to the instance of the Mosaic connector manager.
        /// </summary>
        private ConnectorManager _connectorManager = new ConnectorManager();

        /// <summary>
        /// Reference to the instance of the Mosaic WCF service manager.
        /// </summary>
        private WcfServiceManager _wcfServiceManager = new WcfServiceManager();

        #endregion

        /// <summary>
        /// Initializes the all Mosaic component manager instances and the box picking implementation.
        /// </summary>
        /// <param name="dbSet">The set of active Mosaic databases.</param>
        /// <returns><c>true</c> if initialization was successful;<c>false</c> otherwise.</returns>
        public bool Initialize(DatabaseSet dbSet)
        {
            if (_taskScheduler.Initialize(dbSet) == false)
            {
                Cancel();
                Dispose();
                return false;
            }

            if (_packConveyorManager.Initialize(dbSet, _captureHost) == false)
            {
                Cancel();
                Dispose();
                return false;
            }

            if (InitializeBoxSystem(dbSet) == false)
            {
                Cancel();
                Dispose();
                return false;
            }

            DeletePlcConnections(dbSet);

            if (_orchestrationManager.Initialize(dbSet, _packConveyorManager, _boxSystem, _captureHost) == false)
            {
                Cancel();
                Dispose();
                return false;
            }

            if (_wcfServiceManager.Initialize(dbSet, _packConveyorManager, _orchestrationManager, _boxSystem) == false)
            {
                Cancel();
                Dispose();
                return false;
            }

            if (_converterManager.Initialize(dbSet, _orchestrationManager, _taskScheduler) == false)
            {
                Cancel();
                Dispose();
                return false;
            }

            if (_connectorManager.Initialize(dbSet, _converterManager) == false)
            {
                Cancel();
                Dispose();
                return false;
            }

            if (_taskScheduler.Start() == false)
            {
                Cancel();
                Dispose();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Cancels any pending blocking or asynchronous operations of the component manager.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        public void Cancel()
        {
            if (_boxSystem != null)
            {
                _boxSystem.Shutdown();
            }

            _connectorManager.Cancel();
            _packConveyorManager.Cancel();
            _orchestrationManager.Cancel();            
            _taskScheduler.Cancel();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _connectorManager.Dispose();
            _converterManager.Dispose();
            _wcfServiceManager.Dispose();            
            _orchestrationManager.Dispose();            

            if (_boxSystem != null)
            {
                _boxSystem.Dispose();
            }

            _packConveyorManager.Dispose();
            _captureHost.Dispose();
            _taskScheduler.Dispose();
        }

        /// <summary>
        /// Initializes the box picking module if one is configured.
        /// </summary>
        /// <param name="dbSet">The set of active Mosaic databases.</param>
        /// <returns><c>true</c> if initialization was successful;<c>false</c> otherwise.</returns>
        private bool InitializeBoxSystem(DatabaseSet dbSet)
        {
            this.Trace("Initializing box system module...");

            try
            {
                List<Component> componentList = dbSet.Productive.Query<Component>(new CommandFilter("Type", ComponentType.BoxSystem.ToString()));

                foreach (Component component in componentList)
                {
                    if (component.IsActive == false)
                    {
                        continue;
                    }

                    this.Info("Initializing box system module '{0}' with ID '{1}'.", component.Description, component.ID);
                    _boxSystem = ComponentLoader.LoadInterface<IBoxSystem>(component.Assembly, component.ClassName);

                    if (_boxSystem == null)
                    {
                        this.Fatal("Box system module '{0}' with ID '{1}' in assembly '{2}' and class '{3}' could not be found.",
                                   component.Description, component.ID, component.Assembly, component.ClassName);
                        return false;
                    }

                    if (_boxSystem.Initialize(component.ID,
                                              dbSet.Productive.Query<ConfigurationValue>(new CommandFilter("ComponentID", component.ID)),
                                              _packConveyorManager.PackConveyors,
                                              _captureHost) == false)
                    {
                        this.Error("Initializing box system module '{0}' with ID '{1}' failed.", component.Description, component.ID);
                        return false;
                    }

                    break;
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Initializing box system module failed.", ex);
            }

            return false;
        }

        /// <summary>
        /// Deletes all outdated legacy plc connection configurations.
        /// </summary>
        /// <param name="dbSet">The database set to use.</param>
        private void DeletePlcConnections(DatabaseSet dbSet)
        {
            this.Trace("Deleting outdated legacy plc connections...");

            try
            {
                var plcConnections = dbSet.Productive.Query<Component>(new CommandFilter("Type", "PlcConnection"));

                foreach (Component plcConnection in plcConnections)
                {
                    this.Info("Deleting outdated legacy plc connection '{0}'...", plcConnection.Description);

                    dbSet.Productive.Delete<ConfigurationValue>(new CommandFilter("ComponentID", plcConnection.ID));
                    dbSet.Productive.Delete(plcConnection);
                }
            }
            catch (Exception ex)
            {
                this.Error("Deleting outdated legacy plc connections failed.", ex);
            }
        }
    }
}
