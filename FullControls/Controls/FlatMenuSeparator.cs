using FullControls.Core;
using System.Windows;
using System.Windows.Controls;

namespace FullControls.Controls
{
    /// <summary>
    /// Displays an empty menu item with a colored line inside.
    /// </summary>
    public class FlatMenuSeparator : Control
    {
        /// <summary>
        /// CornerRadius of the separator line.
        /// </summary>
        public CornerRadius SeparatorCornerRadius
        {
            get => (CornerRadius)GetValue(SeparatorCornerRadiusProperty);
            set => SetValue(SeparatorCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SeparatorCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SeparatorCornerRadiusProperty =
            DependencyProperty.Register(nameof(SeparatorCornerRadius), typeof(CornerRadius), typeof(FlatMenuSeparator), new FrameworkPropertyMetadata(new CornerRadius()));

        /// <summary>
        /// Height of the separator line.
        /// </summary>
        /// <remarks>(It has no effect if <see cref="Orientation"/> is set to <see cref="Orientation.Vertical"/>)</remarks>
        public double SeparatorHeight
        {
            get { return (double)GetValue(SeparatorHeightProperty); }
            set { SetValue(SeparatorHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SeparatorHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SeparatorHeightProperty =
            DependencyProperty.Register(nameof(SeparatorHeight), typeof(double), typeof(FlatMenuSeparator), new FrameworkPropertyMetadata(1d));

        /// <summary>
        /// Width of the separator line.
        /// </summary>
        /// <remarks>(It has no effect if <see cref="Orientation"/> is set to <see cref="Orientation.Horizontal"/>)</remarks>
        public double SeparatorWidth
        {
            get { return (double)GetValue(SeparatorWidthProperty); }
            set { SetValue(SeparatorWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SeparatorWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SeparatorWidthProperty =
            DependencyProperty.Register(nameof(SeparatorWidth), typeof(double), typeof(FlatMenuSeparator), new FrameworkPropertyMetadata(1d));

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
            DependencyProperty.Register(nameof(AlignWithOthers), typeof(bool), typeof(FlatMenuSeparator), new PropertyMetadata(false));


        /// <summary>
        /// Creates a new <see cref="FlatMenuSeparator"/>.
        /// </summary>
        static FlatMenuSeparator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuSeparator), new FrameworkPropertyMetadata(typeof(FlatMenuSeparator)));
        }

        internal static void PrepareContainer(FlatMenuItemContainer container, FlatMenuSeparator item)
        {
            if (container != null && item != null)
            {
                container.IsEnabled = false;
                if (item.AlignWithOthers) container.PrepareContainer(true, false);
                else container.PrepareContainer(false, false);
            }
        }
    }
}
