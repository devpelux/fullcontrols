using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    public sealed class FullPasswordBox : Control
    {
        private PasswordBox passwordBox = null;
        private TextBlock peek = null;
        private string _tempPassword = null;

        public Brush BackgroundOnSelected
        {
            get => (Brush)GetValue(BackgroundOnSelectedProperty);
            set => SetValue(BackgroundOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnSelectedProperty =
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(FullPasswordBox));

        public Brush BackgroundOnDisabled
        {
            get => (Brush)GetValue(BackgroundOnDisabledProperty);
            set => SetValue(BackgroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullPasswordBox));

        #region BackgroundBack

        internal Brush BackgroundBack
        {
            get => (Brush)GetValue(BackgroundBackProperty);
            set => SetValue(BackgroundBackProperty, value);
        }

        internal static readonly DependencyProperty BackgroundBackProperty =
            DependencyProperty.Register(nameof(BackgroundBack), typeof(Brush), typeof(FullPasswordBox),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualBackgroundProperty, e.NewValue);
                    ((FullPasswordBox)d).OnActualBackgroundChanged(new BackgroundChangedEventArgs((Brush)e.NewValue));
                })));

        #endregion

        public Brush BorderBrushOnSelected
        {
            get => (Brush)GetValue(BorderBrushOnSelectedProperty);
            set => SetValue(BorderBrushOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnSelectedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(FullPasswordBox));

        public Brush BorderBrushOnDisabled
        {
            get => (Brush)GetValue(BorderBrushOnDisabledProperty);
            set => SetValue(BorderBrushOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        #region BorderBrushBack

        internal Brush BorderBrushBack
        {
            get => (Brush)GetValue(BorderBrushBackProperty);
            set => SetValue(BorderBrushBackProperty, value);
        }

        internal static readonly DependencyProperty BorderBrushBackProperty =
            DependencyProperty.Register(nameof(BorderBrushBack), typeof(Brush), typeof(FullPasswordBox));

        #endregion

        public Brush CaretBrush
        {
            get => (Brush)GetValue(CaretBrushProperty);
            set => SetValue(CaretBrushProperty, value);
        }

        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(FullPasswordBox));

        public Brush SelectionBrush
        {
            get => (Brush)GetValue(SelectionBrushProperty);
            set => SetValue(SelectionBrushProperty, value);
        }

        public static readonly DependencyProperty SelectionBrushProperty =
            DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(FullPasswordBox));

        public Brush SelectionTextBrush
        {
            get => (Brush)GetValue(SelectionTextBrushProperty);
            set => SetValue(SelectionTextBrushProperty, value);
        }

        public static readonly DependencyProperty SelectionTextBrushProperty =
            DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(FullPasswordBox));

        public bool AdaptForegroundAutomatically
        {
            get => (bool)GetValue(AdaptForegroundAutomaticallyProperty);
            set => SetValue(AdaptForegroundAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(FullPasswordBox));

        public bool AdaptCaretBrushAutomatically
        {
            get => (bool)GetValue(AdaptCaretBrushAutomaticallyProperty);
            set => SetValue(AdaptCaretBrushAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptCaretBrushAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(FullPasswordBox));

        public double SelectionOpacity
        {
            get => (double)GetValue(SelectionOpacityProperty);
            set => SetValue(SelectionOpacityProperty, value);
        }

        public static readonly DependencyProperty SelectionOpacityProperty =
            DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(FullPasswordBox));

        public bool ShowHint
        {
            get => (bool)GetValue(ShowHintProperty);
            set => SetValue(ShowHintProperty, value);
        }

        public static readonly DependencyProperty ShowHintProperty =
            DependencyProperty.Register(nameof(ShowHint), typeof(bool), typeof(FullPasswordBox));

        public Brush HintForeground
        {
            get => (Brush)GetValue(HintForegroundProperty);
            set => SetValue(HintForegroundProperty, value);
        }

        public static readonly DependencyProperty HintForegroundProperty =
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(FullPasswordBox));

        public double HintOpacity
        {
            get => (double)GetValue(HintOpacityProperty);
            set => SetValue(HintOpacityProperty, value);
        }

        public static readonly DependencyProperty HintOpacityProperty =
            DependencyProperty.Register(nameof(HintOpacity), typeof(double), typeof(FullPasswordBox));

        public bool AdaptHintForegroundAutomatically
        {
            get => (bool)GetValue(AdaptHintForegroundAutomaticallyProperty);
            set => SetValue(AdaptHintForegroundAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptHintForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptHintForegroundAutomatically), typeof(bool), typeof(FullPasswordBox));

        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(FullPasswordBox));

        public bool EnablePeekButton
        {
            get => (bool)GetValue(EnablePeekButtonProperty);
            set => SetValue(EnablePeekButtonProperty, value);
        }

        public static readonly DependencyProperty EnablePeekButtonProperty =
            DependencyProperty.Register(nameof(EnablePeekButton), typeof(bool), typeof(FullPasswordBox));

        public Brush PeekForeground
        {
            get => (Brush)GetValue(PeekForegroundProperty);
            set => SetValue(PeekForegroundProperty, value);
        }

        public static readonly DependencyProperty PeekForegroundProperty =
            DependencyProperty.Register(nameof(PeekForeground), typeof(Brush), typeof(FullPasswordBox));

        public Brush PeekButtonForeground
        {
            get => (Brush)GetValue(PeekButtonForegroundProperty);
            set => SetValue(PeekButtonForegroundProperty, value);
        }

        public static readonly DependencyProperty PeekButtonForegroundProperty =
            DependencyProperty.Register(nameof(PeekButtonForeground), typeof(Brush), typeof(FullPasswordBox));

        public bool AdaptPeekForegroundAutomatically
        {
            get => (bool)GetValue(AdaptPeekForegroundAutomaticallyProperty);
            set => SetValue(AdaptPeekForegroundAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptPeekForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptPeekForegroundAutomatically), typeof(bool), typeof(FullPasswordBox));

        public bool AdaptPeekButtonForegroundAutomatically
        {
            get => (bool)GetValue(AdaptPeekButtonForegroundAutomaticallyProperty);
            set => SetValue(AdaptPeekButtonForegroundAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptPeekButtonForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptPeekButtonForegroundAutomatically), typeof(bool), typeof(FullPasswordBox));

        public double PeekButtonSize
        {
            get => (double)GetValue(PeekButtonSizeProperty);
            set => SetValue(PeekButtonSizeProperty, value);
        }

        public static readonly DependencyProperty PeekButtonSizeProperty =
            DependencyProperty.Register(nameof(PeekButtonSize), typeof(double), typeof(FullPasswordBox));

        public FontFamily PeekButtonFontFamily
        {
            get => (FontFamily)GetValue(PeekButtonFontFamilyProperty);
            set => SetValue(PeekButtonFontFamilyProperty, value);
        }

        public static readonly DependencyProperty PeekButtonFontFamilyProperty =
            DependencyProperty.Register(nameof(PeekButtonFontFamily), typeof(FontFamily), typeof(FullPasswordBox));

        public double PeekButtonFontSize
        {
            get => (double)GetValue(PeekButtonFontSizeProperty);
            set => SetValue(PeekButtonFontSizeProperty, value);
        }

        public static readonly DependencyProperty PeekButtonFontSizeProperty =
            DependencyProperty.Register(nameof(PeekButtonFontSize), typeof(double), typeof(FullPasswordBox));

        public FontStretch PeekButtonFontStretch
        {
            get => (FontStretch)GetValue(PeekButtonFontStretchProperty);
            set => SetValue(PeekButtonFontStretchProperty, value);
        }

        public static readonly DependencyProperty PeekButtonFontStretchProperty =
            DependencyProperty.Register(nameof(PeekButtonFontStretch), typeof(FontStretch), typeof(FullPasswordBox));

        public FontStyle PeekButtonFontStyle
        {
            get => (FontStyle)GetValue(PeekButtonFontStyleProperty);
            set => SetValue(PeekButtonFontStyleProperty, value);
        }

        public static readonly DependencyProperty PeekButtonFontStyleProperty =
            DependencyProperty.Register(nameof(PeekButtonFontStyle), typeof(FontStyle), typeof(FullPasswordBox));

        public FontWeight PeekButtonFontWeight
        {
            get => (FontWeight)GetValue(PeekButtonFontWeightProperty);
            set => SetValue(PeekButtonFontWeightProperty, value);
        }

        public static readonly DependencyProperty PeekButtonFontWeightProperty =
            DependencyProperty.Register(nameof(PeekButtonFontWeight), typeof(FontWeight), typeof(FullPasswordBox));

        public Cursor PeekButtonCursor
        {
            get => (Cursor)GetValue(PeekButtonCursorProperty);
            set => SetValue(PeekButtonCursorProperty, value);
        }

        public static readonly DependencyProperty PeekButtonCursorProperty =
            DependencyProperty.Register(nameof(PeekButtonCursor), typeof(Cursor), typeof(FullPasswordBox));

        public object PeekButtonContent
        {
            get => GetValue(PeekButtonContentProperty);
            set => SetValue(PeekButtonContentProperty, value);
        }

        public static readonly DependencyProperty PeekButtonContentProperty =
            DependencyProperty.Register(nameof(PeekButtonContent), typeof(object), typeof(FullPasswordBox));

        #region CopyButton

        public bool EnableCopyButton
        {
            get => (bool)GetValue(EnableCopyButtonProperty);
            set => SetValue(EnableCopyButtonProperty, value);
        }

        public static readonly DependencyProperty EnableCopyButtonProperty =
            DependencyProperty.Register(nameof(EnableCopyButton), typeof(bool), typeof(FullPasswordBox));

        public double CopyButtonSize
        {
            get => (double)GetValue(CopyButtonSizeProperty);
            set => SetValue(CopyButtonSizeProperty, value);
        }

        public static readonly DependencyProperty CopyButtonSizeProperty =
            DependencyProperty.Register(nameof(CopyButtonSize), typeof(double), typeof(FullPasswordBox));

        public FontFamily CopyButtonFontFamily
        {
            get => (FontFamily)GetValue(CopyButtonFontFamilyProperty);
            set => SetValue(CopyButtonFontFamilyProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontFamilyProperty =
            DependencyProperty.Register(nameof(CopyButtonFontFamily), typeof(FontFamily), typeof(FullPasswordBox));

        public double CopyButtonFontSize
        {
            get => (double)GetValue(CopyButtonFontSizeProperty);
            set => SetValue(CopyButtonFontSizeProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontSizeProperty =
            DependencyProperty.Register(nameof(CopyButtonFontSize), typeof(double), typeof(FullPasswordBox));

        public FontStretch CopyButtonFontStretch
        {
            get => (FontStretch)GetValue(CopyButtonFontStretchProperty);
            set => SetValue(CopyButtonFontStretchProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontStretchProperty =
            DependencyProperty.Register(nameof(CopyButtonFontStretch), typeof(FontStretch), typeof(FullPasswordBox));

        public FontStyle CopyButtonFontStyle
        {
            get => (FontStyle)GetValue(CopyButtonFontStyleProperty);
            set => SetValue(CopyButtonFontStyleProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontStyleProperty =
            DependencyProperty.Register(nameof(CopyButtonFontStyle), typeof(FontStyle), typeof(FullPasswordBox));

        public FontWeight CopyButtonFontWeight
        {
            get => (FontWeight)GetValue(CopyButtonFontWeightProperty);
            set => SetValue(CopyButtonFontWeightProperty, value);
        }

        public static readonly DependencyProperty CopyButtonFontWeightProperty =
            DependencyProperty.Register(nameof(CopyButtonFontWeight), typeof(FontWeight), typeof(FullPasswordBox));

        public Thickness CopyButtonMargin
        {
            get => (Thickness)GetValue(CopyButtonMarginProperty);
            set => SetValue(CopyButtonMarginProperty, value);
        }

        public static readonly DependencyProperty CopyButtonMarginProperty =
            DependencyProperty.Register(nameof(CopyButtonMargin), typeof(Thickness), typeof(FullPasswordBox));

        public object CopyButtonContent
        {
            get => GetValue(CopyButtonContentProperty);
            set => SetValue(CopyButtonContentProperty, value);
        }

        public static readonly DependencyProperty CopyButtonContentProperty =
            DependencyProperty.Register(nameof(CopyButtonContent), typeof(object), typeof(FullPasswordBox));

        public Brush CopyButtonBackground
        {
            get => (Brush)GetValue(CopyButtonBackgroundProperty);
            set => SetValue(CopyButtonBackgroundProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBackgroundProperty =
            DependencyProperty.Register(nameof(CopyButtonBackground), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonBackgroundOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnMouseOverProperty);
            set => SetValue(CopyButtonBackgroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnMouseOver), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonBackgroundOnPressed
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnPressedProperty);
            set => SetValue(CopyButtonBackgroundOnPressedProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnPressed), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonBackgroundOnDisabled
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnDisabledProperty);
            set => SetValue(CopyButtonBackgroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonBorderBrush
        {
            get => (Brush)GetValue(CopyButtonBorderBrushProperty);
            set => SetValue(CopyButtonBorderBrushProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderBrushProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrush), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonBorderBrushOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnMouseOverProperty);
            set => SetValue(CopyButtonBorderBrushOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnMouseOver), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonBorderBrushOnPressed
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnPressedProperty);
            set => SetValue(CopyButtonBorderBrushOnPressedProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderBrushOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnPressed), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonBorderBrushOnDisabled
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnDisabledProperty);
            set => SetValue(CopyButtonBorderBrushOnDisabledProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonForeground
        {
            get => (Brush)GetValue(CopyButtonForegroundProperty);
            set => SetValue(CopyButtonForegroundProperty, value);
        }

        public static readonly DependencyProperty CopyButtonForegroundProperty =
            DependencyProperty.Register(nameof(CopyButtonForeground), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonForegroundOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonForegroundOnMouseOverProperty);
            set => SetValue(CopyButtonForegroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty CopyButtonForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnMouseOver), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonForegroundOnPressed
        {
            get => (Brush)GetValue(CopyButtonForegroundOnPressedProperty);
            set => SetValue(CopyButtonForegroundOnPressedProperty, value);
        }

        public static readonly DependencyProperty CopyButtonForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnPressed), typeof(Brush), typeof(FullPasswordBox));

        public Brush CopyButtonForegroundOnDisabled
        {
            get => (Brush)GetValue(CopyButtonForegroundOnDisabledProperty);
            set => SetValue(CopyButtonForegroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty CopyButtonForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        public CornerRadius CopyButtonCornerRadius
        {
            get => (CornerRadius)GetValue(CopyButtonCornerRadiusProperty);
            set => SetValue(CopyButtonCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CopyButtonCornerRadiusProperty =
            DependencyProperty.Register(nameof(CopyButtonCornerRadius), typeof(CornerRadius), typeof(FullPasswordBox));

        public Thickness CopyButtonBorderThickness
        {
            get => (Thickness)GetValue(CopyButtonBorderThicknessProperty);
            set => SetValue(CopyButtonBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty CopyButtonBorderThicknessProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderThickness), typeof(Thickness), typeof(FullPasswordBox));

        public TimeSpan CopyButtonAnimationTime
        {
            get => (TimeSpan)GetValue(CopyButtonAnimationTimeProperty);
            set => SetValue(CopyButtonAnimationTimeProperty, value);
        }

        public static readonly DependencyProperty CopyButtonAnimationTimeProperty =
            DependencyProperty.Register(nameof(CopyButtonAnimationTime), typeof(TimeSpan), typeof(FullPasswordBox));

        #endregion

        public bool ShowIcon
        {
            get => (bool)GetValue(ShowIconProperty);
            set => SetValue(ShowIconProperty, value);
        }

        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register(nameof(ShowIcon), typeof(bool), typeof(FullPasswordBox));

        public double MaxIconSize
        {
            get => (double)GetValue(MaxIconSizeProperty);
            set => SetValue(MaxIconSizeProperty, value);
        }

        public static readonly DependencyProperty MaxIconSizeProperty =
            DependencyProperty.Register(nameof(MaxIconSize), typeof(double), typeof(FullPasswordBox));

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(FullPasswordBox));

        public HorizontalAlignment TextAlignment
        {
            get => (HorizontalAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }

        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register(nameof(TextAlignment), typeof(HorizontalAlignment), typeof(FullPasswordBox));

        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullPasswordBox));

        public char PasswordChar
        {
            get => (char)GetValue(PasswordCharProperty);
            set => SetValue(PasswordCharProperty, value);
        }

        public static readonly DependencyProperty PasswordCharProperty =
            DependencyProperty.Register(nameof(PasswordChar), typeof(char), typeof(FullPasswordBox));

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register(nameof(MaxLength), typeof(int), typeof(FullPasswordBox));

        public bool IsInactiveSelectionHighlightEnabled
        {
            get => (bool)GetValue(IsInactiveSelectionHighlightEnabledProperty);
            set => SetValue(IsInactiveSelectionHighlightEnabledProperty, value);
        }

        public static readonly DependencyProperty IsInactiveSelectionHighlightEnabledProperty =
            DependencyProperty.Register(nameof(IsInactiveSelectionHighlightEnabled), typeof(bool), typeof(FullPasswordBox));

        public SecureString SecurePassword => GetSecurePassword();

        public string Password
        {
            get => GetPassword();
            set => SetPassword(value);
        }

        public int PasswordLength => Password.Length;

        public bool IsSelectionActive => passwordBox != null && passwordBox.IsSelectionActive;

        public new bool IsFocused => passwordBox != null && passwordBox.IsFocused;

        public event RoutedEventHandler PasswordChanged;

        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        static FullPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullPasswordBox), new FrameworkPropertyMetadata(typeof(FullPasswordBox)));
        }

        public void Clear() => passwordBox?.Clear();

        public void Copy() => Clipboard.SetText(Password);

        public void Paste() => passwordBox?.Paste();

        public void SelectAll() => passwordBox?.SelectAll();

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            passwordBox = (PasswordBox)Template.FindName("PART_PasswordBox", this);
            peek = (TextBlock)Template.FindName("PART_Peek", this);
            Grid peekButton = (Grid)Template.FindName("PART_PeekButton", this);
            peekButton.MouseLeftButtonDown += PeekButton_MouseLeftButtonDown;
            peekButton.MouseLeftButtonUp += PeekButton_MouseLeftButtonUp;
            peekButton.MouseLeave += PeekButton_MouseLeave;
            ((Button)Template.FindName("PART_CopyButton", this)).Click += (s, e) => Copy();
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            passwordBox.GotFocus += PasswordBox_GotFocus;
            passwordBox.LostFocus += PasswordBox_LostFocus;
            UpdateHintState();
            IsEnabledChanged += (s, e) => OnEnabledChanged();
            SetValue(BackgroundBackProperty, Background);
            SetValue(BorderBrushBackProperty, BorderBrush);
            ReloadBackground();
            OnInitialized();
        }

        private void FullPasswordBox_Click(object sender, RoutedEventArgs e) => throw new NotImplementedException();

        private void OnInitialized()
        {
            if (_tempPassword != null)
            {
                SetPassword(_tempPassword);
                _tempPassword = null;
            }
        }

        private SecureString GetSecurePassword() => passwordBox != null ? passwordBox.SecurePassword : new SecureString();

        private void SetPassword(string password)
        {
            if (passwordBox != null) passwordBox.Password = password;
            else _tempPassword = password;
        }

        private string GetPassword() => passwordBox != null ? passwordBox.Password : "";

        private void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
            AdaptForeColors(e.ActualBackground);
            BackgroundChanged?.Invoke(this, e);
        }

        private void OnEnabledChanged()
        {
            ReloadBackground();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            PasswordChanged?.Invoke(sender, e);
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            _ = VisualStateManager.GoToState(this, "Focused", true);
            ReloadBackground();
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            _ = VisualStateManager.GoToState(this, IsMouseOver ? "MouseOver" : "Normal", true);
            ReloadBackground();
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsFocused)
            {
                _ = VisualStateManager.GoToState(this, "MouseOver", true);
                ReloadBackground();
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!IsFocused)
            {
                _ = VisualStateManager.GoToState(this, "Normal", true);
                ReloadBackground();
            }
        }

        private void PeekButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            peek.Text = Password;
            _ = VisualStateManager.GoToState(this, "Peeked", true);
        }

        private void PeekButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            peek.Text = "";
            _ = VisualStateManager.GoToState(this, "Unpeeked", true);
        }

        private void PeekButton_MouseLeave(object sender, MouseEventArgs e)
        {
            peek.Text = "";
            _ = VisualStateManager.GoToState(this, "Unpeeked", true);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            passwordBox?.Focus();
        }

        private void UpdateHintState()
        {
            _ = VisualStateManager.GoToState(this, PasswordLength == 0 && !IsFocused && ShowHint ? "Hinted" : "Unhinted", true);
        }

        private void AdaptForeColors(Brush backgroundBrush)
        {
            if (backgroundBrush is SolidColorBrush brush)
            {
                SolidColorBrush inverseBrush = new SolidColorBrush(brush.Color.Invert());
                if (AdaptForegroundAutomatically) Foreground = inverseBrush;
                if (AdaptHintForegroundAutomatically) HintForeground = inverseBrush;
                if (AdaptPeekForegroundAutomatically) PeekForeground = inverseBrush;
                if (AdaptPeekButtonForegroundAutomatically) PeekButtonForeground = inverseBrush;
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
