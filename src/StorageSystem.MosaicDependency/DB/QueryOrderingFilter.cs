using System.Data.SQLite;
using System.Text;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic which is required to easily order 
    /// a type independent database query result set.
    /// </summary>
    public class QueryOrderingFilter : CommandFilter
    {
        #region Members

        /// <summary>
        /// Holds the current ordering type.
        /// </summary>
        private OrderingType _orderingType = OrderingType.Asc;

        /// <summary>
        /// Optional additional column names to use.
        /// </summary>
        private string[] _additionalColumnNames;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the text representation of the command filter concatenation.
        /// </summary>
        public override string ConcatText
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets the text representation of the filter object.
        /// </summary>
        public override string FilterText
        {
            get 
            {
                if ((_additionalColumnNames == null) || (_additionalColumnNames.Length == 0))
                {
                    return string.Format("ORDER BY [{0}] {1}", _columnName, _orderingType.ToString().ToUpper());
                }

                var result = new StringBuilder();
                result.Append(string.Format("ORDER BY [{0}]", _columnName));

                foreach (var additionalColumn in _additionalColumnNames)
                {
                    result.Append(string.Format(",[{0}]", additionalColumn));
                }

                return result.ToString();
            }
        }

        /// <summary>
        /// Gets the SQLite parameter definition of the filter object.
        /// </summary>
        public override SQLiteParameter FilterParameter
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has parameter.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has parameter; otherwise, <c>false</c>.
        /// </value>
        public override bool HasParameter
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the name of the ordering column.
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
        }

        /// <summary>
        /// Gets the type of the ordering.
        /// </summary>
        public OrderingType OrderingType
        {
            get { return _orderingType; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOrderingFilter" /> class.
        /// </summary>
        /// <param name="columnName">Name of the column to use for ordering.</param>
        /// <param name="orderingType">Type of the ordering for the result set.</param>
        /// <param name="additionalColumnNames">Optional additional order columns to use.</param>
        public QueryOrderingFilter(string columnName, OrderingType orderingType = OrderingType.Asc, params string[] additionalColumnNames)
            : base(columnName, null)
        {
            _orderingType = orderingType;
            _additionalColumnNames = additionalColumnNames;
        }
    }
}
