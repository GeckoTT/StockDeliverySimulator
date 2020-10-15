using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Status
{
    /// <summary>
    /// Class which implements the StatusRequest Mosaic message.
    /// This request is used to request the status of a Rowa component.
    /// </summary>
    public class StatusRequest : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to include component details in the answer.
        /// </summary>
        public bool IncludeDetails
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusRequest"/> class.
        /// </summary>
        public StatusRequest()
            : base(MessageType.StatusRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public StatusRequest(IConverterStream converterStream)
            : base(MessageType.StatusRequest, converterStream)
        {
        }
    }
}
