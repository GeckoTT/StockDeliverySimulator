using System.Data.SQLite;
using System.Text;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic which is required to easily group 
    /// a type independent database query result set.
    /// </summary>
    public class QueryGroupFilter : CommandFilter
    {
        #region Members

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
                    return string.Format("GROUP BY [{0}]", _columnName);
                }

                var result = new StringBuilder();
                result.Append(string.Format("GROUP BY [{0}]", _columnName));

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

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryGroupFilter" /> class.
        /// </summary>
        /// <param name="columnName">Name of the column to use for grouping.</param>
        /// <param name="additionalColumnNames">Optional additional order columns to use.</param>
        public QueryGroupFilter(string columnName, params string[] additionalColumnNames)
            : base(columnName, null)
        {
            _additionalColumnNames = additionalColumnNames;
        }
    }
}
