using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// Represents a control that provides a scroll bar that has a sliding <see cref="Thumb"/> whose position corresponds to a value.
    /// </summary>
    public class GlassScrollBar : ScrollBar
    {
        /// <summary>
        /// Thickness of the scrollbar.
        /// </summary>
        public double Thickness
        {
            get => (double)GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Thickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register(nameof(Thickness), typeof(double), typeof(GlassScrollBar));

        /// <summary>
        /// CornerRadius of the scrollbar.
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GlassScrollBar));

        /// <summary>
        /// Opacity of the scrollbar when is on his normal state.
        /// </summary>
        public double OpacityNormal
        {
            get => (double)GetValue(OpacityNormalProperty);
            set => SetValue(OpacityNormalProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="OpacityNormal"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OpacityNormalProperty =
            DependencyProperty.Register(nameof(OpacityNormal), typeof(double), typeof(GlassScrollBar));

        /// <summary>
        /// Opacity of the scrollbar when the mouse is over the control.
        /// </summary>
        public double OpacityOnMouseOver
        {
            get => (double)GetValue(OpacityOnMouseOverProperty);
            set => SetValue(OpacityOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="OpacityOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OpacityOnMouseOverProperty =
            DependencyProperty.Register(nameof(OpacityOnMouseOver), typeof(double), typeof(GlassScrollBar));

        /// <summary>
        /// Opacity of the scrollbar when is pressed.
        /// </summary>
        public double OpacityOnMouseDown
        {
            get => (double)GetValue(OpacityOnMouseDownProperty);
            set => SetValue(OpacityOnMouseDownProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="OpacityOnMouseDown"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OpacityOnMouseDownProperty =
            DependencyProperty.Register(nameof(OpacityOnMouseDown), typeof(double), typeof(GlassScrollBar));

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
            DependencyProperty.Register(nameof(EnableButtons), typeof(bool), typeof(GlassScrollBar));

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
            DependencyProperty.Register(nameof(ButtonsSize), typeof(double), typeof(GlassScrollBar));

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
            DependencyProperty.Register(nameof(ButtonsFont), typeof(FontFamily), typeof(GlassScrollBar));

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
            DependencyProperty.Register(nameof(ButtonsContentSize), typeof(double), typeof(GlassScrollBar));

        /// <summary>
        /// Content of the increase button.
        /// </summary>
        public object IncreaseButtonContent
        {
            get => GetValue(IncreaseButtonContentProperty);
            set => SetValue(IncreaseButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IncreaseButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IncreaseButtonContentProperty =
            DependencyProperty.Register(nameof(IncreaseButtonContent), typeof(object), typeof(GlassScrollBar));

        /// <summary>
        /// Content of the decrease button.
        /// </summary>
        public object DecreaseButtonContent
        {
            get => GetValue(DecreaseButtonContentProperty);
            set => SetValue(DecreaseButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DecreaseButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DecreaseButtonContentProperty =
            DependencyProperty.Register(nameof(DecreaseButtonContent), typeof(object), typeof(GlassScrollBar));

        /// <summary>
        /// Foreground of the increase button.
        /// </summary>
        public Brush IncreaseButtonForeground
        {
            get => (Brush)GetValue(IncreaseButtonForegroundProperty);
            set => SetValue(IncreaseButtonForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IncreaseButtonForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IncreaseButtonForegroundProperty =
            DependencyProperty.Register(nameof(IncreaseButtonForeground), typeof(Brush), typeof(GlassScrollBar));

        /// <summary>
        /// Foreground of the decrease button.
        /// </summary>
        public Brush DecreaseButtonForeground
        {
            get => (Brush)GetValue(DecreaseButtonForegroundProperty);
            set => SetValue(DecreaseButtonForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DecreaseButtonForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DecreaseButtonForegroundProperty =
            DependencyProperty.Register(nameof(DecreaseButtonForeground), typeof(Brush), typeof(GlassScrollBar));

        /// <summary>
        /// Background of the thumb.
        /// </summary>
        public Brush ThumbBackground
        {
            get => (Brush)GetValue(ThumbBackgroundProperty);
            set => SetValue(ThumbBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ThumbBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ThumbBackgroundProperty =
            DependencyProperty.Register(nameof(ThumbBackground), typeof(Brush), typeof(GlassScrollBar));


        /// <summary>
        /// Creates a new <see cref="GlassScrollBar"/>.
        /// </summary>
        static GlassScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassScrollBar), new FrameworkPropertyMetadata(typeof(GlassScrollBar)));
        }
    }
}
