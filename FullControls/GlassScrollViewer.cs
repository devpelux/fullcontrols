using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// Represents a scrollable area that can contain other visible elements.
    /// </summary>
    public class GlassScrollViewer : ScrollViewer
    {
        /// <summary>
        /// Place the scrollbars inside the scrollviewer.
        /// </summary>
        public bool PlaceScrollBarsInside
        {
            get => (bool)GetValue(PlaceScrollBarsInsideProperty);
            set => SetValue(PlaceScrollBarsInsideProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PlaceScrollBarsInside"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PlaceScrollBarsInsideProperty =
            DependencyProperty.Register(nameof(PlaceScrollBarsInside), typeof(bool), typeof(GlassScrollViewer));

        /// <summary>
        /// Margin of the vertical scrollbar.
        /// </summary>
        public Thickness VerticalScrollBarMargin
        {
            get => (Thickness)GetValue(VerticalScrollBarMarginProperty);
            set => SetValue(VerticalScrollBarMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarMarginProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarMargin), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Margin of the horizontal scrollbar.
        /// </summary>
        public Thickness HorizontalScrollBarMargin
        {
            get => (Thickness)GetValue(HorizontalScrollBarMarginProperty);
            set => SetValue(HorizontalScrollBarMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarMarginProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarMargin), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Thickness of the scrollbars.
        /// </summary>
        public double ScrollBarsThickness
        {
            get => (double)GetValue(ScrollBarsThicknessProperty);
            set => SetValue(ScrollBarsThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollBarsThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollBarsThicknessProperty =
            DependencyProperty.Register(nameof(ScrollBarsThickness), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// CornerRadius of the scrollbars.
        /// </summary>
        public CornerRadius ScrollBarsCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollBarsCornerRadiusProperty);
            set => SetValue(ScrollBarsCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollBarsCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollBarsCornerRadiusProperty =
            DependencyProperty.Register(nameof(ScrollBarsCornerRadius), typeof(CornerRadius), typeof(GlassScrollViewer));

        /// <summary>
        /// Opacity of the scrollbars when in normal state.
        /// </summary>
        public double ScrollBarsOpacityNormal
        {
            get => (double)GetValue(ScrollBarsOpacityNormalProperty);
            set => SetValue(ScrollBarsOpacityNormalProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollBarsOpacityNormal"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollBarsOpacityNormalProperty =
            DependencyProperty.Register(nameof(ScrollBarsOpacityNormal), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Opacity of the scrollbars when the mouse is over the control.
        /// </summary>
        public double ScrollBarsOpacityOnMouseOver
        {
            get => (double)GetValue(ScrollBarsOpacityOnMouseOverProperty);
            set => SetValue(ScrollBarsOpacityOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollBarsOpacityOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollBarsOpacityOnMouseOverProperty =
            DependencyProperty.Register(nameof(ScrollBarsOpacityOnMouseOver), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Opacity of the scrollbars when is pressed.
        /// </summary>
        public double ScrollBarsOpacityOnMouseDown
        {
            get => (double)GetValue(ScrollBarsOpacityOnMouseDownProperty);
            set => SetValue(ScrollBarsOpacityOnMouseDownProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollBarsOpacityOnMouseDown"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollBarsOpacityOnMouseDownProperty =
            DependencyProperty.Register(nameof(ScrollBarsOpacityOnMouseDown), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Brush of the scrollbars.
        /// </summary>
        public Brush ScrollBarsColor
        {
            get => (Brush)GetValue(ScrollBarsColorProperty);
            set => SetValue(ScrollBarsColorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollBarsColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollBarsColorProperty =
            DependencyProperty.Register(nameof(ScrollBarsColor), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Enables the increase and decrease buttons.
        /// </summary>
        public bool EnableButtons
        {
            get => (bool)GetValue(EnableButtonsProperty);
            set => SetValue(EnableButtonsProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableButtons"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableButtonsProperty =
            DependencyProperty.Register(nameof(EnableButtons), typeof(bool), typeof(GlassScrollViewer));

        /// <summary>
        /// Size of the increase and decrease buttons.
        /// </summary>
        public double ButtonsSize
        {
            get => (double)GetValue(ButtonsSizeProperty);
            set => SetValue(ButtonsSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsSizeProperty =
            DependencyProperty.Register(nameof(ButtonsSize), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Font of the increase and decrease buttons (if used a character).
        /// </summary>
        public FontFamily ButtonsFont
        {
            get => (FontFamily)GetValue(ButtonsFontProperty);
            set => SetValue(ButtonsFontProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsFont"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsFontProperty =
            DependencyProperty.Register(nameof(ButtonsFont), typeof(FontFamily), typeof(GlassScrollViewer));

        /// <summary>
        /// Size of the content of the increase and decrease buttons.
        /// </summary>
        public double ButtonsContentSize
        {
            get => (double)GetValue(ButtonsContentSizeProperty);
            set => SetValue(ButtonsContentSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsContentSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsContentSizeProperty =
            DependencyProperty.Register(nameof(ButtonsContentSize), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Content of the up button.
        /// </summary>
        public object UpButtonContent
        {
            get => GetValue(UpButtonContentProperty);
            set => SetValue(UpButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UpButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UpButtonContentProperty =
            DependencyProperty.Register(nameof(UpButtonContent), typeof(object), typeof(GlassScrollViewer));

        /// <summary>
        /// Content of the down button.
        /// </summary>
        public object DownButtonContent
        {
            get => GetValue(DownButtonContentProperty);
            set => SetValue(DownButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DownButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DownButtonContentProperty =
            DependencyProperty.Register(nameof(DownButtonContent), typeof(object), typeof(GlassScrollViewer));

        /// <summary>
        /// Content of the left button.
        /// </summary>
        public object LeftButtonContent
        {
            get => GetValue(LeftButtonContentProperty);
            set => SetValue(LeftButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LeftButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonContentProperty =
            DependencyProperty.Register(nameof(LeftButtonContent), typeof(object), typeof(GlassScrollViewer));

        /// <summary>
        /// Content of the right button.
        /// </summary>
        public object RightButtonContent
        {
            get => GetValue(RightButtonContentProperty);
            set => SetValue(RightButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="RightButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RightButtonContentProperty =
            DependencyProperty.Register(nameof(RightButtonContent), typeof(object), typeof(GlassScrollViewer));


        /// <summary>
        /// Creates a new <see cref="GlassScrollViewer"/>.
        /// </summary>
        static GlassScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassScrollViewer), new FrameworkPropertyMetadata(typeof(GlassScrollViewer)));
        }
    }
}
