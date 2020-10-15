using System;
using System.Data.SQLite;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic which is required to easily limit 
    /// a type independent database query.
    /// </summary>
    public class QueryLimitationFilter : CommandFilter
    {
        #region Members

        /// <summary>
        /// Holds the current query limitation count.
        /// </summary>
        private uint _limitCount = 0;

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
            get { return string.Format("LIMIT {0}", _limitCount); }
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
        /// Gets the specified limit count.
        /// </summary>
        public uint LimitCount
        {
            get { return _limitCount; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryLimitationFilter"/> class.
        /// </summary>
        /// <param name="limitCount">The limitation count value to set.</param>
        public QueryLimitationFilter(uint limitCount)
            : base ("notused", null)
        {
            if (limitCount <= 0)
            {
                throw new ArgumentException("Invalid limitCount specified.");
            }

            _limitCount = limitCount;
        }
    }
}
