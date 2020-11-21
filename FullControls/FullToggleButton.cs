using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    public class FullToggleButton : ToggleButton
    {
        public Brush BackgroundOnMouseOver
        {
            get => (Brush)GetValue(BackgroundOnMouseOverProperty);
            set => SetValue(BackgroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(FullToggleButton));

        public Brush BackgroundOnMouseOverOnChecked
        {
            get => (Brush)GetValue(BackgroundOnMouseOverOnCheckedProperty);
            set => SetValue(BackgroundOnMouseOverOnCheckedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(FullToggleButton));

        public Brush BackgroundOnChecked
        {
            get => (Brush)GetValue(BackgroundOnCheckedProperty);
            set => SetValue(BackgroundOnCheckedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnCheckedProperty =
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(FullToggleButton));

        public Brush BackgroundOnDisabled
        {
            get => (Brush)GetValue(BackgroundOnDisabledProperty);
            set => SetValue(BackgroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullToggleButton));

        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullToggleButton));

        #region BackgroundBack

        internal Brush BackgroundBack
        {
            get => (Brush)GetValue(BackgroundBackProperty);
            set => SetValue(BackgroundBackProperty, value);
        }

        internal static readonly DependencyProperty BackgroundBackProperty =
            DependencyProperty.Register(nameof(BackgroundBack), typeof(Brush), typeof(FullToggleButton),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualBackgroundProperty, e.NewValue);
                    ((FullToggleButton)d).OnActualBackgroundChanged(new BackgroundChangedEventArgs((Brush)e.NewValue));
                })));

        #endregion

        public Brush BorderBrushOnMouseOver
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverProperty);
            set => SetValue(BorderBrushOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(FullToggleButton));

        public Brush BorderBrushOnMouseOverOnChecked
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverOnCheckedProperty);
            set => SetValue(BorderBrushOnMouseOverOnCheckedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(FullToggleButton));

        public Brush BorderBrushOnChecked
        {
            get => (Brush)GetValue(BorderBrushOnCheckedProperty);
            set => SetValue(BorderBrushOnCheckedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnCheckedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(FullToggleButton));

        public Brush BorderBrushOnDisabled
        {
            get => (Brush)GetValue(BorderBrushOnDisabledProperty);
            set => SetValue(BorderBrushOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullToggleButton));

        #region BorderBrushBack

        internal Brush BorderBrushBack
        {
            get => (Brush)GetValue(BorderBrushBackProperty);
            set => SetValue(BorderBrushBackProperty, value);
        }

        internal static readonly DependencyProperty BorderBrushBackProperty =
            DependencyProperty.Register(nameof(BorderBrushBack), typeof(Brush), typeof(FullToggleButton));

        #endregion

        public Brush ForegroundOnMouseOver
        {
            get => (Brush)GetValue(ForegroundOnMouseOverProperty);
            set => SetValue(ForegroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(FullToggleButton));

        public Brush ForegroundOnMouseOverOnChecked
        {
            get => (Brush)GetValue(ForegroundOnMouseOverOnCheckedProperty);
            set => SetValue(ForegroundOnMouseOverOnCheckedProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnChecked), typeof(Brush), typeof(FullToggleButton));

        public Brush ForegroundOnChecked
        {
            get => (Brush)GetValue(ForegroundOnCheckedProperty);
            set => SetValue(ForegroundOnCheckedProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnCheckedProperty =
            DependencyProperty.Register(nameof(ForegroundOnChecked), typeof(Brush), typeof(FullToggleButton));

        public Brush ForegroundOnDisabled
        {
            get => (Brush)GetValue(ForegroundOnDisabledProperty);
            set => SetValue(ForegroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(FullToggleButton));

        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        public static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(FullToggleButton));

        #region ActualForegroundBack

        internal Brush ActualForegroundBack
        {
            get => (Brush)GetValue(ActualForegroundBackProperty);
            set => SetValue(ActualForegroundBackProperty, value);
        }

        internal static readonly DependencyProperty ActualForegroundBackProperty =
            DependencyProperty.Register(nameof(ActualForegroundBack), typeof(Brush), typeof(FullToggleButton),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualForegroundProperty, e.NewValue);
                })));

        #endregion

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FullToggleButton));

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(FullToggleButton));

        public bool IsDeactivableByClick
        {
            get => (bool)GetValue(IsDeactivableByClickProperty);
            set => SetValue(IsDeactivableByClickProperty, value);
        }

        public static readonly DependencyProperty IsDeactivableByClickProperty =
            DependencyProperty.Register(nameof(IsDeactivableByClick), typeof(bool), typeof(FullToggleButton), new PropertyMetadata(true));

        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullToggleButton));

        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        static FullToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullToggleButton), new FrameworkPropertyMetadata(typeof(FullToggleButton)));
            IsCheckedProperty.OverrideMetadata(typeof(FullToggleButton), new FrameworkPropertyMetadata(false,
                new PropertyChangedCallback((d, e) => ((FullToggleButton)d).OnCheckedChanged((bool?)e.NewValue))));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            IsEnabledChanged += (s, e) => OnEnabledChanged((bool)e.NewValue);
            SetValue(BackgroundBackProperty, Background);
            SetValue(BorderBrushBackProperty, BorderBrush);
            ReloadBackground();
        }

        protected override void OnToggle()
        {
            if (IsDeactivableByClick || IsChecked != true) base.OnToggle();
        }

        protected virtual void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
            BackgroundChanged?.Invoke(this, e);
        }

        protected virtual void OnEnabledChanged(bool enabledState)
        {
            ReloadBackground();
        }

        protected virtual void OnCheckedChanged(bool? checkedState)
        {
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

        private void ReloadBackground()
        {
            if (!IsEnabled) //Disabled state
            {
                SetValue(BackgroundBackProperty, BackgroundOnDisabled);
                SetValue(BorderBrushBackProperty, BorderBrushOnDisabled);
            }
            else if (IsMouseOver) //MouseOver state
            {
                if (IsChecked == true)
                {
                    Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnMouseOverOnChecked, AnimationTime);
                }
                else
                {
                    Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnMouseOver, AnimationTime);
                }
            }
            else if (IsChecked == true) //Checked state
            {
                Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnChecked, AnimationTime);
                Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnChecked, AnimationTime);
            }
            else //Normal state
            {
                SetValue(BackgroundBackProperty, Background);
                SetValue(BorderBrushBackProperty, BorderBrush);
            }
        }
    }
}
