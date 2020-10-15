using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Task
{
    /// <summary>
    /// Class which implements the TaskCancelRequest Mosaic message.
    /// This request is used to request the cancellation of a running task.
    /// </summary>
    public class TaskCancelRequest : MosaicMessage
    {
        #region Members

        /// <summary>
        /// Holds the list of tasks to cancel.
        /// </summary>
        private List<Task> _taskList = new List<Task>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of task to cancel.
        /// </summary>
        public List<Task> Tasks { get { return _taskList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCancelRequest"/> class.
        /// </summary>
        public TaskCancelRequest()
            : base(MessageType.TaskCancelRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCancelRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TaskCancelRequest(IConverterStream converterStream)
            : base(MessageType.TaskCancelRequest, converterStream)
        {
        }
    }
}
