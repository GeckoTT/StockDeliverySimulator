
namespace CareFusion.Mosaic.Interfaces.Messages.Task
{
    /// <summary>
    /// Defines different state values for a task.
    /// </summary>
    public enum TaskState
    {
        /// <summary>
        /// The state of the task is unknown (e.g. task does not exist).
        /// </summary>
        Unknown,

        /// <summary>
        /// The task has been queued for execution.
        /// </summary>
        Queued,

        /// <summary>
        /// The task is currently executing.
        /// </summary>
        InProcess,

        /// <summary>
        /// The task is currently aborting.
        /// </summary>
        Aborting,

        /// <summary>
        /// The task has been aborted.
        /// </summary>
        Aborted,

        /// <summary>
        /// The task has finished successfully.
        /// </summary>
        Completed,

        /// <summary>
        /// The task has finished with an incomplete result (e.g. not all packs were output). 
        /// </summary>
        Incomplete,

        /// <summary>
        /// The task has been cancelled (result of a cancellation request).
        /// </summary>
        Cancelled,

        /// <summary>
        /// An error occurred while trying to cancel a task.
        /// </summary>
        CancelError
    }
}
