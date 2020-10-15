using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.ArticleInformation
{
    public class ArticleInfoResponse : MosaicMessage
    {
        #region Properties
        public Article[] Articles { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new <see cref="ArticleInfoResponse"/> instance.
        /// </summary>
        public ArticleInfoResponse() : base(MessageType.ArticleInformationResponse)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ArticleInfoResponse"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ArticleInfoResponse(IConverterStream converterStream) : base(MessageType.ArticleInformationResponse, converterStream)
        {
        }
    }
}
