using System;
using System.Linq;
using System.Windows.Media;

namespace FullControls.Extra
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Check if the <see cref="string"/> is a <see cref="double"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns>True is the <see cref="string"/> is a <see cref="double"/>, False otherwise.</returns>
        public static bool IsDouble(this string str) => double.TryParse(str, out _);

        /// <summary>
        /// Check if the <see cref="string"/> is an <see cref="int"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns>True is the <see cref="string"/> is an <see cref="int"/>, False otherwise.</returns>
        public static bool IsInt(this string str) => int.TryParse(str, out _);

        /// <summary>
        /// Check if the <see cref="string"/> contains only numeric chars.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to check.</param>
        /// <returns>True is the <see cref="string"/> contains only numeric chars, False otherwise.</returns>
        public static bool IsNumeric(this string str) => str.All(char.IsDigit);

        /// <summary>
        /// Normalize the string for the type <see cref="double"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to normalize.</param>
        /// <returns>The <see cref="string"/> normalized for the type <see cref="double"/>.</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public static string NormalizeForDouble(this string str)
        {
            char end = str.Last();
            return $"{double.Parse(str)}{(end is '.' or ',' ? end : "")}";
        }

        /// <summary>
        /// Inverts the color by subtracting every value R, G, B from 255.
        /// </summary>
        /// <param name="color">Colore.</param>
        /// <returns>Inverted color.</returns>
        public static Color Invert(this Color color)
            => Color.FromRgb((byte)(255 - color.R), (byte)(255 - color.G), (byte)(255 - color.B));
    }
}
