using FullControls.Core;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control that provides a scroll bar that has a sliding <see cref="Thumb"/> whose position corresponds to a value.
    /// </summary>
    public class GlassScrollBar : ScrollBar
    {
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
        /// Gets or sets the amount of time, in milliseconds, the control waits while it is pressed before it starts scrolling. The value must be non-negative.
        /// </summary>
        public int ScrollDelay
        {
            get => (int)GetValue(ScrollDelayProperty);
            set => SetValue(ScrollDelayProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollDelay"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollDelayProperty =
            DependencyProperty.Register(nameof(ScrollDelay), typeof(int), typeof(GlassScrollBar),
                new FrameworkPropertyMetadata(Utility.GetKeyboardDelay()),
                new ValidateValueCallback(IsScrollDelayValid));

        /// <summary>
        /// Gets or sets the amount of time, in milliseconds, the control repeats scrolling once repeating starts. The value must be non-negative.
        /// </summary>
        public int ScrollInterval
        {
            get => (int)GetValue(ScrollIntervalProperty);
            set => SetValue(ScrollIntervalProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollInterval"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollIntervalProperty =
            DependencyProperty.Register(nameof(ScrollInterval), typeof(int), typeof(GlassScrollBar),
                new FrameworkPropertyMetadata(Utility.GetKeyboardSpeed()),
                new ValidateValueCallback(IsScrollIntervalValid));

        #region Thumb

        /// <summary>
        /// Padding of the thumb.
        /// </summary>
        public Thickness ThumbPadding
        {
            get => (Thickness)GetValue(ThumbPaddingProperty);
            set => SetValue(ThumbPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ThumbPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ThumbPaddingProperty =
            DependencyProperty.Register(nameof(ThumbPadding), typeof(Thickness), typeof(GlassScrollBar));

        /// <summary>
        /// CornerRadius of the thumb.
        /// </summary>
        public CornerRadius ThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ThumbCornerRadiusProperty);
            set => SetValue(ThumbCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ThumbCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ThumbCornerRadiusProperty =
            DependencyProperty.Register(nameof(ThumbCornerRadius), typeof(CornerRadius), typeof(GlassScrollBar));

        /// <summary>
        /// Border thickness of the thumb.
        /// </summary>
        public Thickness ThumbBorderThickness
        {
            get => (Thickness)GetValue(ThumbBorderThicknessProperty);
            set => SetValue(ThumbBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ThumbBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ThumbBorderThicknessProperty =
            DependencyProperty.Register(nameof(ThumbBorderThickness), typeof(Thickness), typeof(GlassScrollBar));

        /// <summary>
        /// Border brush of the thumb.
        /// </summary>
        public Brush ThumbBorderBrush
        {
            get => (Brush)GetValue(ThumbBorderBrushProperty);
            set => SetValue(ThumbBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ThumbBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ThumbBorderBrushProperty =
            DependencyProperty.Register(nameof(ThumbBorderBrush), typeof(Brush), typeof(GlassScrollBar));

        /// <summary>
        /// Foreground when the control is disabled.
        /// </summary>
        public Brush ForegroundOnDisabled
        {
            get => (Brush)GetValue(ForegroundOnDisabledProperty);
            set => SetValue(ForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(GlassScrollBar));

        /// <summary>
        /// Opacity of the scrollbar thumb when is on his normal state.
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
        /// Opacity of the scrollbar thumb when the mouse is over the control.
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
        /// Opacity of the scrollbar thumb when is pressed.
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

        #endregion

        #region Buttons

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
        /// Size of the font of the increase and decrease buttons.
        /// </summary>
        public double ButtonsFontSize
        {
            get => (double)GetValue(ButtonsFontSizeProperty);
            set => SetValue(ButtonsFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsFontSizeProperty =
            DependencyProperty.Register(nameof(ButtonsFontSize), typeof(double), typeof(GlassScrollBar));

        /// <summary>
        /// CornerRadius of the buttons.
        /// </summary>
        public CornerRadius ButtonsCornerRadius
        {
            get => (CornerRadius)GetValue(ButtonsCornerRadiusProperty);
            set => SetValue(ButtonsCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsCornerRadiusProperty =
            DependencyProperty.Register(nameof(ButtonsCornerRadius), typeof(CornerRadius), typeof(GlassScrollBar));

        /// <summary>
        /// Background of the buttons.
        /// </summary>
        public Brush ButtonsBackground
        {
            get => (Brush)GetValue(ButtonsBackgroundProperty);
            set => SetValue(ButtonsBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsBackgroundProperty =
            DependencyProperty.Register(nameof(ButtonsBackground), typeof(Brush), typeof(GlassScrollBar));

        /// <summary>
        /// BorderBrush of the buttons.
        /// </summary>
        public Brush ButtonsBorderBrush
        {
            get => (Brush)GetValue(ButtonsBorderBrushProperty);
            set => SetValue(ButtonsBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsBorderBrushProperty =
            DependencyProperty.Register(nameof(ButtonsBorderBrush), typeof(Brush), typeof(GlassScrollBar));

        /// <summary>
        /// BorderThickness of the buttons.
        /// </summary>
        public Thickness ButtonsBorderThickness
        {
            get => (Thickness)GetValue(ButtonsBorderThicknessProperty);
            set => SetValue(ButtonsBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsBorderThicknessProperty =
            DependencyProperty.Register(nameof(ButtonsBorderThickness), typeof(Thickness), typeof(GlassScrollBar));

        /// <summary>
        /// Foreground of the buttons.
        /// </summary>
        public Brush ButtonsForeground
        {
            get => (Brush)GetValue(ButtonsForegroundProperty);
            set => SetValue(ButtonsForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsForegroundProperty =
            DependencyProperty.Register(nameof(ButtonsForeground), typeof(Brush), typeof(GlassScrollBar));

        /// <summary>
        /// Foreground of the buttons when the control is disabled.
        /// </summary>
        public Brush ButtonsForegroundOnDisabled
        {
            get => (Brush)GetValue(ButtonsForegroundOnDisabledProperty);
            set => SetValue(ButtonsForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(ButtonsForegroundOnDisabled), typeof(Brush), typeof(GlassScrollBar));

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

        #endregion


        /// <summary>
        /// Creates a new <see cref="GlassScrollBar"/>.
        /// </summary>
        static GlassScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassScrollBar), new FrameworkPropertyMetadata(typeof(GlassScrollBar)));
        }

        /// <summary>
        /// Check if the delay is valid.
        /// </summary>
        /// <param name="value">Value to validate.</param>
        /// <returns><see langword="true"/> if the delay is valid, <see langword="false"/> otherwise.</returns>
        internal static bool IsScrollDelayValid(object value) { return ((int)value) >= 0; }

        /// <summary>
        /// Check if the interval is valid.
        /// </summary>
        /// <param name="value">Value to validate.</param>
        /// <returns><see langword="true"/> if the interval is valid, <see langword="false"/> otherwise.</returns>
        internal static bool IsScrollIntervalValid(object value) { return ((int)value) > 0; }
    }
}
