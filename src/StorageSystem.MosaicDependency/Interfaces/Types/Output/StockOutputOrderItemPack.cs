using System;
using System.Data;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.Interfaces.Types.Articles;
using CareFusion.Mosaic.Interfaces.Types.Database;
using CareFusion.Mosaic.Interfaces.Types.Packs;
using CareFusion.Mosaic.Interfaces.Types.Stock;

namespace CareFusion.Mosaic.Interfaces.Types.Output
{
    /// <summary>
    /// Class which represents a pack which is related to an order item of a stock output order for a storage system.
    /// </summary>
    public class StockOutputOrderItemPack : IDatabaseType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the pack.
        /// </summary>
        public long ID { get; set; }

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
        /// Gets or sets according article ID of the pack.
        /// </summary>
        public int RobotArticleID { get; set; }

        /// <summary>
        /// Gets or sets according article code of the pack.
        /// </summary>
        public string RobotArticleCode { get; set; }

        /// <summary>
        /// Gets or sets according article code of the pack.
        /// </summary>
        public string RobotArticleName { get; set; }

        /// <summary>
        /// Gets or sets the dosage form of the pack article.
        /// </summary>
        public string RobotArticleDosageForm { get; set; }

        /// <summary>
        /// Gets or sets the packaging unit of the pack article.
        /// </summary>
        public string RobotArticlePackagingUnit { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of sub items for this article.
        /// </summary>
        public int RobotArticleMaxSubItemQuantity { get; set; }

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
        /// Gets or sets the box number of this pack during output.
        /// </summary>
        public string BoxNumber { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this pack is in fridge.
        /// </summary>
        public bool IsInFridge { get; set; }

        /// <summary>
        /// Gets or sets the shape for this pack.
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
        /// Gets or sets the number of the output which was used to dispense the pack.
        /// </summary>
        public int OutputNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of the output point which was used to dispense the pack.
        /// </summary>
        public int OutputPoint { get; set; }

        /// <summary>
        /// Gets or sets the labelling state of the dispensed pack.
        /// </summary>
        public StockOutputOrderItemPackLabelState LabelState  { get; set; }

        /// <summary>
        /// Gets or sets the tenant description of the dispensed pack.
        /// </summary>
        public string TenantDescription { get; set; }

        /// <summary>
        /// Gets or sets the stock location identifier of the dispensed pack.
        /// </summary>
        public string StockLocationID { get; set; }

        /// <summary>
        /// Gets or sets the stock location description of the dispensed pack.
        /// </summary>
        public string StockLocationDescription { get; set; }

        /// <summary>
        /// Gets or sets the machine location of the dispensed pack.
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
                    "ID", "StockOutputOrderItemID", "StockOutputOrderID",
                    "ComponentID", "RobotArticleCode", "RobotArticleName", "RobotArticleDosageForm", "RobotArticlePackagingUnit",
                    "RobotArticleMaxSubItemQuantity", "BatchNumber", "DeliveryNumber", "ExpiryDate", 
                    "ExternalID", "BoxNumber", "IsInFridge", "Shape", "SubItemQuantity", "ScanCode",
                    "StockInDate", "Depth", "Height", "Width", "OutputNumber", "OutputPoint", "LabelState",
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
                    this.StockOutputOrderItemID,
                    this.StockOutputOrderID,
                    this.ComponentID,
                    this.RobotArticleCode,
                    this.RobotArticleName,
                    this.RobotArticleDosageForm,
                    this.RobotArticlePackagingUnit,
                    this.RobotArticleMaxSubItemQuantity,
                    this.BatchNumber,
                    this.DeliveryNumber,
                    this.ExpiryDate,
                    this.ExternalID,
                    this.BoxNumber,
                    this.IsInFridge,
                    this.Shape.ToString(),
                    this.SubItemQuantity,
                    this.ScanCode,
                    this.StockInDate,
                    this.Depth,
                    this.Height,
                    this.Width,
                    this.OutputNumber,
                    this.OutputPoint,
                    this.LabelState.ToString(),
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
        /// Initializes a new instance of the <see cref="StockOutputOrderItemPack"/> class.
        /// </summary>
        public StockOutputOrderItemPack()
        {
            this.RobotArticleCode = string.Empty;
            this.RobotArticleName = string.Empty;
            this.RobotArticleDosageForm = string.Empty;
            this.RobotArticlePackagingUnit = string.Empty;
            this.BatchNumber = string.Empty;
            this.DeliveryNumber = string.Empty;
            this.ExternalID = string.Empty;
            this.ScanCode = string.Empty;
            this.BoxNumber = string.Empty;
            this.LabelState = StockOutputOrderItemPackLabelState.NotLabelled;
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
            this.StockOutputOrderItemID = (int)dataRow["StockOutputOrderItemID"];
            this.StockOutputOrderID = (int)dataRow["StockOutputOrderID"];
            this.ComponentID = (int)dataRow["ComponentID"];
            this.RobotArticleCode = (string)dataRow["RobotArticleCode"];
            this.RobotArticleName = (string)dataRow["RobotArticleName"];
            this.RobotArticleDosageForm = (string)dataRow["RobotArticleDosageForm"];
            this.RobotArticlePackagingUnit = (string)dataRow["RobotArticlePackagingUnit"];
            this.RobotArticleMaxSubItemQuantity = (int)dataRow["RobotArticleMaxSubItemQuantity"];
            this.BatchNumber = (string)dataRow["BatchNumber"];
            this.DeliveryNumber = (string)dataRow["DeliveryNumber"];
            this.ExpiryDate = (DateTime)dataRow["ExpiryDate"];
            this.ExternalID = (string)dataRow["ExternalID"];
            this.BoxNumber = (string)dataRow["BoxNumber"];
            this.IsInFridge = (bool)dataRow["IsInFridge"];
            this.Shape = (PackShape)Enum.Parse(typeof(PackShape), (string)dataRow["Shape"]);
            this.SubItemQuantity = (int)dataRow["SubItemQuantity"];
            this.ScanCode = (string)dataRow["ScanCode"];
            this.StockInDate = (DateTime)dataRow["StockInDate"];
            this.Depth = (int)dataRow["Depth"];
            this.Height = (int)dataRow["Height"];
            this.Width = (int)dataRow["Width"];
            this.OutputNumber = (int)dataRow["OutputNumber"];
            this.OutputPoint = (int)dataRow["OutputPoint"];
            this.LabelState = (StockOutputOrderItemPackLabelState)Enum.Parse(typeof(StockOutputOrderItemPackLabelState), (string)dataRow["LabelState"]);

            this.TenantID = (string)dataRow["TenantID"];
            this.TenantDescription = (string)dataRow["TenantDescription"];
            this.StockLocationID = (string)dataRow["StockLocationID"];
            this.StockLocationDescription = (string)dataRow["StockLocationDescription"];
            this.MachineLocation = (string)dataRow["MachineLocation"];
        }

        /// <summary>
        /// Updates the article information of this item pack.
        /// </summary>
        /// <param name="database">The database to retrieve the article information from.</param>
        public void UpdateArticleInformation(DB.Database database)
        {
            if (database == null)
            {
                throw new ArgumentException("Invalid database specified.");
            }

            if ((this.RobotArticleID == 0) || (this.ComponentID == 0))
            {
                this.RobotArticleCode = string.Empty;
                this.RobotArticleName = string.Empty;
                this.RobotArticleDosageForm = string.Empty;
                this.RobotArticlePackagingUnit = string.Empty;
            }
            else
            {
                var articleList = database.Query<RobotArticle>(new CommandFilter("ID", this.RobotArticleID),
                                                          new CommandFilter("ComponentID", this.ComponentID));

                if (articleList.Count == 0)
                {
                    this.Error("Article with ID '{0}' for component '{1}' not found.", this.RobotArticleID, this.ComponentID);

                    this.RobotArticleCode = this.ScanCode == null ? string.Empty : this.ScanCode;
                    this.RobotArticleName = string.Empty;
                    this.RobotArticleDosageForm = string.Empty;
                    this.RobotArticlePackagingUnit = string.Empty;
                }

                this.RobotArticleCode = articleList[0].Code;
                this.RobotArticleName = articleList[0].Name;
                this.RobotArticleDosageForm = articleList[0].DosageForm;
                this.RobotArticlePackagingUnit = articleList[0].PackagingUnit;
            }
        }

        /// <summary>
        /// Updates the stock location and tenant information of this item pack.
        /// </summary>
        /// <param name="database">The database to retrieve the stock location and tenant information from.</param>
        public void UpdateLocationAndTenantInformation(DB.Database database)
        {
            if (database == null)
            {
                throw new ArgumentException("Invalid database specified.");
            }

            var tenants = database.Query<Tenant>(new CommandFilter("ID", this.TenantID),
                                                 new CommandFilter("ComponentID", this.ComponentID));

            if (tenants.Count > 0)
            {
                this.TenantDescription = tenants[0].Description;
            }

            var locations = database.Query<StockLocation>(new CommandFilter("ID", this.StockLocationID),
                                                          new CommandFilter("ComponentID", this.ComponentID));

            if (locations.Count > 0)
            {
                this.StockLocationDescription = locations[0].Description;
            }
        }

        /// <summary>
        /// Creates a clone of this stock output order item pack with an alternate component ID and pack ID.
        /// </summary>
        /// <param name="tenantID">The alternate tenant ID for the clone.</param>
        /// <param name="componentID">The alternate component ID for the clone.</param>
        /// <param name="outputOrderItemID">The alternate output order item ID to set.</param>
        /// <param name="outputOrderID">The alternate output order ID.</param>
        /// <param name="packID">The alternate pack ID for the clone.</param>
        /// <returns>
        /// Newly created clone object.
        /// </returns>
        public StockOutputOrderItemPack Clone(string tenantID, int componentID, int outputOrderItemID, int outputOrderID, long packID)
        {
            return new StockOutputOrderItemPack()
            {
                ID = packID,
                StockOutputOrderItemID = outputOrderItemID,
                StockOutputOrderID = outputOrderID,
                ComponentID = componentID,
                TenantID = tenantID,
                RobotArticleID = this.RobotArticleID,
                RobotArticleCode = this.RobotArticleCode,
                RobotArticleName = this.RobotArticleName,
                RobotArticleDosageForm = this.RobotArticleDosageForm,
                RobotArticlePackagingUnit = this.RobotArticlePackagingUnit,
                RobotArticleMaxSubItemQuantity = this.RobotArticleMaxSubItemQuantity,
                BatchNumber = this.BatchNumber,
                DeliveryNumber = this.DeliveryNumber,
                ExpiryDate = this.ExpiryDate,
                ExternalID = this.ExternalID,
                BoxNumber = this.BoxNumber,
                IsInFridge = this.IsInFridge,
                Shape = this.Shape,
                SubItemQuantity = this.SubItemQuantity,
                ScanCode = this.ScanCode,
                StockInDate = this.StockInDate,
                Depth = this.Depth,
                Height = this.Height,
                Width = this.Width,
                OutputNumber = this.OutputNumber,
                OutputPoint = this.OutputPoint,
                LabelState = this.LabelState,                
                TenantDescription = this.TenantDescription,
                StockLocationID = this.StockLocationID,
                StockLocationDescription = this.StockLocationDescription,
                MachineLocation = this.MachineLocation
            };
        }
    }
}
