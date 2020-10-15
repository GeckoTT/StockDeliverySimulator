using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages
{
    /// <summary>
    /// Class which defines the base for every kind of Mosaic message.
    /// </summary>
    public class MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the message.
        /// Equally to WWKS 2.0 this identifier is used to group messages which are related to the same process.  
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the message sender.
        /// </summary>
        public int Source { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the message receiver.
        /// </summary>
        public int Destination { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier which is bound to this message.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets custom data which is used only by the converter which created the message.
        /// </summary>
        public object ConverterData { get; set; }

        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        public MessageType Type { get; protected set; }

        /// <summary>
        /// Gets the converter stream instance which created the message.
        /// This might by null if the message was generated inside of Mosaic.
        /// </summary>
        public IConverterStream ConverterStream { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicMessage"/> class.
        /// </summary>
        /// <param name="type">The type of the Mosaic message.</param>
        protected MosaicMessage(MessageType type)
        {
            this.ID = string.Empty;
            this.Type = type;
            this.TenantID = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicMessage"/> class.
        /// </summary>
        /// <param name="type">The type of the Mosaic message.</param>
        /// <param name="converterStream">The converter stream which created the message.</param>
        protected MosaicMessage(MessageType type, IConverterStream converterStream)
        {
            this.ID = string.Empty;
            this.Type = type;
            this.TenantID = string.Empty;
            this.ConverterStream = converterStream;
        }

        /// <summary>
        /// Adopts the Mosaic message header of the specified message.
        /// </summary>
        /// <param name="message">The message to adopt the header from.</param>
        public void AdoptHeader(MosaicMessage message)
        {
            this.ID = message.ID != null ? message.ID : string.Empty;
            this.Source = message.Destination;
            this.Destination = message.Source;
            this.TenantID = message.TenantID;
            this.ConverterData = message.ConverterData;
            this.ConverterStream = message.ConverterStream;
        }

        /// <summary>
        /// Adopts the Mosaic message header of the specified message 
        /// and uses the alternate converter stream and converter data.
        /// </summary>
        /// <param name="message">The message to adopt the header from.</param>
        /// <param name="converterStream">The converter stream to use.</param>
        /// <param name="converterData">The converter data to use.</param>
        public void AdoptHeader(MosaicMessage message, IConverterStream converterStream, object converterData)
        {
            this.ID = message.ID != null ? message.ID : string.Empty;
            this.Source = message.Destination;
            this.Destination = message.Source;
            this.TenantID = message.TenantID;
            this.ConverterData = converterData;
            this.ConverterStream = converterStream;
        }

        /// <summary>
        /// Updates the header of the message with the specified converter stream and converter data.
        /// </summary>
        /// <param name="converterStream">The converter stream to use.</param>
        /// <param name="converterData">The converter data to use.</param>
        public void UpdateHeader(IConverterStream converterStream, object converterData)
        {
            this.ConverterData = converterData;
            this.ConverterStream = converterStream;
        }

        #endregion

    }
}
