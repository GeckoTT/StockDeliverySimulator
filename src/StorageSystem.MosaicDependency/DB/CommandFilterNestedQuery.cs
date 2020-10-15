using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic which is required to nest a sub querry
    /// </summary>
    public class CommandFilterNestedQuery : CommandMultiFilter
    {
        #region Members
        /// <summary>
        /// Table name to use in the nested query
        /// </summary>
        private string _nestedTableName;

        /// <summary>
        /// Field Name within the nested Table of the Id that relates to outer table.
        /// </summary>
        private string _nestedJoinningFieldName;

        /// <summary>
        /// Field Name from the outer Table of the Id that relates to outer table.
        /// </summary>
        private string _outerJoinningFieldName;
        #endregion


        #region Properties

        /// <summary>
        /// Gets the text representation of the filter object.
        /// </summary>
        public override string FilterText
        {
            get
            {
                StringBuilder result = new StringBuilder();
                result.Append(String.Format("{0} in (select {1} from {2}", _outerJoinningFieldName, _nestedJoinningFieldName, _nestedTableName));

                if ((CommandFilter != null) && (CommandFilter.Length != 0))
                {
                    result.Append(" where ");
                }

                for (int i = 0; i < CommandFilter.Length; ++i)
                {
                    result.Append(CommandFilter[i].FilterText);

                    if (i < CommandFilter.Length - 1)
                    {
                        if (string.IsNullOrEmpty(CommandFilter[i + 1].ConcatText) == false)
                        {
                            result.Append(string.Format(" {0} ", CommandFilter[i].ConcatText));
                        }
                        else
                        {
                            result.Append(" ");
                        }
                    }
                }

                result.Append(")");
                return result.ToString();
            }
        }

        public override bool HasParameter
        {
            get { return true; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFilterNestedQuery"/> class.
        /// </summary>
        /// <param name="concatType">Concatination type of the group.</param>
        /// <param name="nestedTableName">Name of the nested Table</param>
        /// <param name="nestedJoinningFieldName">Name of the field from the nested table use to join the outer table</param>
        /// <param name="outerJoinningFieldName">Name of the field from the outer table use to join the nested table</param>
        /// <param name="commandFilters">Array of command Filters</param>
        public CommandFilterNestedQuery(ConcatenationType concatType, 
            string nestedTableName,
            string nestedJoinningFieldName,
            string outerJoinningFieldName,
            CommandFilter[] commandFilters)
            : base(concatType, commandFilters)
        {
            _nestedTableName = nestedTableName;
            _nestedJoinningFieldName = nestedJoinningFieldName;
            _outerJoinningFieldName = outerJoinningFieldName;
        }
    }
}
