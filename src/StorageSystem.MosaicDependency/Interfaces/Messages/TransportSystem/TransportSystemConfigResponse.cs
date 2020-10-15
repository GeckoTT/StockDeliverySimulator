using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemConfigResponse Mosaic message.
    /// This response is used to answer to the according TransportSystemConfigRequest.
    /// </summary>
    public class TransportSystemConfigResponse : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// The transfer point to get the information for.
        /// </summary>
        public string TransferPoint { get; set; }

        /// <summary>
        /// Length of the transport container in millimeter.
        /// </summary>
        public int ContainerLength { get; set; }

        /// <summary>
        /// Diameter of the transport container in millimeter.
        /// </summary>
        public int ContainerDiameter { get; set; }

        /// <summary>
        /// Width of the transport container in millimeter.
        /// </summary>
        public int ContainerWidth { get; set; }

        /// <summary>
        /// Height of the transport container in millimeter.
        /// </summary>
        public int ContainerHeight { get; set; }

        /// <summary>
        /// Type of the transport container.
        /// </summary>
        public string ContainerType { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemConfigResponse"/> class.
        /// </summary>
        public TransportSystemConfigResponse()
            : base(MessageType.TransportSystemConfigResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemConfigResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemConfigResponse(IConverterStream converterStream)
            : base(MessageType.TransportSystemConfigResponse, converterStream)
        {
        }
    }
}
