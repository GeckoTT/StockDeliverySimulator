using CareFusion.Mosaic.Interfaces.Types.Database;
using System.Data;

namespace CareFusion.Mosaic.Interfaces.Types.Stock
{
    /// <summary>
    /// Class which represents a Mosaic stock location database type.
    /// </summary>
    public class StockLocation : IDatabaseType
    {
        #region Properties

       /// <summary>
        /// Gets or sets the database identifier of the stock location.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the component identifier of the stock location.
        /// </summary>
        public int ComponentID { get; set; }

        /// <summary>
        /// Gets or sets the description of the stock location.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the total capacity of the stock location.
        /// </summary>
        public int TotalCapacity { get; set; }

        /// <summary>
        /// Gets or sets the currently used capacity of the stock location.
        /// </summary>
        public int UsedCapacity { get; set; }

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
                    "ID", "ComponentID", "Description", "TotalCapacity", "UsedCapacity"
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
                    this.ComponentID,
                    this.Description,
                    this.TotalCapacity,
                    this.UsedCapacity
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
                return new string[] { "ID", "ComponentID" };
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
                return new object[] { this.ID, this.ComponentID };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies { get { return null; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockLocation"/> class.
        /// </summary>
        public StockLocation()
        {
            this.ID = string.Empty;
            this.Description = string.Empty;
            this.TotalCapacity = 0;
            this.UsedCapacity = 0;
        }

        /// <summary>
        /// Loads the content of the data type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the data type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (string)dataRow["ID"];
            this.ComponentID = (int)dataRow["ComponentID"];
            this.Description = (string)dataRow["Description"];
            this.TotalCapacity = (int)dataRow["TotalCapacity"];
            this.UsedCapacity = (int)dataRow["UsedCapacity"];
        }
    }

}
