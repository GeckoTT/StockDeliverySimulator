using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareFusion.Lib.StorageSystem.Stock
{
    /// <summary>
    /// Interface which defines the methods and properties of an Article Information request.
    /// </summary>
    public interface IStorageSystemArticleInfoRequest
    {
        #region Properties
        IArticleInfo[] ArticleList { get; }
        #endregion

        /// <summary>
        /// Finishes the Article information request by sending the according answer to
        /// the storage system. This method has to be called after the list of
        /// requested article was updated.
        /// </summary>
        void Finish();
    }
}
