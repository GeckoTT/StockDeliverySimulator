using System.Data;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Articles
{
    /// <summary>
    /// Class which represents an gui article which is stored in Mosaic.
    /// </summary>
    public class GuiArticle : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the article.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the article.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the system internal article code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the type of the article.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the unit of the article.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this article requires fridge storage.
        /// </summary>
        public bool IsFridge { get; set; }

        /// <summary>
        /// Gets or sets the largest depth of this article.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the largest height of this article.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the largest width of this article.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the pack count for this article.
        /// </summary>
        public int PackCount { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier of this article.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the tenant description of this article.
        /// </summary>
        public string TenantDescription { get; set; }

        /// <summary>
        /// Gets or sets the stock location identifier of this article.
        /// </summary>
        public string StockLocationID { get; set; }

        /// <summary>
        /// Gets or sets the stock location description of this article.
        /// </summary>
        public string StockLocationDescription { get; set; }
                
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
                    "ID", "Name", "Code", "Type", 
                    "Unit", "IsFridge", "Depth", "Height",
                    "Width", "PackCount",
                    "TenantID", "TenantDescription", 
                    "StockLocationID", "StockLocationDescription"
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
                    this.Name,
                    this.Code,                    
                    this.Type,
                    this.Unit,
                    this.IsFridge,
                    this.Depth,
                    this.Height,
                    this.Width,
                    this.PackCount,
                    this.TenantID,
                    this.TenantDescription,
                    this.StockLocationID,
                    this.StockLocationDescription
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
                return new string[] { "ID" };
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
                return new object[] { this.ID };
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
        /// Initializes a new instance of the <see cref="GuiArticle"/> class.
        /// </summary>
        public GuiArticle()
        {
            this.ID = string.Empty;
            this.Code = string.Empty;
            this.Name = string.Empty;
            this.Type = string.Empty;
            this.Unit = string.Empty;
            this.TenantID = string.Empty;
            this.TenantDescription = string.Empty;
            this.StockLocationID = string.Empty;
            this.StockLocationDescription = string.Empty;
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (string)dataRow["ID"];
            this.Code = (string)dataRow["Code"];
            this.Name = (string)dataRow["Name"];      
            this.Type = (string)dataRow["Type"];
            this.Unit = (string)dataRow["Unit"];
            this.IsFridge = (bool)dataRow["IsFridge"];
            this.Depth = (int)dataRow["Depth"];
            this.Height = (int)dataRow["Height"];
            this.Width = (int)dataRow["Width"];
            this.PackCount = (int)dataRow["PackCount"];
            this.TenantID = (string)dataRow["TenantID"];
            this.TenantDescription = (string)dataRow["TenantDescription"];
            this.StockLocationID = (string)dataRow["StockLocationID"];
            this.StockLocationDescription = (string)dataRow["StockLocationDescription"];
        }
    }
}
