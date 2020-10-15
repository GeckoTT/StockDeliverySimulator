using System;
using System.Collections.Generic;
using System.Data;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Interfaces.Types.Database;


namespace CareFusion.Mosaic.Interfaces.Types.Output
{
    /// <summary>
    /// Class which represents a stock output order for a storage system.
    /// </summary>
    public class StockOutputOrder : IDatabaseType
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
        /// Holds the list of order items which are assigned to this stock output order.
        /// </summary>
        private List<StockOutputOrderItem> _orderItems = new List<StockOutputOrderItem>();
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the stock output order.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the Mosaic component which is assigned to this stock output order.
        /// </summary>
        public int ComponentID { get; set; }

        /// <summary>
        /// Gets or sets the tenant code of the stock output order.
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the parent stock output order.
        /// </summary>
        public int ParentOrderID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the parent's stock output order component.
        /// </summary>
        public int ParentComponentID { get; set; }

         /// <summary>
        /// Gets or sets the tenant of the parent's stock output order component.
        /// </summary>
        public string ParentTenantID { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the initiator of this stock output order.
        /// </summary>
        public int SourceID { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the optional box number according to this order.
        /// </summary>
        public string BoxNumber { get; set; }

        /// <summary>
        /// Gets or sets the box object that is assigned to this stock output order (not persistent).
        /// </summary>
        //public IBox Box { get; set; }

        /// <summary>
        /// Gets or sets the optional external number of this stock output order.
        /// </summary>
        public string ExternalNumber { get; set; }

        /// <summary>
        /// Gets or sets the output number for this stock output order.
        /// </summary>
        public int OutputNumber { get; set; }

        /// <summary>
        /// Gets or sets the output point for this stock output order.
        /// </summary>
        public int OutputPoint { get; set; }

        /// <summary>
        /// Gets or sets a flag whether the content of this box is filled to a box (not persistent).
        /// </summary>
        public bool IsFilledToBox { get; set; }
        
        /// <summary>
        /// Gets or sets the priority of this stock output order.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the state of the stock output order.
        /// </summary>
        public StockOutputOrderState State { get; set; }

        /// <summary>
        /// Gets or sets the created date of the stock output order.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the history date of the stock output order.
        /// </summary>
        public DateTime HistoryDate { get; set; }

        /// <summary>
        /// Gets the list of items which are assigned to this stock output order.
        /// </summary>
        public List<StockOutputOrderItem> Items 
        { 
            get 
            {
                if ((_requireLazyLoad) && (_database != null))
                {
                    if (this.HistoryDate != DateTime.MinValue)
                    {
                        _orderItems = _database.Query<StockOutputOrderItem>(new CommandFilter("StockOutputOrderID", this.ID),
                                                                            new CommandFilter("ComponentID", this.ComponentID),
                                                                            new CommandFilter("TenantID", this.TenantID),                                                                            
                                                                            new CommandFilter("HistoryDate", this.HistoryDate));
                    }
                    else
                    {
                        _orderItems = _database.Query<StockOutputOrderItem>(new CommandFilter("StockOutputOrderID", this.ID),
                                                                            new CommandFilter("ComponentID", this.ComponentID),
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
                    "ID", "ComponentID", "TenantID", "ParentOrderID", "ParentComponentID", 
                    "ParentTenantID", "SourceID", "OrderNumber", 
                    "BoxNumber", "ExternalNumber", "OutputNumber", "OutputPoint", "Priority",
                    "State", "Created"
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
                    this.TenantID,
                    (this.ParentOrderID > 0) ? this.ParentOrderID : (object)DBNull.Value,
                    (this.ParentComponentID > 0) ? this.ParentComponentID : (object)DBNull.Value,
                    (this.ParentTenantID != null) ? this.ParentTenantID : (object)DBNull.Value,
                    this.SourceID,
                    this.OrderNumber,
                    this.BoxNumber,
                    this.ExternalNumber,
                    this.OutputNumber,
                    this.OutputPoint,
                    this.Priority.ToString(),
                    this.State.ToString(),
                    this.Created                    
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
                return new string[] { "ID", "ComponentID", "TenantID" };
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
                return new object[] { this.ID, this.ComponentID, this.TenantID };
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
        /// Initializes a new instance of the <see cref="StockOutputOrder"/> class.
        /// </summary>
        public StockOutputOrder()
        {
            this.TenantID = string.Empty;
            this.ParentTenantID = null;
            this.OrderNumber = string.Empty;
            this.BoxNumber = string.Empty;
            this.ExternalNumber = string.Empty;
            this.Created = DateTime.UtcNow;
            this.Priority = 3;
            this.HistoryDate = DateTime.MinValue;            
        }

        /// <summary>
        /// Loads the content of the database type from the specified database row object.
        /// </summary>
        /// <param name="dataRow">The database row object to load the database type from.</param>
        /// <param name="database">The database instance to use for loading additional dependencies.</param>
        public void Load(DataRow dataRow, DB.Database database)
        {
            this.ID = (int)dataRow["ID"];
            this.ComponentID = (int)dataRow["ComponentID"];
            this.TenantID = (string)dataRow["TenantID"];

            object id = dataRow["ParentOrderID"];
            this.ParentOrderID = (id == DBNull.Value) ? 0 : (int)id;

            id = dataRow["ParentComponentID"];
            this.ParentComponentID = (id == DBNull.Value) ? 0 : (int)id;

            id = dataRow["ParentTenantID"];
            this.ParentTenantID = (id == DBNull.Value) ? null : (string)id;

            this.SourceID = (int)dataRow["SourceID"];
            this.OrderNumber = (string)dataRow["OrderNumber"];
            this.BoxNumber = (string)dataRow["BoxNumber"];
            this.ExternalNumber = (string)dataRow["ExternalNumber"];
            this.OutputNumber = (int)dataRow["OutputNumber"];
            this.OutputPoint = (int)dataRow["OutputPoint"];
            this.Priority = (int)dataRow["Priority"]; 
            this.State = (StockOutputOrderState)Enum.Parse(typeof(StockOutputOrderState), (string)dataRow["State"]);
            this.Created = ((DateTime)dataRow["Created"]).ToUniversalTime();

            if (dataRow.Table.Columns.Contains("HistoryDate"))
            {
                this.HistoryDate = ((DateTime)dataRow["HistoryDate"]).ToUniversalTime();
            }

            _requireLazyLoad = true;
            _database = database;
        }

        /// <summary>
        /// Clones this output order instance.
        /// </summary>
        /// <returns>Cloned stock output order.</returns>
        public StockOutputOrder Clone()
        {
            StockOutputOrder result = new StockOutputOrder()
            {
                ID = this.ID,
                ComponentID = this.ComponentID,
                TenantID = this.TenantID,
                ParentOrderID = this.ParentOrderID,
                ParentComponentID = this.ParentComponentID,
                ParentTenantID = this.ParentTenantID,
                SourceID = this.SourceID,
                OrderNumber = this.OrderNumber,
                BoxNumber = this.BoxNumber,
                ExternalNumber = this.ExternalNumber,
                OutputNumber = this.OutputNumber,
                OutputPoint = this.OutputPoint,
                Priority = this.Priority,
                State = this.State,
                Created = this.Created,                
                HistoryDate = this.HistoryDate
            };

            foreach (var item in this.Items)
            {
                result.Items.Add(item.Clone());
            }

            return result;
        }

        /// <summary>
        /// Sorts the order items from most detailed to less detailed.
        /// </summary>
        public void SortOrderItems()
        {
            List<StockOutputOrderItem> orderItemList = new List<StockOutputOrderItem>();

            // first detail level are pack specific output requests
            foreach (var orderItem in this.Items.ToArray())
            {
                if (orderItem.PackID != 0)
                {
                    orderItemList.Add(orderItem);
                    this.Items.Remove(orderItem);
                }
            }

            // second detail level are external id specific output requests
            foreach (var orderItem in this.Items.ToArray())
            {
                if (string.IsNullOrEmpty(orderItem.ExternalID) == false)
                {
                    orderItemList.Add(orderItem);
                    this.Items.Remove(orderItem);
                }
            }

            // third detail level are batch number specific output requests
            foreach (var orderItem in this.Items.ToArray())
            {
                if (string.IsNullOrEmpty(orderItem.BatchNumber) == false)
                {
                    orderItemList.Add(orderItem);
                    this.Items.Remove(orderItem);
                }
            }

            // fourth detail level are expiry date specific output requests
            foreach (var orderItem in this.Items.ToArray())
            {
                if (orderItem.ExpiryDate > DateTime.MinValue)
                {
                    orderItemList.Add(orderItem);
                    this.Items.Remove(orderItem);
                }
            }

            if (this.Items.Count > 0)
            {
                orderItemList.AddRange(this.Items);
                this.Items.Clear();
            }

            if (orderItemList.Count > 0)
            {
                this.Items.AddRange(orderItemList);
            }
        }
    }
}
