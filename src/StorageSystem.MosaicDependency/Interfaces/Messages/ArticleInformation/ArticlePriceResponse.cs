using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.ArticleInformation
{
    /// <summary>
    /// The Mosaic internal representation of a WWKS2 ArticlePriceResponse.
    /// </summary>
    class ArticlePriceResponse : MosaicMessage
    {
        #region Properties

        public string Currency { get; set; }

        public Article[] Articles { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new <see cref="ArticlePriceRequest"/> instance.
        /// </summary>
        public ArticlePriceResponse() : base(MessageType.ArticlePriceResponse)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ArticlePriceRequest"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ArticlePriceResponse(IConverterStream converterStream) : base(MessageType.ArticlePriceResponse, converterStream)
        {
        }
    }
}
