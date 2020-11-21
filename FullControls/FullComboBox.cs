using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    public class FullComboBox : ComboBox
    {
        public Brush BackgroundOnMouseOver
        {
            get => (Brush)GetValue(BackgroundOnMouseOverProperty);
            set => SetValue(BackgroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(FullComboBox));

        public Brush BackgroundOnMouseOverOnChecked
        {
            get => (Brush)GetValue(BackgroundOnMouseOverOnCheckedProperty);
            set => SetValue(BackgroundOnMouseOverOnCheckedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(FullComboBox));

        public Brush BackgroundOnChecked
        {
            get => (Brush)GetValue(BackgroundOnCheckedProperty);
            set => SetValue(BackgroundOnCheckedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnCheckedProperty =
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(FullComboBox));

        public Brush BackgroundOnDisabled
        {
            get => (Brush)GetValue(BackgroundOnDisabledProperty);
            set => SetValue(BackgroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullComboBox));

        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullComboBox));

        public Brush BorderBrushOnMouseOver
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverProperty);
            set => SetValue(BorderBrushOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(FullComboBox));

        public Brush BorderBrushOnMouseOverOnChecked
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverOnCheckedProperty);
            set => SetValue(BorderBrushOnMouseOverOnCheckedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(FullComboBox));

        public Brush BorderBrushOnChecked
        {
            get => (Brush)GetValue(BorderBrushOnCheckedProperty);
            set => SetValue(BorderBrushOnCheckedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnCheckedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(FullComboBox));

        public Brush BorderBrushOnDisabled
        {
            get => (Brush)GetValue(BorderBrushOnDisabledProperty);
            set => SetValue(BorderBrushOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullComboBox));

        public Brush ForeColor
        {
            get => (Brush)GetValue(ForeColorProperty);
            set => SetValue(ForeColorProperty, value);
        }

        public static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register(nameof(ForeColor), typeof(Brush), typeof(FullComboBox));

        public Brush ForeColorOnMouseOver
        {
            get => (Brush)GetValue(ForeColorOnMouseOverProperty);
            set => SetValue(ForeColorOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty ForeColorOnMouseOverProperty =
            DependencyProperty.Register(nameof(ForeColorOnMouseOver), typeof(Brush), typeof(FullComboBox));

        public Brush ForeColorOnMouseOverOnChecked
        {
            get => (Brush)GetValue(ForeColorOnMouseOverOnCheckedProperty);
            set => SetValue(ForeColorOnMouseOverOnCheckedProperty, value);
        }

        public static readonly DependencyProperty ForeColorOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(ForeColorOnMouseOverOnChecked), typeof(Brush), typeof(FullComboBox));

        public Brush ForeColorOnChecked
        {
            get => (Brush)GetValue(ForeColorOnCheckedProperty);
            set => SetValue(ForeColorOnCheckedProperty, value);
        }

        public static readonly DependencyProperty ForeColorOnCheckedProperty =
            DependencyProperty.Register(nameof(ForeColorOnChecked), typeof(Brush), typeof(FullComboBox));

        public Brush ForeColorOnDisabled
        {
            get => (Brush)GetValue(ForeColorOnDisabledProperty);
            set => SetValue(ForeColorOnDisabledProperty, value);
        }

        public static readonly DependencyProperty ForeColorOnDisabledProperty =
            DependencyProperty.Register(nameof(ForeColorOnDisabled), typeof(Brush), typeof(FullComboBox));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FullComboBox));

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(FullComboBox));

        public Thickness ToggleContentMargin
        {
            get => (Thickness)GetValue(ToggleContentMarginProperty);
            set => SetValue(ToggleContentMarginProperty, value);
        }

        public static readonly DependencyProperty ToggleContentMarginProperty =
            DependencyProperty.Register(nameof(ToggleContentMargin), typeof(Thickness), typeof(FullComboBox));

        public VerticalAlignment ToggleVerticalContentAlignment
        {
            get => (VerticalAlignment)GetValue(ToggleVerticalContentAlignmentProperty);
            set => SetValue(ToggleVerticalContentAlignmentProperty, value);
        }

        public static readonly DependencyProperty ToggleVerticalContentAlignmentProperty =
            DependencyProperty.Register(nameof(ToggleVerticalContentAlignment), typeof(VerticalAlignment), typeof(FullComboBox));

        public HorizontalAlignment ToggleHorizontalContentAlignment
        {
            get => (HorizontalAlignment)GetValue(ToggleHorizontalContentAlignmentProperty);
            set => SetValue(ToggleHorizontalContentAlignmentProperty, value);
        }

        public static readonly DependencyProperty ToggleHorizontalContentAlignmentProperty =
            DependencyProperty.Register(nameof(ToggleHorizontalContentAlignment), typeof(HorizontalAlignment), typeof(FullComboBox));

        public TextAlignment TextAlignment
        {
            get => (TextAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }

        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(FullComboBox));

        public Thickness PopupBorderThickness
        {
            get => (Thickness)GetValue(PopupBorderThicknessProperty);
            set => SetValue(PopupBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty PopupBorderThicknessProperty =
            DependencyProperty.Register(nameof(PopupBorderThickness), typeof(Thickness), typeof(FullComboBox));

        public bool AdaptForegroundAutomatically
        {
            get => (bool)GetValue(AdaptForegroundAutomaticallyProperty);
            set => SetValue(AdaptForegroundAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(FullComboBox));

        public bool AdaptCaretBrushAutomatically
        {
            get => (bool)GetValue(AdaptCaretBrushAutomaticallyProperty);
            set => SetValue(AdaptCaretBrushAutomaticallyProperty, value);
        }

        public static readonly DependencyProperty AdaptCaretBrushAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(FullComboBox));

        public Brush CaretBrush
        {
            get => (Brush)GetValue(CaretBrushProperty);
            set => SetValue(CaretBrushProperty, value);
        }

        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(FullComboBox));

        public Brush SelectionBrush
        {
            get => (Brush)GetValue(SelectionBrushProperty);
            set => SetValue(SelectionBrushProperty, value);
        }

        public static readonly DependencyProperty SelectionBrushProperty =
            DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(FullComboBox));

        public Brush SelectionTextBrush
        {
            get => (Brush)GetValue(SelectionTextBrushProperty);
            set => SetValue(SelectionTextBrushProperty, value);
        }

        public static readonly DependencyProperty SelectionTextBrushProperty =
            DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(FullComboBox));

        public Brush PopupBorderBrush
        {
            get => (Brush)GetValue(PopupBorderBrushProperty);
            set => SetValue(PopupBorderBrushProperty, value);
        }

        public static readonly DependencyProperty PopupBorderBrushProperty =
            DependencyProperty.Register(nameof(PopupBorderBrush), typeof(Brush), typeof(FullComboBox));

        public Brush PopupBackground
        {
            get => (Brush)GetValue(PopupBackgroundProperty);
            set => SetValue(PopupBackgroundProperty, value);
        }

        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.Register(nameof(PopupBackground), typeof(Brush), typeof(FullComboBox));

        public PopupAnimation PopupAnimation
        {
            get => (PopupAnimation)GetValue(PopupAnimationProperty);
            set => SetValue(PopupAnimationProperty, value);
        }

        public static readonly DependencyProperty PopupAnimationProperty =
            DependencyProperty.Register(nameof(PopupAnimation), typeof(PopupAnimation), typeof(FullComboBox));

        public double SelectionOpacity
        {
            get => (double)GetValue(SelectionOpacityProperty);
            set => SetValue(SelectionOpacityProperty, value);
        }

        public static readonly DependencyProperty SelectionOpacityProperty =
            DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(FullComboBox));

        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullComboBox));

        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        static FullComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullComboBox), new FrameworkPropertyMetadata(typeof(FullComboBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ((FullToggleButton)Template.FindName("PART_ToggleButton", this)).BackgroundChanged +=
                (o, e) => OnActualBackgroundChanged(new BackgroundChangedEventArgs(e.ActualBackground));
            OnActualBackgroundChanged(new BackgroundChangedEventArgs(IsEnabled ? IsDropDownOpen ? BackgroundOnChecked : Background : BackgroundOnDisabled));
        }

        protected virtual void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
            SetValue(ActualBackgroundProperty, e.ActualBackground);
            AdaptForeColors(e.ActualBackground);
            BackgroundChanged?.Invoke(this, e);
        }

        private void AdaptForeColors(Brush backgroundBrush)
        {
            if (backgroundBrush is SolidColorBrush brush)
            {
                SolidColorBrush inverseBrush = new SolidColorBrush(brush.Color.Invert());
                if (AdaptForegroundAutomatically) Foreground = inverseBrush;
                if (AdaptCaretBrushAutomatically) CaretBrush = inverseBrush;
            }
        }
    }
}
