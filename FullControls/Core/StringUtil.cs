using System;
using System.ComponentModel;
using System.Linq;

namespace FullControls.Core
{
    /// <summary>
    /// Provides a set of <see cref="string"/> extensions.
    /// </summary>
    internal static class StringUtil
    {
        private static readonly char[] doubleSeparators = new char[] { '.', ',' };
        private const char NON_ZERO_DIGIT = '1';

        #region Numeric checkers

        /// <summary>
        /// Checks if the <see cref="string"/> is a <see cref="double"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns><see langword="true"/> if the <see cref="string"/> is a <see cref="double"/>, <see langword="false"/> otherwise.</returns>
        internal static bool IsDouble(this string str) => double.TryParse(str, out _);

        /// <summary>
        /// Checks if the <see cref="string"/> is an <see cref="int"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns><see langword="true"/> if the <see cref="string"/> is an <see cref="int"/>, <see langword="false"/> otherwise.</returns>
        internal static bool IsInt(this string str) => int.TryParse(str, out _);

        /// <summary>
        /// Checks if the <see cref="string"/> contains only numeric chars.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns><see langword="true"/> if the <see cref="string"/> contains only numeric chars, <see langword="false"/> otherwise.</returns>
        internal static bool IsNumeric(this string str) => str.All(char.IsDigit);

        #endregion

        #region Numeric normalizers

        /// <summary>
        /// Normalizes the <see cref="string"/> for the type <see cref="double"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to normalize.</param>
        /// <param name="ignoreFractionalZeros">Ignore if there are only zeros as the fractional part to speed up the algorithm.</param>
        /// <returns>The <see cref="string"/> normalized for the type <see cref="double"/>.</returns>
        /// <exception cref="FormatException"/>
        internal static string NormalizeForDouble(this string str, bool ignoreFractionalZeros = true)
        {
            if (str.IsDouble())
            {
                if (ignoreFractionalZeros)
                {
                    return double.Parse(str).ToString();
                }
                else
                {
                    int lastSeparator = str.LastIndexOfAny(doubleSeparators);
                    if (lastSeparator != -1)
                    {
                        string intPart = double.Parse(str[..(lastSeparator + 1)].Append(NON_ZERO_DIGIT)).ToString().Reduce(1);
                        string fracPart = str[(lastSeparator + 1)..];
                        return string.Concat(intPart, fracPart);
                    }
                    else return double.Parse(str).ToString();
                }
            }
            else throw new FormatException($"{str} is not a valid double.");
        }

        /// <summary>
        /// Normalizes the <see cref="string"/> for the type <see cref="int"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to normalize.</param>
        /// <returns>The <see cref="string"/> normalized for the type <see cref="int"/>.</returns>
        /// <exception cref="FormatException"/>
        internal static string NormalizeForInt(this string str) => str.IsInt() ? int.Parse(str).ToString() : throw new FormatException($"{str} is not a valid int.");

        #endregion

        #region Manipulators

        /// <summary>
        /// Appends a <see cref="char"/> at the end of the <see cref="string"/>.
        /// </summary>
        /// <param name="str">Initial string.</param>
        /// <param name="c"><see cref="char"/> to append.</param>
        /// <returns>A new <see cref="string"/> to which was added the <see cref="char"/> specified.</returns>
        internal static string Append(this string str, char c) => string.Concat(str, c);

        /// <summary>
        /// Appends a <see cref="string"/> at the end of the <see cref="string"/>.
        /// </summary>
        /// <param name="str">Initial string.</param>
        /// <param name="str2"><see cref="string"/> to append.</param>
        /// <returns>A new <see cref="string"/> to which was added the <see cref="string"/> specified.</returns>
        internal static string Append(this string str, string str2) => string.Concat(str, str2);

        /// <summary>
        /// Cuts the <see cref="string"/> by removing a specified number of chars from the end of the <see cref="string"/>.
        /// </summary>
        /// <param name="str">Initial string.</param>
        /// <param name="count">Number of chars to remove from the end of the <see cref="string"/>.</param>
        /// <returns>A new <see cref="string"/> that is equivalent to this <see cref="string"/> except for the removed characters.</returns>
        /// <exception cref="ArgumentOutOfRangeException"/>
        internal static string Reduce(this string str, int count) => count == 0 ? str
            : count > 0 ? count <= str.Length ? str.Remove(str.Length - count)
            : throw new ArgumentOutOfRangeException(nameof(count), "Length must must be less than or equal to length of string.")
            : throw new ArgumentOutOfRangeException(nameof(count), "Length cannot be less than zero.");

        /// <summary>
        /// Returns a <see cref="string"/> by taking only the specified number of chars from the start of the <see cref="string"/>.
        /// </summary>
        /// <param name="str">Initial string.</param>
        /// <param name="count">Number of chars to take from the start of the <see cref="string"/>.</param>
        /// <returns>
        /// A new <see cref="string"/> that contains only the specified number of chars from the start of the original <see cref="string"/>.<br/>
        /// If the original <see cref="string"/> is shorter, returns only the original <see cref="string"/>.
        /// </returns>
        internal static string TakeStr(this string str, int count) => str.Length <= count ? str : str[..count];

        #endregion

        #region Converters

        /// <summary>
        /// Converts the string to an <see cref="int"/>.<br/>
        /// In case of errors returns a specified default value.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to convert.</param>
        /// <param name="defaultValue">The default value used in case of errors.</param>
        /// <returns>An <see cref="int"/> resulting from the conversion, or the default value in case of errors.</returns>
        internal static int ToInt(this string str, int defaultValue = 0) => str.IsInt() ? int.Parse(str) : defaultValue;

        /// <summary>
        /// Converts the string to a <see cref="double"/>.<br/>
        /// In case of errors returns a specified default value.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to convert.</param>
        /// <param name="defaultValue">The default value used in case of errors.</param>
        /// <returns>A <see cref="double"/> resulting from the conversion, or the default value in case of errors.</returns>
        internal static double ToDouble(this string str, double defaultValue = 0) => str.IsDouble() ? double.Parse(str) : defaultValue;

        /// <summary>
        /// Converts the string to the specific type using a <see cref="TypeDescriptor"/> converter.<br/>
        /// In case of errors returns a specified default value.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="str">The <see cref="string"/> to convert.</param>
        /// <param name="defaultValue">The default value used in case of errors.</param>
        /// <returns>Object of the type specified resulting from the conversion, or the default value in case of errors.</returns>
        internal static T? ParseTo<T>(this string str, T? defaultValue = default)
        {
            try
            {
                return (T?)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion
    }
}
