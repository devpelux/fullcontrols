using FullControls.Core;
using System.Windows;
using System.Windows.Controls;

namespace FullControls
{
    /// <summary>
    /// Displays an unclickable menu item.
    /// </summary>
    public class FlatMenuTitle : Control
    {
        /// <summary>
        /// Gets or sets the item that labels the control.
        /// </summary>
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Header"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(object), typeof(FlatMenuTitle));

        /// <summary>
        /// Margin of the header.
        /// </summary>
        public Thickness HeaderMargin
        {
            get => (Thickness)GetValue(HeaderMarginProperty);
            set => SetValue(HeaderMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderMarginProperty =
            DependencyProperty.Register(nameof(HeaderMargin), typeof(Thickness), typeof(FlatMenuTitle));

        /// <summary>
        /// Enables automatic alignment to fit with other items.
        /// </summary>
        public bool AlignWithOthers
        {
            get => (bool)GetValue(AlignWithOthersProperty);
            set => SetValue(AlignWithOthersProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AlignWithOthers"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlignWithOthersProperty =
            DependencyProperty.Register(nameof(AlignWithOthers), typeof(bool), typeof(FlatMenuTitle), new PropertyMetadata(true));


        /// <summary>
        /// Creates a new <see cref="FlatMenuTitle"/>.
        /// </summary>
        static FlatMenuTitle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuTitle), new FrameworkPropertyMetadata(typeof(FlatMenuTitle)));
        }

        internal static void PrepareContainer(FlatMenuItemContainer container, FlatMenuTitle item)
        {
            if (container != null && item != null)
            {
                container.IsEnabled = false;
                if (item.AlignWithOthers) container.PrepareContainer(true, true);
                else container.PrepareContainer(false, false);
            }
        }
    }
}
