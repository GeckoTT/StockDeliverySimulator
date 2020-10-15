using System;
using System.Collections.Generic;
using System.Data;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.Interfaces.Types.Input
{
    /// <summary>
    /// Class which represents a stock delivery for a storage system.
    /// </summary>
    public class StockDelivery : IDatabaseType
    {
        #region Members

        /// <summary>
        /// Flag whether to lazy load dependencies.
        /// </summary>
        private bool _requireLazyLoad = false;

        /// <summary>
        /// Database reference to use for lazy loading.
        /// </summary>
        private DB.Database _database = null; 

        /// <summary>
        /// Holds the list of order items which are assigned to this stock delivery.
        /// </summary>
        private List<StockDeliveryItem> _orderItems = new List<StockDeliveryItem>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the stock delivery.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the component which initiated this stock delivery.
        /// </summary>
        public int SourceID { get; set; }

        /// <summary>
        /// Gets or sets the delivery number.
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// Gets or sets the optional box number according to this order.
        /// </summary>
        public string BoxNumber { get; set; }

        /// <summary>
        /// Gets or sets the priority of this stock output order.
        /// </summary>
        public StockDeliveryPriority Priority { get; set; }

        /// <summary>
        /// Gets or sets the state of the stock delivery.
        /// </summary>
        public StockDeliveryState State { get; set; }

        /// <summary>
        /// Gets or sets the created date of the stock delivery.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier of the stock delivery.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the history date of the stock delivery.
        /// </summary>
        public DateTime HistoryDate { get; set; }

        /// <summary>
        /// Gets the list of items which are assigned to this stock output order.
        /// </summary>
        public List<StockDeliveryItem> Items 
        { 
            get 
            {
                if ((_requireLazyLoad) && (_database != null))
                {
                    if (this.HistoryDate != DateTime.MinValue)
                    {
                        _orderItems = _database.Query<StockDeliveryItem>(new CommandFilter("StockDeliveryID", this.ID),
                                                                         new CommandFilter("TenantID", this.TenantID),
                                                                         new CommandFilter("HistoryDate", this.HistoryDate));
                    }
                    else
                    {
                        _orderItems = _database.Query<StockDeliveryItem>(new CommandFilter("StockDeliveryID", this.ID),                                                                         
                                                                         new CommandFilter("TenantID", this.TenantID));
                    }

                    _requireLazyLoad = false;
                }

                return _orderItems; 
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
                    "ID", "SourceID", "DeliveryNumber", 
                    "BoxNumber", "Priority",
                    "State", "Created", "TenantID"
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
                    this.SourceID,
                    this.DeliveryNumber,
                    this.BoxNumber,
                    this.Priority.ToString(),
                    this.State.ToString(),
                    this.Created,
                    this.TenantID
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
            get { return new IDatabaseType[][] { this.Items.ToArray() }; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDelivery"/> class.
        /// </summary>
        public StockDelivery()
        {
            this.DeliveryNumber = string.Empty;
            this.BoxNumber = string.Empty;
            this.Created = DateTime.UtcNow;
            this.Priority = StockDeliveryPriority.Normal;
            this.State = StockDeliveryState.Queued;
            this.TenantID = string.Empty;
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.SourceID = (int)dataRow["SourceID"];
            this.DeliveryNumber = (string)dataRow["DeliveryNumber"];
            this.BoxNumber = (string)dataRow["BoxNumber"];
            this.Priority = (StockDeliveryPriority)Enum.Parse(typeof(StockDeliveryPriority), (string)dataRow["Priority"]);
            this.State = (StockDeliveryState)Enum.Parse(typeof(StockDeliveryState), (string)dataRow["State"]);
            this.Created = ((DateTime)dataRow["Created"]).ToUniversalTime();
            this.TenantID = (string)dataRow["TenantID"];

            if (dataRow.Table.Columns.Contains("HistoryDate"))
            {
                this.HistoryDate = ((DateTime)dataRow["HistoryDate"]).ToUniversalTime();
            }

            _requireLazyLoad = true;
            _database = database;
        }
    }
}
