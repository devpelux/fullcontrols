using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    public class FullComboBoxItem : ComboBoxItem
    {
        private bool loaded = false;

        public Brush BackgroundOnMouseOver
        {
            get => (Brush)GetValue(BackgroundOnMouseOverProperty);
            set => SetValue(BackgroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BackgroundOnMouseOverOnSelected
        {
            get => (Brush)GetValue(BackgroundOnMouseOverOnSelectedProperty);
            set => SetValue(BackgroundOnMouseOverOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnMouseOverOnSelectedProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BackgroundOnSelected
        {
            get => (Brush)GetValue(BackgroundOnSelectedProperty);
            set => SetValue(BackgroundOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnSelectedProperty =
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BackgroundOnFocused
        {
            get => (Brush)GetValue(BackgroundOnFocusedProperty);
            set => SetValue(BackgroundOnFocusedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnFocusedProperty =
            DependencyProperty.Register(nameof(BackgroundOnFocused), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BackgroundOnFocusedOnSelected
        {
            get => (Brush)GetValue(BackgroundOnFocusedOnSelectedProperty);
            set => SetValue(BackgroundOnFocusedOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnFocusedOnSelectedProperty =
            DependencyProperty.Register(nameof(BackgroundOnFocusedOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BackgroundOnDisabled
        {
            get => (Brush)GetValue(BackgroundOnDisabledProperty);
            set => SetValue(BackgroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullComboBoxItem));

        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullComboBoxItem));

        #region BackgroundBack

        internal Brush BackgroundBack
        {
            get => (Brush)GetValue(BackgroundBackProperty);
            set => SetValue(BackgroundBackProperty, value);
        }

        internal static readonly DependencyProperty BackgroundBackProperty =
            DependencyProperty.Register(nameof(BackgroundBack), typeof(Brush), typeof(FullComboBoxItem),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualBackgroundProperty, e.NewValue);
                    ((FullComboBoxItem)d).OnActualBackgroundChanged(new BackgroundChangedEventArgs((Brush)e.NewValue));
                })));

        #endregion

        public Brush BorderBrushOnMouseOver
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverProperty);
            set => SetValue(BorderBrushOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BorderBrushOnMouseOverOnSelected
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverOnSelectedProperty);
            set => SetValue(BorderBrushOnMouseOverOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnMouseOverOnSelectedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BorderBrushOnSelected
        {
            get => (Brush)GetValue(BorderBrushOnSelectedProperty);
            set => SetValue(BorderBrushOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnSelectedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BorderBrushOnFocused
        {
            get => (Brush)GetValue(BorderBrushOnFocusedProperty);
            set => SetValue(BorderBrushOnFocusedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnFocusedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnFocused), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BorderBrushOnFocusedOnSelected
        {
            get => (Brush)GetValue(BorderBrushOnFocusedOnSelectedProperty);
            set => SetValue(BorderBrushOnFocusedOnSelectedProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnFocusedOnSelectedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnFocusedOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush BorderBrushOnDisabled
        {
            get => (Brush)GetValue(BorderBrushOnDisabledProperty);
            set => SetValue(BorderBrushOnDisabledProperty, value);
        }

        public static readonly DependencyProperty BorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullComboBoxItem));

        #region BorderBrushBack

        internal Brush BorderBrushBack
        {
            get => (Brush)GetValue(BorderBrushBackProperty);
            set => SetValue(BorderBrushBackProperty, value);
        }

        internal static readonly DependencyProperty BorderBrushBackProperty =
            DependencyProperty.Register(nameof(BorderBrushBack), typeof(Brush), typeof(FullComboBoxItem));

        #endregion

        public Brush ForegroundOnMouseOver
        {
            get => (Brush)GetValue(ForegroundOnMouseOverProperty);
            set => SetValue(ForegroundOnMouseOverProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(FullComboBoxItem));

        public Brush ForegroundOnMouseOverOnSelected
        {
            get => (Brush)GetValue(ForegroundOnMouseOverOnSelectedProperty);
            set => SetValue(ForegroundOnMouseOverOnSelectedProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnMouseOverOnSelectedProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush ForegroundOnSelected
        {
            get => (Brush)GetValue(ForegroundOnSelectedProperty);
            set => SetValue(ForegroundOnSelectedProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnSelectedProperty =
            DependencyProperty.Register(nameof(ForegroundOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush ForegroundOnFocused
        {
            get => (Brush)GetValue(ForegroundOnFocusedProperty);
            set => SetValue(ForegroundOnFocusedProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnFocusedProperty =
            DependencyProperty.Register(nameof(ForegroundOnFocused), typeof(Brush), typeof(FullComboBoxItem));

        public Brush ForegroundOnFocusedOnSelected
        {
            get => (Brush)GetValue(ForegroundOnFocusedOnSelectedProperty);
            set => SetValue(ForegroundOnFocusedOnSelectedProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnFocusedOnSelectedProperty =
            DependencyProperty.Register(nameof(ForegroundOnFocusedOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        public Brush ForegroundOnDisabled
        {
            get => (Brush)GetValue(ForegroundOnDisabledProperty);
            set => SetValue(ForegroundOnDisabledProperty, value);
        }

        public static readonly DependencyProperty ForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(FullComboBoxItem));

        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        public static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(FullComboBoxItem));

        #region ActualForegroundBack

        internal Brush ActualForegroundBack
        {
            get => (Brush)GetValue(ActualForegroundBackProperty);
            set => SetValue(ActualForegroundBackProperty, value);
        }

        internal static readonly DependencyProperty ActualForegroundBackProperty =
            DependencyProperty.Register(nameof(ActualForegroundBack), typeof(Brush), typeof(FullComboBoxItem),
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FullComboBoxItem));

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(FullComboBoxItem));

        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullComboBoxItem));

        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        static FullComboBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullComboBoxItem), new FrameworkPropertyMetadata(typeof(FullComboBoxItem)));
            IsSelectedProperty.OverrideMetadata(typeof(FullComboBoxItem), new FrameworkPropertyMetadata(false,
                new PropertyChangedCallback((d, e) => ((FullComboBoxItem)d).OnSelectedChanged((bool)e.NewValue))));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            IsEnabledChanged += (s, e) => OnEnabledChanged((bool)e.NewValue);
            SetValue(BackgroundBackProperty, Background);
            SetValue(BorderBrushBackProperty, BorderBrush);
            ReloadBackground();
            loaded = true;
        }

        protected virtual void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
            BackgroundChanged?.Invoke(this, e);
        }

        protected virtual void OnEnabledChanged(bool enabledState)
        {
            ReloadBackground();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            ReloadBackground();
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
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

        protected virtual void OnSelectedChanged(bool selectedState)
        {
            if (loaded) ReloadBackground();
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
                if (IsSelected)
                {
                    Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnMouseOverOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnMouseOverOnSelected, AnimationTime);
                }
                else
                {
                    Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnMouseOver, AnimationTime);
                }
            }
            else if (IsFocused) //Focused state
            {
                if (IsSelected)
                {
                    Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnFocusedOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnFocusedOnSelected, AnimationTime);
                }
                else
                {
                    Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnFocused, AnimationTime);
                    Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnFocused, AnimationTime);
                }
            }
            else if (IsSelected) //Selected state
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
