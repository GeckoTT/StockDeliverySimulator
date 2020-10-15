using System;
using CareFusion.Mosaic.Interfaces.Messages.Task;
using CareFusion.Mosaic.Interfaces.Types.Output;

namespace CareFusion.Mosaic.Converters
{
    /// <summary>
    /// Class which defines protocol related type conversion methods.
    /// </summary>
    public static class TypeConverter
    {
        #region Constants

        /// <summary>
        /// Defines an empty date according to Vmax protocol implementation.
        /// </summary>
        private static DateTime EmptyDate = new DateTime(1899, 12, 30);

        #endregion

        /// <summary>
        /// Converts the specified string to the enum of the specified type in a safe manner.
        /// </summary>
        /// <typeparam name="T">Type to convert the string to.</typeparam>
        /// <param name="enumString">The enum string to convert.</param>
        /// <param name="defaultValue">The default value to set, if the conversion fails.</param>
        /// <returns></returns>
        public static T ConvertEnum<T>(string enumString, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(enumString))
            {
                return defaultValue;
            }

            T result = defaultValue;

            if (Enum.TryParse<T>(enumString, out result) == false)
            {
                return defaultValue;
            }

            return result;
        }

        /// <summary>
        /// Converts the specified boolean value into a valid boolean string.
        /// </summary>
        /// <param name="booleanString">The boolean value to convert.</param>
        /// <returns>Appro</returns>
        public static bool ConvertBool(string booleanString)
        {
            bool result = false;

            if (string.IsNullOrWhiteSpace(booleanString))
            {
                return result;
            }

            if (bool.TryParse(booleanString, out result) == false)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Converts the specified int string into an integer.
        /// </summary>
        /// <param name="intString">The number string to convert.</param>
        /// <returns>An appropriate conversion of the specified int string.</returns>
        public static int ConvertInt(string intString)
        {
            int result = 0;

            if (string.IsNullOrWhiteSpace(intString))
            {
                return result;
            }

            if (int.TryParse(intString, out result) == false)
            {
                result = 0;
            }

            return result;
        }
        
        /// <summary>
        /// Converts the specified long string into an unsigned integer.
        /// </summary>
        /// <param name="longString">The ulong string to convert.</param>
        /// <returns>An appropriate conversion of the specified ulong string.</returns>
        public static ulong ConvertULong(string longString)
        {
            ulong result = 0;

            if (string.IsNullOrWhiteSpace(longString))
            {
                return result;
            }

            if (ulong.TryParse(longString, out result) == false)
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Converts the specified input string into a save string (not null).
        /// </summary>
        /// <param name="inputString">The input string to convert.</param>
        /// <returns>Always returns a valid string.</returns>
        public static string ConvertString(string inputString)
        {
            return (inputString == null) ? string.Empty : inputString;
        }

        /// <summary>
        /// Converts the specified date string into a valid Mosaic date value.
        /// </summary>
        /// <param name="dateString">The date string to convert.</param>
        /// <returns>The converted date value.</returns>
        public static DateTime ConvertDate(string dateString)
        {
            DateTime result = DateTime.MinValue;

            if (string.IsNullOrWhiteSpace(dateString))
            {
                return result;
            }

            if (DateTime.TryParse(dateString, out result))
            {
                if (result == EmptyDate)
                {
                    result = DateTime.MinValue;
                }
            }
            else
            {
                result = DateTime.MinValue;
            }

            return result;
        }

        /// <summary>
        /// Converts the specified date value into a valid protocol date value.
        /// </summary>
        /// <param name="date">The date value to convert.</param>
        /// <returns>The converted protocol date value.</returns>
        public static string ConvertDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return string.Format("{0:yyyy-MM-dd}", EmptyDate);
            }

            return string.Format("{0:yyyy-MM-dd}", date);
        }

        /// <summary>
        /// Converts the specified date value into a valid protocol date time value.
        /// </summary>
        /// <param name="date">The date value to convert.</param>
        /// <returns>The converted protocol date time value.</returns>
        public static string ConvertDateTime(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return string.Format("{0:yyyy-MM-ddTHH:mm:ssZ}", EmptyDate);
            }

            return string.Format("{0:yyyy-MM-ddTHH:mm:ssZ}", date);
        }

        /// <summary>
        /// Converts the specified date value into a valid protocol date value or null.
        /// </summary>
        /// <param name="date">The date value to convert.</param>
        /// <returns>The converted protocol date value or null.</returns>
        public static string ConvertDateNull(DateTime date)
        {
            if ((date == DateTime.MinValue) || (date == DateTime.MaxValue))
            {
                return null;
            }

            return string.Format("{0:yyyy-MM-dd}", date);
        }

        /// <summary>
        /// Converts the specified date value into a valid protocol date time value or null.
        /// </summary>
        /// <param name="date">The date value to convert.</param>
        /// <returns>The converted protocol date time value or null.</returns>
        public static string ConvertDateTimeNull(DateTime date)
        {
            if ((date == DateTime.MinValue) || (date == DateTime.MaxValue))
            {
                return null;
            }

            return string.Format("{0:yyyy-MM-ddTHH:mm:ssZ}", date);
        }

        /// <summary>
        /// Converts the specified state string into a valid state enumeration value.
        /// </summary>
        /// <param name="stateString">The state string to convert.</param>
        /// <returns>The valid state enumeration value</returns>
        public static StockOutputOrderState ConvertOrderState(string stateString)
        {
            StockOutputOrderState result = StockOutputOrderState.Rejected;

            if (string.IsNullOrWhiteSpace(stateString))
            {
                return result;
            }

            if (Enum.TryParse<StockOutputOrderState>(stateString, out result) == false)
            {
                result = StockOutputOrderState.Rejected;
            }

            return result;
        }

        /// <summary>
        /// Converts the specified state string into a valid state enumeration value.
        /// </summary>
        /// <param name="stateString">The state string to convert.</param>
        /// <returns>The valid state enumeration value</returns>
        public static TaskState ConvertTaskState(string stateString)
        {
            TaskState result = TaskState.Unknown;

            if (string.IsNullOrWhiteSpace(stateString))
            {
                return result;
            }

            if (Enum.TryParse<TaskState>(stateString, out result) == false)
            {
                result = TaskState.Unknown;
            }

            return result;
        }

        /// <summary>
        /// Converts the specified output priority string into an according integer value.
        /// </summary>
        /// <param name="priority">The priority string to convert.</param>
        /// <returns>The converted priority integer value.</returns>
        public static int ConvertOutputPriority(string priority)
        {
            if (string.IsNullOrEmpty(priority))
                return 3;

            if (string.Compare(priority, "Normal") == 0)
                return 3;

            if (string.Compare(priority, "Low") == 0)
                return 5;

            if (string.Compare(priority, "High") == 0)
                return 1;

            return 3;
        }

        /// <summary>
        /// Converts the specified output priority integer into an according string value.
        /// </summary>
        /// <param name="priority">The priority integer to convert.</param>
        /// <returns>The converted priority string value.</returns>
        public static string ConvertOutputPriority(int priority)
        {
            if (priority < 3)
                return "High";

            if (priority > 3)
                return "Low";

            return "Normal";
        }
    }
}
