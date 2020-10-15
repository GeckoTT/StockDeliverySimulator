using System;
using System.Data.SQLite;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic which is required to specify the columns and values
    /// which should only be affected by a type independent database command.
    /// </summary>
    public class CommandParameter
    {
        #region Members

        /// <summary>
        /// Holds the name of the database column which should be affected by a command.
        /// </summary>
        private string _columnName = string.Empty;

        /// <summary>
        /// Holds the value of the database column which should be affected by a command.
        /// </summary>
        private object _columnValue = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the text representation of the parameter object.
        /// </summary>
        public string ParameterText
        {
            get { return string.Format("[{0}]=@{0}", _columnName); }
        }

        /// <summary>
        /// Gets the SQLite parameter definition of the parameter object.
        /// </summary>
        public SQLiteParameter Parameter
        {
            get { return new SQLiteParameter(string.Format("@{0}", _columnName), _columnValue); }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandParameter" /> class.
        /// </summary>
        /// <param name="columnName">Name of the database column which should be affected by a command.</param>
        /// <param name="columnValue">Value of the database column which should be affected by a command.</param>
        public CommandParameter(string columnName, object columnValue)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentException("Invalid columnName specified.");
            }

            _columnName = columnName;
            _columnValue = (columnValue != null) ? columnValue : DBNull.Value;
        }
    }
}
