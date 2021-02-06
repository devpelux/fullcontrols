using System.Windows;
using System.Windows.Controls;

namespace FullControls
{
    /// <summary>
    /// Displays an empty space as <see cref="MenuItem"/>.
    /// </summary>
    public class FlatMenuSpace : MenuItem
    {
        /// <summary>
        /// Creates a new <see cref="FlatMenuSpace"/>.
        /// </summary>
        static FlatMenuSpace()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuSpace), new FrameworkPropertyMetadata(typeof(FlatMenuSpace)));
        }

        /// <inheritdoc/>
        protected override DependencyObject GetContainerForItemOverride() => new FlatMenuSpace();
    }
}
