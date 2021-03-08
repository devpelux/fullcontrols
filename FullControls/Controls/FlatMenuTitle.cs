using FullControls.Core;
using System.Windows;
using System.Windows.Controls;

namespace FullControls.Controls
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
        /// Gets or sets the margin of the header.
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
        /// Gets or sets a value indicating if enable automatic alignment to fit with other items.
        /// </summary>
        public bool AlignWithOthers
        {
            get => (bool)GetValue(AlignWithOthersProperty);
            set => SetValue(AlignWithOthersProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AlignWithOthers"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlignWithOthersProperty =
            DependencyProperty.Register(nameof(AlignWithOthers), typeof(bool), typeof(FlatMenuTitle),
                new PropertyMetadata(BoolBox.True));


        static FlatMenuTitle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuTitle),
                new FrameworkPropertyMetadata(typeof(FlatMenuTitle)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FlatMenuTitle"/>.
        /// </summary>
        public FlatMenuTitle() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) { }

        /// <summary>
        /// Prepares the container for the item.
        /// </summary>
        /// <param name="container">Container to prepare.</param>
        /// <param name="item">Item contained.</param>
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
