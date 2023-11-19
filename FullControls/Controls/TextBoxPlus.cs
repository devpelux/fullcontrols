using FullControls.Common;
using FullControls.Core;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control that can be used to display or edit unformatted text.
    /// </summary>
    public class TextBoxPlus : TextBox, IVState
    {
        private bool loaded = false;

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
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(TextBoxPlus));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => ((TextBoxPlus)d).OnActualBackgroundChanged((Brush)e.NewValue))));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBackgroundPropertyKey, e.NewValue))));

        #endregion

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
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(TextBoxPlus));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBorderBrushPropertyKey, e.NewValue))));

        #endregion

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
            DependencyProperty.Register(nameof(ForegroundBrush), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(ForegroundBrushOnSelected), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(ForegroundBrushOnDisabled), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(UnderlineBrush), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(UnderlineBrushOnSelected), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(UnderlineBrushOnDisabled), typeof(Brush), typeof(TextBoxPlus));

        /// <summary>
        /// Gets the actual underline brush of the control.
        /// </summary>
        public Brush ActualUnderlineBrush => (Brush)GetValue(ActualUnderlineBrushProperty);

        #region ActualUnderlineBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualUnderlineBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualUnderlineBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualUnderlineBrush), typeof(Brush), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualUnderlineBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualUnderlineBrushProperty = ActualUnderlineBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualUnderlineBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualUnderlineBrushPropertyProxy =
            DependencyProperty.Register("ActualUnderlineBrushProxy", typeof(Brush), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualUnderlineBrushPropertyKey, e.NewValue))));

        #endregion

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
            DependencyProperty.Register(nameof(UnderlineThickness), typeof(Thickness), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(UnderlineThicknessOnSelected), typeof(Thickness), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(UnderlineThicknessOnDisabled), typeof(Thickness), typeof(TextBoxPlus));

        /// <summary>
        /// Gets the actual underline thickness of the control.
        /// </summary>
        public Thickness ActualUnderlineThickness => (Thickness)GetValue(ActualUnderlineThicknessProperty);

        #region ActualUnderlineThicknessProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualUnderlineThickness"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualUnderlineThicknessPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualUnderlineThickness), typeof(Thickness), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Thickness)));

        /// <summary>
        /// Identifies the <see cref="ActualUnderlineThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualUnderlineThicknessProperty = ActualUnderlineThicknessPropertyKey.DependencyProperty;

        #endregion

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
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(TextBoxPlus),
                new PropertyMetadata(BoolBox.True));

        #region Hint

        /// <summary>
        /// Gets or sets the suggestion displayed if <see cref="TextBox.Text"/> is empty.
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
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => ((TextBoxPlus)d).UpdateHintState())));

        /// <summary>
        /// Gets a value indicating if the hint is displayed.
        /// </summary>
        public bool IsHintDisplayed => (bool)GetValue(IsHintDisplayedProperty);

        #region IsHintDisplayedProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="IsHintDisplayed"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey IsHintDisplayedPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsHintDisplayed), typeof(bool), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(BoolBox.False));

        /// <summary>
        /// Identifies the <see cref="IsHintDisplayed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsHintDisplayedProperty = IsHintDisplayedPropertyKey.DependencyProperty;

        #endregion

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
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(HintForegroundOnSelected), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(HintForegroundOnDisabled), typeof(Brush), typeof(TextBoxPlus));

        /// <summary>
        /// Gets the actual foreground brush of the hint.
        /// </summary>
        public Brush ActualHintForeground => (Brush)GetValue(ActualHintForegroundProperty);

        #region ActualHintForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualHintForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualHintForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualHintForeground), typeof(Brush), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualHintForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualHintForegroundProperty = ActualHintForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualHintForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualHintForegroundPropertyProxy =
            DependencyProperty.Register("ActualHintForegroundProxy", typeof(Brush), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualHintForegroundPropertyKey, e.NewValue))));

        #endregion

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
            DependencyProperty.Register(nameof(Label), typeof(object), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => d.SetValue(LabelTypePropertyKey, CurrentLabelType(d)))));

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
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => d.SetValue(LabelTypePropertyKey, CurrentLabelType(d)))));

        /// <summary>
        /// Gets a value indicating the actual label type.
        /// </summary>
        public LabelType LabelType => (LabelType)GetValue(LabelTypeProperty);

        #region LabelTypeProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="LabelType"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey LabelTypePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(LabelType), typeof(LabelType), typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(LabelType.Undefined));

        /// <summary>
        /// Identifies the <see cref="LabelType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelTypeProperty = LabelTypePropertyKey.DependencyProperty;

        /// <summary>
        /// Calculates the current label type based on the values of <see cref="Label"/> and <see cref="Icon"/>.
        /// </summary>
        private static LabelType CurrentLabelType(DependencyObject d)
        {
            bool label = d.GetValue(LabelProperty) != null;
            bool icon = d.GetValue(IconProperty) != null;

            //Visualization predominance: Label -> Icon -> Nothing
            return label ? LabelType.Content : icon ? LabelType.Icon : LabelType.Undefined;
        }

        #endregion

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
            DependencyProperty.Register(nameof(LabelPlacement), typeof(Dock), typeof(TextBoxPlus),
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
            DependencyProperty.Register(nameof(LabelWidth), typeof(double), typeof(TextBoxPlus),
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
            DependencyProperty.Register(nameof(LabelHeight), typeof(double), typeof(TextBoxPlus),
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
            DependencyProperty.Register(nameof(LabelMaxWidth), typeof(double), typeof(TextBoxPlus),
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
            DependencyProperty.Register(nameof(LabelMaxHeight), typeof(double), typeof(TextBoxPlus),
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
            DependencyProperty.Register(nameof(LabelMargin), typeof(Thickness), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(LabelVerticalAlignment), typeof(VerticalAlignment), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(LabelHorizontalAlignment), typeof(HorizontalAlignment), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(LabelForeground), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(LabelFontSize), typeof(double), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(LabelFontFamily), typeof(FontFamily), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(LabelFontStretch), typeof(FontStretch), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(LabelFontStyle), typeof(FontStyle), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(LabelFontWeight), typeof(FontWeight), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(ExternalBackground), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(ExternalBorderBrush), typeof(Brush), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(ExternalBorderThickness), typeof(Thickness), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(ExternalPadding), typeof(Thickness), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(ExternalCornerRadius), typeof(CornerRadius), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(TextBoxPlus));

        /// <summary>
        /// Gets or sets the style of the scroll viewer used if the content is too long.
        /// </summary>
        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollViewerStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollViewerStyleProperty =
            DependencyProperty.Register(nameof(ScrollViewerStyle), typeof(Style), typeof(TextBoxPlus));

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
            DependencyProperty.Register(nameof(AutoMargin), typeof(bool), typeof(TextBoxPlus),
                new PropertyMetadata(BoolBox.False));

        /// <summary>
        /// Gets or sets a value indicating the text type accepted.
        /// </summary>
        public TextType TextType
        {
            get => (TextType)GetValue(TextTypeProperty);
            set => SetValue(TextTypeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TextType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextTypeProperty =
            DependencyProperty.Register(nameof(TextType), typeof(TextType), typeof(TextBoxPlus),
                new PropertyMetadata(TextType.Text, new PropertyChangedCallback((d, e) => ((TextBoxPlus)d).OnTextTypeChanged((TextType)e.NewValue))));

        /// <summary>
        /// <para>Gets or sets a regular expression used to filter the text accepted.</para>
        /// <para>This property is ignored if <see cref="TextType"/> is different than <see cref="TextType.Text"/>.</para>
        /// </summary>
        public string? RegexFilter
        {
            get => (string?)GetValue(RegexFilterProperty);
            set => SetValue(RegexFilterProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="RegexFilter"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RegexFilterProperty =
            DependencyProperty.Register(nameof(RegexFilter), typeof(string), typeof(TextBoxPlus),
                new PropertyMetadata(null, new PropertyChangedCallback((d, e) => ((TextBoxPlus)d).OnRegexFilterChanged((string?)e.NewValue))));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(TextBoxPlus));

        /// <summary>
        /// Gets the length of the text (Text.Length).
        /// </summary>
        public int TextLength => Text != null ? Text.Length : 0;

        /// <summary>
        /// Gets or sets the <see cref="TextBox.Text"/> as <see cref="double"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public double TextAsDouble
        {
            get => Text is not null and not "" and not "+" and not "-" ? double.Parse(Text) : 0D;
            set => Text = value.ToString();
        }

        /// <summary>
        /// Gets or sets the <see cref="TextBox.Text"/> as <see cref="long"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public long TextAsIntegral
        {
            get => Text is not null and not "" and not "+" and not "-" ? long.Parse(Text) : 0L;
            set => Text = value.ToString();
        }


        static TextBoxPlus()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(typeof(TextBoxPlus)));

            IsEnabledProperty.OverrideMetadata(typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((TextBoxPlus)d).OnEnabledChanged((bool)e.NewValue))));

            TextProperty.OverrideMetadata(typeof(TextBoxPlus),
                new FrameworkPropertyMetadata(null, new CoerceValueCallback((d, o)
                => ((TextBoxPlus)d).CoerceText((string)o))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextBoxPlus"/>.
        /// </summary>
        public TextBoxPlus() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <summary>
        /// Copy the value of the <see cref="TextBox.Text"/> property on the <see cref="Clipboard"/>.
        /// </summary>
        public void CopyAll() => Clipboard.SetText(Text);

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateHintState();
            loaded = true;
            OnVStateChanged(GetCurrentVState(), true);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e)
        {
            OnActualBackgroundChanged(ActualBackground);
            OnVStateChanged(GetCurrentVState());
        }

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        private void OnActualBackgroundChanged(Brush actualBackground)
        {
            if (actualBackground is SolidColorBrush brush)
            {
                Color color = brush.Color;
                Color inverseColor = Color.FromRgb((byte)(255 - color.R), (byte)(255 - color.G), (byte)(255 - color.B));
                SolidColorBrush inverseBrush = new(inverseColor);
                if (AdaptCaretBrushAutomatically) CaretBrush = inverseBrush;
            }
        }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(GetCurrentVState());

        /// <inheritdoc/>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            UpdateHintState();
        }

        /// <inheritdoc/>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            UpdateHintState();
            OnVStateChanged(GetCurrentVState());
        }

        /// <inheritdoc/>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            UpdateHintState();
            OnVStateChanged(GetCurrentVState());
        }

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            OnVStateChanged(GetCurrentVState());
        }

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            OnVStateChanged(GetCurrentVState());
        }

        /// <inheritdoc/>
        public VState GetCurrentVState()
        {
            if (!loaded) return VState.UNSET;
            if (!IsEnabled) return VStates.DISABLED;
            else if (IsFocused) return VStates.FOCUSED;
            else if (IsMouseOver) return VStates.MOUSE_OVER;
            else return VStates.DEFAULT;
        }

        /// <summary>
        /// Called when the current <see cref="VState"/> is changed.
        /// </summary>
        /// <param name="vstate">Current <see cref="VState"/>.</param>
        /// <param name="initial">Specifies if this is the initial <see cref="VState"/>.</param>
        protected virtual void OnVStateChanged(VState vstate, bool initial = false)
        {
            if (vstate == VStates.DEFAULT)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, Background, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ForegroundProperty, ForegroundBrush, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualHintForegroundPropertyProxy, HintForeground, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualUnderlineBrushPropertyProxy, UnderlineBrush, initial ? TimeSpan.Zero : AnimationTime);
                SetValue(ActualUnderlineThicknessPropertyKey, UnderlineThickness);
            }
            else if (vstate == VStates.MOUSE_OVER)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ForegroundProperty, ForegroundBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualHintForegroundPropertyProxy, HintForegroundOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualUnderlineBrushPropertyProxy, UnderlineBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                SetValue(ActualUnderlineThicknessPropertyKey, UnderlineThicknessOnSelected);
            }
            else if (vstate == VStates.FOCUSED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ForegroundProperty, ForegroundBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualHintForegroundPropertyProxy, HintForegroundOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualUnderlineBrushPropertyProxy, UnderlineBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                SetValue(ActualUnderlineThicknessPropertyKey, UnderlineThicknessOnSelected);
            }
            else if (vstate == VStates.DISABLED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ForegroundProperty, ForegroundBrushOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualHintForegroundPropertyProxy, HintForegroundOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualUnderlineBrushPropertyProxy, UnderlineBrushOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                SetValue(ActualUnderlineThicknessPropertyKey, UnderlineThicknessOnDisabled);
            }
        }

        /// <summary>
        /// Correct the <see cref="TextBox.Text"/> string basing on the text type allowed and the regex filter.
        /// </summary>
        /// <param name="str">String to correct.</param>
        /// <returns>Corrected string.</returns>
        private string? CoerceText(string str)
        {
            return TextType switch
            {
                TextType.DoubleOnly => str is null or "" or "+" or "-" ? str : str.IsDouble() ? str.NormalizeForDouble(false) : Text,
                TextType.IntegralOnly => str is null or "" or "+" or "-" ? str : str.IsLong() ? str.NormalizeForLong() : Text,
                TextType.NumericOnly => str is null or "" ? str : str.IsNumeric() ? str : Text,
                TextType.Text => str is null or "" ? str : RegexFilter == null ? str : Regex.IsMatch(str, RegexFilter) ? str : Text,
                _ => str,
            };
        }

        /// <summary>
        /// Called when <see cref="TextType"/> is changed.
        /// </summary>
        /// <param name="textType">Actual <see cref="TextType"/> value.</param>
        private void OnTextTypeChanged(TextType textType)
        {
            switch (textType)
            {
                case TextType.DoubleOnly:
                    if (Text != "" && Text?.IsDouble() != true) Clear();
                    break;
                case TextType.IntegralOnly:
                    if (Text != "" && Text?.IsLong() != true) Clear();
                    break;
                case TextType.NumericOnly:
                    if (Text?.IsNumeric() != true) Clear();
                    break;
                case TextType.Text:
                    if (RegexFilter != null && !Regex.IsMatch(Text, RegexFilter)) Clear();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Called when <see cref="RegexFilter"/> is changed.
        /// </summary>
        /// <param name="regexFilter">Actual <see cref="RegexFilter"/> value.</param>
        private void OnRegexFilterChanged(string? regexFilter)
        {
            //Validating the regex filter.
            _ = Regex.IsMatch("", regexFilter ?? "");

            //Applying the regex filter.
            if (TextType == TextType.Text && regexFilter != null && !Regex.IsMatch(Text, regexFilter))
            {
                Clear();
            }
        }

        /// <summary>
        /// Update the visualstate to <see langword="Hinted"/> or <see langword="Unhinted"/> if is necessary to display or hide the hint.
        /// </summary>
        private void UpdateHintState()
        {
            bool hinted = TextLength == 0 && !IsFocused && !string.IsNullOrEmpty(Hint);
            SetValue(IsHintDisplayedPropertyKey, BoolBox.Box(hinted));
            _ = VisualStateManager.GoToState(this, hinted ? "Hinted" : "Unhinted", true);
        }


        /// <summary>
        /// Control v-states.
        /// </summary>
        public static class VStates
        {
            /// <summary>
            /// Default state.
            /// </summary>
            public static readonly VState DEFAULT = new(nameof(DEFAULT), typeof(TextBoxPlus));

            /// <summary>
            /// The mouse is over the control.
            /// </summary>
            public static readonly VState MOUSE_OVER = new(nameof(MOUSE_OVER), typeof(TextBoxPlus));

            /// <summary>
            /// The control is focused.
            /// </summary>
            public static readonly VState FOCUSED = new(nameof(FOCUSED), typeof(TextBoxPlus));

            /// <summary>
            /// The control is disabled.
            /// </summary>
            public static readonly VState DISABLED = new(nameof(DISABLED), typeof(TextBoxPlus));
        }
    }
}
