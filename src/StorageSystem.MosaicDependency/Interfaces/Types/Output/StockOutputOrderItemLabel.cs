using System.Data;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Output
{
    /// <summary>
    /// Class which represents a label which is related to an order item of a stock output order for a storage system.
    /// </summary>
    public class StockOutputOrderItemLabel : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the label.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of related stock output order item.
        /// </summary>
        public int StockOutputOrderItemID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of related stock output order item.
        /// </summary>
        public int StockOutputOrderID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the storage system which stores the pack.
        /// </summary>
        public int ComponentID { get; set; }

        /// <summary>
        /// Gets or sets the tenant code of the stock output order.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets label template identifier.
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// Gets or sets label content.
        /// </summary>
        public string Content { get; set; }
        
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
                    "ID", "StockOutputOrderItemID", "StockOutputOrderID", "ComponentID", "TenantID", "TemplateID", "Content"
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
                    this.StockOutputOrderItemID,
                    this.StockOutputOrderID,
                    this.ComponentID,
                    this.TenantID,
                    this.TemplateID,
                    this.Content
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
                return new string[] { "ID", "StockOutputOrderItemID", "StockOutputOrderID", "ComponentID", "TenantID" }; 
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
                return new object[] { this.ID, this.StockOutputOrderItemID, this.StockOutputOrderID, this.ComponentID, this.TenantID }; 
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies
        {
            get { return null; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOutputOrderItemLabel"/> class.
        /// </summary>
        public StockOutputOrderItemLabel()
        {
            this.TenantID = string.Empty;
            this.TemplateID = string.Empty;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.StockOutputOrderItemID = (int)dataRow["StockOutputOrderItemID"];
            this.StockOutputOrderID = (int)dataRow["StockOutputOrderID"];
            this.ComponentID = (int)dataRow["ComponentID"];
            this.TenantID = (string)dataRow["TenantID"];
            this.TemplateID = (string)dataRow["TemplateID"];
            this.Content = (string)dataRow["Content"];
        }
    }
}
