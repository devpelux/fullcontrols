using System.Windows;

namespace FullControls.Extra.Extensions
{
    /// <summary>
    /// Provides a set of <see cref="Thickness"/> extensions.
    /// </summary>
    public static class ThicknessExtensions
    {
        /// <summary>
        /// Sum a <see cref="Thickness"/> to the current <see cref="Thickness"/>.
        /// </summary>
        /// <param name="a">Current <see cref="Thickness"/>.</param>
        /// <param name="b"><see cref="Thickness"/> to sum to the current.</param>
        /// <returns></returns>
        public static Thickness Add(this Thickness a, Thickness b) => new(a.Left + b.Left, a.Top + b.Top, a.Right + b.Right, a.Bottom + b.Bottom);

        /// <summary>
        /// Subtract a <see cref="Thickness"/> from the current <see cref="Thickness"/>.
        /// </summary>
        /// <param name="a">Current <see cref="Thickness"/>.</param>
        /// <param name="b"><see cref="Thickness"/> to subtract from the current.</param>
        /// <returns></returns>
        public static Thickness Subtract(this Thickness a, Thickness b) => new(a.Left - b.Left, a.Top - b.Top, a.Right - b.Right, a.Bottom - b.Bottom);

        /// <summary>
        /// Invert the <see cref="Thickness"/> by replacing every value with its negative.
        /// </summary>
        /// <param name="thickness">Current <see cref="Thickness"/>.</param>
        /// <returns></returns>
        public static Thickness Invert(this Thickness thickness) => new(-thickness.Left, -thickness.Top, -thickness.Right, -thickness.Bottom);
    }
}
