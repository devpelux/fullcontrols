using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    /// <summary>
    /// Implements a selectable item inside a <see cref="ComboBox"/>.
    /// </summary>
    public class FullComboBoxItem : ComboBoxItem
    {
        private bool loaded = false;

        /// <summary>
        /// Background color when the mouse is over the control.
        /// </summary>
        public Brush BackgroundOnMouseOver
        {
            get => (Brush)GetValue(BackgroundOnMouseOverProperty);
            set => SetValue(BackgroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Background color when the control is selected and the mouse is over the control.
        /// </summary>
        public Brush BackgroundOnMouseOverOnSelected
        {
            get => (Brush)GetValue(BackgroundOnMouseOverOnSelectedProperty);
            set => SetValue(BackgroundOnMouseOverOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnMouseOverOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnMouseOverOnSelectedProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnSelected), typeof(Brush), typeof(FullComboBoxItem));

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
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Background color when the control is focused.
        /// </summary>
        public Brush BackgroundOnFocused
        {
            get => (Brush)GetValue(BackgroundOnFocusedProperty);
            set => SetValue(BackgroundOnFocusedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnFocused"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnFocusedProperty =
            DependencyProperty.Register(nameof(BackgroundOnFocused), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Background color when the control is focused and selected.
        /// </summary>
        public Brush BackgroundOnFocusedOnSelected
        {
            get => (Brush)GetValue(BackgroundOnFocusedOnSelectedProperty);
            set => SetValue(BackgroundOnFocusedOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnFocusedOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnFocusedOnSelectedProperty =
            DependencyProperty.Register(nameof(BackgroundOnFocusedOnSelected), typeof(Brush), typeof(FullComboBoxItem));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Actual Background color of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullComboBoxItem));

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
            DependencyProperty.Register(nameof(BackgroundBack), typeof(Brush), typeof(FullComboBoxItem),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualBackgroundProperty, e.NewValue);
                    ((FullComboBoxItem)d).OnActualBackgroundChanged(new BackgroundChangedEventArgs((Brush)e.NewValue));
                })));

        #endregion

        /// <summary>
        /// BorderBrush color when the mouse is over the control.
        /// </summary>
        public Brush BorderBrushOnMouseOver
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverProperty);
            set => SetValue(BorderBrushOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// BorderBrush color when the control is selected and the mouse is over the control.
        /// </summary>
        public Brush BorderBrushOnMouseOverOnSelected
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverOnSelectedProperty);
            set => SetValue(BorderBrushOnMouseOverOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnMouseOverOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnMouseOverOnSelectedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnSelected), typeof(Brush), typeof(FullComboBoxItem));

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
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// BorderBrush color when the control is focused.
        /// </summary>
        public Brush BorderBrushOnFocused
        {
            get => (Brush)GetValue(BorderBrushOnFocusedProperty);
            set => SetValue(BorderBrushOnFocusedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnFocused"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnFocusedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnFocused), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// BorderBrush color when the control is focused and selected.
        /// </summary>
        public Brush BorderBrushOnFocusedOnSelected
        {
            get => (Brush)GetValue(BorderBrushOnFocusedOnSelectedProperty);
            set => SetValue(BorderBrushOnFocusedOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnFocusedOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnFocusedOnSelectedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnFocusedOnSelected), typeof(Brush), typeof(FullComboBoxItem));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullComboBoxItem));

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
            DependencyProperty.Register(nameof(BorderBrushBack), typeof(Brush), typeof(FullComboBoxItem));

        #endregion

        /// <summary>
        /// Foreground color when the mouse is over the control.
        /// </summary>
        public Brush ForegroundOnMouseOver
        {
            get => (Brush)GetValue(ForegroundOnMouseOverProperty);
            set => SetValue(ForegroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Foreground color when the control is selected and the mouse is over the control.
        /// </summary>
        public Brush ForegroundOnMouseOverOnSelected
        {
            get => (Brush)GetValue(ForegroundOnMouseOverOnSelectedProperty);
            set => SetValue(ForegroundOnMouseOverOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnMouseOverOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnMouseOverOnSelectedProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Foreground color when the control is selected.
        /// </summary>
        public Brush ForegroundOnSelected
        {
            get => (Brush)GetValue(ForegroundOnSelectedProperty);
            set => SetValue(ForegroundOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnSelectedProperty =
            DependencyProperty.Register(nameof(ForegroundOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Foreground color when the control is focused.
        /// </summary>
        public Brush ForegroundOnFocused
        {
            get => (Brush)GetValue(ForegroundOnFocusedProperty);
            set => SetValue(ForegroundOnFocusedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnFocused"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnFocusedProperty =
            DependencyProperty.Register(nameof(ForegroundOnFocused), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Foreground color when the control is focused and selected.
        /// </summary>
        public Brush ForegroundOnFocusedOnSelected
        {
            get => (Brush)GetValue(ForegroundOnFocusedOnSelectedProperty);
            set => SetValue(ForegroundOnFocusedOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnFocusedOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnFocusedOnSelectedProperty =
            DependencyProperty.Register(nameof(ForegroundOnFocusedOnSelected), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Foreground color when the control is disabled.
        /// </summary>
        public Brush ForegroundOnDisabled
        {
            get => (Brush)GetValue(ForegroundOnDisabledProperty);
            set => SetValue(ForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(FullComboBoxItem));

        /// <summary>
        /// Actual Foreground color of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(FullComboBoxItem));

        #region ActualForegroundBack

        /// <summary>
        /// Actual Foreground color of the control.
        /// </summary>
        internal Brush ActualForegroundBack
        {
            get => (Brush)GetValue(ActualForegroundBackProperty);
            set => SetValue(ActualForegroundBackProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ActualForegroundBack"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForegroundBackProperty =
            DependencyProperty.Register(nameof(ActualForegroundBack), typeof(Brush), typeof(FullComboBoxItem),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualForegroundProperty, e.NewValue);
                })));

        #endregion

        /// <summary>
        /// CornerRadius of the control.
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FullComboBoxItem));

        /// <summary>
        /// Margin of the control content.
        /// </summary>
        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ContentMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(FullComboBoxItem));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullComboBoxItem));

        /// <summary>
        /// Raised when the background is changed.
        /// </summary>
        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        /// <summary>
        /// Creates a new <see cref="FullComboBoxItem"/>.
        /// </summary>
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

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="e">Data of the <see cref="BackgroundChanged"/> event.</param>
        protected virtual void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
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

        /// <summary>
        /// Called when the <see cref="ListBoxItem.IsSelected"/> is changed.
        /// </summary>
        /// <param name="selectedState">Actual state of <see cref="ListBoxItem.IsSelected"/>.</param>
        protected virtual void OnSelectedChanged(bool selectedState)
        {
            if (loaded) ReloadBackground();
        }

        /// <summary>
        /// Apply the correct background to the control, based on its state.
        /// </summary>
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
