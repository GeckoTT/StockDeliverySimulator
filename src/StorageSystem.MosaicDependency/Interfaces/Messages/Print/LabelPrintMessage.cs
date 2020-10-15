using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Print
{
    /// <summary>
    /// Class which implements the LabelPrintMessage Mosaic message.
    /// This request is used to notify about the result of a label printing operation.
    /// </summary>
    public class LabelPrintMessage : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets an optional descriptive name of the request sender.
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// Gets or sets the order number of the stock output order which raised the output of the pack.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the article code of the pack.
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the label.
        /// </summary>
        public string LabelId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the label template.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the flag whether the label was printed.
        /// </summary>
        public bool WasPrinted { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelPrintMessage"/> class.
        /// </summary>
        public LabelPrintMessage()
            : base(MessageType.LabelPrintMessage)
        {
            this.SourceName = string.Empty;
            this.OrderNumber = string.Empty;
            this.ArticleCode = string.Empty;
            this.LabelId = string.Empty;
            this.TemplateId = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelPrintMessage"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public LabelPrintMessage(IConverterStream converterStream)
            : base(MessageType.LabelPrintMessage, converterStream)
        {
            this.SourceName = string.Empty;
            this.OrderNumber = string.Empty;
            this.ArticleCode = string.Empty;
            this.LabelId = string.Empty;
            this.TemplateId = string.Empty;
        }

    }
}
