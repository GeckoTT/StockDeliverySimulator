using CareFusion.Lib.StorageSystem.State;
using System.Data;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Class which contains the data model of the storage system components.
    /// </summary>
    public class ComponentsModel
    {
        #region Members

        /// <summary>
        /// Holds the components data model.
        /// </summary>
        private DataTable _componentsModel = new DataTable();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the master article data model.
        /// </summary>
        public DataTable Components
        {
            get { return _componentsModel; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentsModel"/> class.
        /// </summary>
        public ComponentsModel()
        {
            DataColumn column = _componentsModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Type";

            column = _componentsModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "Description";

            column = _componentsModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "State";

            column = _componentsModel.Columns.Add();
            column.DataType = typeof(string);
            column.ColumnName = "StateText";
        }

        /// <summary>
        /// Updates the internal components model with the specified components list.
        /// </summary>
        /// <param name="components">The componennts to use.</param>
        public void Update(IComponent[] components)
        {
            _componentsModel.Rows.Clear();

            foreach (var component in components)
            {
                DataRow row = _componentsModel.NewRow();
             
                row[0] = component.Type;
                row[1] = component.Description;
                row[2] = component.State.ToString();
                row[3] = component.StateText;

                _componentsModel.Rows.Add(row);
            }
        }
        
        #endregion
    }
}
