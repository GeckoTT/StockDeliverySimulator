using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the ArticleInfoRequest Mosaic message.
    /// This request is used to request the detailed information for an article.
    /// </summary>
    public class ArticleInfoRequest : MosaicMessage
    {
        #region Properties

        /// <summary>
        /// Defines the article code to get information for.
        /// </summary>
        public string ArticleCode { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleInfoRequest"/> class.
        /// </summary>
        public ArticleInfoRequest()
            : base(MessageType.ArticleInfoRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleInfoRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ArticleInfoRequest(IConverterStream converterStream)
            : base(MessageType.ArticleInfoRequest, converterStream)
        {
        }
    }
}
