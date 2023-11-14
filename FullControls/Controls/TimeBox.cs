using FullControls.Common;
using FullControls.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control that can be used to display or edit time values.
    /// </summary>
    [TemplatePart(Name = PartContentHost, Type = typeof(ContentPresenter))]
    public class TimeBox : Control
    {
        private readonly TextBoxPlus timeBox;

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        private const string PartContentHost = "PART_ContentHost";

        #region TextBoxPlus properties

        /// <summary>
        /// Gets or sets the background brush when the control is selected.
        /// </summary>
        public Brush BackgroundOnSelected
        {
            get => (Brush)GetValue(BackgroundOnSelectedProperty);
            set => SetValue(BackgroundOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnSelectedProperty =
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the background brush when the control is disabled.
        /// </summary>
        public Brush BackgroundOnDisabled
        {
            get => (Brush)GetValue(BackgroundOnDisabledProperty);
            set => SetValue(BackgroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the border brush when the control is selected.
        /// </summary>
        public Brush BorderBrushOnSelected
        {
            get => (Brush)GetValue(BorderBrushOnSelectedProperty);
            set => SetValue(BorderBrushOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnSelectedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the border brush when the control is disabled.
        /// </summary>
        public Brush BorderBrushOnDisabled
        {
            get => (Brush)GetValue(BorderBrushOnDisabledProperty);
            set => SetValue(BorderBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the foreground brush.
        /// </summary>
        public Brush ForegroundBrush
        {
            get => (Brush)GetValue(ForegroundBrushProperty);
            set => SetValue(ForegroundBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundBrushProperty =
            DependencyProperty.Register(nameof(ForegroundBrush), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the foreground brush when the control is selected.
        /// </summary>
        public Brush ForegroundBrushOnSelected
        {
            get => (Brush)GetValue(ForegroundBrushOnSelectedProperty);
            set => SetValue(ForegroundBrushOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundBrushOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundBrushOnSelectedProperty =
            DependencyProperty.Register(nameof(ForegroundBrushOnSelected), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the foreground brush when the control is disabled.
        /// </summary>
        public Brush ForegroundBrushOnDisabled
        {
            get => (Brush)GetValue(ForegroundBrushOnDisabledProperty);
            set => SetValue(ForegroundBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(ForegroundBrushOnDisabled), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the underline brush.
        /// </summary>
        public Brush UnderlineBrush
        {
            get => (Brush)GetValue(UnderlineBrushProperty);
            set => SetValue(UnderlineBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineBrushProperty =
            DependencyProperty.Register(nameof(UnderlineBrush), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the underline brush when the control is selected.
        /// </summary>
        public Brush UnderlineBrushOnSelected
        {
            get => (Brush)GetValue(UnderlineBrushOnSelectedProperty);
            set => SetValue(UnderlineBrushOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineBrushOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineBrushOnSelectedProperty =
            DependencyProperty.Register(nameof(UnderlineBrushOnSelected), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the underline brush when the control is disabled.
        /// </summary>
        public Brush UnderlineBrushOnDisabled
        {
            get => (Brush)GetValue(UnderlineBrushOnDisabledProperty);
            set => SetValue(UnderlineBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(UnderlineBrushOnDisabled), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the underline thickness.
        /// </summary>
        public Thickness UnderlineThickness
        {
            get => (Thickness)GetValue(UnderlineThicknessProperty);
            set => SetValue(UnderlineThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineThicknessProperty =
            DependencyProperty.Register(nameof(UnderlineThickness), typeof(Thickness), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the underline thickness when the control is selected.
        /// </summary>
        public Thickness UnderlineThicknessOnSelected
        {
            get => (Thickness)GetValue(UnderlineThicknessOnSelectedProperty);
            set => SetValue(UnderlineThicknessOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineThicknessOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineThicknessOnSelectedProperty =
            DependencyProperty.Register(nameof(UnderlineThicknessOnSelected), typeof(Thickness), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the underline thickness when the control is disabled.
        /// </summary>
        public Thickness UnderlineThicknessOnDisabled
        {
            get => (Thickness)GetValue(UnderlineThicknessOnDisabledProperty);
            set => SetValue(UnderlineThicknessOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineThicknessOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineThicknessOnDisabledProperty =
            DependencyProperty.Register(nameof(UnderlineThicknessOnDisabled), typeof(Thickness), typeof(TimeBox));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the caret brush to the actual background brush of the control.
        /// </summary>
        public bool AdaptCaretBrushAutomatically
        {
            get => (bool)GetValue(AdaptCaretBrushAutomaticallyProperty);
            set => SetValue(AdaptCaretBrushAutomaticallyProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AdaptCaretBrushAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptCaretBrushAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(TimeBox),
                new PropertyMetadata(BoolBox.True));

        #region Hint

        /// <summary>
        /// Gets or sets the suggestion displayed if the text is empty.
        /// </summary>
        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Hint"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(TimeBox),
                new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the foreground brush of the hint.
        /// </summary>
        public Brush HintForeground
        {
            get => (Brush)GetValue(HintForegroundProperty);
            set => SetValue(HintForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HintForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintForegroundProperty =
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the foreground brush of the hint when the control is selected.
        /// </summary>
        public Brush HintForegroundOnSelected
        {
            get => (Brush)GetValue(HintForegroundOnSelectedProperty);
            set => SetValue(HintForegroundOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HintForegroundOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintForegroundOnSelectedProperty =
            DependencyProperty.Register(nameof(HintForegroundOnSelected), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the foreground brush of the hint when the control is disabled.
        /// </summary>
        public Brush HintForegroundOnDisabled
        {
            get => (Brush)GetValue(HintForegroundOnDisabledProperty);
            set => SetValue(HintForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HintForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(HintForegroundOnDisabled), typeof(Brush), typeof(TimeBox));

        #endregion

        #region Label

        /// <summary>
        /// Gets or sets the label displayed alongside the control.
        /// </summary>
        public object Label
        {
            get => GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Label"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(object), typeof(TimeBox),
                new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the icon displayed alongside the control.
        /// </summary>
        /// <remarks>The icon will be displayed only if <see cref="Label"/> is <see langword="null"/>.</remarks>
        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Icon"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(TimeBox),
                new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the placement of the label.
        /// </summary>
        public Dock LabelPlacement
        {
            get => (Dock)GetValue(LabelPlacementProperty);
            set => SetValue(LabelPlacementProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelPlacement"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelPlacementProperty =
            DependencyProperty.Register(nameof(LabelPlacement), typeof(Dock), typeof(TimeBox),
                new PropertyMetadata(Dock.Top));

        /// <summary>
        /// Gets or sets the width of the label.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double LabelWidth
        {
            get => (double)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register(nameof(LabelWidth), typeof(double), typeof(TimeBox),
                new FrameworkPropertyMetadata(double.NaN),
                new ValidateValueCallback(Util.IsWidthHeightValid));

        /// <summary>
        /// Gets or sets the height of the label.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double LabelHeight
        {
            get => (double)GetValue(LabelHeightProperty);
            set => SetValue(LabelHeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelHeightProperty =
            DependencyProperty.Register(nameof(LabelHeight), typeof(double), typeof(TimeBox),
                new FrameworkPropertyMetadata(double.NaN),
                new ValidateValueCallback(Util.IsWidthHeightValid));

        /// <summary>
        /// Gets or sets the max width of the label.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double LabelMaxWidth
        {
            get => (double)GetValue(LabelMaxWidthProperty);
            set => SetValue(LabelMaxWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelMaxWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelMaxWidthProperty =
            DependencyProperty.Register(nameof(LabelMaxWidth), typeof(double), typeof(TimeBox),
                new FrameworkPropertyMetadata(double.PositiveInfinity),
                new ValidateValueCallback(Util.IsMaxWidthHeightValid));

        /// <summary>
        /// Gets or sets the max height of the label.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double LabelMaxHeight
        {
            get => (double)GetValue(LabelMaxHeightProperty);
            set => SetValue(LabelMaxHeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelMaxHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelMaxHeightProperty =
            DependencyProperty.Register(nameof(LabelMaxHeight), typeof(double), typeof(TimeBox),
                new FrameworkPropertyMetadata(double.PositiveInfinity),
                new ValidateValueCallback(Util.IsMaxWidthHeightValid));

        /// <summary>
        /// Gets or sets the margin of the label.
        /// </summary>
        public Thickness LabelMargin
        {
            get => (Thickness)GetValue(LabelMarginProperty);
            set => SetValue(LabelMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelMarginProperty =
            DependencyProperty.Register(nameof(LabelMargin), typeof(Thickness), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the vertical alignment of the label.
        /// </summary>
        public VerticalAlignment LabelVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(LabelVerticalAlignmentProperty);
            set => SetValue(LabelVerticalAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelVerticalAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(LabelVerticalAlignment), typeof(VerticalAlignment), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the horizontal alignment of the label.
        /// </summary>
        public HorizontalAlignment LabelHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(LabelHorizontalAlignmentProperty);
            set => SetValue(LabelHorizontalAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelHorizontalAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(LabelHorizontalAlignment), typeof(HorizontalAlignment), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the foreground brush of the label.
        /// </summary>
        public Brush LabelForeground
        {
            get => (Brush)GetValue(LabelForegroundProperty);
            set => SetValue(LabelForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelForegroundProperty =
            DependencyProperty.Register(nameof(LabelForeground), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the font size of the label.
        /// </summary>
        public double LabelFontSize
        {
            get => (double)GetValue(LabelFontSizeProperty);
            set => SetValue(LabelFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register(nameof(LabelFontSize), typeof(double), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the font family of the label.
        /// </summary>
        public FontFamily LabelFontFamily
        {
            get => (FontFamily)GetValue(LabelFontFamilyProperty);
            set => SetValue(LabelFontFamilyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontFamily"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontFamilyProperty =
            DependencyProperty.Register(nameof(LabelFontFamily), typeof(FontFamily), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the font stretch of the label.
        /// </summary>
        public FontStretch LabelFontStretch
        {
            get => (FontStretch)GetValue(LabelFontStretchProperty);
            set => SetValue(LabelFontStretchProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontStretch"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontStretchProperty =
            DependencyProperty.Register(nameof(LabelFontStretch), typeof(FontStretch), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the font style of the label.
        /// </summary>
        public FontStyle LabelFontStyle
        {
            get => (FontStyle)GetValue(LabelFontStyleProperty);
            set => SetValue(LabelFontStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontStyleProperty =
            DependencyProperty.Register(nameof(LabelFontStyle), typeof(FontStyle), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the font weight of the label.
        /// </summary>
        public FontWeight LabelFontWeight
        {
            get => (FontWeight)GetValue(LabelFontWeightProperty);
            set => SetValue(LabelFontWeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontWeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontWeightProperty =
            DependencyProperty.Register(nameof(LabelFontWeight), typeof(FontWeight), typeof(TimeBox));

        #endregion

        #region ExternalOutline

        /// <summary>
        /// Gets or sets the background brush of the external outline.
        /// </summary>
        public Brush ExternalBackground
        {
            get => (Brush)GetValue(ExternalBackgroundProperty);
            set => SetValue(ExternalBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalBackgroundProperty =
            DependencyProperty.Register(nameof(ExternalBackground), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the border brush of the external outline.
        /// </summary>
        public Brush ExternalBorderBrush
        {
            get => (Brush)GetValue(ExternalBorderBrushProperty);
            set => SetValue(ExternalBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalBorderBrushProperty =
            DependencyProperty.Register(nameof(ExternalBorderBrush), typeof(Brush), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the border thickness of the external outline.
        /// </summary>
        public Thickness ExternalBorderThickness
        {
            get => (Thickness)GetValue(ExternalBorderThicknessProperty);
            set => SetValue(ExternalBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalBorderThicknessProperty =
            DependencyProperty.Register(nameof(ExternalBorderThickness), typeof(Thickness), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the padding of the external outline.
        /// </summary>
        public Thickness ExternalPadding
        {
            get => (Thickness)GetValue(ExternalPaddingProperty);
            set => SetValue(ExternalPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalPaddingProperty =
            DependencyProperty.Register(nameof(ExternalPadding), typeof(Thickness), typeof(TimeBox));

        /// <summary>
        /// Gets or sets the corner radius of the external outline.
        /// </summary>
        public CornerRadius ExternalCornerRadius
        {
            get => (CornerRadius)GetValue(ExternalCornerRadiusProperty);
            set => SetValue(ExternalCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalCornerRadiusProperty =
            DependencyProperty.Register(nameof(ExternalCornerRadius), typeof(CornerRadius), typeof(TimeBox));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(TimeBox));

        /// <summary>
        /// Gets or sets a value indicating if enable automatic adjustement of margins between all text controls in the same group.
        /// </summary>
        public bool AutoMargin
        {
            get => (bool)GetValue(AutoMarginProperty);
            set => SetValue(AutoMarginProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AutoMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoMarginProperty =
            DependencyProperty.Register(nameof(AutoMargin), typeof(bool), typeof(TimeBox),
                new PropertyMetadata(BoolBox.False));

        /// <summary>
        /// Gets or sets the duration of the control animation when it changes state.
        /// </summary>
        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AnimationTime"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(TimeBox));

        #endregion TextBoxPlus properties


        static TimeBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeBox),
                new FrameworkPropertyMetadata(typeof(TimeBox)));

            IsEnabledProperty.OverrideMetadata(typeof(TimeBox),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((TimeBox)d).OnEnabledChanged())));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TimeBox"/>.
        /// </summary>
        public TimeBox() : base()
        {
            Loaded += (o, e) => OnLoaded();
            timeBox = PrepareTimeBoxChild();
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Template.FindName(PartContentHost, this) is ContentPresenter contentHost) contentHost.Content = timeBox;
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        protected virtual void OnLoaded() { }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        protected virtual void OnEnabledChanged() { }

        /// <inheritdoc/>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            timeBox.Focus();
        }

        public void SetRawTimeDate(RawTime date)
        {
            timeBox.Text = date.ToString("dd/MM/yyyy");
        }

        public RawTime GetRawTimeDate()
        {
            string text = timeBox.Text;
            string daystr = text.Substring(0, 2);
            string monthstr = text.Substring(3, 2);
            string yearstr = text.Substring(6, 4);
            int day = int.Parse(daystr);
            int month = int.Parse(monthstr);
            int year = int.Parse(yearstr);

            return new(year, month, day);
        }

        public void SetRawTimeMinutes(RawTime date)
        {
            timeBox.Text = date.ToString("HH:mm");
        }

        public RawTime GetRawTimeMinutes()
        {
            string text = timeBox.Text;
            string hourstr = text.Substring(0, 2);
            string minutestr = text.Substring(3, 2);
            int hour = int.Parse(hourstr);
            int minute = int.Parse(minutestr);

            return new(hour, minute);
        }

        #region TimeBox loader

        /// <summary>
        /// Prepares the <see cref="TextBoxPlus"/> child control.
        /// </summary>
        private TextBoxPlus PrepareTimeBoxChild()
        {
            TextBoxPlus timeBox = new();

            //Setting properties
            timeBox.Focusable = true;
            //Setting bindings
            timeBox.SetBinding(TextBoxPlus.HintProperty, new Binding(nameof(Hint)) { Source = this });
            timeBox.SetBinding(TextBoxPlus.LabelProperty, new Binding(nameof(Label)) { Source = this });
            timeBox.SetBinding(TextBoxPlus.LabelHeightProperty, new Binding(nameof(LabelHeight)) { Source = this });
            timeBox.SetBinding(TextBoxPlus.LabelMarginProperty, new Binding(nameof(LabelMargin)) { Source = this });

            return timeBox;
        }

        #endregion TimeBox loader
    }
}
