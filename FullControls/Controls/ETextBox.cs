using FullControls.Common;
using FullControls.Core;
using FullControls.Extra;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control that can be used to display or edit unformatted text.
    /// </summary>
    [TemplatePart(Name = PartCopyButton, Type = typeof(UIElement))]
    public class ETextBox : TextBox
    {
        private bool loaded = false;

        /// <summary>
        /// CopyButton template part.
        /// </summary>
        protected const string PartCopyButton = "PART_CopyButton";

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
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(ETextBox),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((ETextBox)d).OnActualBackgroundChanged((Brush)e.NewValue))));

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
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the foreground brush to the actual background brush of the control.
        /// </summary>
        public bool AdaptForegroundAutomatically
        {
            get => (bool)GetValue(AdaptForegroundAutomaticallyProperty);
            set => SetValue(AdaptForegroundAutomaticallyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AdaptForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(ETextBox));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the caret brush to the actual background brush of the control.
        /// </summary>
        public bool AdaptCaretBrushAutomatically
        {
            get => (bool)GetValue(AdaptCaretBrushAutomaticallyProperty);
            set => SetValue(AdaptCaretBrushAutomaticallyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AdaptCaretBrushAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptCaretBrushAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(ETextBox));

        /// <summary>
        /// Gets or sets a value indicating if to display or not the hint.
        /// </summary>
        public bool ShowHint
        {
            get => (bool)GetValue(ShowHintProperty);
            set => SetValue(ShowHintProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShowHint"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowHintProperty =
            DependencyProperty.Register(nameof(ShowHint), typeof(bool), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the opacity of the hint.
        /// </summary>
        public double HintOpacity
        {
            get => (double)GetValue(HintOpacityProperty);
            set => SetValue(HintOpacityProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HintOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintOpacityProperty =
            DependencyProperty.Register(nameof(HintOpacity), typeof(double), typeof(ETextBox));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the hint foreground brush to the actual background brush of the control.
        /// </summary>
        public bool AdaptHintForegroundAutomatically
        {
            get => (bool)GetValue(AdaptHintForegroundAutomaticallyProperty);
            set => SetValue(AdaptHintForegroundAutomaticallyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AdaptHintForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptHintForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptHintForegroundAutomatically), typeof(bool), typeof(ETextBox));

        #endregion

        #region CopyButton

        /// <summary>
        /// Gets or sets a value indicating if to display or not a button that copies the text on the <see cref="Clipboard"/> when clicked.
        /// </summary>
        public bool EnableCopyButton
        {
            get => (bool)GetValue(EnableCopyButtonProperty);
            set => SetValue(EnableCopyButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableCopyButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableCopyButtonProperty =
            DependencyProperty.Register(nameof(EnableCopyButton), typeof(bool), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the content of the copy button.
        /// </summary>
        public object CopyButtonContent
        {
            get => GetValue(CopyButtonContentProperty);
            set => SetValue(CopyButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonContentProperty =
            DependencyProperty.Register(nameof(CopyButtonContent), typeof(object), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the width of the copy button.
        /// </summary>
        public double CopyButtonSize
        {
            get => (double)GetValue(CopyButtonSizeProperty);
            set => SetValue(CopyButtonSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonSizeProperty =
            DependencyProperty.Register(nameof(CopyButtonSize), typeof(double), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the font family of the copy button.
        /// </summary>
        public FontFamily CopyButtonFontFamily
        {
            get => (FontFamily)GetValue(CopyButtonFontFamilyProperty);
            set => SetValue(CopyButtonFontFamilyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontFamily"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontFamilyProperty =
            DependencyProperty.Register(nameof(CopyButtonFontFamily), typeof(FontFamily), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the font size of the copy button.
        /// </summary>
        public double CopyButtonFontSize
        {
            get => (double)GetValue(CopyButtonFontSizeProperty);
            set => SetValue(CopyButtonFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontSizeProperty =
            DependencyProperty.Register(nameof(CopyButtonFontSize), typeof(double), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the font stretch of the copy button.
        /// </summary>
        public FontStretch CopyButtonFontStretch
        {
            get => (FontStretch)GetValue(CopyButtonFontStretchProperty);
            set => SetValue(CopyButtonFontStretchProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontStretch"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontStretchProperty =
            DependencyProperty.Register(nameof(CopyButtonFontStretch), typeof(FontStretch), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the font style of the copy button.
        /// </summary>
        public FontStyle CopyButtonFontStyle
        {
            get => (FontStyle)GetValue(CopyButtonFontStyleProperty);
            set => SetValue(CopyButtonFontStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontStyleProperty =
            DependencyProperty.Register(nameof(CopyButtonFontStyle), typeof(FontStyle), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the font weight of the copy button.
        /// </summary>
        public FontWeight CopyButtonFontWeight
        {
            get => (FontWeight)GetValue(CopyButtonFontWeightProperty);
            set => SetValue(CopyButtonFontWeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontWeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontWeightProperty =
            DependencyProperty.Register(nameof(CopyButtonFontWeight), typeof(FontWeight), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the margin of the copy button.
        /// </summary>
        public Thickness CopyButtonMargin
        {
            get => (Thickness)GetValue(CopyButtonMarginProperty);
            set => SetValue(CopyButtonMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonMarginProperty =
            DependencyProperty.Register(nameof(CopyButtonMargin), typeof(Thickness), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the background brush of the copy button.
        /// </summary>
        public Brush CopyButtonBackground
        {
            get => (Brush)GetValue(CopyButtonBackgroundProperty);
            set => SetValue(CopyButtonBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBackgroundProperty =
            DependencyProperty.Register(nameof(CopyButtonBackground), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the background brush of the copy button when the mouse is over it.
        /// </summary>
        public Brush CopyButtonBackgroundOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnMouseOverProperty);
            set => SetValue(CopyButtonBackgroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBackgroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnMouseOver), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the background brush of the copy button when is pressed.
        /// </summary>
        public Brush CopyButtonBackgroundOnPressed
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnPressedProperty);
            set => SetValue(CopyButtonBackgroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBackgroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnPressed), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the background brush of the copy button when is disabled.
        /// </summary>
        public Brush CopyButtonBackgroundOnDisabled
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnDisabledProperty);
            set => SetValue(CopyButtonBackgroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBackgroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnDisabled), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the border brush of the copy button.
        /// </summary>
        public Brush CopyButtonBorderBrush
        {
            get => (Brush)GetValue(CopyButtonBorderBrushProperty);
            set => SetValue(CopyButtonBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderBrushProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrush), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the border brush of the copy button when the mouse is over it.
        /// </summary>
        public Brush CopyButtonBorderBrushOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnMouseOverProperty);
            set => SetValue(CopyButtonBorderBrushOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderBrushOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnMouseOver), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the border brush of the copy button when is pressed.
        /// </summary>
        public Brush CopyButtonBorderBrushOnPressed
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnPressedProperty);
            set => SetValue(CopyButtonBorderBrushOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderBrushOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderBrushOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnPressed), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the border brush of the copy button when is disabled.
        /// </summary>
        public Brush CopyButtonBorderBrushOnDisabled
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnDisabledProperty);
            set => SetValue(CopyButtonBorderBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnDisabled), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the foreground brush of the copy button.
        /// </summary>
        public Brush CopyButtonForeground
        {
            get => (Brush)GetValue(CopyButtonForegroundProperty);
            set => SetValue(CopyButtonForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonForegroundProperty =
            DependencyProperty.Register(nameof(CopyButtonForeground), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the foreground brush of the copy button when the mouse is over it.
        /// </summary>
        public Brush CopyButtonForegroundOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonForegroundOnMouseOverProperty);
            set => SetValue(CopyButtonForegroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonForegroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnMouseOver), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the foreground brush of the copy button when is pressed.
        /// </summary>
        public Brush CopyButtonForegroundOnPressed
        {
            get => (Brush)GetValue(CopyButtonForegroundOnPressedProperty);
            set => SetValue(CopyButtonForegroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonForegroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnPressed), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the foreground brush of the copy button when is disabled.
        /// </summary>
        public Brush CopyButtonForegroundOnDisabled
        {
            get => (Brush)GetValue(CopyButtonForegroundOnDisabledProperty);
            set => SetValue(CopyButtonForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnDisabled), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the corner radius of the copy button.
        /// </summary>
        public CornerRadius CopyButtonCornerRadius
        {
            get => (CornerRadius)GetValue(CopyButtonCornerRadiusProperty);
            set => SetValue(CopyButtonCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonCornerRadiusProperty =
            DependencyProperty.Register(nameof(CopyButtonCornerRadius), typeof(CornerRadius), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the border thickness of the copy button.
        /// </summary>
        public Thickness CopyButtonBorderThickness
        {
            get => (Thickness)GetValue(CopyButtonBorderThicknessProperty);
            set => SetValue(CopyButtonBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderThicknessProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderThickness), typeof(Thickness), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the duration of the copy button animation when it changes state.
        /// </summary>
        public TimeSpan CopyButtonAnimationTime
        {
            get => (TimeSpan)GetValue(CopyButtonAnimationTimeProperty);
            set => SetValue(CopyButtonAnimationTimeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonAnimationTime"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonAnimationTimeProperty =
            DependencyProperty.Register(nameof(CopyButtonAnimationTime), typeof(TimeSpan), typeof(ETextBox));

        #endregion

        #region Label

        /// <summary>
        /// Gets or sets the label displayed on the left or top of the control.
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
            DependencyProperty.Register(nameof(Label), typeof(object), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the icon displayed on the left or top of the control.
        /// </summary>
        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Icon"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the label type.
        /// </summary>
        public LabelType LabelType
        {
            get => (LabelType)GetValue(LabelTypeProperty);
            set => SetValue(LabelTypeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelTypeProperty =
            DependencyProperty.Register(nameof(LabelType), typeof(LabelType), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the orientation order between the label and the text area.
        /// </summary>
        public Orientation Order
        {
            get => (Orientation)GetValue(OrderProperty);
            set => SetValue(OrderProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Order"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register(nameof(Order), typeof(Orientation), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the max width of the label.
        /// </summary>
        public double LabelMaxSize
        {
            get => (double)GetValue(LabelMaxSizeProperty);
            set => SetValue(LabelMaxSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelMaxSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelMaxSizeProperty =
            DependencyProperty.Register(nameof(LabelMaxSize), typeof(double), typeof(ETextBox), new FrameworkPropertyMetadata(double.PositiveInfinity));

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
            DependencyProperty.Register(nameof(LabelMargin), typeof(Thickness), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(LabelForeground), typeof(Brush), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(LabelFontSize), typeof(double), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(LabelFontFamily), typeof(FontFamily), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(LabelFontStretch), typeof(FontStretch), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(LabelFontStyle), typeof(FontStyle), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(LabelFontWeight), typeof(FontWeight), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(ExternalBackground), typeof(Brush), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(ExternalBorderBrush), typeof(Brush), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(ExternalBorderThickness), typeof(Thickness), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(ExternalPadding), typeof(Thickness), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(ExternalCornerRadius), typeof(CornerRadius), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ETextBox));

        /// <summary>
        /// Gets or sets the width of the text area.
        /// </summary>
        public double TextViewSize
        {
            get => (double)GetValue(TextViewSizeProperty);
            set => SetValue(TextViewSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TextViewSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextViewSizeProperty =
            DependencyProperty.Register(nameof(TextViewSize), typeof(double), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(ScrollViewerStyle), typeof(Style), typeof(ETextBox));

        /// <summary>
        /// Gets or sets a value indicating if enable automatic adjustement of margins between all text controls in the same group.
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
            DependencyProperty.Register(nameof(AutoMargin), typeof(bool), typeof(ETextBox));

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
            DependencyProperty.Register(nameof(TextType), typeof(TextType), typeof(ETextBox),
                new PropertyMetadata(TextType.Text, new PropertyChangedCallback((d, e) => ((ETextBox)d).OnTextTypeChanged((TextType)e.NewValue))));

        /// <summary>
        /// Gets a value indicating if <see cref="TextBox.Text"/> is a <see cref="double"/> value.
        /// </summary>
        public bool IsDouble => Text?.IsDouble() == true || Text == "";

        /// <summary>
        /// Gets a value indicating if <see cref="TextBox.Text"/> is an <see cref="int"/> value.
        /// </summary>
        public bool IsInt => Text?.IsInt() == true || Text == "";

        /// <summary>
        /// Gets a value indicating if <see cref="TextBox.Text"/> contains only numeric chars.
        /// </summary>
        public bool IsNumeric => Text?.IsNumeric() == true;

        /// <summary>
        /// Gets or sets the <see cref="TextBox.Text"/> as <see cref="double"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public double TextDouble
        {
            get => Text is not null and not "" and not "+" and not "-" ? double.Parse(Text) : 0d;
            set => Text = value.ToString();
        }

        /// <summary>
        /// Gets or sets the <see cref="TextBox.Text"/> as <see cref="int"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        /// <exception cref="OverflowException"/>
        public int TextInt
        {
            get => (int)TextDouble;
            set => TextDouble = value;
        }

        /// <summary>
        /// Gets the length of the text (Text.Length).
        /// </summary>
        public int TextLength => Text != null ? Text.Length : 0;

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(ETextBox));


        static ETextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ETextBox), new FrameworkPropertyMetadata(typeof(ETextBox)));
            IsEnabledProperty.OverrideMetadata(typeof(ETextBox), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ETextBox)d).OnEnabledChanged((bool)e.NewValue))));
            TextProperty.OverrideMetadata(typeof(ETextBox), new FrameworkPropertyMetadata(null,
                new CoerceValueCallback((d, o) => ((ETextBox)d).CoerceText((string)o))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ETextBox"/>.
        /// </summary>
        public ETextBox() : base()
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
            UIElement copyButton = (UIElement)Template.FindName(PartCopyButton, this);
            if (copyButton != null) copyButton.PreviewMouseLeftButtonDown += (s, e) => CopyAll();
            UpdateHintState();
            Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
            loaded = true;
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        protected virtual void OnActualBackgroundChanged(Brush actualBackground) => AdaptForeColors(actualBackground);

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

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
            OnVStateChanged(VStateOverride());
        }

        /// <inheritdoc/>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            UpdateHintState();
            OnVStateChanged(VStateOverride());
        }

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            OnVStateChanged(VStateOverride());
        }

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            OnVStateChanged(VStateOverride());
        }

        /// <summary>
        /// Called to calculate the <b>v-state</b> of the control.
        /// </summary>
        protected virtual string VStateOverride()
        {
            if (!loaded) return "Undefined";
            if (!IsEnabled) return "Disabled";
            else if (IsFocused) return "Focused";
            else if (IsMouseOver) return "MouseOver";
            else return "Normal";
        }

        /// <summary>
        /// Called when the <b>v-state</b> of the control changed.
        /// </summary>
        /// <remarks>Is called <b>v-state</b> because is not related to the VisualState of the control.</remarks>
        /// <param name="vstate">Actual <b>v-state</b> of the control.</param>
        protected virtual void OnVStateChanged(string vstate)
        {
            switch (vstate)
            {
                case "Normal":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
                    break;
                case "MouseOver":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnSelected, AnimationTime);
                    break;
                case "Focused":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnSelected, AnimationTime);
                    break;
                case "Disabled":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnDisabled, TimeSpan.Zero);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Correct the <see cref="TextBox.Text"/> string if should be numeric.
        /// </summary>
        /// <param name="str">String to correct.</param>
        /// <returns>Corrected string.</returns>
        private string CoerceText(string str) => str is "" or null ? str
            : (TextType switch
            {
                TextType.DoubleOnly => str is "+" or "-" ? str : str.IsDouble() ? str.NormalizeForDouble(false) : Text,
                TextType.IntOnly => str is "+" or "-" ? str : str.IsInt() ? str.NormalizeForInt() : Text,
                TextType.NumericOnly => str.IsNumeric() ? str : Text,
                TextType.Text => str,
                _ => str,
            });

        /// <summary>
        /// Called when <see cref="TextType"/> is changed.
        /// </summary>
        /// <param name="textType">Actual <see cref="TextType"/> value.</param>
        private void OnTextTypeChanged(TextType textType)
        {
            switch (textType)
            {
                case TextType.DoubleOnly:
                    if (!IsDouble) Clear();
                    break;
                case TextType.IntOnly:
                    if (!IsInt) Clear();
                    break;
                case TextType.NumericOnly:
                    if (!IsNumeric) Clear();
                    break;
                case TextType.Text:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Update the visualstate to <see langword="Hinted"/> or <see langword="Unhinted"/> if is necessary to display or hide the hint.
        /// </summary>
        private void UpdateHintState() => _ = VisualStateManager.GoToState(this, TextLength == 0 && !IsFocused && ShowHint ? "Hinted" : "Unhinted", true);

        /// <summary>
        /// Adapt some brushes to the actual background of the control.
        /// </summary>
        /// <param name="backgroundBrush">Actual background of the control.</param>
        private void AdaptForeColors(Brush backgroundBrush)
        {
            if (backgroundBrush is SolidColorBrush brush)
            {
                SolidColorBrush inverseBrush = new SolidColorBrush(brush.Color.Invert());
                if (AdaptForegroundAutomatically) Foreground = inverseBrush;
                if (AdaptHintForegroundAutomatically) HintForeground = inverseBrush;
                if (AdaptCaretBrushAutomatically) CaretBrush = inverseBrush;
            }
        }
    }
}
