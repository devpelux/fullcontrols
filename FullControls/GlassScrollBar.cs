using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FullControls
{
    public class GlassScrollBar : ScrollBar
    {
        public double Thickness
        {
            get => (double)GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register(nameof(Thickness), typeof(double), typeof(GlassScrollBar));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GlassScrollBar));

        public double OpacityNormal
        {
            get => (double)GetValue(OpacityNormalProperty);
            set => SetValue(OpacityNormalProperty, value);
        }

        public static readonly DependencyProperty OpacityNormalProperty =
            DependencyProperty.Register(nameof(OpacityNormal), typeof(double), typeof(GlassScrollBar));

        public double OpacityOnMouseOver
        {
            get => (double)GetValue(OpacityOnMouseOverProperty);
            set => SetValue(OpacityOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty OpacityOnMouseOverProperty =
            DependencyProperty.Register(nameof(OpacityOnMouseOver), typeof(double), typeof(GlassScrollBar));

        public double OpacityOnMouseDown
        {
            get => (double)GetValue(OpacityOnMouseDownProperty);
            set => SetValue(OpacityOnMouseDownProperty, value);
        }

        public static readonly DependencyProperty OpacityOnMouseDownProperty =
            DependencyProperty.Register(nameof(OpacityOnMouseDown), typeof(double), typeof(GlassScrollBar));

        public bool EnableButtons
        {
            get => (bool)GetValue(EnableButtonsProperty);
            set => SetValue(EnableButtonsProperty, value);
        }

        public static readonly DependencyProperty EnableButtonsProperty =
            DependencyProperty.Register(nameof(EnableButtons), typeof(bool), typeof(GlassScrollBar));

        public double ButtonsSize
        {
            get => (double)GetValue(ButtonsSizeProperty);
            set => SetValue(ButtonsSizeProperty, value);
        }

        public static readonly DependencyProperty ButtonsSizeProperty =
            DependencyProperty.Register(nameof(ButtonsSize), typeof(double), typeof(GlassScrollBar));

        public FontFamily ButtonsFont
        {
            get => (FontFamily)GetValue(ButtonsFontProperty);
            set => SetValue(ButtonsFontProperty, value);
        }

        public static readonly DependencyProperty ButtonsFontProperty =
            DependencyProperty.Register(nameof(ButtonsFont), typeof(FontFamily), typeof(GlassScrollBar));

        public double ButtonsContentSize
        {
            get => (double)GetValue(ButtonsContentSizeProperty);
            set => SetValue(ButtonsContentSizeProperty, value);
        }

        public static readonly DependencyProperty ButtonsContentSizeProperty =
            DependencyProperty.Register(nameof(ButtonsContentSize), typeof(double), typeof(GlassScrollBar));

        public object IncreaseButtonContent
        {
            get => GetValue(IncreaseButtonContentProperty);
            set => SetValue(IncreaseButtonContentProperty, value);
        }

        public static readonly DependencyProperty IncreaseButtonContentProperty =
            DependencyProperty.Register(nameof(IncreaseButtonContent), typeof(object), typeof(GlassScrollBar));

        public object DecreaseButtonContent
        {
            get => GetValue(DecreaseButtonContentProperty);
            set => SetValue(DecreaseButtonContentProperty, value);
        }

        public static readonly DependencyProperty DecreaseButtonContentProperty =
            DependencyProperty.Register(nameof(DecreaseButtonContent), typeof(object), typeof(GlassScrollBar));

        public Brush IncreaseButtonForeground
        {
            get => (Brush)GetValue(IncreaseButtonForegroundProperty);
            set => SetValue(IncreaseButtonForegroundProperty, value);
        }

        public static readonly DependencyProperty IncreaseButtonForegroundProperty =
            DependencyProperty.Register(nameof(IncreaseButtonForeground), typeof(Brush), typeof(GlassScrollBar));

        public Brush DecreaseButtonForeground
        {
            get => (Brush)GetValue(DecreaseButtonForegroundProperty);
            set => SetValue(DecreaseButtonForegroundProperty, value);
        }

        public static readonly DependencyProperty DecreaseButtonForegroundProperty =
            DependencyProperty.Register(nameof(DecreaseButtonForeground), typeof(Brush), typeof(GlassScrollBar));

        public Brush ThumbBackground
        {
            get => (Brush)GetValue(ThumbBackgroundProperty);
            set => SetValue(ThumbBackgroundProperty, value);
        }

        public static readonly DependencyProperty ThumbBackgroundProperty =
            DependencyProperty.Register(nameof(ThumbBackground), typeof(Brush), typeof(GlassScrollBar));


        static GlassScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassScrollBar), new FrameworkPropertyMetadata(typeof(GlassScrollBar)));
        }
    }
}
