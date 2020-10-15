using System;
using System.Collections.Generic;
using System.Threading;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Components;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Scheduler;
using CareFusion.Mosaic.Interfaces.Types.Components;

namespace CareFusion.Mosaic.Core.Components
{
    /// <summary>
    /// Class which implements the Mosaic internal task scheduler.
    /// </summary>
    public class TaskScheduler : IDisposable
    {
        #region Members

        /// <summary>
        /// Thread save flag whether the scheduler thread is running.
        /// </summary>
        private int _isSchedulerRunning = 0;

        /// <summary>
        /// Shutdown event for the scheduler thread.
        /// </summary>
        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);

        /// <summary>
        /// Holds the currently active converter streams which are assigned to a scheduler tasks.
        /// </summary>
        private Dictionary<ISchedulerTask, List<IConverterStream>> _taskConverterStreams = new Dictionary<ISchedulerTask, List<IConverterStream>>();

        /// <summary>
        /// Holds the configuration of converter streams which are configured for a scheduler task.
        /// </summary>
        private Dictionary<ISchedulerTask, List<int>> _taskConverterStreamConfig = new Dictionary<ISchedulerTask, List<int>>();

        #endregion

        /// <summary>
        /// Initializes the task scheduler with all configured scheduler tasks.
        /// </summary>
        /// <param name="dbSet">The set of active Mosaic databases.</param>
        /// <returns><c>true</c> if initialization was successful;<c>false</c> otherwise.</returns>
        public bool Initialize(DatabaseSet dbSet)
        {
            if (dbSet == null)
            {
                throw new ArgumentException("Invalid dbSet specified.");
            }

            this.Trace("Initializing task scheduler...");

            _taskConverterStreams.Clear();
            _taskConverterStreamConfig.Clear();

            try
            {
                List<Component> componentList = dbSet.Productive.Query<Component>(new CommandFilter("Type", ComponentType.SchedulerTask.ToString()));

                foreach (Component component in componentList)
                {
                    if (component.IsActive == false)
                    {
                        continue;
                    }

                    this.Info("Initializing scheduler task '{0}' with ID '{1}'.", component.Description, component.ID);
                    ISchedulerTask task = ComponentLoader.LoadInterface<ISchedulerTask>(component.Assembly, component.ClassName);

                    if (task == null)
                    {
                        this.Fatal("Scheduler task '{0}' with ID '{1}' in assembly '{2}' and class '{3}' could not be found.",
                                   component.Description, component.ID, component.Assembly, component.ClassName);
                        return false;
                    }

                    if (task.Initialize(component.ID,
                                        dbSet.Productive.Query<ConfigurationValue>(new CommandFilter("ComponentID", component.ID)),
                                        dbSet) == false)
                    {
                        this.Error("Initializing scheduler task '{0}' with ID '{1}' failed.", component.Description, component.ID);
                        return false;
                    }

                    List<int> converterConfiguration = new List<int>();
                    var connectedConverterList = dbSet.Productive.Query<Component>(new CommandFilter("ConnectedComponentID", component.ID));

                    foreach (var converter in connectedConverterList)
                    {
                        converterConfiguration.Add(converter.ID);
                    }

                    _taskConverterStreams.Add(task, new List<IConverterStream>());
                    _taskConverterStreamConfig.Add(task, converterConfiguration);
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Initializing scheduler tasks failed.", ex);
            }

            return false;
        }

        /// <summary>
        /// Starts the scheduler and begins to execute the configured scheduler tasks.
        /// </summary>
        /// <returns><c>true</c> if successful; <c>false</c> otherwise.</returns>
        public bool Start()
        {
            if (_isSchedulerRunning != 0)
            {
                return true;
            }

            if (_taskConverterStreams.Count > 0)
            {
                // finally start the scheduler thread
                _isSchedulerRunning = 1;
                if (ThreadPool.QueueUserWorkItem(new WaitCallback(RunTaskScheduler)) == false)
                {
                    _isSchedulerRunning = 0;
                    this.Error("Starting task scheduler thread failed.");
                    return false;
                }
            }

            return true;

        }

        /// <summary>
        /// Adds the specified converter stream to the specified scheduler task.
        /// </summary>
        /// <param name="converterStream">The converter stream to add to the task.</param>
        /// <param name="taskID">The identifier of the scheduler task to add the converter to.</param>
        public void AddConverterStream(IConverterStream converterStream, int taskID)
        {
            lock (_taskConverterStreams)
            {
                var taskList = _taskConverterStreams.Keys;

                foreach (var task in taskList)
                {
                    if (task.ID != taskID)
                    {
                        continue;
                    }

                    _taskConverterStreams[task].Add(converterStream);
                    return;
                }
            }

            this.Error("The scheduler task '{0}' does not exist.", taskID);
            converterStream.Dispose();
        }

        /// <summary>
        /// Cancels all running task scheduler instances and the scheduler thread.
        /// This method will block and not return until all outstanding operations have finished.
        /// </summary>
        public void Cancel()
        {
            this.Trace("Cancel all running scheduler task instances.");

            _shutdownEvent.Set();

            lock (_taskConverterStreams)
            {
                var taskList = _taskConverterStreams.Keys;

                foreach (var task in taskList)
                {
                    var converterList = _taskConverterStreams[task];

                    foreach (var converterStream in converterList)
                    {
                        converterStream.Cancel();
                    }

                    task.Cancel();
                }
            }

            while (Interlocked.CompareExchange(ref _isSchedulerRunning, 0, 0) != 0)
            {
                Thread.Sleep(50);
            }

            this.Trace("All running scheduler task instances have been cancelled.");
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Trace("Cleanup all scheduler task instances...");

            lock (_taskConverterStreams)
            {
                var taskList = _taskConverterStreams.Keys;

                foreach (var task in taskList)
                {
                    var converterList = _taskConverterStreams[task];

                    foreach (var converterStream in converterList)
                    {
                        converterStream.Dispose();
                    }

                    task.Dispose();
                }

                _taskConverterStreams.Clear();
                _taskConverterStreamConfig.Clear();
            }

            _shutdownEvent.Dispose();
        }

        /// <summary>
        /// Runs the task scheduler.
        /// </summary>
        /// <param name="param">The param.</param>
        private void RunTaskScheduler(object param)
        {
            this.Info("Task Scheduler started.");

            int waitTime = 1000;

            do
            {
                try
                {
                    VerifyTaskConverterStreams();

                    lock (_taskConverterStreams)
                    {
                        // execute tasks
                        var taskList = _taskConverterStreams.Keys;

                        foreach (var task in taskList)
                        {
                            if (task.ExecuteTime > DateTime.UtcNow)
                            {
                                continue;
                            }

                            if (VerifyTaskConverterStreams(task))
                            {
                                task.Execute(_taskConverterStreams[task]);
                            }
                        }

                        // calculate next  execution time
                        DateTime nextExecutionTime = DateTime.MaxValue;

                        foreach (var task in taskList)
                        {
                            if (task.ExecuteTime < nextExecutionTime)
                            {
                                nextExecutionTime = task.ExecuteTime;
                            }
                        }

                        double nextExecutionWaitTime = (nextExecutionTime - DateTime.UtcNow).TotalMilliseconds;

                        if ((nextExecutionWaitTime <= 0) || (nextExecutionWaitTime > int.MaxValue))
                        {
                            waitTime = 2000;
                        }
                        else
                        {
                            waitTime = Convert.ToInt32(nextExecutionWaitTime);
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Error("Executing scheduler tasks failed.", ex);
                }
            }
            while (_shutdownEvent.WaitOne(waitTime) == false);

            this.Info("Task Scheduler stopped.");
            Interlocked.Exchange(ref _isSchedulerRunning, 0);
        }

        /// <summary>
        /// Verifies all active converter streams that are assigned to any scheduler task whether they are still active.
        /// </summary>
        private void VerifyTaskConverterStreams()
        {
            lock (_taskConverterStreams)
            {
                var taskList = _taskConverterStreams.Keys;

                foreach (var task in taskList)
                {
                    var converterStreamList = _taskConverterStreams[task].ToArray();

                    foreach (var stream in converterStreamList)
                    {
                        if (stream.Connection.IsConnected == false)
                        {
                            this.Info("Task related stream of converter '{0}' for task '{1}' is not connected anymore -> process cleanup.", 
                                      stream.ConverterID, task.ID);

                            stream.Cancel();
                            stream.Dispose();
                            _taskConverterStreams[task].Remove(stream);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Verifies whether all configured converter streams for the specified task are ready.
        /// </summary>
        /// <param name="task">The task to check the converter streams for.</param>
        /// <returns><c>true</c> if all converter streams, required by the task, are ready;<c>false</c> otherwise.</returns>
        private bool VerifyTaskConverterStreams(ISchedulerTask task)
        {
            bool isConverterStreamReady = false;
            var converterStreamList = _taskConverterStreams[task];
            var configuredConverterStreamList = _taskConverterStreamConfig[task];

            foreach (var converterStreamID in configuredConverterStreamList)
            {
                isConverterStreamReady = false;

                foreach (var converterStream in converterStreamList)
                {
                    if (converterStream.ConverterID == converterStreamID)
                    {
                        isConverterStreamReady = true;
                        break;
                    }
                }

                if (isConverterStreamReady == false)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
