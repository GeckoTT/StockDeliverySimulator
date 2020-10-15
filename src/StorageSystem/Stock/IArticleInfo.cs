using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareFusion.Lib.StorageSystem.Stock
{
    /// <summary>
    /// Interface which defines the methods and properties of a storage system article.
    /// </summary>
    public interface IArticleInfo
    {
        #region Properties

        /// <summary>
        /// Gets the unique identifier of the article (e.g. PZN or EAN).
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the Depth of the article.
        /// </summary>
        int Depth { get; }

        /// <summary>
        /// Gets the With of the article.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the Heigth of the article.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets the Weight of the article.
        /// </summary>
        int Weight { get; }

        /// <summary>
        /// Sets the article related information.
        /// These information are required by the storage system to ensure the correct behaviour of the
        /// output processes later on. Additionally these information are shown in the UI of the storage system.
        /// </summary>
        /// <param name="articleId">Unique identifier of the article.</param>
        /// <param name="articleName">Name of the article.</param>
        /// <param name="dosageForm">Dosage form of the article.</param>
        /// <param name="packagingUnit">Packaging unit of the article.</param>
        /// <param name="maxSubItemQuantity">
        /// Optional maximum number of elements (e.g. pills or ampoules) which are in one pack of this article.
        /// A value of 0 means "no maximum defined".
        /// </param>
        /// <param name="virtualArticleId">Optionnal: Unique identifier of the virtual article.</param>
        /// <param name="virtualArticleName">Optionnal: Name of the virtual article.</param>
        /// <param name="requiresFridge">Optionnal: if the article needs to be stored in a fridge.</param>
        /// <param name="serialNumberSinceExpiryDate">Optionnal: .</param>
        /// <param name="productCodeList">Optionnal: Additional product code.</param>
        void SetArticleInformation(string articleId,
                                   string articleName,
                                   string dosageForm,
                                   string packagingUnit,
                                   uint maxSubItemQuantity = 0,
                                   string virtualArticleId = null,
                                   string virtualArticleName = null,
                                   bool requiresFridge = false,
                                   Nullable<DateTime> serialNumberSinceExpiryDate = null,
                                   List<string> productCodeList = null);
        #endregion
    }
}
