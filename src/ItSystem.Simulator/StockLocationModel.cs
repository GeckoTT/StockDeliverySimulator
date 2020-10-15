using CareFusion.Lib.StorageSystem.Stock;
using System.Data;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Class which contains the data model of the storage system stock locations.
    /// </summary>
    public class StockLocationModel
    {
        #region Members

        /// <summary>
        /// Holds the stock location data model.
        /// </summary>
        private DataTable _stockLocationsModel = new DataTable();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the stock location data model.
        /// </summary>
        public DataTable StockLocations
        {
            get { return _stockLocationsModel; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="StockLocationModel"/> class.
        /// </summary>
        public StockLocationModel()
        {
            DataColumn column = _stockLocationsModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Id";

            column = _stockLocationsModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Description";
        }

        /// <summary>
        /// Updates the internal stock location model with the specified stock location list.
        /// </summary>
        /// <param name="stockLocations">The stock locations to use.</param>
        public void Update(IStockLocation[] stockLocations)
        {
            _stockLocationsModel.Rows.Clear();

            foreach (var stockLocation in stockLocations)
            {
                DataRow row = _stockLocationsModel.NewRow();

                row[0] = stockLocation.Id;
                row[1] = stockLocation.Description;

                _stockLocationsModel.Rows.Add(row);
            }
        }
        
        #endregion
    }
}
