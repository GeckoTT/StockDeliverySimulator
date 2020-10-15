using System;
using System.Collections.Generic;
using System.Data;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Output
{
    /// <summary>
    /// Class which represents an order item of a stock output order for a storage system.
    /// </summary>
    public class StockOutputOrderItem : IDatabaseType
    {
        #region Members

        /// <summary>
        /// Flag whether to lazy load the item related packs.
        /// </summary>
        private bool _lazyLoadPacks = false;

        /// <summary>
        /// Flag whether to lazy load the item related labels.
        /// </summary>
        private bool _lazyLoadLabels = false;

        /// <summary>
        /// Database reference to use for lazy loading.
        /// </summary>
        private DB.Database _database = null;

        /// <summary>
        /// The history date of the order item.
        /// </summary>
        private DateTime _historyDate;

        /// <summary>
        /// Holds the list of packs which are assigned to this stock output order item.
        /// </summary>
        private List<StockOutputOrderItemPack> _packList = new List<StockOutputOrderItemPack>();

        /// <summary>
        /// Holds the list of labels which are assigned to this stock output order item.
        /// </summary>
        private List<StockOutputOrderItemLabel> _labelList = new List<StockOutputOrderItemLabel>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the stock output order item.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the according stock output order.
        /// </summary>
        public int StockOutputOrderID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the Mosaic component which is assigned to this stock output order item.
        /// </summary>
        public int ComponentID { get; set; }

        /// <summary>
        /// Gets or sets the tenant code of the stock output order.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the pack for this stock output order item.
        /// </summary>
        public long PackID { get; set; }

        /// <summary>
        /// Gets or sets the PIS article code of this stock output order item.
        /// </summary>
        public string PISArticleCode { get; set; }

        /// <summary>
        /// Gets or sets the Robot article code of this stock output order item.
        /// </summary>
        public string RobotArticleCode { get; set; }

        /// <summary>
        /// Gets or sets the article name for the article code of this stock output order item.
        /// </summary>
        public string RobotArticleName { get; set; }

        /// <summary>
        /// Gets or sets the batch number of this stock output order item.
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets the single batch number flag of this stock output order item.
        /// </summary>
        public bool SingleBatchNumber { get; set; }

        /// <summary>
        /// Gets or sets the optional external id of this stock output order item.
        /// </summary>
        public string ExternalID { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of this stock output order item.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the stock location identifier of this stock output order item.
        /// </summary>
        public string StockLocationID { get; set; }

        /// <summary>
        /// Gets or sets the machine location of this stock output order item.
        /// </summary>
        public string MachineLocation { get; set; }

        /// <summary>
        /// Gets or sets the requested output quantity of this stock output order item.
        /// </summary>
        public int RequestedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the actually processed output quantity of this stock output order item.
        /// </summary>
        public int ProcessedQuantity { get; set; }
        
        /// <summary>
        /// Gets or sets the requested pill output quantity of this stock output order item.
        /// </summary>
        public int RequestedSubItemQuantity { get; set; }

        /// <summary>
        /// Gets or sets the actually processed pill output quantity of this stock output order item.
        /// </summary>
        public int ProcessedSubItemQuantity { get; set; }
        
        /// <summary>
        /// Gets the list of packs which are assigned to this stock output order item.
        /// </summary>
        public List<StockOutputOrderItemPack> Packs 
        { 
            get 
            {
                if ((_lazyLoadPacks) && (_database != null))
                {
                    if (_historyDate != DateTime.MinValue)
                    {
                        _packList = _database.Query<StockOutputOrderItemPack>(new CommandFilter("StockOutputOrderID", this.StockOutputOrderID),
                                                                              new CommandFilter("StockOutputOrderItemID", this.ID),
                                                                              new CommandFilter("ComponentID", this.ComponentID),
                                                                              new CommandFilter("TenantID", this.TenantID),
                                                                              new CommandFilter("HistoryDate", _historyDate));
                    }
                    else
                    {
                        _packList = _database.Query<StockOutputOrderItemPack>(new CommandFilter("StockOutputOrderID", this.StockOutputOrderID),
                                                                              new CommandFilter("StockOutputOrderItemID", this.ID),
                                                                              new CommandFilter("ComponentID", this.ComponentID),
                                                                              new CommandFilter("TenantID", this.TenantID));
                    }

                    _lazyLoadPacks = false;
                }

                return _packList; 
            } 
        }

        /// <summary>
        /// Gets the list of labels which are assigned to this stock output order item.
        /// </summary>
        public List<StockOutputOrderItemLabel> Labels
        {
            get
            {
                if ((_lazyLoadLabels) && (_database != null))
                {
                    if (_historyDate != DateTime.MinValue)
                    {
                        _labelList = _database.Query<StockOutputOrderItemLabel>(new CommandFilter("StockOutputOrderID", this.StockOutputOrderID),
                                                                                new CommandFilter("StockOutputOrderItemID", this.ID),
                                                                                new CommandFilter("ComponentID", this.ComponentID),
                                                                                new CommandFilter("TenantID", this.TenantID),
                                                                                new CommandFilter("HistoryDate", _historyDate));
                    }
                    else
                    {
                        _labelList = _database.Query<StockOutputOrderItemLabel>(new CommandFilter("StockOutputOrderID", this.StockOutputOrderID),
                                                                                new CommandFilter("StockOutputOrderItemID", this.ID),                                                                                
                                                                                new CommandFilter("ComponentID", this.ComponentID),
                                                                                new CommandFilter("TenantID", this.TenantID));
                    }

                    _lazyLoadLabels = false;
                }

                return _labelList; 
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
                    "ID", "StockOutputOrderID", "ComponentID", "TenantID", "PackID", "PISArticleCode", "RobotArticleCode", "RobotArticleName",
                    "BatchNumber", "SingleBatchNumber", "ExternalID", "ExpiryDate", "StockLocationID", "MachineLocation", "RequestedQuantity",
                    "ProcessedQuantity", "RequestedSubItemQuantity", "ProcessedSubItemQuantity"
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
                    this.StockOutputOrderID,
                    this.ComponentID,
                    this.TenantID,
                    this.PackID,
                    this.PISArticleCode,
                    this.RobotArticleCode,
                    this.RobotArticleName,
                    this.BatchNumber,
                    this.SingleBatchNumber,
                    this.ExternalID,
                    this.ExpiryDate,
                    this.StockLocationID,
                    this.MachineLocation,                    
                    this.RequestedQuantity,
                    this.ProcessedQuantity,
                    this.RequestedSubItemQuantity,
                    this.ProcessedSubItemQuantity
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
                return new string[] { "ID", "StockOutputOrderID", "ComponentID", "TenantID" };
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
                return new object[] { this.ID, this.StockOutputOrderID, this.ComponentID, this.TenantID };
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
                    this.Labels.ToArray()
                };
            }
        }
        
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockOutputOrderItem"/> class.
        /// </summary>
        public StockOutputOrderItem()
        {
            this.TenantID = string.Empty;
            this.PISArticleCode = string.Empty;
            this.RobotArticleCode = string.Empty;
            this.RobotArticleName = string.Empty;
            this.BatchNumber = string.Empty;
            this.SingleBatchNumber = false;
            this.ExternalID = string.Empty;
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
            this.StockOutputOrderID = (int)dataRow["StockOutputOrderID"];
            this.ComponentID = (int)dataRow["ComponentID"];
            this.TenantID = (string)dataRow["TenantID"];
            this.PackID = (long)dataRow["PackID"];
            this.PISArticleCode = (string)dataRow["PisArticleCode"];
            this.RobotArticleCode = (string)dataRow["RobotArticleCode"];
            this.RobotArticleName = (string)dataRow["RobotArticleName"];
            this.BatchNumber = (string)dataRow["BatchNumber"];
            this.SingleBatchNumber = (bool)dataRow["SingleBatchNumber"];
            this.ExternalID = (string)dataRow["ExternalID"];
            this.ExpiryDate = (DateTime)dataRow["ExpiryDate"];
            this.StockLocationID = (string)dataRow["StockLocationID"];
            this.MachineLocation = (string)dataRow["MachineLocation"];
            this.RequestedQuantity = (int)dataRow["RequestedQuantity"];
            this.ProcessedQuantity = (int)dataRow["ProcessedQuantity"];
            this.RequestedSubItemQuantity = (int)dataRow["RequestedSubItemQuantity"];
            this.ProcessedSubItemQuantity = (int)dataRow["ProcessedSubItemQuantity"];

            if (dataRow.Table.Columns.Contains("HistoryDate"))
            {
                _historyDate = ((DateTime)dataRow["HistoryDate"]).ToUniversalTime();
            }

            _lazyLoadPacks = true;
            _lazyLoadLabels = true;
            _database = database;
        }

         /// <summary>
        /// Clones this output order instance.
        /// </summary>
        /// <returns>Cloned stock output order.</returns>
        public StockOutputOrderItem Clone()
        {
            StockOutputOrderItem result = new StockOutputOrderItem()
            {
                ID = this.ID,
                StockOutputOrderID = this.StockOutputOrderID,
                ComponentID = this.ComponentID,
                TenantID = this.TenantID,
                PackID = this.PackID,
                PISArticleCode = this.PISArticleCode,
                RobotArticleCode = this.RobotArticleCode,
                RobotArticleName = this.RobotArticleName,
                BatchNumber = this.BatchNumber,
                SingleBatchNumber = this.SingleBatchNumber,
                ExternalID = this.ExternalID,
                ExpiryDate = this.ExpiryDate,
                StockLocationID = this.StockLocationID,
                MachineLocation = this.MachineLocation,
                RequestedQuantity = this.RequestedQuantity,
                ProcessedQuantity = this.ProcessedQuantity,
                RequestedSubItemQuantity = this.RequestedSubItemQuantity,
                ProcessedSubItemQuantity = this.ProcessedSubItemQuantity
            };

            foreach (var pack in this.Packs)
            {
                result.Packs.Add(pack.Clone(pack.TenantID, pack.ComponentID, pack.StockOutputOrderItemID, pack.StockOutputOrderID, pack.ID));
            }

            foreach (var label in this.Labels)
            {
                result.Labels.Add(new StockOutputOrderItemLabel() 
                {
                    ID = label.ID,
                    StockOutputOrderItemID = label.StockOutputOrderItemID,
                    StockOutputOrderID = label.StockOutputOrderID,
                    ComponentID = label.ComponentID,
                    TenantID = label.TenantID,
                    TemplateID = label.TemplateID,
                    Content = label.Content,
                });
            }

            return result;
        }
    }
}
