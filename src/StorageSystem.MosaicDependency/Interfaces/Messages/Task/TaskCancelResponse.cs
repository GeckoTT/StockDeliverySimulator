using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Task
{
    /// <summary>
    /// Class which implements the TaskCancelResponse Mosaic message.
    /// This response is used as answer for a TaskCancelRequest.
    /// </summary>
    public class TaskCancelResponse : MosaicMessage
    {
        #region Members

        /// <summary>
        /// Holds the list of tasks that have been requested to be cancelled.
        /// </summary>
        private List<Task> _taskList = new List<Task>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of tasks that have been requested to be cancelled.
        /// </summary>
        public List<Task> Tasks { get { return _taskList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCancelResponse"/> class.
        /// </summary>
        public TaskCancelResponse()
            : base(MessageType.TaskCancelResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCancelResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TaskCancelResponse(IConverterStream converterStream)
            : base(MessageType.TaskCancelResponse, converterStream)
        {
        }
    }
}
