using System.Collections.Generic;
using CareFusion.Mosaic.Interfaces.Converters;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Stock;

namespace CareFusion.Mosaic.Interfaces.Messages.Stock
{
    /// <summary>
    /// Class which implements the ArticleMasterSetRequest Mosaic message.
    /// This request is used to define the master article set for Mosaic.
    /// </summary>
    public class ArticleMasterSetRequest : MosaicMessage
    {
        #region Members

        /// <summary>
        /// List of defined PIS articles.
        /// </summary>
        private List<PISArticle> _pisArticleList = new List<PISArticle>();

        /// <summary>
        /// List of Trees of PIS articles according to the requested packs.
        /// </summary>
        private readonly List<ArticleTree<PISArticle>> _articleTrees = new List<ArticleTree<PISArticle>>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of articles.
        /// </summary>
        public List<PISArticle> PISArticles { get { return _pisArticleList; } }

        /// <summary>
        /// Gets the list of articles as a tree as provided by PIS.
        /// </summary>
        public List<ArticleTree<PISArticle>> ArticleTrees { get { return _articleTrees; } }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetRequest"/> class.
        /// </summary>
        public ArticleMasterSetRequest()
            : base(MessageType.ArticleMasterSetRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMasterSetRequest"/> class.
        /// </summary>
        /// <param name="converterStream">The converter stream which created the request.</param>
        public ArticleMasterSetRequest(IConverterStream converterStream)
            : base(MessageType.ArticleMasterSetRequest, converterStream)
        {
        }
    }
}
