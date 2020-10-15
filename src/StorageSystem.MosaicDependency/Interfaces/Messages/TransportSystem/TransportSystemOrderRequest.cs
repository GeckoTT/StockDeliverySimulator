using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.TransportSystem
{
    /// <summary>
    /// Class which implements the TransportSystemOrderRequest Mosaic message.
    /// This request is used to send commands to a transport system hand over point.
    /// </summary>
    public class TransportSystemOrderRequest : MosaicMessage
    {
        #region Members

        /// <summary>
        /// Holds the list of packs according to this command.
        /// </summary>
        private List<TransportSystemPack> _packList = new List<TransportSystemPack>();

        #endregion

        #region Properties

        /// <summary>
        /// The transfer point to get the information for.
        /// </summary>
        public string TransferPoint { get; set; }

        /// <summary>
        /// The identifier of the according output.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// The command to execute.
        /// </summary>
        public TransportSystemCommand Command { get; set; }

        /// <summary>
        /// Gets the list of packs according to this command.
        /// </summary>
        public List<TransportSystemPack> Packs { get { return _packList; } }
        
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemOrderRequest"/> class.
        /// </summary>
        public TransportSystemOrderRequest()
            : base(MessageType.TransportSystemOrderRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSystemOrderRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public TransportSystemOrderRequest(IConverterStream converterStream)
            : base(MessageType.TransportSystemOrderRequest, converterStream)
        {
        }
    }
}
