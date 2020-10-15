using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemStatusResponse Mosaic message.
    /// This response is used to answer to the according TransportSystemStatusRequest.
    /// </summary>
    public class TransportSystemStatusResponse : MosaicMessage
    {
        #region Members

        /// <summary>
        /// List of output details.
        /// </summary>
        private List<TransportSystemOutputDetail> _outputDetailList = new List<TransportSystemOutputDetail>();

        #endregion

        #region Properties

        /// <summary>
        /// The transfer point to get the information for.
        /// </summary>
        public string TransferPoint { get; set; }

        /// <summary>
        /// The identifier of the currently selected output (might be empty).
        /// </summary>
        public string SelectedOutput { get; set; }

        /// <summary>
        /// Flag whether this transfer point is operational.
        /// </summary>
        public bool IsOperational { get; set; }

        /// <summary>
        /// Flag whether this transfer point is ready for dispensing of packs.
        /// </summary>
        public bool IsReady { get; set; }

        /// <summary>
        /// The output which is currently processed by the underlying transport system of this transfer point.
        /// </summary>
        public string BusyForOutput { get; set; }

        /// <summary>
        /// Returns the list of output details.
        /// </summary>
        public List<TransportSystemOutputDetail> OutputDetails { get { return _outputDetailList; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemStatusResponse"/> class.
        /// </summary>
        public TransportSystemStatusResponse()
            : base(MessageType.TransportSystemStatusResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemStatusResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemStatusResponse(IConverterStream converterStream)
            : base(MessageType.TransportSystemStatusResponse, converterStream)
        {
        }
    }
}
