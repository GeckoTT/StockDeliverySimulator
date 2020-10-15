using CareFusion.Mosaic.Converters.Wwks2.Types;
using CareFusion.Mosaic.Interfaces.Converters;

namespace CareFusion.Mosaic.Interfaces.Messages.Sales
{
    public class ArticleSelectedMessage : MosaicMessage
    {
        #region Properties
        public Article Article { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new <see cref="ArticleSelectedMessage"/> instance.
        /// </summary>
        public ArticleSelectedMessage() : base(MessageType.ArticleSelectedMessage)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ArticleSelectedMessage"/> instance.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ArticleSelectedMessage(IConverterStream converterStream) : base(MessageType.ArticleSelectedMessage, converterStream)
        {
        }
    }
}