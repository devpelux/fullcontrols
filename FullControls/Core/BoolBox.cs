namespace FullControls.Core
{
    /// <summary>
    /// Provides boxed values for <see cref="bool"/> values.
    /// </summary>
    internal static class BoolBox
    {
        /// <summary>
        /// Boxed value for <see langword="true"/>.
        /// </summary>
        internal static readonly object True = true;

        /// <summary>
        /// Boxed value for <see langword="false"/>.
        /// </summary>
        internal static readonly object False = false;


        /// <summary>
        /// Boxes a <see cref="bool"/> value.
        /// </summary>
        /// <param name="value">Value to box.</param>
        internal static object Box(bool value) => value ? True : False;

        /// <summary>
        /// Unboxes a <see cref="bool"/> value.
        /// </summary>
        /// <param name="value">Value to unbox.</param>
        internal static bool Unbox(object value) => (bool)value;
    }
}
