using System;
using System.Text;

namespace CareFusion.Mosaic.Converters
{
    /// <summary>
    /// Class which defines WWKS 1.14/2.0 / TIOSysMan related protocol related text conversion methods.
    /// </summary>
    public static class TextConverter
    {
        /// <summary>
        /// Escapes invalid XML chars with the Rowa internal character replacing algorithm
        /// </summary>
        /// <param name="inputString">The input string to check for invalid characters.</param>
        /// <returns>Input string with escaped characters.</returns>
        public static string EscapeInvalidXmlChars(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return inputString;
            }

            StringBuilder result = new StringBuilder(inputString.Length);

            for (int i = 0; i < inputString.Length; ++i)
            {
                char c = inputString[i];

                if (c < 0x20)
                {
                    if (c != 0x09 && c != 0x0A && c != 0x0D)
                    {
                        result.AppendFormat("\\x{0:X2}", Convert.ToByte(c));
                        continue;
                    }
                }

                result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// Unescapes invalid XML chars with the Rowa internal character replacing algorithm
        /// </summary>
        /// <param name="inputString">The input string to check for escaped characters.</param>
        /// <returns>Input string with unescaped characters.</returns>
        public static string UnescapeInvalidXmlChars(string inputString)
        {
            if ((string.IsNullOrWhiteSpace(inputString)) ||
                (inputString.Length <= 3) ||
                (inputString.Contains("\\x") == false))
            {
                return inputString;
            }

            try
            {
                int arrPos = 0;
                char[] resultArray = new char[inputString.Length];

                for (int i = 0, max = inputString.Length; i < max; ++i)
                {
                    if ((inputString[i] == '\\') && (i < max - 3) && (inputString[i + 1] == 'x'))
                    {
                        resultArray[arrPos++] = Convert.ToChar(Convert.ToByte(string.Format("{0}{1}",
                                                                                            inputString[i + 2],
                                                                                            inputString[i + 3]), 16));
                        i += 3;
                    }
                    else
                    {
                        resultArray[arrPos++] = inputString[i];
                    }
                }

                return new String(resultArray, 0, arrPos);
            }
            catch (Exception)
            {
                return inputString;
            }
        }

        /// <summary>
        /// Escapes invalid HL7 chars with the CCE character replacing algorithm
        /// </summary>
        /// <param name="inputString">The input string to check for invalid characters.</param>
        /// <returns>Input string with escaped characters.</returns>
        public static string EscapeInvalidHL7Chars(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return inputString;
            }

            StringBuilder result = new StringBuilder(inputString.Length);

            for (int i = 0; i < inputString.Length; ++i)
            {
                char c = inputString[i];

                switch (c)
                {
                    case '|': result.Append(@"\F\"); break;
                    case '^': result.Append(@"\S\"); break;
                    case '&': result.Append(@"\T\"); break;
                    case '~': result.Append(@"\R\"); break;
                    case '\\': result.Append(@"\E\"); break;
                    default: result.Append(c); break;
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Unescapes invalid HL7 chars with the CCE character replacing algorithm
        /// </summary>
        /// <param name="inputString">The input string to check for escaped characters.</param>
        /// <returns>Input string with unescaped characters.</returns>
        public static string UnescapeInvalidHL7Chars(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return inputString;
            }

            inputString = inputString.Replace(@"\F\", "|");
            inputString = inputString.Replace(@"\S\", "^");
            inputString = inputString.Replace(@"\T\", "&");
            inputString = inputString.Replace(@"\R\", "~");
            return inputString.Replace(@"\E\", "\\");
        }
    }
}
