using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    public class FullTextBox : TextBox
    {
        public Brush BackgroundOnSelected
        {
            get => (Brush)GetValue(BackgroundOnSelectedProperty);
            set => SetValue(BackgroundOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnSelectedProperty =
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(FullTextBox));

        public Brush BackgroundOnDisabled
        {
            get => (Brush)GetValue(BackgroundOnDisabledProperty);
            set => SetValue(BackgroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullTextBox));

        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullTextBox));

        #region BackgroundBack

        internal Brush BackgroundBack
        {
            get => (Brush)GetValue(BackgroundBackProperty);
            set => SetValue(BackgroundBackProperty, value);
        }

        internal static readonly DependencyProperty BackgroundBackProperty =
            DependencyProperty.Register(nameof(BackgroundBack), typeof(Brush), typeof(FullTextBox),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualBackgroundProperty, e.NewValue);
                    ((FullTextBox)d).OnActualBackgroundChanged(new BackgroundChangedEventArgs((Brush)e.NewValue));
                })));

        #endregion

        public Brush BorderBrushOnSelected
        {
            get => (Brush)GetValue(BorderBrushOnSelectedProperty);
            set => SetValue(BorderBrushOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnSelectedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(FullTextBox));

        public Brush BorderBrushOnDisabled
        {
            get => (Brush)GetValue(BorderBrushOnDisabledProperty);
            set => SetValue(BorderBrushOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullTextBox));

        #region BorderBrushBack

        internal Brush BorderBrushBack
        {
            get => (Brush)GetValue(BorderBrushBackProperty);
            set => SetValue(BorderBrushBackProperty, value);
        }

        internal static readonly DependencyProperty BorderBrushBackProperty =
            DependencyProperty.Register(nameof(BorderBrushBack), typeof(Brush), typeof(FullTextBox));

        #endregion

        public bool AdaptForegroundAutomatically
        {
            get => (bool)GetValue(AdaptForegroundAutomaticallyProperty);
            set => SetValue(AdaptForegroundAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(FullTextBox));

        public bool AdaptCaretBrushAutomatically
        {
            get => (bool)GetValue(AdaptCaretBrushAutomaticallyProperty);
            set => SetValue(AdaptCaretBrushAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptCaretBrushAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(FullTextBox));

        public bool ShowHint
        {
            get => (bool)GetValue(ShowHintProperty);
            set => SetValue(ShowHintProperty, value);
        }

        public static readonly DependencyProperty ShowHintProperty =
            DependencyProperty.Register(nameof(ShowHint), typeof(bool), typeof(FullTextBox));

        public Brush HintForeground
        {
            get => (Brush)GetValue(HintForegroundProperty);
            set => SetValue(HintForegroundProperty, value);
        }

        public static readonly DependencyProperty HintForegroundProperty =
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(FullTextBox));

        public double HintOpacity
        {
            get => (double)GetValue(HintOpacityProperty);
            set => SetValue(HintOpacityProperty, value);
        }

        public static readonly DependencyProperty HintOpacityProperty =
            DependencyProperty.Register(nameof(HintOpacity), typeof(double), typeof(FullTextBox));

        public bool AdaptHintForegroundAutomatically
        {
            get => (bool)GetValue(AdaptHintForegroundAutomaticallyProperty);
            set => SetValue(AdaptHintForegroundAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptHintForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptHintForegroundAutomatically), typeof(bool), typeof(FullTextBox));

        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(FullTextBox));

        #region CopyButton

        public bool EnableCopyButton
        {
            get => (bool)GetValue(EnableCopyButtonProperty);
            set => SetValue(EnableCopyButtonProperty, value);
        }

        public static readonly DependencyProperty EnableCopyButtonProperty =
            DependencyProperty.Register(nameof(EnableCopyButton), typeof(bool), typeof(FullTextBox));

        public double CopyButtonSize
        {
            get => (double)GetValue(CopyButtonSizeProperty);
            set => SetValue(CopyButtonSizeProperty, value);
        }

        public static readonly DependencyProperty CopyButtonSizeProperty =
            DependencyProperty.Register(nameof(CopyButtonSize), typeof(double), typeof(FullTextBox));

        public FontFamily CopyButtonFontFamily
        {
            get => (FontFamily)GetValue(CopyButtonFontFamilyProperty);
            set => SetValue(CopyButtonFontFamilyProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontFamilyProperty =
            DependencyProperty.Register(nameof(CopyButtonFontFamily), typeof(FontFamily), typeof(FullTextBox));

        public double CopyButtonFontSize
        {
            get => (double)GetValue(CopyButtonFontSizeProperty);
            set => SetValue(CopyButtonFontSizeProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontSizeProperty =
            DependencyProperty.Register(nameof(CopyButtonFontSize), typeof(double), typeof(FullTextBox));

        public FontStretch CopyButtonFontStretch
        {
            get => (FontStretch)GetValue(CopyButtonFontStretchProperty);
            set => SetValue(CopyButtonFontStretchProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontStretchProperty =
            DependencyProperty.Register(nameof(CopyButtonFontStretch), typeof(FontStretch), typeof(FullTextBox));

        public FontStyle CopyButtonFontStyle
        {
            get => (FontStyle)GetValue(CopyButtonFontStyleProperty);
            set => SetValue(CopyButtonFontStyleProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontStyleProperty =
            DependencyProperty.Register(nameof(CopyButtonFontStyle), typeof(FontStyle), typeof(FullTextBox));

        public FontWeight CopyButtonFontWeight
        {
            get => (FontWeight)GetValue(CopyButtonFontWeightProperty);
            set => SetValue(CopyButtonFontWeightProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontWeightProperty =
            DependencyProperty.Register(nameof(CopyButtonFontWeight), typeof(FontWeight), typeof(FullTextBox));

        public Thickness CopyButtonMargin
        {
            get => (Thickness)GetValue(CopyButtonMarginProperty);
            set => SetValue(CopyButtonMarginProperty, value);
        }

        public static readonly DependencyProperty CopyButtonMarginProperty =
            DependencyProperty.Register(nameof(CopyButtonMargin), typeof(Thickness), typeof(FullTextBox));

        public object CopyButtonContent
        {
            get => GetValue(CopyButtonContentProperty);
            set => SetValue(CopyButtonContentProperty, value);
        }

        public static readonly DependencyProperty CopyButtonContentProperty =
            DependencyProperty.Register(nameof(CopyButtonContent), typeof(object), typeof(FullTextBox));

        public Brush CopyButtonBackground
        {
            get => (Brush)GetValue(CopyButtonBackgroundProperty);
            set => SetValue(CopyButtonBackgroundProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBackgroundProperty =
            DependencyProperty.Register(nameof(CopyButtonBackground), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonBackgroundOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnMouseOverProperty);
            set => SetValue(CopyButtonBackgroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnMouseOver), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonBackgroundOnPressed
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnPressedProperty);
            set => SetValue(CopyButtonBackgroundOnPressedProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnPressed), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonBackgroundOnDisabled
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnDisabledProperty);
            set => SetValue(CopyButtonBackgroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnDisabled), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonBorderBrush
        {
            get => (Brush)GetValue(CopyButtonBorderBrushProperty);
            set => SetValue(CopyButtonBorderBrushProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderBrushProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrush), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonBorderBrushOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnMouseOverProperty);
            set => SetValue(CopyButtonBorderBrushOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnMouseOver), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonBorderBrushOnPressed
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnPressedProperty);
            set => SetValue(CopyButtonBorderBrushOnPressedProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderBrushOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnPressed), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonBorderBrushOnDisabled
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnDisabledProperty);
            set => SetValue(CopyButtonBorderBrushOnDisabledProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnDisabled), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonForeground
        {
            get => (Brush)GetValue(CopyButtonForegroundProperty);
            set => SetValue(CopyButtonForegroundProperty, value);
        }

        public static readonly DependencyProperty CopyButtonForegroundProperty =
            DependencyProperty.Register(nameof(CopyButtonForeground), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonForegroundOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonForegroundOnMouseOverProperty);
            set => SetValue(CopyButtonForegroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty CopyButtonForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnMouseOver), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonForegroundOnPressed
        {
            get => (Brush)GetValue(CopyButtonForegroundOnPressedProperty);
            set => SetValue(CopyButtonForegroundOnPressedProperty, value);
        }

        public static readonly DependencyProperty CopyButtonForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnPressed), typeof(Brush), typeof(FullTextBox));

        public Brush CopyButtonForegroundOnDisabled
        {
            get => (Brush)GetValue(CopyButtonForegroundOnDisabledProperty);
            set => SetValue(CopyButtonForegroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty CopyButtonForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnDisabled), typeof(Brush), typeof(FullTextBox));

        public CornerRadius CopyButtonCornerRadius
        {
            get => (CornerRadius)GetValue(CopyButtonCornerRadiusProperty);
            set => SetValue(CopyButtonCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CopyButtonCornerRadiusProperty =
            DependencyProperty.Register(nameof(CopyButtonCornerRadius), typeof(CornerRadius), typeof(FullTextBox));

        public Thickness CopyButtonBorderThickness
        {
            get => (Thickness)GetValue(CopyButtonBorderThicknessProperty);
            set => SetValue(CopyButtonBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderThicknessProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderThickness), typeof(Thickness), typeof(FullTextBox));

        public TimeSpan CopyButtonAnimationTime
        {
            get => (TimeSpan)GetValue(CopyButtonAnimationTimeProperty);
            set => SetValue(CopyButtonAnimationTimeProperty, value);
        }

        public static readonly DependencyProperty CopyButtonAnimationTimeProperty =
            DependencyProperty.Register(nameof(CopyButtonAnimationTime), typeof(TimeSpan), typeof(FullTextBox));

        #endregion

        public bool ShowIcon
        {
            get => (bool)GetValue(ShowIconProperty);
            set => SetValue(ShowIconProperty, value);
        }

        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register(nameof(ShowIcon), typeof(bool), typeof(FullTextBox));

        public double MaxIconSize
        {
            get => (double)GetValue(MaxIconSizeProperty);
            set => SetValue(MaxIconSizeProperty, value);
        }

        public static readonly DependencyProperty MaxIconSizeProperty =
            DependencyProperty.Register(nameof(MaxIconSize), typeof(double), typeof(FullTextBox));

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(FullTextBox));

        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullTextBox));

        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        static FullTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullTextBox), new FrameworkPropertyMetadata(typeof(FullTextBox)));
        }

        public void CopyAll() => Clipboard.SetText(Text);

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ((Button)Template.FindName("PART_CopyButton", this)).Click += (s, e) => CopyAll();
            UpdateHintState();
            IsEnabledChanged += (s, e) => OnEnabledChanged();
            SetValue(BackgroundBackProperty, Background);
            SetValue(BorderBrushBackProperty, BorderBrush);
            ReloadBackground();
        }

        protected virtual void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
            AdaptForeColors(e.ActualBackground);
            BackgroundChanged?.Invoke(this, e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            UpdateHintState();
        }

        private void OnEnabledChanged()
        {
            ReloadBackground();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            UpdateHintState();
            ReloadBackground();
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            UpdateHintState();
            ReloadBackground();
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ReloadBackground();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            ReloadBackground();
        }

        private void UpdateHintState()
        {
            _ = VisualStateManager.GoToState(this, Text.Length == 0 && !IsFocused && ShowHint ? "Hinted" : "Unhinted", true);
        }

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

        private void ReloadBackground()
        {
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
