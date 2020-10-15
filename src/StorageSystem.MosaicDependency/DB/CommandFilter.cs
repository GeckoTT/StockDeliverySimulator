using System;
using System.Data.SQLite;
using System.Text;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic which is required to easily filter 
    /// a type independent database command.
    /// </summary>
    public class CommandFilter
    {
        #region Members

        /// <summary>
        /// Holds the name of the database column which is used to filter within a command.
        /// </summary>
        protected string _columnName = string.Empty;

        /// <summary>
        /// Holds the value of the database column which is used to filter within a command.
        /// </summary>
        protected object _columnValue = null;

        /// <summary>
        /// Holds the comparison type to use.
        /// </summary>
        protected ComparisonType _comparisonType = ComparisonType.EqualTo;

        /// <summary>
        /// Holds the concatenation type to use.
        /// </summary>
        protected ConcatenationType _concatenationType = ConcatenationType.And;

        /// <summary>
        /// Optional index of the command filter.
        /// </summary>
        protected int _filterIndex = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the text representation of the filter object.
        /// </summary>
        public virtual string FilterText
        {
            get 
            {
                if (_columnValue == DBNull.Value)
                {
                    if (_comparisonType == ComparisonType.NotEqualTo)
                    {
                        return string.Format("[{0}] IS NOT NULL", _columnName);
                    }
                    else
                    {
                        return string.Format("[{0}] IS NULL", _columnName);
                    }                   
                }
                else
                {
                    switch (_comparisonType)
                    {
                        case ComparisonType.LargerThan: return string.Format("[{0}]>@{0}{1}", _columnName, _filterIndex);
                        case ComparisonType.SmallerThan: return string.Format("[{0}]<@{0}{1}", _columnName, _filterIndex);
                        case ComparisonType.EqualOrLargerThan: return string.Format("[{0}]>=@{0}{1}", _columnName, _filterIndex);
                        case ComparisonType.EqualOrSmallerThan: return string.Format("[{0}]<=@{0}{1}", _columnName, _filterIndex);
                        case ComparisonType.NotEqualTo: return string.Format("[{0}]!=@{0}{1}", _columnName, _filterIndex);
                        case ComparisonType.Like: return string.Format("[{0}] LIKE @{0}{1}", _columnName, _filterIndex);
                        default: return string.Format("[{0}]=@{0}{1}", _columnName, _filterIndex);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the text representation of the command filter concatenation.
        /// </summary>
        public virtual string ConcatText
        {
            get { return _concatenationType.ToString().ToUpper(); }
        }

        /// <summary>
        /// Gets the SQLite parameter definition of the filter object.
        /// </summary>
        public virtual SQLiteParameter FilterParameter
        {
            get 
            {
                if (_columnValue == DBNull.Value)
                {
                    return null;
                }

                if ((_comparisonType == ComparisonType.Like) &&
                    (_columnValue != null) &&
                    (_columnValue.GetType() == typeof(String)))
                {
                    return new SQLiteParameter(string.Format("@{0}{1}", _columnName, _filterIndex), string.Format("%{0}%", _columnValue));
                }
                else
                {
                    return new SQLiteParameter(string.Format("@{0}{1}", _columnName, _filterIndex), _columnValue);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has parameter.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has parameter; otherwise, <c>false</c>.
        /// </value>
        public virtual bool HasParameter
        {
            get { return true; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFilter" /> class.
        /// </summary>
        /// <param name="columnName">Name of the database column which is used to filter within a command.</param>
        /// <param name="columnValue">Value of the database column which is used to filter within a command.</param>
        /// <param name="comparisonType">Type of comparison to process.</param>
        /// <param name="concatenationType">Type of the concatenation.</param>
        /// <param name="filterIndex">Optional index of the filter to use - if the same filter type is used multiple times.</param>
        public CommandFilter(string columnName, 
                             object columnValue, 
                             ComparisonType comparisonType = ComparisonType.EqualTo,
                             ConcatenationType concatenationType = ConcatenationType.And,
                             int filterIndex = 0)
        {
            _columnName = columnName;
            _comparisonType = comparisonType;
            _filterIndex = filterIndex;
            _concatenationType = concatenationType;
            _columnValue = (columnValue != null) ? columnValue : DBNull.Value;
        }
    }
}
