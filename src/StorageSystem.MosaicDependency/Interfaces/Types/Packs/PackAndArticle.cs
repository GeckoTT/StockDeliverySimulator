using System;
using System.Data;

namespace CareFusion.Mosaic.Interfaces.Types.Packs
{
    /// <summary>
    /// Class which represents a pack-article-combination which is stored in a storage system.
    /// </summary>
    public class PackAndArticle : RobotPack
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the article.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the dosage form of the article.
        /// </summary>
        public string DosageForm { get; set; }

        /// <summary>
        /// Gets or sets the packaging unit of the article.
        /// </summary>
        public string PackagingUnit { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this article requires fridge storage.
        /// </summary>
        public bool RequiresFridge { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of sub items for this article.
        /// </summary>
        public int MaxSubItemQuantity { get; set; }

        /// <summary>
        /// Gets or sets the stock location description for this article.
        /// </summary>
        public string StockLocationDescription { get; set; }

        /// <summary>
        /// Gets or sets the tenant description for this article.
        /// </summary>
        public string TenantDescription { get; set; }

        /// <summary>
        /// Gets or sets the number of packs for this article.
        /// </summary>
        public long PackCount { get; set; }

        #endregion

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public override void Load(DataRow dataRow, DB.Database database)
        {
            base.Load(dataRow, database);

            this.Name = (string)dataRow["Name"];
            this.DosageForm = (string)dataRow["DosageForm"];
            this.PackagingUnit = (string)dataRow["PackagingUnit"];
            this.RequiresFridge = (bool)dataRow["RequiresFridge"];
            this.MaxSubItemQuantity = (int)dataRow["MaxSubItemQuantity"];

            var tmp = dataRow["StockLocationDescription"];
            this.StockLocationDescription = (tmp == DBNull.Value) ? string.Empty : (string)tmp;

            tmp = dataRow["TenantDescription"];
            this.TenantDescription = (tmp == DBNull.Value) ? string.Empty : (string)tmp;

            if (dataRow.Table.Columns.Contains("NumRows"))
            {
                this.PackCount = (long)dataRow["NumRows"];
            }
        }
    }
}
