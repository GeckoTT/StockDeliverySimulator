using System;
using System.Data;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Packs
{
    /// <summary>
    /// Class which represents a pack which is stored in a storage system.
    /// </summary>
    public class RobotPack : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the pack.
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the according article.
        /// </summary>
        public int RobotArticleID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the storage system which stores the pack.
        /// </summary>
        public int ComponentID { get; set; }

        /// <summary>
        /// Gets or sets the it system internal article code.
        /// </summary>
#warning remove that!!!
        public string PISArticleCode { get; set; }

        /// <summary>
        /// Gets or sets the robot used article code.
        /// </summary>
        public string RobotArticleCode { get; set; }

        /// <summary>
        /// Gets or sets the batch number which was used during pack input.
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets the delivery number which was used during pack input.
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// Gets or sets the ExpiryDate of the pack.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the external identifier which was assigned during pack input.
        /// </summary>
        public string ExternalID { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this pack is in fridge.
        /// </summary>
        public bool IsInFridge { get; set; }

        /// <summary>
        /// Gets or sets the shape of the pack.
        /// </summary>
        public PackShape Shape { get; set; }

        /// <summary>
        /// Gets or sets the amount of pills in the pack.
        /// </summary>
        public int SubItemQuantity { get; set; }

        /// <summary>
        /// Gets or sets the raw scancode of the pack.
        /// </summary>
        public string ScanCode { get; set; }

        /// <summary>
        /// Gets or sets the date when the pack was input into the storage system.
        /// </summary>
        public DateTime StockInDate { get; set; }

        /// <summary>
        /// Gets or sets the depth of the pack in millimeters.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the height of the pack in millimeters.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the width of the pack in millimeters.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets a flag whether the pack is available for output.
        /// </summary>
        public bool IsAvailable { get; set; }
        
        /// <summary>
        /// Gets or sets a flag whether the pack is blocked -> no output is possible.
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets a flag whether the pack is online -> storage system is generally connected.
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// Gets or sets the stock location identifier of the pack.
        /// </summary>
        public string StockLocationID { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier of the pack.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the machine location of the pack.
        /// </summary>
        public string MachineLocation { get; set; }

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
                    "ID", "RobotArticleID", "ComponentID", "RobotArticleCode", 
                    "BatchNumber", "DeliveryNumber", "ExpiryDate", "ExternalID",
                    "IsInFridge", "Shape", "SubItemQuantity", "ScanCode",
                    "StockInDate", "Depth", "Height", "Width",
                    "IsAvailable", "IsBlocked", "IsOnline", "StockLocationID",
                    "TenantID", "MachineLocation"
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
                    (int)this.ID,
                    this.RobotArticleID,
                    this.ComponentID,
                    this.RobotArticleCode,
                    this.BatchNumber,
                    this.DeliveryNumber,
                    this.ExpiryDate,
                    this.ExternalID,
                    this.IsInFridge,
                    this.Shape.ToString(),
                    this.SubItemQuantity,
                    this.ScanCode,
                    this.StockInDate,
                    this.Depth,
                    this.Height,
                    this.Width,
                    this.IsAvailable,
                    this.IsBlocked,
                    this.IsOnline,
                    this.StockLocationID,
                    this.TenantID,
                    this.MachineLocation
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
                return new string[] { "ID", "RobotArticleID", "ComponentID" };
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
                return new object[] { (int)this.ID, this.RobotArticleID, this.ComponentID };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies
        {
            // TODO: return pack attributes.
            get { return null; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotPack"/> class.
        /// </summary>
        public RobotPack()
        {
            this.IsBlocked = false;
            this.IsOnline = true;
            this.IsAvailable = true;

            this.RobotArticleCode = string.Empty;
            this.BatchNumber = string.Empty;
            this.DeliveryNumber = string.Empty;
            this.ExternalID = string.Empty;
            this.ScanCode = string.Empty;
            this.MachineLocation = string.Empty;
            this.StockLocationID = string.Empty;
            this.TenantID = string.Empty;
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public virtual void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.RobotArticleID = (int)dataRow["RobotArticleID"];
            this.ComponentID = (int)dataRow["ComponentID"];
            this.RobotArticleCode = (string)dataRow["RobotArticleCode"];
            this.BatchNumber = (string)dataRow["BatchNumber"];
            this.DeliveryNumber = (string)dataRow["DeliveryNumber"];
            this.ExpiryDate = (DateTime)dataRow["ExpiryDate"];
            this.ExternalID = (string)dataRow["ExternalID"];
            this.IsInFridge = (bool)dataRow["IsInFridge"];
            this.Shape = (PackShape)Enum.Parse(typeof(PackShape), (string)dataRow["Shape"]);
            this.SubItemQuantity = (int)dataRow["SubItemQuantity"];
            this.ScanCode = (string)dataRow["ScanCode"];
            this.StockInDate = (DateTime)dataRow["StockInDate"];
            this.Depth = (int)dataRow["Depth"];
            this.Height = (int)dataRow["Height"];
            this.Width = (int)dataRow["Width"];
            this.IsAvailable = (bool)dataRow["IsAvailable"];
            this.IsBlocked = (bool)dataRow["IsBlocked"];
            this.IsOnline = (bool)dataRow["IsOnline"];
            this.StockLocationID = (string)dataRow["StockLocationID"];
            this.TenantID = (string)dataRow["TenantID"];
            this.MachineLocation = (string)dataRow["MachineLocation"];
        }
    }
}
