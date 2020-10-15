using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Print
{
    /// <summary>
    /// Class which implements the LabelPrintRequest Mosaic message.
    /// This request is used to request the label printing information for a pack.
    /// </summary>
    public class LabelPrintRequest : MosaicMessage
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

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelPrintRequest"/> class.
        /// </summary>
        public LabelPrintRequest()
            : base(MessageType.LabelPrintRequest)
        {
            this.SourceName = string.Empty;
            this.OrderNumber = string.Empty;
            this.ArticleCode = string.Empty;
            this.LabelId = string.Empty;
            this.TemplateId = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelPrintRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public LabelPrintRequest(IConverterStream converterStream)
            : base(MessageType.LabelPrintRequest, converterStream)
        {
            this.SourceName = string.Empty;
            this.OrderNumber = string.Empty;
            this.ArticleCode = string.Empty;
            this.LabelId = string.Empty;
            this.TemplateId = string.Empty;
        }
    }
}
