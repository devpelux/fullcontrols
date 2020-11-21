using System.Windows.Media;

namespace FullControls.Extra
{
    internal static class Extensions
    {
        internal static Color Invert(this Color color)
            => Color.FromRgb((byte)(255 - color.R), (byte)(255 - color.G), (byte)(255 - color.B));
    }
}
