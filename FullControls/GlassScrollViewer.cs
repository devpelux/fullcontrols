using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FullControls
{
    public class GlassScrollViewer : ScrollViewer
    {
        public bool PlaceScrollBarsInside
        {
            get => (bool)GetValue(PlaceScrollBarsInsideProperty);
            set => SetValue(PlaceScrollBarsInsideProperty, value);
        }

        public static readonly DependencyProperty PlaceScrollBarsInsideProperty =
            DependencyProperty.Register(nameof(PlaceScrollBarsInside), typeof(bool), typeof(GlassScrollViewer));

        public Thickness VerticalScrollBarMargin
        {
            get => (Thickness)GetValue(VerticalScrollBarMarginProperty);
            set => SetValue(VerticalScrollBarMarginProperty, value);
        }

        public static readonly DependencyProperty VerticalScrollBarMarginProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarMargin), typeof(Thickness), typeof(GlassScrollViewer));

        public Thickness HorizontalScrollBarMargin
        {
            get => (Thickness)GetValue(HorizontalScrollBarMarginProperty);
            set => SetValue(HorizontalScrollBarMarginProperty, value);
        }

        public static readonly DependencyProperty HorizontalScrollBarMarginProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarMargin), typeof(Thickness), typeof(GlassScrollViewer));

        public double ScrollBarsThickness
        {
            get => (double)GetValue(ScrollBarsThicknessProperty);
            set => SetValue(ScrollBarsThicknessProperty, value);
        }

        public static readonly DependencyProperty ScrollBarsThicknessProperty =
            DependencyProperty.Register(nameof(ScrollBarsThickness), typeof(double), typeof(GlassScrollViewer));

        public CornerRadius ScrollBarsCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollBarsCornerRadiusProperty);
            set => SetValue(ScrollBarsCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ScrollBarsCornerRadiusProperty =
            DependencyProperty.Register(nameof(ScrollBarsCornerRadius), typeof(CornerRadius), typeof(GlassScrollViewer));

        public double ScrollBarsOpacityNormal
        {
            get => (double)GetValue(ScrollBarsOpacityNormalProperty);
            set => SetValue(ScrollBarsOpacityNormalProperty, value);
        }

        public static readonly DependencyProperty ScrollBarsOpacityNormalProperty =
            DependencyProperty.Register(nameof(ScrollBarsOpacityNormal), typeof(double), typeof(GlassScrollViewer));

        public double ScrollBarsOpacityOnMouseOver
        {
            get => (double)GetValue(ScrollBarsOpacityOnMouseOverProperty);
            set => SetValue(ScrollBarsOpacityOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty ScrollBarsOpacityOnMouseOverProperty =
            DependencyProperty.Register(nameof(ScrollBarsOpacityOnMouseOver), typeof(double), typeof(GlassScrollViewer));

        public double ScrollBarsOpacityOnMouseDown
        {
            get => (double)GetValue(ScrollBarsOpacityOnMouseDownProperty);
            set => SetValue(ScrollBarsOpacityOnMouseDownProperty, value);
        }

        public static readonly DependencyProperty ScrollBarsOpacityOnMouseDownProperty =
            DependencyProperty.Register(nameof(ScrollBarsOpacityOnMouseDown), typeof(double), typeof(GlassScrollViewer));

        public Brush ScrollBarsColor
        {
            get => (Brush)GetValue(ScrollBarsColorProperty);
            set => SetValue(ScrollBarsColorProperty, value);
        }

        public static readonly DependencyProperty ScrollBarsColorProperty =
            DependencyProperty.Register(nameof(ScrollBarsColor), typeof(Brush), typeof(GlassScrollViewer));

        public bool EnableButtons
        {
            get => (bool)GetValue(EnableButtonsProperty);
            set => SetValue(EnableButtonsProperty, value);
        }

        public static readonly DependencyProperty EnableButtonsProperty =
            DependencyProperty.Register(nameof(EnableButtons), typeof(bool), typeof(GlassScrollViewer));

        public double ButtonsSize
        {
            get => (double)GetValue(ButtonsSizeProperty);
            set => SetValue(ButtonsSizeProperty, value);
        }

        public static readonly DependencyProperty ButtonsSizeProperty =
            DependencyProperty.Register(nameof(ButtonsSize), typeof(double), typeof(GlassScrollViewer));

        public FontFamily ButtonsFont
        {
            get => (FontFamily)GetValue(ButtonsFontProperty);
            set => SetValue(ButtonsFontProperty, value);
        }

        public static readonly DependencyProperty ButtonsFontProperty =
            DependencyProperty.Register(nameof(ButtonsFont), typeof(FontFamily), typeof(GlassScrollViewer));

        public double ButtonsContentSize
        {
            get => (double)GetValue(ButtonsContentSizeProperty);
            set => SetValue(ButtonsContentSizeProperty, value);
        }

        public static readonly DependencyProperty ButtonsContentSizeProperty =
            DependencyProperty.Register(nameof(ButtonsContentSize), typeof(double), typeof(GlassScrollViewer));

        public object UpButtonContent
        {
            get => GetValue(UpButtonContentProperty);
            set => SetValue(UpButtonContentProperty, value);
        }

        public static readonly DependencyProperty UpButtonContentProperty =
            DependencyProperty.Register(nameof(UpButtonContent), typeof(object), typeof(GlassScrollViewer));

        public object DownButtonContent
        {
            get => GetValue(DownButtonContentProperty);
            set => SetValue(DownButtonContentProperty, value);
        }

        public static readonly DependencyProperty DownButtonContentProperty =
            DependencyProperty.Register(nameof(DownButtonContent), typeof(object), typeof(GlassScrollViewer));

        public object LeftButtonContent
        {
            get => GetValue(LeftButtonContentProperty);
            set => SetValue(LeftButtonContentProperty, value);
        }

        public static readonly DependencyProperty LeftButtonContentProperty =
            DependencyProperty.Register(nameof(LeftButtonContent), typeof(object), typeof(GlassScrollViewer));

        public object RightButtonContent
        {
            get => GetValue(RightButtonContentProperty);
            set => SetValue(RightButtonContentProperty, value);
        }

        public static readonly DependencyProperty RightButtonContentProperty =
            DependencyProperty.Register(nameof(RightButtonContent), typeof(object), typeof(GlassScrollViewer));


        static GlassScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassScrollViewer), new FrameworkPropertyMetadata(typeof(GlassScrollViewer)));
        }
    }
}
