using System;
using System.Data;
using CareFusion.Mosaic.Interfaces.Types.Database;
using System.Collections.Generic;
using CareFusion.Mosaic.DB;

namespace CareFusion.Mosaic.Interfaces.Types.Input
{
    /// <summary>
    /// Class which represents an order item of a stock delivery for a storage system.
    /// </summary>
    public class StockDeliveryItem : IDatabaseType
    {
        #region Members

        /// <summary>
        /// Flag whether to lazy load the item related packs.
        /// </summary>
        private bool _lazyLoadPacks = false;

        /// <summary>
        /// The history date of the order item.
        /// </summary>
        private DateTime _historyDate;

        /// <summary>
        /// Database reference to use for lazy loading.
        /// </summary>
        private DB.Database _database = null;

        /// <summary>
        /// Holds the list of packs which are assigned to this stock delivery item.
        /// </summary>
        private List<StockDeliveryItemPack> _packs = new List<StockDeliveryItemPack>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the stock delivery item.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the according stock delivery.
        /// </summary>
        public int StockDeliveryID { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier of the stock delivery.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the article code of this stock output order item.
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// Gets or sets the batch number of this stock output order item.
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets the optional external id of this stock output order item.
        /// </summary>
        public string ExternalID { get; set; }

        /// <summary>
        /// Gets or sets the article name of this stock delivery item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the article dosage form of this stock delivery item.
        /// </summary>
        public string DosageForm { get; set; }

        /// <summary>
        /// Gets or sets the article packaging unit of this stock delivery item.
        /// </summary>
        public string PackagingUnit { get; set; }

        /// <summary>
        /// Gets or sets the requires fridge flag of this stock delivery item.
        /// </summary>
        public bool RequiresFridge { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of this stock delivery item.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of sub items for this article.
        /// </summary>
        public int MaxSubItemQuantity { get; set; }

        /// <summary>
        /// Gets or sets the stock location identifier of this stock delivery item.
        /// </summary>
        public string StockLocationID { get; set; }

        /// <summary>
        /// Gets or sets the machine location of this stock delivery item.
        /// </summary>
        public string MachineLocation { get; set; }

        /// <summary>
        /// Gets or sets the requested input quantity of this stock delivery item.
        /// </summary>
        public int RequestedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the actually processed input quantity of this stock delivery item.
        /// </summary>
        public int ProcessedQuantity { get; set; }

        /// <summary>
        /// Gets the list of packs which are assigned to this stock delivery item.
        /// </summary>
        public List<StockDeliveryItemPack> Packs
        {
            get
            {
                if ((_lazyLoadPacks) && (_database != null))
                {
                    if (_historyDate != DateTime.MinValue)
                    {
                        _packs = _database.Query<StockDeliveryItemPack>(new CommandFilter("StockDeliveryID", this.StockDeliveryID),
                                                                        new CommandFilter("StockDeliveryItemID", this.ID),
                                                                        new CommandFilter("TenantID", this.TenantID),
                                                                        new CommandFilter("HistoryDate", _historyDate));
                    }
                    else
                    {
                        _packs = _database.Query<StockDeliveryItemPack>(new CommandFilter("StockDeliveryID", this.StockDeliveryID),
                                                                        new CommandFilter("StockDeliveryItemID", this.ID),
                                                                        new CommandFilter("TenantID", this.TenantID));
                    }

                    _lazyLoadPacks = false;
                }

                return _packs;
            }
        }

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
                    "ID", "StockDeliveryID", "TenantID", "ArticleCode", "BatchNumber",
                    "ExternalID", "Name", "DosageForm", "PackagingUnit", "RequiresFridge",
                    "ExpiryDate", "MaxSubItemQuantity", "StockLocationID", "MachineLocation",
                    "RequestedQuantity", "ProcessedQuantity"
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
                    this.StockDeliveryID,
                    this.TenantID,
                    this.ArticleCode,
                    this.BatchNumber,
                    this.ExternalID,
                    this.Name,
                    this.DosageForm,
                    this.PackagingUnit,
                    this.RequiresFridge,
                    this.ExpiryDate,
                    this.MaxSubItemQuantity,
                    this.StockLocationID,
                    this.MachineLocation,                    
                    this.RequestedQuantity,
                    this.ProcessedQuantity
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
                return new string[] { "ID", "StockDeliveryID", "TenantID" };
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
                return new object[] { this.ID, this.StockDeliveryID, this.TenantID };
            }
        }

        /// <summary>
        /// Gets an array of dependent database objects according to this object instance.
        /// These dependent objects are also serialized whenever this object instance is serialized.
        /// </summary>
        public IDatabaseType[][] Dependencies
        {
            get 
            {
                return new IDatabaseType[][] 
                {
                    this.Packs.ToArray(),
                };
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliveryItem"/> class.
        /// </summary>
        public StockDeliveryItem()
        {
            this.TenantID = string.Empty;
            this.ArticleCode = string.Empty;
            this.BatchNumber = string.Empty;
            this.ExternalID = string.Empty;
            this.Name = string.Empty;
            this.DosageForm = string.Empty;
            this.PackagingUnit = string.Empty;
            this.ExpiryDate = DateTime.MinValue;
            this.StockLocationID = string.Empty;
            this.MachineLocation = string.Empty;
            _historyDate = DateTime.MinValue;
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.StockDeliveryID = (int)dataRow["StockDeliveryID"];
            this.TenantID = (string)dataRow["TenantID"];
            this.ArticleCode = (string)dataRow["ArticleCode"];
            this.BatchNumber = (string)dataRow["BatchNumber"];
            this.ExternalID = (string)dataRow["ExternalID"];
            this.Name = (string)dataRow["Name"];
            this.DosageForm = (string)dataRow["DosageForm"];
            this.PackagingUnit = (string)dataRow["PackagingUnit"];
            this.RequiresFridge = (bool)dataRow["RequiresFridge"];
            this.ExpiryDate = (DateTime)dataRow["ExpiryDate"];
            this.MaxSubItemQuantity = (int)dataRow["MaxSubItemQuantity"];
            this.RequestedQuantity = (int)dataRow["RequestedQuantity"];
            this.ProcessedQuantity = (int)dataRow["ProcessedQuantity"];
            this.StockLocationID = (string)dataRow["StockLocationID"];
            this.MachineLocation = (string)dataRow["MachineLocation"];

            if (dataRow.Table.Columns.Contains("HistoryDate"))
            {
                _historyDate = ((DateTime)dataRow["HistoryDate"]).ToUniversalTime();
            }

            _lazyLoadPacks = true;
            _database = database;
        }
    }
}
