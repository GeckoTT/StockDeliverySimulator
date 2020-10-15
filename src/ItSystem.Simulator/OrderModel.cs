using CareFusion.Lib.StorageSystem.Output;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Event arguments for the pack dispensed event.
    /// </summary>
    public class PackDispensedArgs : EventArgs
    {
        /// <summary>
        /// Packs that were dispensed.
        /// </summary>
        public IDispensedPack[] Packs { get; set; }
    }

    /// <summary>
    /// Event arguments for the box released event.
    /// </summary>
    public class BoxReleasedArgs : EventArgs
    {
        /// <summary>
        /// Boxes released.
        /// </summary>
        public DataTable Boxes { get; set; }
    }

    /// <summary>
    /// Class which contains the data model of a storage system output order.
    /// </summary>
    public class OrderModel
    {
        #region Members

        /// <summary>
        /// Order data model.
        /// </summary>
        private DataTable _orderModel = new DataTable();

        /// <summary>
        /// Order box model.
        /// </summary>
        private DataTable _orderBoxModel = new DataTable();

        /// <summary>
        /// Order item data model for the current order.
        /// </summary>
        private DataTable _orderItemModel = new DataTable();

        /// <summary>
        /// Order item label data model for the current order.
        /// </summary>
        private DataTable _itemLabelModel = new DataTable();

        /// <summary>
        /// Dispensed packs data model for the current order.
        /// </summary>
        private DataTable _dispensedPackModel = new DataTable();

        /// <summary>
        /// Current list of output orders in the order list.
        /// </summary>
        private List<IOutputProcess> _orderList = new List<IOutputProcess>();

        /// <summary>
        /// The mapping between orders and their states.
        /// </summary>
        private Dictionary<IOutputProcess, OutputProcessState> _orderStates = new Dictionary<IOutputProcess, OutputProcessState>();

        /// <summary>
        /// The orders and the related boxes.
        /// </summary>
        private Dictionary<string, HashSet<string>> _orderBoxes = new Dictionary<string, HashSet<string>>();

        /// <summary>
        /// Reference to the currently selected output order.
        /// </summary>
        private IOutputProcess _selectedOrder = null;

        /// <summary>
        /// Reference to the currently selected order item.
        /// </summary>
        private int _selectedOrderItem = -1;

        /// <summary>
        /// The object instance to use for invoke gui save methods.
        /// </summary>
        private Control _invokeInstance;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the currently active order data model.
        /// </summary>
        public DataTable Orders
        {
            get { return _orderModel; }
        }

        /// <summary>
        /// Gets the currently active order boxes data model.
        /// </summary>
        public DataTable OrderBoxes
        {
            get { return _orderBoxModel; }
        }

        /// <summary>
        /// Gets the currently active order items data model.
        /// </summary>
        public DataTable OrderItems
        {
            get { return _orderItemModel; }
        }

        /// <summary>
        /// Gets the currently active label data model.
        /// </summary>
        public DataTable ItemLabels
        {
            get { return _itemLabelModel; }
        }

        /// <summary>
        /// Gets the currently active dispensed packs data model.
        /// </summary>
        public DataTable DispensedPacks
        {
            get { return _dispensedPackModel; }
        }

        #endregion

        #region Events

        /// <summary>
        /// Event which is thrown after a job has finished to notify about pack dispension.
        /// </summary>
        public event EventHandler PackDispensed;

        /// <summary>
        /// Event which is thrown after a box is released.
        /// </summary>
        public event EventHandler BoxReleased;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderModel" /> class.
        /// </summary>
        /// <param name="invokeInstance">The invoke instance to use.</param>
        public OrderModel(Control invokeInstance)
        {
            if (invokeInstance == null)
            {
                throw new ArgumentException("Invalid invokeInstance specified.");
            }

            _invokeInstance = invokeInstance;

            DataColumn column = _orderModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Number";

            column = _orderModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Priority";

            column = _orderModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "Output";

            column = _orderModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "Point";

            column = _orderModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Box";

            column = _orderModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Status";

            ////////////////////////////////////

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "Index";

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Article";

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Batch";

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ExternalID";

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ExpiryDate";

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(long);
            column.ColumnName = "PackID";

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Machine";

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "Quantity";

            column = _orderItemModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "SubItems";

            ////////////////////////////////////

            column = _itemLabelModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "TemplateId";

            column = _itemLabelModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Content";

            ////////////////////////////////////

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(long);
            column.ColumnName = "ID";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Delivery";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Batch";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ExternalID";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ExpiryDate";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(bool);
            column.ColumnName = "Fridge";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "SubItems";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Labelled";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "Output";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(int);
            column.ColumnName = "Point";

            column = _dispensedPackModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Box";

            column = _orderBoxModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Order";

            column = _orderBoxModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Box";
        }

        /// <summary>
        /// Clears the complete order data model.
        /// </summary>
        public void Clear()
        {
            foreach (var order in _orderList)
            {
                order.Finished -= OnOrderFinished;
                order.BoxReleased -= OnBoxReleased;
            }

            _orderList.Clear();
            _orderStates.Clear();
            _orderBoxes.Clear();
            UpdateModel();
            _orderBoxModel.Clear();
        }

        /// <summary>
        /// Adds the specified order to the data model.
        /// </summary>
        /// <param name="order">The order to add.</param>
        public void AddOrder(IOutputProcess order)
        {
            if (order == null)
            {
                return;
            }

            foreach (var existingOrder in _orderList)
            {
                if (existingOrder.OrderNumber == order.OrderNumber)
                {
                    existingOrder.Finished -= OnOrderFinished;
                    order.BoxReleased -= OnBoxReleased;
                    _orderList.Remove(existingOrder);
                    break;
                }
            }

            order.Finished += OnOrderFinished;
            order.BoxReleased += OnBoxReleased;
            _orderList.Add(order);
            _orderStates[order] = order.State;

            UpdateModel();
        }

        /// <summary>
        /// Clears the current order selection.
        /// </summary>
        public void ClearOrderSelection()
        {
            _selectedOrder = null;
            UpdateOrderModel();
        }

        /// <summary>
        /// Selects the order with the specified order number.
        /// </summary>
        /// <param name="orderNumber">Number of the order to select.</param>
        public void SelectOrder(string orderNumber)
        {
            _selectedOrder = null;

            foreach (var order in _orderList)
            {
                if (order.OrderNumber == orderNumber)
                {
                    _selectedOrder = order;
                    break;
                }
            }

            UpdateOrderModel();

            _orderBoxModel.Clear();
            if (_orderBoxes.Where(x => x.Key.Equals(orderNumber)).FirstOrDefault().Value != null)
            {
                foreach (var box in _orderBoxes.Where(x => x.Key.Equals(orderNumber)).FirstOrDefault().Value)
                {
                    var row = _orderBoxModel.NewRow();
                    row[0] = orderNumber;
                    row[1] = box;
                    _orderBoxModel.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// Clears the current order item selection.
        /// </summary>
        public void ClearOrderItemSelection()
        {
            _selectedOrderItem = -1;
            UpdateOrderItemModel();
        }

        /// <summary>
        /// Selects the specified order item.
        /// </summary>
        /// <param name="itemIndex">Index of the order item to select.</param>
        public void SelectOrderItem(int itemIndex)
        {
            if (_selectedOrder == null)
            {
                return;
            }

            _selectedOrderItem = itemIndex;
            UpdateOrderItemModel();
        }

        /// <summary>
        /// Sends all pending orders.
        /// </summary>
        public void SendOrders()
        {
            try
            {
                foreach (var order in _orderList)
                {
                    if (_orderStates[order] == OutputProcessState.Created)
                    {
                        order.Start();
                        _orderStates[order] = OutputProcessState.Queued;
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = string.Format("Sending pending output orders failed!\n\n{0}", ex.Message);
                MessageBox.Show(msg, "IT System Simulator");
            }

            UpdateModel();
        }

        /// <summary>
        /// Sends a cancellation for the currently selected order.
        /// </summary>
        public void CancelCurrentOrder()
        {
            if (_selectedOrder == null)
            {
                return;
            }

            try
            {
                _selectedOrder.Cancel();                
            }
            catch (Exception ex)
            {
                var msg = string.Format("Cancel selected output order '{0}' failed!\n\n{1}", 
                                        _selectedOrder.OrderNumber, ex.Message);

                MessageBox.Show(msg, "IT System Simulator");
            }

            UpdateModel();
        }
        
        /// <summary>
        /// Called when an output order finished.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnOrderFinished(object sender, EventArgs e)
        {
            if (_invokeInstance.InvokeRequired)
            {
                _invokeInstance.Invoke(new EventHandler((s, ee) => { OnOrderFinished(s, ee); }), sender, e);
                return;
            }

            var order = (IOutputProcess)sender;
            _orderStates[order] = order.State;

            UpdateModel();

            this.PackDispensed?.Invoke(this, new PackDispensedArgs() { Packs = order.Packs });
        }

        /// <summary>
        /// Called when a box is released.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">>The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBoxReleased(object sender, EventArgs e)
        {
            if (_invokeInstance.InvokeRequired)
            {
                _invokeInstance.BeginInvoke (new EventHandler((s, ee) => { OnBoxReleased(s, ee); }), sender, e);
                return;
            }

            var order = (IOutputProcess)sender;

            if (_orderBoxes.Keys.Contains(order.OrderNumber))
            {
                _orderBoxes.Where(x => x.Key.Equals(order.OrderNumber)).FirstOrDefault().Value.Add(order.Boxes.Last());
            }
            else
            {
                _orderBoxes.Add(order.OrderNumber, new HashSet<string> { order.Boxes.Last() });
            }

            UpdateOrderBoxes(order.OrderNumber);

            this.BoxReleased?.Invoke(this, new BoxReleasedArgs() { Boxes = _orderBoxModel });
        }

        /// <summary>
        /// Updates the boxes released for a given order
        /// </summary>
        /// <param name="orderNumber">The order number</param>
        private void UpdateOrderBoxes(string orderNumber)
        {
            _orderBoxModel.Clear();

            if (_orderBoxes.Where(x => x.Key.Equals(orderNumber)).FirstOrDefault().Value.Count > 0)
            {
                foreach(var box in _orderBoxes.Where(x => x.Key.Equals(orderNumber)).FirstOrDefault().Value)
                {
                    var row = _orderBoxModel.NewRow();
                    row[0] = orderNumber;
                    row[1] = box;
                    _orderBoxModel.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// Updates the order model itself.
        /// </summary>
        private void UpdateModel()
        {
            _orderModel.Rows.Clear();
 
            foreach (var order in _orderList)
            {
                DataRow row = _orderModel.NewRow();
                row[0] = order.OrderNumber;
                row[1] = order.Priority.ToString();
                row[2] = order.OutputDestination;
                row[3] = order.OutputPoint;
                row[4] = order.BoxNumber;
                row[5] = _orderStates[order].ToString();
                _orderModel.Rows.Add(row);
            }

            if ((_selectedOrder != null) && (_orderList.Contains(_selectedOrder) == false))
            {
                _selectedOrder = null;
            }

            if ((_selectedOrder == null) && (_orderList.Count > 0))
            {
                _selectedOrder = _orderList[0];
            }

            UpdateOrderModel();
        }

        /// <summary>
        /// Updates the order data model.
        /// </summary>
        private void UpdateOrderModel()
        {
            _orderItemModel.Rows.Clear();
            _dispensedPackModel.Rows.Clear();

            if (_selectedOrder == null)
            {
                return;
            }

            if (_selectedOrder != null)
            {
                foreach (var pack in _selectedOrder.Packs)
                {
                    DataRow row = _dispensedPackModel.NewRow();
                    row[0] = pack.Id;
                    row[1] = pack.DeliveryNumber;
                    row[2] = pack.BatchNumber;
                    row[3] = pack.ExternalId;
                    row[4] = string.Format("{0:yyyy-MM-dd}", pack.ExpiryDate);
                    row[5] = pack.IsInFridge;
                    row[6] = pack.SubItemQuantity;
                    row[7] = pack.LabelState.ToString();
                    row[8] = pack.OutputDestination;
                    row[9] = pack.OutputPoint;
                    row[10] = pack.BoxNumber;
                    _dispensedPackModel.Rows.Add(row);
                }
            }


            for (int i = 0; i < _selectedOrder.Criteria.Length; ++i)
            {
                DataRow row = _orderItemModel.NewRow();
                row[0] = i;
                row[1] = _selectedOrder.Criteria[i].ArticleId;
                row[2] = _selectedOrder.Criteria[i].BatchNumber;
                row[3] = _selectedOrder.Criteria[i].ExternalId;
                row[4] = _selectedOrder.Criteria[i].MinimumExpiryDate.HasValue ? string.Format("{0:yyyy-MM-dd}", _selectedOrder.Criteria[i].MinimumExpiryDate) : string.Empty;
                row[5] = _selectedOrder.Criteria[i].PackId;
                row[6] = _selectedOrder.Criteria[i].MachineLocation;
                row[7] = _selectedOrder.Criteria[i].Quantity;
                row[8] = _selectedOrder.Criteria[i].SubItemQuantity;
                _orderItemModel.Rows.Add(row);
            }

            if ((_selectedOrderItem != -1) && (_selectedOrderItem >= _selectedOrder.Criteria.Length))
            {
                _selectedOrderItem = -1;
            }

            if ((_selectedOrderItem == -1) && (_selectedOrder.Criteria.Length > 0))
            {
                _selectedOrderItem = 0;
            }

            UpdateOrderItemModel();
        }

        /// <summary>
        /// Updates the order item data model.
        /// </summary>
        private void UpdateOrderItemModel()
        {
            _itemLabelModel.Rows.Clear();

            if (_selectedOrderItem != -1)
            {
                foreach (var label in _selectedOrder.Criteria[_selectedOrderItem].Labels)
                {
                    DataRow row = _itemLabelModel.NewRow();
                    row[0] = label.TemplateId;
                    row[1] = label.Content;
                    _itemLabelModel.Rows.Add(row);
                }
            }
        }
   
        #endregion
    }
}
