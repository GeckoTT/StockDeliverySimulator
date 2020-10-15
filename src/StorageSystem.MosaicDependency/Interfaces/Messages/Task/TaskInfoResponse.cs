using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Task
{
    /// <summary>
    /// Class which implements the TaskInfoResponse Mosaic message.
    /// This response is used to answer to an according TaskInfoRequest.
    /// </summary>
    public class TaskInfoResponse : MosaicMessage
    {
        #region Members

        /// <summary>
        /// Holds the list of tasks that have been queried.
        /// </summary>
        private List<Task> _taskList = new List<Task>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of tasks that have been queried.
        /// </summary>
        public List<Task> Tasks { get { return _taskList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInfoResponse"/> class.
        /// </summary>
        public TaskInfoResponse()
            : base(MessageType.TaskInfoResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInfoResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TaskInfoResponse(IConverterStream converterStream)
            : base(MessageType.TaskInfoResponse, converterStream)
        {
        }
    }
}
