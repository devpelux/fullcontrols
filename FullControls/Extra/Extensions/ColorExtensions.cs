using System.Windows.Media;

namespace FullControls.Extra.Extensions
{
    /// <summary>
    /// Provides a set of <see cref="Color"/> extensions.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Invert the color by subtracting every value R, G, B from 255.
        /// </summary>
        /// <param name="color">Colore.</param>
        /// <returns>Inverted color.</returns>
        public static Color Invert(this Color color)
            => Color.FromRgb((byte)(255 - color.R), (byte)(255 - color.G), (byte)(255 - color.B));
    }
}
