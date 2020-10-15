using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Packs
{
    /// <summary>
    /// Class which represents a gui pack which is stored in Mosaic.
    /// </summary>
    public class GuiPack : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the pack.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the storage system which stores the pack.
        /// </summary>
        public int ComponentID { get; set; }

        /// <summary>
        /// Gets or sets the it system internal article name.
        /// </summary>
        public string ArticleName { get; set; }

        /// <summary>
        /// Gets or sets the it system internal article code.
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// Gets or sets the batch number which was used during pack input.
        /// </summary>
        public string Batch { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this pack is a special (round) pack.
        /// </summary>
        public bool IsSpecial { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this pack is in fridge.
        /// </summary>
        public bool IsFridge { get; set; }

        /// <summary>
        /// Gets or sets the date when the pack was input into the storage system.
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Gets or sets the ExpiryDate of the pack.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of pills in the pack.
        /// </summary>
        public int SubItemQuantity { get; set; }

        /// <summary>
        /// Gets or sets the raw scancode of the pack.
        /// </summary>
        public string ScanCode { get; set; }

        /// <summary>
        /// Gets or sets the external identifier which was assigned during pack input.
        /// </summary>
        public string ExternalIdCode { get; set; }

        /// <summary>
        /// Gets or sets the delivery number which was used during pack input.
        /// </summary>
        public string DeliveryNumber { get; set; }

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
        /// Gets or sets the storage system name of the pack.
        /// </summary>
        public string StorageSystemName { get; set; }
        
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
                    "ID", "ComponentID", "ArticleName", "ArticleCode", 
                    "Batch", "IsSpecial", "IsFridge", "EntryDate",
                    "ExpiryDate", "SubItemQuantity", "ScanCode", "ExternalIdCode",
                    "DeliveryNumber", "Depth", "Height", "Width",
                    "StorageSystemName",
                    "TenantID", "TenantDescription", "StockLocationID", "StockLocationDescription"
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
                    this.ArticleName,
                    this.ArticleCode,
                    this.Batch,
                    this.IsSpecial,
                    this.IsFridge,
                    this.EntryDate,
                    this.ExpiryDate,
                    this.SubItemQuantity,
                    this.ScanCode,
                    this.ExternalIdCode,
                    this.DeliveryNumber,
                    this.Depth,
                    this.Height,
                    this.Width,
                    this.StorageSystemName,
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
        public IDatabaseType[][] Dependencies
        {
            // TODO: return pack attributes.
            get { return null; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GuiPack"/> class.
        /// </summary>
        public GuiPack()
        {
            this.ArticleName = string.Empty;
            this.ArticleCode = string.Empty;
            this.Batch = string.Empty;
            this.ScanCode = string.Empty;
            this.ExternalIdCode = string.Empty;
            this.DeliveryNumber = string.Empty;
            this.StorageSystemName = string.Empty;
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
        public virtual void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.ComponentID = (int)dataRow["ComponentID"];
            this.ArticleName = (string)dataRow["ArticleName"];
            this.ArticleCode = (string)dataRow["ArticleCode"];
            this.Batch = (string)dataRow["Batch"];
            this.IsSpecial = (bool)dataRow["IsSpecial"];
            this.IsFridge = (bool)dataRow["IsFridge"];
            this.EntryDate = (DateTime)dataRow["EntryDate"];
            this.ExpiryDate = (DateTime)dataRow["ExpiryDate"];
            this.SubItemQuantity = (int)dataRow["SubItemQuantity"];
            this.ScanCode = (string)dataRow["ScanCode"];
            this.ExternalIdCode = (string)dataRow["ExternalIdCode"];
            this.DeliveryNumber = (string)dataRow["DeliveryNumber"];
            this.Depth = (int)dataRow["Depth"];
            this.Height = (int)dataRow["Height"];
            this.Width = (int)dataRow["Width"];
            this.StorageSystemName = (string)dataRow["StorageSystemName"];
            this.TenantID = (string)dataRow["TenantID"];
            this.TenantDescription = (string)dataRow["TenantDescription"];
            this.StockLocationID = (string)dataRow["StockLocationID"];
            this.StockLocationDescription = (string)dataRow["StockLocationDescription"];
        }

    }
}
