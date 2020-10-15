using System;
using System.Data.SQLite;
using System.Text;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which is the base to combine multiple command filters
    /// </summary>
    public abstract class CommandMultiFilter : CommandFilter
    {
        #region Members

        /// <summary>
        /// List of group members.
        /// </summary>
        private CommandFilter[] _commandFilters;

        #endregion


        #region Properties
        
        /// <summary>
        /// Gets the SQLite parameter definition of the filter object.
        /// </summary>
        public override SQLiteParameter FilterParameter
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the CommandFilters.
        /// </summary>
        public CommandFilter[] CommandFilter
        {
            get { return _commandFilters; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has parameter.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has parameter; otherwise, <c>false</c>.
        /// </value>
        public override bool HasParameter
        {
            get
            {
                foreach (var commandFilter in _commandFilters)
                {
                    if (commandFilter.HasParameter)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="CommandGroup" /> class.
        /// </summary>
        /// <param name="concatType">Concatination type of the group.</param>
        /// <param name="commandFilters">Array of command Filters</param>
        public CommandMultiFilter(ConcatenationType concatType, params CommandFilter[] commandFilters)
            : base(string.Empty, null, ComparisonType.EqualTo, concatType)
        {
            if (commandFilters == null)
            {
                throw new ArgumentException("Invalid group elements specified.");
            }

            _commandFilters = commandFilters;
        }
    }
}
