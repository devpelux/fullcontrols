using System.Windows;

namespace FullControls.Extra.Extensions
{
    /// <summary>
    /// Provides a set of <see cref="Thickness"/> extensions.
    /// </summary>
    public static class ThicknessExtensions
    {
        /// <summary>
        /// Sum a <see cref="Thickness"/> to another.
        /// </summary>
        /// <param name="a">Original <see cref="Thickness"/>.</param>
        /// <param name="b"><see cref="Thickness"/> to sum to the original.</param>
        /// <returns></returns>
        public static Thickness Add(this Thickness a, Thickness b) => new(a.Left + b.Left, a.Top + b.Top, a.Right + b.Right, a.Bottom + b.Bottom);

        /// <summary>
        /// Subtract a <see cref="Thickness"/> to another.
        /// </summary>
        /// <param name="a">Original <see cref="Thickness"/>.</param>
        /// <param name="b"><see cref="Thickness"/> to subtract from the original.</param>
        /// <returns></returns>
        public static Thickness Subtract(this Thickness a, Thickness b) => new(a.Left - b.Left, a.Top - b.Top, a.Right - b.Right, a.Bottom - b.Bottom);
    }
}
