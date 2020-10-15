using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Status
{
    /// <summary>
    /// Class which implements the StatusMessage Mosaic message.
    /// This message is used to asynchronously notify about status changes.
    /// </summary>
    public class StatusMessage : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the root component of this StatusResponse.  
        /// </summary>
        public StatusComponent Component { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusMessage"/> class.
        /// </summary>
        public StatusMessage()
            : base(MessageType.StatusMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the message.</param>
        public StatusMessage(IConverterStream converterStream)
            : base(MessageType.StatusMessage, converterStream)
        {
        }

        #endregion
    }
}
