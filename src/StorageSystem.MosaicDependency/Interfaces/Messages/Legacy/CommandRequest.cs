using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Legacy
{
    /// <summary>
    /// Class which implements the legacy Command Mosaic message.
    /// </summary>
    public class CommandRequest : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the command of the request.
        /// </summary>
        public string Command { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRequest"/> class.
        /// </summary>
        public CommandRequest()
            : base(MessageType.CommandRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public CommandRequest(IConverterStream converterStream)
            : base(MessageType.CommandRequest, converterStream)
        {
        }
    }
}
