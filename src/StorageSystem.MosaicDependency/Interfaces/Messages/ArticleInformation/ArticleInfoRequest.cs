using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.ArticleInformation
{
    /// <summary>
    /// The Mosaic internal representation of a WWKS2 ArticleInfoRequest.
    /// </summary>
    public class ArticleInfoRequest : MosaicMessage
    {
        #region Properties

        public Article[] Articles { get; set; }

        public bool IncludeCrossSellingArticles { get; set; }

        public bool IncludeAlternativeArticles { get; set; }

        public bool IncludeAlternativePackSizeArticles { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new <see cref="ArticleInfoRequest"/> instance.
        /// </summary>
        public ArticleInfoRequest() : base(MessageType.ArticleInformationRequest)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ArticleInfoRequest"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ArticleInfoRequest(IConverterStream converterStream) : base(MessageType.ArticleInformationRequest, converterStream)
        {
        }
    }
}
