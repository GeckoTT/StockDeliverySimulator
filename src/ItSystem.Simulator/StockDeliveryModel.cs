using CareFusion.Lib.StorageSystem;
using CareFusion.Lib.StorageSystem.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Class which contains the data model of the stock deliveries.
    /// </summary>
    public class StockDeliveryModel
    {
        #region Members

        /// <summary>
        /// Stock delivery item data model.
        /// </summary>
        private DataTable _stockDeliveryItemModel = new DataTable();

        #endregion

        #region Properties

        /// <summary>
        /// Gets stock delivery data item model.
        /// </summary>
        public DataTable StockDeliveryItems
        {
            get { return _stockDeliveryItemModel; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StockDeliveryModel"/> class.
        /// </summary>
        public StockDeliveryModel()
        {
            DataColumn column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Delivery";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ArticleID";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Name";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Dosage";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Packaging";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(bool);
            column.ColumnName = "Fridge";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "MaxSubItems";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Batch";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "ExternalID";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(DateTime);
            column.ColumnName = "ExpiryDate";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(uint);
            column.ColumnName = "PackCount";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "StockLocation";

            column = _stockDeliveryItemModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "MachineLocation";

        }

        /// <summary>
        /// Sends the current stock delivery set to the specified storage system.
        /// </summary>
        /// <param name="storageSystem">Storage system to send the stock deliveries too.</param>
        public void Send(IStorageSystem storageSystem)
        {
            var deliveryMap = new Dictionary<string, List<DataRow>>();
            var deliveryList = new List<IStockDelivery>();

            foreach (DataRow row in _stockDeliveryItemModel.Rows)
            {
                var deliveryNumber = (row[0] != DBNull.Value) ? ((string)row[0]).Trim() : string.Empty;

                if (deliveryMap.ContainsKey(deliveryNumber) == false)
                {
                    deliveryMap.Add(deliveryNumber, new List<DataRow>());
                }

                deliveryMap[deliveryNumber].Add(row);
            }

            foreach (string deliveryNumber in deliveryMap.Keys)
            {
                var delivery = storageSystem.CreateStockDelivery(deliveryNumber);

                foreach (var itemRow in deliveryMap[deliveryNumber])
                {
                    DateTime? expiryDate = null;

                    if (itemRow[9] != DBNull.Value)
                    {
                        expiryDate = (DateTime)itemRow[9];
                    }

                    delivery.AddItem((itemRow[1] != DBNull.Value) ? (string)itemRow[1] : string.Empty,
                                     (itemRow[2] != DBNull.Value) ? (string)itemRow[2] : string.Empty,
                                     (itemRow[4] != DBNull.Value) ? (string)itemRow[4] : string.Empty,
                                     (itemRow[3] != DBNull.Value) ? (string)itemRow[3] : string.Empty,
                                     (itemRow[5] != DBNull.Value) ? (bool)itemRow[5] : false,
                                     (itemRow[6] != DBNull.Value) ? (uint)itemRow[6] : 0,
                                     (itemRow[7] != DBNull.Value) ? (string)itemRow[7] : string.Empty,
                                     (itemRow[8] != DBNull.Value) ? (string)itemRow[8] : string.Empty,
                                     expiryDate, 
                                     (itemRow[10] != DBNull.Value) ? (uint)itemRow[10] :0,
                                     (itemRow[11] != DBNull.Value) ? (string)itemRow[11] : null,
                                     (itemRow[12] != DBNull.Value) ? (string)itemRow[12] : null);
                }

                deliveryList.Add(delivery);
            }
            
            storageSystem.AddStockDeliveries(deliveryList);
        }

        public void LoadStockDelivery(string fileName)
        {
            _stockDeliveryItemModel.Rows.Clear();

            string[] lines = null;
            using (StreamReader reader = new StreamReader(fileName))
            {
                lines = reader.ReadToEnd().Split('\r', '\n');
                reader.Close();
            }

#warning this doesn't work for other languague.
            if (lines[0] == "Delivery,ArticleID,Name,Dosage,Packaging,Fridge,MaxSubItems,Batch,ExternalId,ExpiryDate,PackCount,StockLocation,MachineLocation")
            {
                // don't process the title line.
                lines[0] = "";
            }

            foreach (string line in lines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    string[] fields = Regex.Split(line, ",");

                    string delivery = fields[0].Trim();
                    string articleID = fields[1].Trim();
                    string name = fields[2].Trim();
                    string dosage = fields[3].Trim();
                    string packaging = fields[4].Trim();
                    bool fridge = (fields[5].Trim()=="Y") ? true : false;
                    int maxSubItems = int.Parse(fields[6].Trim());
                    string batch = fields[7].Trim();
                    string externalId = fields[8].Trim();
                    DateTime expiryDate;
                    DateTime.TryParse(fields[9].Trim(),out expiryDate);
                    int packCount = int.Parse(fields[10].Trim());
                    string stockLocation = fields[11].Trim();
                    string machineLocation = fields[12].Trim();

                    DataRow row = _stockDeliveryItemModel.NewRow();

                    row["Delivery"] = delivery;
                    row["ArticleID"] = articleID;
                    row["Name"] = name;
                    row["Dosage"] = dosage;
                    row["Packaging"] = packaging;
                    row["Fridge"] = fridge;
                    row["MaxSubItems"] = maxSubItems;
                    row["Batch"] = batch;
                    row["ExternalID"] = externalId;
                    row["ExpiryDate"] = expiryDate;
                    row["PackCount"] = packCount;
                    row["StockLocation"] = stockLocation;
                    row["MachineLocation"] = machineLocation;

                    _stockDeliveryItemModel.Rows.Add(row);
                  
                }
            }

           
        }
    }
}
