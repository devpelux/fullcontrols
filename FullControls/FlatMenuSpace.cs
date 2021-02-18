using FullControls.Core;
using System.Windows;
using System.Windows.Controls;

namespace FullControls
{
    /// <summary>
    /// Displays an empty menu item.
    /// </summary>
    public class FlatMenuSpace : Control
    {
        /// <summary>
        /// Creates a new <see cref="FlatMenuSpace"/>.
        /// </summary>
        static FlatMenuSpace()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuSpace), new FrameworkPropertyMetadata(typeof(FlatMenuSpace)));
        }

        internal static void PrepareContainer(Control container)
        {
            if (container != null) container.IsEnabled = false;
        }

        internal static void PrepareContainer(FlatMenuItemContainer container, FlatMenuSpace item)
        {
            if (container != null && item != null)
            {
                container.IsEnabled = false;
                container.PrepareContainer(false, false);
            }
        }
    }
}
