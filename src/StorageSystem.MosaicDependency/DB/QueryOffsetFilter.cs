using System;
using System.Data.SQLite;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic which is required to easily skip records in 
    /// a type independent database query.
    /// </summary>
    public class QueryOffsetFilter : CommandFilter
    {
        #region Members

        /// <summary>
        /// Holds the current query offset count.
        /// </summary>
        private uint _offsetCount = 0;

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
            get { return string.Format("OFFSET {0}", _offsetCount); }
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
        /// Initializes a new instance of the <see cref="QueryOffsetFilter"/> class.
        /// </summary>
        /// <param name="offsetCount">The offset count value to set.</param>
        public QueryOffsetFilter(uint offsetCount)
            : base("notused", null)
        {
            if (offsetCount <= 0)
            {
                throw new ArgumentException("Invalid offsetCount specified.");
            }

            _offsetCount = offsetCount;
        }
    }
}
