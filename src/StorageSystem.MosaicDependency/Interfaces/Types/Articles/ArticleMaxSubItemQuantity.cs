using CareFusion.Mosaic.Interfaces.Types.Database;
using System.Data;

namespace CareFusion.Mosaic.Interfaces.Types.Articles
{
    /// <summary>
    /// Class which represents an article max sub item quantity.
    /// </summary>
    public class ArticleMaxSubItemQuantity : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the article.
        /// </summary>
        public string ID { get; set; }

         /// <summary>
        /// Gets or sets the tenant identifier of the article.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of sub items for this article.
        /// </summary>
        public int MaxSubItemQuantity { get; set; }

        /// <summary>
        /// Gets an array of the property names of this object.
        /// These names are required to serialize this object to the database.
        /// </summary>
        public string[] PropertyNames
        {
            get
            {
                return new string[] 
                {
                    "ID", "TenantID", "MaxSubItemQuantity"
                };
            }
        }

        /// <summary>
        /// Gets an array of the raw property values of this object.
        /// These values are required to serialize this object to the database.
        /// </summary>
        public object[] PropertyValues
        {
            get
            {
                return new object[] 
                {
                    this.ID,
                    this.TenantID,
                    this.MaxSubItemQuantity
                };
            }
        }

        /// <summary>
        /// Gets an array of the property names which define the unique key of this object.
        /// These names are required to delete this object from the database.
        /// </summary>
        public string[] KeyPropertyNames
        {
            get
            {
                return new string[] { "ID", "TenantID" };
            }
        }

        /// <summary>
        /// Gets an array of the raw property values which define the unique key of this object.
        /// These names are required to delete this object from the database.
        /// </summary>
        public object[] KeyPropertyValues
        {
            get
            {
                return new object[] { this.ID, this.TenantID };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies
        {
            // TODO: return article attributes.
            get { return null; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleMaxSubItemQuantity"/> class.
        /// </summary>
        public ArticleMaxSubItemQuantity()
        {
            this.ID = string.Empty;
            this.TenantID = string.Empty;            
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (string)dataRow["ID"];
            this.TenantID = (string)dataRow["TenantID"];
            this.MaxSubItemQuantity = (int)dataRow["MaxSubItemQuantity"];         
        }
    }
}
