using System;
using System.Collections.Generic;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Interfaces.Scheduler
{
    /// <summary>
    /// Interface which defines a Mosaic scheduler task.
    /// </summary>
    public interface ISchedulerTask : IComponent
    {
        #region Properties

        /// <summary>
        /// Gets the timestamp of the next task execution in UTC. 
        /// </summary>
        DateTime ExecuteTime { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the scheduler task with the specified configuration.
        /// </summary>
        /// <param name="taskID">The identifier of the scheduler task.</param>
        /// <param name="configurationValueList">The list of configuration values, assigned to this scheduler task.</param>
        /// <param name="dbSet">The set of active Mosaic databases.</param>
        /// <returns>
        ///   <c>true</c> if initialization was successful; <c>false</c> otherwise.
        /// </returns>
        bool Initialize(int taskID, List<ConfigurationValue> configurationValueList, DatabaseSet dbSet);

        /// <summary>
        /// Executes the scheduler task.
        /// </summary>
        /// <param name="converterStreamList">
        /// The list of converter stream instances which are assigned to this scheduler task and currently connected.
        /// </param>
        void Execute(List<IConverterStream> converterStreamList);

        /// <summary>
        /// Cancels any pending blocking or asynchronous operations of the orchestration.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        void Cancel();

        #endregion
    }
}
