using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    /// <summary>
    /// Represents a control that can be used to display or edit unformatted text.
    /// </summary>
    public class FullTextBox : TextBox
    {
        private bool loaded = false;

        /// <summary>
        /// Background color when the control is selected.
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
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(FullTextBox));

        /// <summary>
        /// Background color when the control is disabled.
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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullTextBox));

        /// <summary>
        /// Actual Background color of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullTextBox),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => ((FullTextBox)d).OnActualBackgroundChanged(new BackgroundChangedEventArgs((Brush)e.NewValue)))));

        #region BackgroundBack

        /// <summary>
        /// Actual Background color of the control.
        /// </summary>
        internal Brush BackgroundBack
        {
            get => (Brush)GetValue(BackgroundBackProperty);
            set => SetValue(BackgroundBackProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundBack"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty BackgroundBackProperty =
            DependencyProperty.Register(nameof(BackgroundBack), typeof(Brush), typeof(FullTextBox),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBackgroundProperty, e.NewValue))));

        #endregion

        /// <summary>
        /// BorderBrush color when the control is selected.
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
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(FullTextBox));

        /// <summary>
        /// BorderBrush color when the control is disabled.
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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullTextBox));

        #region BorderBrushBack

        /// <summary>
        /// Actual BorderBrush color of the control.
        /// </summary>
        internal Brush BorderBrushBack
        {
            get => (Brush)GetValue(BorderBrushBackProperty);
            set => SetValue(BorderBrushBackProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushBack"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty BorderBrushBackProperty =
            DependencyProperty.Register(nameof(BorderBrushBack), typeof(Brush), typeof(FullTextBox));

        #endregion

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
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(ShowHint), typeof(bool), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(HintOpacity), typeof(double), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(AdaptHintForegroundAutomatically), typeof(bool), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(EnableCopyButton), typeof(bool), typeof(FullTextBox));

        /// <summary>
        /// Size of the copy button.
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
            DependencyProperty.Register(nameof(CopyButtonSize), typeof(double), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonFontFamily), typeof(FontFamily), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonFontSize), typeof(double), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonFontStretch), typeof(FontStretch), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonFontStyle), typeof(FontStyle), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonFontWeight), typeof(FontWeight), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonMargin), typeof(Thickness), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonContent), typeof(object), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBackground), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnMouseOver), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnPressed), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnDisabled), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBorderBrush), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnMouseOver), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnPressed), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnDisabled), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonForeground), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonForegroundOnMouseOver), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonForegroundOnPressed), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonForegroundOnDisabled), typeof(Brush), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonCornerRadius), typeof(CornerRadius), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonBorderThickness), typeof(Thickness), typeof(FullTextBox));

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
            DependencyProperty.Register(nameof(CopyButtonAnimationTime), typeof(TimeSpan), typeof(FullTextBox));

        #endregion

        #region Icon

        /// <summary>
        /// Icon that is displayed to the left of the text box.
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
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(FullTextBox));

        /// <summary>
        /// Max size of the icon.
        /// </summary>
        public double MaxIconSize
        {
            get => (double)GetValue(MaxIconSizeProperty);
            set => SetValue(MaxIconSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="MaxIconSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaxIconSizeProperty =
            DependencyProperty.Register(nameof(MaxIconSize), typeof(double), typeof(FullTextBox));

        #endregion

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullTextBox));

        /// <summary>
        /// Raised when the background is changed.
        /// </summary>
        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        /// <summary>
        /// Creates a new <see cref="FullTextBox"/>.
        /// </summary>
        static FullTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullTextBox), new FrameworkPropertyMetadata(typeof(FullTextBox)));
            IsEnabledProperty.OverrideMetadata(typeof(FullTextBox), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((FullTextBox)d).OnEnabledChanged((bool)e.NewValue))));
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
            ((Button)Template.FindName("PART_CopyButton", this)).Click += (s, e) => CopyAll();
            UpdateHintState();
            SetValue(BackgroundBackProperty, Background);
            SetValue(BorderBrushBackProperty, BorderBrush);
            loaded = true;
            ReloadBackground();
        }

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="e">Data of the <see cref="BackgroundChanged"/> event.</param>
        protected virtual void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
            AdaptForeColors(e.ActualBackground);
            BackgroundChanged?.Invoke(this, e);
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
        /// Update the visualstate to "Hinted" or "Unhinted" if is necessary to display or hide the hint.
        /// </summary>
        private void UpdateHintState()
        {
            _ = VisualStateManager.GoToState(this, Text.Length == 0 && !IsFocused && ShowHint ? "Hinted" : "Unhinted", true);
        }

        /// <summary>
        /// Adapt some colors to the actual background of the control.
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
                SetValue(BackgroundBackProperty, BackgroundOnDisabled);
                SetValue(BorderBrushBackProperty, BorderBrushOnDisabled);
            }
            else if (IsFocused) //Selected state
            {
                Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnSelected, AnimationTime);
                Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnSelected, AnimationTime);
            }
            else if (IsMouseOver) //Selected state
            {
                Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnSelected, AnimationTime);
                Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnSelected, AnimationTime);
            }
            else //Normal state
            {
                SetValue(BackgroundBackProperty, Background);
                SetValue(BorderBrushBackProperty, BorderBrush);
            }
        }
    }
}
