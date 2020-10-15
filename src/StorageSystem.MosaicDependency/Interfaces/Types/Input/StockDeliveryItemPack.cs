using CareFusion.Mosaic.Interfaces.Types.Database;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using System;
using System.Data;

namespace CareFusion.Mosaic.Interfaces.Types.Input
{
   /// <summary>
    /// Class which represents a pack which is assigned to an order item of a stock delivery for a storage system.
    /// </summary>
    public class StockDeliveryItemPack : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the pack.
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the according stock delivery item.
        /// </summary>
        public int StockDeliveryItemID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the according stock delivery.
        /// </summary>
        public int StockDeliveryID { get; set; }

        /// <summary>
        /// Gets or sets the batch number of the pack.
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of the pack.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the optional external id of this pack.
        /// </summary>
        public string ExternalID { get; set; }

        /// <summary>
        /// Gets or sets the is in fridge flag of this pack.
        /// </summary>
        public bool IsInFridge { get; set; }

        /// <summary>
        /// Gets or sets the shape of this pack.
        /// </summary>
        public PackShape Shape { get; set; }

        /// <summary>
        /// Gets or sets the sub item quantity of this pack.
        /// </summary>
        public int SubItemQuantity { get; set; }

        /// <summary>
        /// Gets or sets the scan code of this pack.
        /// </summary>
        public string ScanCode { get; set; }

        /// <summary>
        /// Gets or sets the stock in date of this pack.
        /// </summary>
        public DateTime StockInDate { get; set; }

        /// <summary>
        /// Gets or sets the depth of this pack in mm.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the height of this pack in mm.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the width of this pack in mm.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier of this pack.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the tenant description of this pack.
        /// </summary>
        public string TenantDescription { get; set; }

        /// <summary>
        /// Gets or sets the stock location identifier of this pack.
        /// </summary>
        public string StockLocationID { get; set; }

        /// <summary>
        /// Gets or sets the stock location description of this pack.
        /// </summary>
        public string StockLocationDescription { get; set; }

        /// <summary>
        /// Gets or sets the machine location of this pack.
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
                    "ID", "StockDeliveryItemID", "StockDeliveryID", "BatchNumber",
                    "ExpiryDate", "ExternalID", "IsInFridge", "Shape", "SubItemQuantity",
                    "ScanCode", "StockInDate", "Depth", "Height", "Width",
                    "TenantID", "TenantDescription", "StockLocationID", "StockLocationDescription", "MachineLocation"
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
                    this.StockDeliveryItemID,
                    this.StockDeliveryID,
                    this.BatchNumber,
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
                    this.TenantID,
                    this.TenantDescription,
                    this.StockLocationID,
                    this.StockLocationDescription,
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
                return new string[] { "ID", "StockDeliveryItemID", "StockDeliveryID", "TenantID" };
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
                return new object[] { this.ID, this.StockDeliveryItemID, this.StockDeliveryID, this.TenantID };
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
        /// Initializes a new instance of the <see cref="StockDeliveryItem"/> class.
        /// </summary>
        public StockDeliveryItemPack()
        {
            this.TenantID = string.Empty;
            this.BatchNumber = string.Empty;
            this.ExternalID = string.Empty;
            this.ScanCode = string.Empty;
            this.ExpiryDate = DateTime.MinValue;
            this.Shape = PackShape.Cuboid;
            this.StockInDate = DateTime.MinValue;
            this.TenantID = string.Empty;
            this.TenantDescription = string.Empty;
            this.StockLocationID = string.Empty;
            this.StockLocationDescription = string.Empty;
            this.MachineLocation = string.Empty;
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (long)dataRow["ID"];
            this.StockDeliveryItemID = (int)dataRow["StockDeliveryItemID"];
            this.StockDeliveryID = (int)dataRow["StockDeliveryID"];
            this.TenantID = (string)dataRow["TenantID"];
            this.BatchNumber = (string)dataRow["BatchNumber"];
            this.ExpiryDate = (DateTime)dataRow["ExpiryDate"];
            this.ExternalID = (string)dataRow["ExternalID"];
            this.IsInFridge = (bool)dataRow["IsInFridge"];
            this.Shape = (PackShape)Enum.Parse(typeof(PackShape), (string)dataRow["Shape"]);
            this.SubItemQuantity = (int)dataRow["SubItemQuantity"];
            this.ScanCode = (string)dataRow["ScanCode"];
            this.StockInDate = (DateTime)dataRow["StockInDate"];
            this.Depth = (int)dataRow["Depth"];
            this.Width = (int)dataRow["Width"];
            this.Height = (int)dataRow["Height"];
            this.TenantID = (string)dataRow["TenantID"];
            this.TenantDescription = (string)dataRow["TenantDescription"];
            this.StockLocationID = (string)dataRow["StockLocationID"];
            this.StockLocationDescription = (string)dataRow["StockLocationDescription"];
            this.MachineLocation = (string)dataRow["MachineLocation"];
        }
    }

    
}
