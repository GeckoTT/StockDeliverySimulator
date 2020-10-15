using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Configuration;
using System.Collections.Generic;

namespace CareFusion.Mosaic.Interfaces.Messages.Configuration
{
    /// <summary>
    /// Class which implements the InputConfigurationMessage Mosaic message.
    /// </summary>
    public class InputConfigurationMessage : MosaicMessage
    {
        #region Members

        /// <summary>
        /// List of configured input sources.
        /// </summary>
        private List<InputSource> _inputSources = new List<InputSource>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of configured input sources.
        /// </summary>
        public List<InputSource> InputSources { get { return _inputSources; } }

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="InputConfigurationMessage"/> class.
        /// </summary>
        public InputConfigurationMessage()
            : base(MessageType.InputConfigurationMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputConfigurationMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public InputConfigurationMessage(IConverterStream converterStream)
            : base(MessageType.InputConfigurationMessage, converterStream)
        {
        }
    }
}
