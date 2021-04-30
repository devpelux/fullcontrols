﻿using System.Windows;

namespace FullControls.Extra.Extensions
{
    /// <summary>
    /// Provides a set of <see cref="Size"/> extensions.
    /// </summary>
    public static class SizeExtensions
    {
        /// <summary>
        /// Sum a <see cref="Size"/> to another.
        /// </summary>
        /// <param name="a">Original <see cref="Size"/>.</param>
        /// <param name="b"><see cref="Size"/> to sum to the original.</param>
        /// <returns></returns>
        public static Size Add(this Size a, Size b) => new(a.Width + b.Width, a.Height + b.Height);

        /// <summary>
        /// Subtract a <see cref="Size"/> to another.
        /// </summary>
        /// <param name="a">Original <see cref="Size"/>.</param>
        /// <param name="b"><see cref="Size"/> to subtract from the original.</param>
        /// <returns></returns>
        public static Size Subtract(this Size a, Size b) => new(a.Width - b.Width, a.Height - b.Height);

        /// <summary>
        /// Initializes a new <see cref="Size"/> with uniform dimensions from a <see cref="double"/> value.
        /// </summary>
        /// <param name="dim">Dimensions.</param>
        /// <returns>New <see cref="Size"/> with uniform dimensions.</returns>
        public static Size UniformSize(double dim) => new(dim, dim);
    }
}
