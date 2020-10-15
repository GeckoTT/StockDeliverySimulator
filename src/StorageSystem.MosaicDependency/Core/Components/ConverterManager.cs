using System;
using System.Collections.Generic;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Connectors;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Core.Components
{
    /// <summary>
    /// Class which manages the initialization and creation of the configured converter components.
    /// </summary>
    public class ConverterManager : IDisposable
    {
        #region Members

        /// <summary>
        /// Holds the reference of the active orchestration manager to notify in case of newly created connections.
        /// </summary>
        private OrchestrationManager _orchestrationManager = null;

        /// <summary>
        /// Holds the reference of the active task scheduler to notify in case of newly created connections.
        /// </summary>
        private TaskScheduler _taskScheduler = null;

        /// <summary>
        /// The list of active converter instances.
        /// </summary>
        private List<IConverter> _converterList = new List<IConverter>();

        /// <summary>
        /// Contains the configured converter -- task assignments.  
        /// </summary>
        private Dictionary<int, int> _taskAssignments = new Dictionary<int, int>();
        
        #endregion

        /// <summary>
        /// Initializes the connector manager with all configured connectors.
        /// </summary>
        /// <param name="dbSet">The set of active Mosaic databases.</param>
        /// <param name="orchestrationManager">The active orchestration manager to notify about new converter streams.</param>
        /// <param name="taskScheduler">The active task scheduler to notify about converter streams.</param>
        /// <returns><c>true</c> if initialization was successful;<c>false</c> otherwise.</returns>
        public bool Initialize(DatabaseSet dbSet, 
                               OrchestrationManager orchestrationManager, 
                               TaskScheduler taskScheduler)
        {
            if (dbSet == null)
            {
                throw new ArgumentException("Invalid dbSet specified.");
            }

            if (orchestrationManager == null)
            {
                throw new ArgumentException("Invalid orchestrationManager specified.");
            }

            if (taskScheduler == null)
            {
                throw new ArgumentException("Invalid taskScheduler specified.");
            }

            this.Trace("Initializing converter manager...");

            _converterList.Clear();
            _taskAssignments.Clear();
            _orchestrationManager = orchestrationManager;
            _taskScheduler = taskScheduler;

            try
            {
                List<Component> componentList = dbSet.Productive.Query<Component>(new CommandFilter("Type", ComponentType.Converter.ToString()));

                foreach (Component component in componentList)
                {
                    if (component.IsActive == false)
                    {
                        continue;
                    }

                    this.Info("Initializing converter '{0}' with ID '{1}'.", component.Description, component.ID);
                    IConverter converter = ComponentLoader.LoadInterface<IConverter>(component.Assembly, component.ClassName);

                    if (converter == null)
                    {
                        this.Fatal("Converter '{0}' with ID '{1}' in assembly '{2}' and class '{3}' could not be found.",
                                   component.Description, component.ID, component.Assembly, component.ClassName);
                        return false;
                    }

                    if (converter.Initialize(component.ID,
                                             dbSet.Productive.Query<ConfigurationValue>(new CommandFilter("ComponentID", component.ID))) == false)
                    {
                        this.Error("Initializing converter '{0}' with ID '{1}' failed.", component.Description, component.ID);
                        return false;
                    }

                    _converterList.Add(converter);

                    if (component.ConnectedComponentID != 0)
                    {
                        _taskAssignments.Add(converter.ID, component.ConnectedComponentID);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Initializing converters failed.", ex);
            }

            return false;
        }

        /// <summary>
        /// Creates a new converter stream for the specified connection and
        /// passes the new converter stream to the orchestration or task scheduler.
        /// </summary>
        /// <param name="connection">The connection to use for creating a new converter stream.</param>
        /// <param name="converterID">The identifier of the converter to use for creating the stream.</param>
        public void CreateConverterStream(IConnection connection, int converterID)
        {
            if (connection == null)
            {
                throw new ArgumentException("Invalid connection specified.");
            }

            int taskID = 0;
            IConverter converter = null;
   
            lock (_converterList)
            {
                foreach (var conv in _converterList)
                {
                    if (conv.ID != converterID)
                    {
                        continue;
                    }

                    converter = conv;
                    if (_taskAssignments.ContainsKey(conv.ID))
                    {
                        taskID = _taskAssignments[conv.ID];
                    }
                    break;
                }
            }

            if (converter == null)
            {
                connection.Dispose();
                return;
            }

            IConverterStream stream = converter.CreateStream(connection);
            if (stream == null)
            {
                connection.Dispose();
                return;
            }

            if (taskID == 0)
            {
                _orchestrationManager.AddConverterStream(stream);
            }
            else
            {
                _taskScheduler.AddConverterStream(stream, taskID);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Trace("Cleanup all converter instances...");

            lock (_converterList)
            {
                foreach (var converter in _converterList)
                {
                    converter.Dispose();
                }

                _converterList.Clear();
                _taskAssignments.Clear();
            }
        }

    }
}
