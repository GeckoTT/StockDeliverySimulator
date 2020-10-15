using System;
using System.Data.SQLite;
using System.Globalization;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// This is a case insensitive string collation function for SQLite.
    /// </summary>
    [SQLiteFunction(FuncType = FunctionType.Collation, Name = "ArticleCodeCompare")]
    public class DatabaseCaseInsensitiveCollation : SQLiteFunction
    {
        /// <summary>
        /// Compares the specified article code strings in a specialized Mosaic way.
        /// </summary>
        /// <param name="first">The first string to compare.</param>
        /// <param name="second">The second string to compare.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the lexical relationship between the two strings.
        /// </returns>
        public override int Compare(string first, string second)
        {
            first = first.Trim();
            second = second.Trim();

            var lengthDiff = first.Length - second.Length;

            if (lengthDiff > 0)
            {
                second = string.Format("{0}{1}", new String('0', lengthDiff), second);
            }
            else if (lengthDiff < 0)
            {
                first = string.Format("{0}{1}", new String('0', -lengthDiff), first); 
            }

            return string.Compare(first, second, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase);
        }
    }
}
