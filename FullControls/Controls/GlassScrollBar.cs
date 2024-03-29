﻿using FullControls.Core;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control that provides a scroll bar that has a sliding <see cref="Thumb"/> whose position corresponds to a value.
    /// </summary>
    public class GlassScrollBar : ScrollBar
    {
        #region Default arrows

        /// <summary>
        /// Default up arrow.
        /// </summary>
        public Path UpArrow { get; } = new Path() { Data = Geometry.Parse("M 0 6 L 8 6 L 4 0 Z") };

        /// <summary>
        /// Default down arrow.
        /// </summary>
        public Path DownArrow { get; } = new Path() { Data = Geometry.Parse("M 0 0 L 4 6 L 8 0 Z") };

        /// <summary>
        /// Default left arrow.
        /// </summary>
        public Path LeftArrow { get; } = new Path() { Data = Geometry.Parse("M 6 0 L 6 8 L 0 4 Z") };

        /// <summary>
        /// Default right arrow.
        /// </summary>
        public Path RightArrow { get; } = new Path() { Data = Geometry.Parse("M 0 0 L 6 4 L 0 8 Z") };

        #endregion

        /// <summary>
        /// Gets or sets the corner radius of the control.
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
                new FrameworkPropertyMetadata(Util.GetKeyboardDelay()),
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
                new FrameworkPropertyMetadata(Util.GetKeyboardSpeed()),
                new ValidateValueCallback(IsScrollIntervalValid));

        #region Thumb

        /// <summary>
        /// Gets or sets the padding of the thumb.
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
        /// Gets or sets the corner radius of the thumb.
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
        /// Gets or sets the border thickness of the thumb.
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
        /// Gets or sets the border brush of the thumb.
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
        /// Gets or sets the foreground brush when the control is disabled.
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
        /// Gets or sets the opacity of the scrollbar thumb when is on his normal state.
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
        /// Gets or sets the opacity of the scrollbar thumb when the mouse is over the control.
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
        /// Gets or sets the opacity of the scrollbar thumb when is pressed.
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
        /// Gets or sets a value indicating if enable the increase and decrease buttons.
        /// </summary>
        public bool EnableButtons
        {
            get => (bool)GetValue(EnableButtonsProperty);
            set => SetValue(EnableButtonsProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableButtons"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableButtonsProperty =
            DependencyProperty.Register(nameof(EnableButtons), typeof(bool), typeof(GlassScrollBar),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets the size of the increase and decrease buttons.
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
        /// Gets or sets the font of the increase and decrease buttons.
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
        /// Gets or sets the font size of the increase and decrease buttons.
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
        /// Gets or sets the corner radius of the buttons.
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
        /// Gets or sets the background brush of the buttons.
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
        /// Gets or sets the border brush of the buttons.
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
        /// Gets or sets the border thickness of the buttons.
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
        /// Gets or sets the foreground brush of the buttons.
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
        /// Gets or sets the foreground brush of the buttons when the control is disabled.
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
        /// Gets or sets the padding of the increase button.
        /// </summary>
        public Thickness IncreaseButtonPadding
        {
            get => (Thickness)GetValue(IncreaseButtonPaddingProperty);
            set => SetValue(IncreaseButtonPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IncreaseButtonPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IncreaseButtonPaddingProperty =
            DependencyProperty.Register(nameof(IncreaseButtonPadding), typeof(Thickness), typeof(GlassScrollBar));

        /// <summary>
        /// Gets or sets the padding of the decrease button.
        /// </summary>
        public Thickness DecreaseButtonPadding
        {
            get => (Thickness)GetValue(DecreaseButtonPaddingProperty);
            set => SetValue(DecreaseButtonPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DecreaseButtonPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DecreaseButtonPaddingProperty =
            DependencyProperty.Register(nameof(DecreaseButtonPadding), typeof(Thickness), typeof(GlassScrollBar));

        /// <summary>
        /// Gets or sets the content of the increase button.
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
        /// Gets or sets the content of the decrease button.
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


        static GlassScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassScrollBar),
                new FrameworkPropertyMetadata(typeof(GlassScrollBar)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GlassScrollBar"/>.
        /// </summary>
        public GlassScrollBar() : base()
        {
            PrepareDefaultArrows();
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) { }

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

        /// <summary>
        /// Prepares the default arrows.
        /// </summary>
        private void PrepareDefaultArrows()
        {
            UpArrow.SetBinding(Shape.FillProperty, new Binding(nameof(ButtonsForeground)) { Source = this });
            DownArrow.SetBinding(Shape.FillProperty, new Binding(nameof(ButtonsForeground)) { Source = this });
            LeftArrow.SetBinding(Shape.FillProperty, new Binding(nameof(ButtonsForeground)) { Source = this });
            RightArrow.SetBinding(Shape.FillProperty, new Binding(nameof(ButtonsForeground)) { Source = this });
        }
    }
}
