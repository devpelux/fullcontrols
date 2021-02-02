using System.Windows;
using System.Windows.Controls;

namespace FullControls
{
    /// <summary>
    /// Displays an empty space with a colored line as <see cref="MenuItem"/>.
    /// </summary>
    public class FlatMenuSeparator : MenuItem
    {
        /// <summary>
        /// CornerRadius of the control.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FlatMenuSeparator));

        /// <summary>
        /// Height of the separator line.
        /// </summary>
        /// <remarks>(It has no effect if <see cref="SeparatorWidth"/> is set to <see cref="Orientation.Vertical"/>)</remarks>
        public double SeparatorHeight
        {
            get { return (double)GetValue(SeparatorHeightProperty); }
            set { SetValue(SeparatorHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SeparatorHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SeparatorHeightProperty =
            DependencyProperty.Register(nameof(SeparatorHeight), typeof(double), typeof(FlatMenuSeparator), new PropertyMetadata(1d));

        /// <summary>
        /// Width of the separator line.
        /// </summary>
        /// <remarks>(It has no effect if <see cref="SeparatorWidth"/> is set to <see cref="Orientation.Horizontal"/>)</remarks>
        public double SeparatorWidth
        {
            get { return (double)GetValue(SeparatorWidthProperty); }
            set { SetValue(SeparatorWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SeparatorWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SeparatorWidthProperty =
            DependencyProperty.Register(nameof(SeparatorWidth), typeof(double), typeof(FlatMenuSeparator), new PropertyMetadata(1d));

        /// <summary>
        /// Orientation of the separator.
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Orientation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(FlatMenuSeparator), new PropertyMetadata(Orientation.Horizontal));

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
            DependencyProperty.Register(nameof(AutoMargin), typeof(bool), typeof(FlatMenuSeparator), new PropertyMetadata(false));


        /// <summary>
        /// Creates a new <see cref="FlatMenuSeparator"/>.
        /// </summary>
        static FlatMenuSeparator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuSeparator), new FrameworkPropertyMetadata(typeof(FlatMenuSeparator)));
        }

        /// <inheritdoc/>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new FlatMenuSeparator();
        }
    }
}
