using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Core;
using FullControls.Extra;

namespace FullControls
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
        /// Background brush when the control is selected.
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
        /// Background brush when the control is disabled.
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
        /// Actual Background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(ETextBox),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((ETextBox)d).OnActualBackgroundChanged((Brush)e.NewValue))));

        /// <summary>
        /// BorderBrush when the control is selected.
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
        /// BorderBrush when the control is disabled.
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
        /// Actual BorderBrush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(ETextBox));

        /// <summary>
        /// Specifies if adapt automatically the foreground to the actual background of the control.
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
        /// Specifies if adapt automatically the caret brush to the actual background of the control.
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
        /// Specifies if to display or not the hint.
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
        /// Foreground of the hint.
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
        /// Opacity of the hint.
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
        /// Specifies if adapt automatically the hint foreground to the actual background of the control.
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

        /// <summary>
        /// Suggestion that will displayed if there is no text inside the textbox.
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

        #endregion

        #region CopyButton

        /// <summary>
        /// Specifies if to display or not a button that copies the text on the Clipboard when clicked.
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
        /// Width of the copy button.
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
        /// FontFamily of the copy button.
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
        /// Font size of the copy button.
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
        /// FontStretch of the copy button.
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
        /// FontStyle of the copy button.
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
        /// FontWeight of the copy button.
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
        /// Margin of the copy button.
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
        /// Content of the copy button.
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
        /// Background of the copy button.
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
        /// Background of the copy button when the mouse is over it.
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
        /// Background of the copy button when is pressed.
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
        /// Background of the copy button when is disabled.
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
        /// BorderBrush of the copy button.
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
        /// BorderBrush of the copy button when the mouse is over it.
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
        /// BorderBrush of the copy button when is pressed.
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
        /// BorderBrush of the copy button when is disabled.
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
        /// Foreground of the copy button.
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
        /// Foreground of the copy button when the mouse is over it.
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
        /// Foreground of the copy button when is pressed.
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
        /// Foreground of the copy button when is disabled.
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
        /// CornerRadius of the copy button.
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
        /// Border thickness of the copy button.
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
        /// Duration of the copy button animation when it changes state.
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
        /// Label that is displayed to the left or top of the TextBox.
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
        /// Icon that is displayed to the left or top of the TextBox.
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
        /// Label type.
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
        /// Orientation order between Label and TextBox.
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
        /// Max Width of the label.
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
        /// Margin of the label.
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
        /// Foreground of the label.
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
        /// FontSize of the label.
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
        /// FontFamily of the label.
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
        /// FontStretch of the label.
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
        /// FontStyle of the label.
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
        /// FontWeight of the label.
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

        #region ExternalBorder

        /// <summary>
        /// Background brush of the external border.
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
        /// BorderBrush of the external border.
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
        /// BorderThickness of the external border.
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
        /// Padding of the external border.
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
        /// CornerRadius of the external border.
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
        /// Width of the TextBox.
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
        /// Enables automatic adjustement of margins between all items in the same group.
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
        /// Specifies the text type accepted by the textbox.
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
        /// Check if <see cref="TextBox.Text"/> is a <see cref="double"/> value.
        /// </summary>
        public bool IsDouble => Text?.IsDouble() == true || Text == "";

        /// <summary>
        /// Check if <see cref="TextBox.Text"/> is an <see cref="int"/> value.
        /// </summary>
        public bool IsInt => Text?.IsInt() == true || Text == "";

        /// <summary>
        /// Check if <see cref="TextBox.Text"/> contains only numeric chars.
        /// </summary>
        public bool IsNumeric => Text?.IsNumeric() == true;

        /// <summary>
        /// Handles the <see cref="TextBox.Text"/> as <see cref="double"/>.
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
        /// Handles the <see cref="TextBox.Text"/> as <see cref="int"/>.
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
        /// Length of <see cref="TextBox.Text"/>.
        /// </summary>
        public int TextLength => Text != null ? Text.Length : 0;

        /// <summary>
        /// Duration of the control animation when it changes state.
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


        /// <summary>
        /// Creates a new <see cref="ETextBox"/>.
        /// </summary>
        static ETextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ETextBox), new FrameworkPropertyMetadata(typeof(ETextBox)));
            IsEnabledProperty.OverrideMetadata(typeof(ETextBox), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ETextBox)d).OnEnabledChanged((bool)e.NewValue))));
            TextProperty.OverrideMetadata(typeof(ETextBox), new FrameworkPropertyMetadata(null,
                new CoerceValueCallback((d, o) => ((ETextBox)d).CoerceText((string)o))));
        }

        /// <summary>
        /// Copy the value of the <see cref="TextBox.Text"/> property on the Clipboard.
        /// </summary>
        public void CopyAll() => Clipboard.SetText(Text);

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UIElement copyButton = (UIElement)Template.FindName(PartCopyButton, this);
            if (copyButton != null) copyButton.PreviewMouseLeftButtonDown += (s, e) => CopyAll();
            UpdateHintState();
            Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
            loaded = true;
            ReloadBackground();
        }

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        protected virtual void OnActualBackgroundChanged(Brush actualBackground)
        {
            AdaptForeColors(actualBackground);
        }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState)
        {
            ReloadBackground();
        }

        /// <summary>
        /// Called when the text is changed.
        /// </summary>
        /// <param name="e">The arguments that are associated with the <see cref="TextBoxBase.TextChanged"/> event.</param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            UpdateHintState();
        }

        /// <summary>
        /// Invoked whenever an unhandled <see cref="UIElement.GotFocus"/> event reaches this element in its route.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            UpdateHintState();
            ReloadBackground();
        }

        /// <summary>
        /// Raises <see cref="UIElement.LostFocus"/> routed event by using the event data that is provided.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            UpdateHintState();
            ReloadBackground();
        }

        /// <summary>
        /// Called when the mouse enter the control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ReloadBackground();
        }

        /// <summary>
        /// Called when the mouse leave the control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            ReloadBackground();
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
        /// Update the visualstate to "Hinted" or "Unhinted" if is necessary to display or hide the hint.
        /// </summary>
        private void UpdateHintState()
        {
            _ = VisualStateManager.GoToState(this, TextLength == 0 && !IsFocused && ShowHint ? "Hinted" : "Unhinted", true);
        }

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

        /// <summary>
        /// Apply the correct background to the control, based on its state.
        /// </summary>
        private void ReloadBackground()
        {
            if (!loaded) return;
            if (!IsEnabled) //Disabled state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnDisabled, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnDisabled, TimeSpan.Zero);
            }
            else if (IsFocused) //Selected state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnSelected, AnimationTime);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnSelected, AnimationTime);
            }
            else if (IsMouseOver) //Selected state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnSelected, AnimationTime);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnSelected, AnimationTime);
            }
            else //Normal state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
            }
        }
    }
}
