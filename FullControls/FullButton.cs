using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    public class FullButton : Button
    {
        public Brush BackgroundOnMouseOver
        {
            get => (Brush)GetValue(BackgroundOnMouseOverProperty);
            set => SetValue(BackgroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(FullButton));

        public Brush BackgroundOnPressed
        {
            get => (Brush)GetValue(BackgroundOnPressedProperty);
            set => SetValue(BackgroundOnPressedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(BackgroundOnPressed), typeof(Brush), typeof(FullButton));

        public Brush BackgroundOnDisabled
        {
            get => (Brush)GetValue(BackgroundOnDisabledProperty);
            set => SetValue(BackgroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullButton));

        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullButton));

        #region BackgroundBack

        internal Brush BackgroundBack
        {
            get => (Brush)GetValue(BackgroundBackProperty);
            set => SetValue(BackgroundBackProperty, value);
        }

        internal static readonly DependencyProperty BackgroundBackProperty =
            DependencyProperty.Register(nameof(BackgroundBack), typeof(Brush), typeof(FullButton),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualBackgroundProperty, e.NewValue);
                    ((FullButton)d).OnActualBackgroundChanged(new BackgroundChangedEventArgs((Brush)e.NewValue));
                })));

        #endregion

        public Brush BorderBrushOnMouseOver
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverProperty);
            set => SetValue(BorderBrushOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(FullButton));

        public Brush BorderBrushOnPressed
        {
            get => (Brush)GetValue(BorderBrushOnPressedProperty);
            set => SetValue(BorderBrushOnPressedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnPressedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnPressed), typeof(Brush), typeof(FullButton));

        public Brush BorderBrushOnDisabled
        {
            get => (Brush)GetValue(BorderBrushOnDisabledProperty);
            set => SetValue(BorderBrushOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullButton));

        #region BorderBrushBack

        internal Brush BorderBrushBack
        {
            get => (Brush)GetValue(BorderBrushBackProperty);
            set => SetValue(BorderBrushBackProperty, value);
        }

        internal static readonly DependencyProperty BorderBrushBackProperty =
            DependencyProperty.Register(nameof(BorderBrushBack), typeof(Brush), typeof(FullButton));

        #endregion

        public Brush ForegroundOnMouseOver
        {
            get => (Brush)GetValue(ForegroundOnMouseOverProperty);
            set => SetValue(ForegroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(FullButton));

        public Brush ForegroundOnPressed
        {
            get => (Brush)GetValue(ForegroundOnPressedProperty);
            set => SetValue(ForegroundOnPressedProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(ForegroundOnPressed), typeof(Brush), typeof(FullButton));

        public Brush ForegroundOnDisabled
        {
            get => (Brush)GetValue(ForegroundOnDisabledProperty);
            set => SetValue(ForegroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(FullButton));

        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        public static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(FullButton));

        #region ActualForegroundBack

        internal Brush ActualForegroundBack
        {
            get => (Brush)GetValue(ActualForegroundBackProperty);
            set => SetValue(ActualForegroundBackProperty, value);
        }

        internal static readonly DependencyProperty ActualForegroundBackProperty =
            DependencyProperty.Register(nameof(ActualForegroundBack), typeof(Brush), typeof(FullButton),
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FullButton));

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(FullButton));

        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullButton));

        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        static FullButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullButton), new FrameworkPropertyMetadata(typeof(FullButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            IsEnabledChanged += (s, e) => OnEnabledChanged((bool)e.NewValue);
            SetValue(BackgroundBackProperty, Background);
            SetValue(BorderBrushBackProperty, BorderBrush);
            ReloadBackground();
        }

        protected virtual void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
            BackgroundChanged?.Invoke(this, e);
        }

        protected virtual void OnEnabledChanged(bool enabledState)
        {
            ReloadBackground();
        }

        protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsPressedChanged(e);
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
            else if (IsPressed) //Pressed state
            {
                SetValue(BackgroundBackProperty, BackgroundOnPressed);
                SetValue(BorderBrushBackProperty, BorderBrushOnPressed);
            }
            else if (IsMouseOver) //MouseOver state
            {
                Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnMouseOver, AnimationTime);
                Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnMouseOver, AnimationTime);
            }
            else //Normal state
            {
                SetValue(BackgroundBackProperty, Background);
                SetValue(BorderBrushBackProperty, BorderBrush);
            }
        }
    }
}
