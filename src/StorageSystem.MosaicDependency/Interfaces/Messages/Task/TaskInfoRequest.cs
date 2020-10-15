using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Task
{
    /// <summary>
    /// Class which implements the TaskInfoRequest Mosaic message.
    /// This request is used to query detailed information about running Mosaic tasks.
    /// </summary>
    public class TaskInfoRequest : MosaicMessage
    {
        #region Members

        /// <summary>
        /// Holds the list of tasks to query information for.
        /// </summary>
        private List<Task> _taskList = new List<Task>();

        #endregion

        #region Properties

        /// <summary>
        /// Flag whether to include the task details.
        /// </summary>
        public bool IncludeTaskDetails { get; set; }

        /// <summary>
        /// Gets the list of tasks to query information for.
        /// </summary>
        public List<Task> Tasks { get { return _taskList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInfoRequest"/> class.
        /// </summary>
        public TaskInfoRequest()
            : base(MessageType.TaskInfoRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInfoRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TaskInfoRequest(IConverterStream converterStream)
            : base(MessageType.TaskInfoRequest, converterStream)
        {
        }
    }
}
