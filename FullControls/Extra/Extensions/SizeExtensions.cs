using System.Windows;

namespace FullControls.Extra.Extensions
{
    /// <summary>
    /// Provides a set of <see cref="Size"/> extensions.
    /// </summary>
    public static class SizeExtensions
    {
        /// <summary>
        /// Sum a <see cref="Size"/> to the current <see cref="Size"/>.
        /// </summary>
        /// <param name="a">Current <see cref="Size"/>.</param>
        /// <param name="b"><see cref="Size"/> to sum to the current.</param>
        /// <returns></returns>
        public static Size Add(this Size a, Size b) => new(a.Width + b.Width, a.Height + b.Height);

        /// <summary>
        /// Subtract a <see cref="Size"/> from the current <see cref="Size"/>.
        /// </summary>
        /// <param name="a">Current <see cref="Size"/>.</param>
        /// <param name="b"><see cref="Size"/> to subtract from the current.</param>
        /// <returns></returns>
        public static Size Subtract(this Size a, Size b) => new(a.Width - b.Width, a.Height - b.Height);

        /// <summary>
        /// Invert the <see cref="Size"/> by replacing every value with its negative.
        /// </summary>
        /// <param name="size">Current <see cref="Size"/>.</param>
        /// <returns></returns>
        public static Size Invert(this Size size) => new(-size.Width, -size.Height);

        /// <summary>
        /// Initializes a new <see cref="Size"/> with uniform dimensions.
        /// </summary>
        /// <param name="dim">Dimensions.</param>
        /// <returns>New <see cref="Size"/> with uniform dimensions.</returns>
        public static Size UniformSize(double dim) => new(dim, dim);
    }
}
