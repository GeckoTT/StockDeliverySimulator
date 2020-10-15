using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Status
{
    /// <summary>
    /// Class which implements the StatusResponse Mosaic message.
    /// This response is used to answer to the according status request.
    /// </summary>
    public class StatusResponse : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the root component of this StatusResponse.  
        /// </summary>
        public StatusComponent Component { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusResponse"/> class.
        /// </summary>
        public StatusResponse()
            : base(MessageType.StatusResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the response.</param>
        public StatusResponse(IConverterStream converterStream)
            : base(MessageType.StatusResponse, converterStream)
        {
        }

        #endregion
    }
}
