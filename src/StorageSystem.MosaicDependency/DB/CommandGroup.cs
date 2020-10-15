using System;
using System.Data.SQLite;
using System.Text;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which is used to combine multiple command filters within a braced group.
    /// </summary>
    public class CommandGroup : CommandMultiFilter
    {
        #region Properties

        /// <summary>
        /// Gets the text representation of the filter object.
        /// </summary>
        public override string FilterText
        {
            get 
            {
                if ((CommandFilter == null) || (CommandFilter.Length == 0))
                {
                    return string.Empty;
                }

                var result = new StringBuilder();
                result.Append("(");

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
        
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandGroup" /> class.
        /// </summary>
        /// <param name="concatType">Concatination type of the group.</param>
        /// <param name="groupElements">Elements of the group.</param>
        public CommandGroup(ConcatenationType concatType, params CommandFilter[] groupElements)
            : base(concatType, groupElements)
        {
        }
    }
}
