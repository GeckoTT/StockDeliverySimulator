using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the ArticleMasterSetResponse Mosaic message.
    /// This response is used as answer to the ArticleMasterSetRequest.
    /// </summary>
    public class ArticleMasterSetResponse : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the result value itself.
        /// </summary>
        public bool SetResult { get; set; }

        /// <summary>
        /// Gets or sets the set result text.
        /// </summary>
        public string SetResultText { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetResponse"/> class.
        /// </summary>
        public ArticleMasterSetResponse()
            : base(MessageType.ArticleMasterSetResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetResponse"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ArticleMasterSetResponse(IConverterStream converterStream)
            : base(MessageType.ArticleMasterSetResponse, converterStream)
        {
        }
    }
}
