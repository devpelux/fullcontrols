using FullControls.Controls;

namespace FullControls.Common
{
    /// <summary>
    /// Defines the way of arranging a child in a <see cref="Kaleidoborder"/>.
    /// </summary>
    public enum ChildArrangingMode
    {
        /// <summary>
        /// The child will get the minimum space available.
        /// </summary>
        MinimumSpace,

        /// <summary>
        /// The child will get the space of the main border background minus the padding.
        /// </summary>
        MainBorderSpace
    }
}
