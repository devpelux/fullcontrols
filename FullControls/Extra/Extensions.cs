using System.Windows.Media;

namespace FullControls.Extra
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Inverts the color by subtracting every value R, G, B from 255.
        /// </summary>
        /// <param name="color">Colore.</param>
        /// <returns>Inverted color.</returns>
        public static Color Invert(this Color color)
            => Color.FromRgb((byte)(255 - color.R), (byte)(255 - color.G), (byte)(255 - color.B));
    }
}
