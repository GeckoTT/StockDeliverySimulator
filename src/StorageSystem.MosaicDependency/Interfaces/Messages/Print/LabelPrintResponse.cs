using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Print
{
    /// <summary>
    /// Class which implements the LabelPrintResponse Mosaic message.
    /// This request is used to response to the label printing request.
    /// </summary>
    public class LabelPrintResponse : MosaicMessage
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
        /// Gets or sets the flag whether to print a label.
        /// </summary>
        public bool PrintLabel { get; set; }

        /// <summary>
        /// Arbitrary label content to print.
        /// </summary>
        public string LabelContent { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelPrintResponse"/> class.
        /// </summary>
        public LabelPrintResponse()
            : base(MessageType.LabelPrintResponse)
        {
            this.SourceName = string.Empty;
            this.OrderNumber = string.Empty;
            this.ArticleCode = string.Empty;
            this.LabelId = string.Empty;
            this.TemplateId = string.Empty;
            this.LabelContent = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelPrintResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public LabelPrintResponse(IConverterStream converterStream)
            : base(MessageType.LabelPrintResponse, converterStream)
        {
            this.SourceName = string.Empty;
            this.OrderNumber = string.Empty;
            this.ArticleCode = string.Empty;
            this.LabelId = string.Empty;
            this.TemplateId = string.Empty;
            this.LabelContent = string.Empty;
        }
    }
}
