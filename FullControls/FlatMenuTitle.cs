using System.Windows;
using System.Windows.Controls;

namespace FullControls
{
    /// <summary>
    /// Displays an unclickable <see cref="MenuItem"/>.
    /// </summary>
    public class FlatMenuTitle : MenuItem
    {
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
        /// Enables automatic margin adjustement to fit with other <see cref="MenuItem"/>.
        /// </summary>
        public bool AutoMargin
        {
            get => (bool)GetValue(AutoMarginProperty);
            set => SetValue(AutoMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AutoMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoMarginProperty =
            DependencyProperty.Register(nameof(AutoMargin), typeof(bool), typeof(FlatMenuTitle), new PropertyMetadata(true));


        /// <summary>
        /// Creates a new <see cref="FlatMenuTitle"/>.
        /// </summary>
        static FlatMenuTitle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuTitle), new FrameworkPropertyMetadata(typeof(FlatMenuTitle)));
        }

        /// <inheritdoc/>
        protected override DependencyObject GetContainerForItemOverride() => new FlatMenuTitle();
    }
}
