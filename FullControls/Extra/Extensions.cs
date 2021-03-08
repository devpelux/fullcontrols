using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace FullControls.Extra
{
    /// <summary>
    /// Provides a set of extensions.
    /// </summary>
    public static class Extensions
    {
        private static readonly char[] doubleSeparators = new char[] { '.', ',' };
        private const char NON_ZERO_DIGIT = '1';

        /// <summary>
        /// Check if the <see cref="string"/> is a <see cref="double"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns><see langword="true"/> if the <see cref="string"/> is a <see cref="double"/>, <see langword="false"/> otherwise.</returns>
        public static bool IsDouble(this string str) => double.TryParse(str, out _);

        /// <summary>
        /// Check if the <see cref="string"/> is an <see cref="int"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns><see langword="true"/> if the <see cref="string"/> is an <see cref="int"/>, <see langword="false"/> otherwise.</returns>
        public static bool IsInt(this string str) => int.TryParse(str, out _);

        /// <summary>
        /// Check if the <see cref="string"/> contains only numeric chars.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns><see langword="true"/> if the <see cref="string"/> contains only numeric chars, <see langword="false"/> otherwise.</returns>
        public static bool IsNumeric(this string str) => str.All(char.IsDigit);

        /// <summary>
        /// Normalize the string for the type <see cref="double"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to normalize.</param>
        /// <param name="ignoreFractionalZeros">Ignore if there are only zeros as the fractional part to speed up the algorithm.</param>
        /// <returns>The <see cref="string"/> normalized for the type <see cref="double"/>.</returns>
        /// <exception cref="FormatException"/>
        public static string NormalizeForDouble(this string str, bool ignoreFractionalZeros = true)
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
                        string intPart = double.Parse(str.Substring(0, lastSeparator + 1).Append(NON_ZERO_DIGIT)).ToString().Reduce(1);
                        string fracPart = str.Substring(lastSeparator + 1);
                        return string.Concat(intPart, fracPart);
                    }
                    else return double.Parse(str).ToString();
                }
            }
            else throw new FormatException($"{str} is not a valid double.");
        }

        /// <summary>
        /// Normalize the string for the type <see cref="int"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to normalize.</param>
        /// <returns>The <see cref="string"/> normalized for the type <see cref="int"/>.</returns>
        /// <exception cref="FormatException"/>
        public static string NormalizeForInt(this string str) => str.IsInt() ? int.Parse(str).ToString() : throw new FormatException($"{str} is not a valid int.");

        /// <summary>
        /// Append a <see cref="char"/> at the end of the string.
        /// </summary>
        /// <param name="str">Initial string.</param>
        /// <param name="c"><see cref="char"/> to append.</param>
        /// <returns>A new string to which was added the <see cref="char"/> specified.</returns>
        public static string Append(this string str, char c) => string.Concat(str, c);

        /// <summary>
        /// Append a <see cref="string"/> at the end of the string.
        /// </summary>
        /// <param name="str">Initial string.</param>
        /// <param name="str2"><see cref="string"/> to append.</param>
        /// <returns>A new string to which was added the <see cref="string"/> specified.</returns>
        public static string Append(this string str, string str2) => string.Concat(str, str2);

        /// <summary>
        /// Cut the string by a specified length from the end.
        /// </summary>
        /// <param name="str">Initial string.</param>
        /// <param name="length">Number of chars to remove from the end of the string.</param>
        /// <returns>A new string that is equivalent to this string except for the removed characters.</returns>
        public static string Reduce(this string str, int length) => length == 0 ? str
            : length > 0 ? length <= str.Length ? str.Remove(str.Length - length)
            : throw new ArgumentOutOfRangeException(nameof(length), "Length must must be less than or equal to length of string.")
            : throw new ArgumentOutOfRangeException(nameof(length), "Length cannot be less than zero.");

        /// <summary>
        /// Invert the color by subtracting every value R, G, B from 255.
        /// </summary>
        /// <param name="color">Colore.</param>
        /// <returns>Inverted color.</returns>
        public static Color Invert(this Color color)
            => Color.FromRgb((byte)(255 - color.R), (byte)(255 - color.G), (byte)(255 - color.B));

        /// <summary>
        /// Check if the <see cref="DependencyProperty"/> is <see langword="null"/>.
        /// </summary>
        /// <param name="dependencyObject"><see cref="DependencyObject"/> that contains the property.</param>
        /// <param name="dependencyProperty"><see cref="DependencyProperty"/> to check if is <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if is <see langword="null"/>, <see langword="false"/> otherwise.</returns>
        public static bool IsNull(this DependencyObject dependencyObject, DependencyProperty dependencyProperty)
            => dependencyObject.GetValue(dependencyProperty) == null;

        /// <summary>
        /// Check if the <see cref="DependencyProperty"/> is not <see langword="null"/>.
        /// </summary>
        /// <param name="dependencyObject"><see cref="DependencyObject"/> that contains the property.</param>
        /// <param name="dependencyProperty"><see cref="DependencyProperty"/> to check if is not <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if is not <see langword="null"/>, <see langword="false"/> otherwise.</returns>
        public static bool IsNotNull(this DependencyObject dependencyObject, DependencyProperty dependencyProperty)
            => dependencyObject.GetValue(dependencyProperty) != null;
    }
}
