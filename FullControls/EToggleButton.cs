using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Core;

namespace FullControls
{
    /// <summary>
    /// Control that can switch states, such as <see cref="CheckBox"/>.
    /// </summary>
    public class EToggleButton : ToggleButton
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// Background color when the control is checked and the mouse is over the control.
        /// </summary>
        public Brush BackgroundOnMouseOverOnChecked
        {
            get => (Brush)GetValue(BackgroundOnMouseOverOnCheckedProperty);
            set => SetValue(BackgroundOnMouseOverOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnMouseOverOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// Background color when the control is checked.
        /// </summary>
        public Brush BackgroundOnChecked
        {
            get => (Brush)GetValue(BackgroundOnCheckedProperty);
            set => SetValue(BackgroundOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnCheckedProperty =
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(EToggleButton));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// Actual Background color of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(EToggleButton),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((EToggleButton)d).OnActualBackgroundChanged((Brush)e.NewValue))));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// BorderBrush color when the control is checked and the mouse is over the control.
        /// </summary>
        public Brush BorderBrushOnMouseOverOnChecked
        {
            get => (Brush)GetValue(BorderBrushOnMouseOverOnCheckedProperty);
            set => SetValue(BorderBrushOnMouseOverOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnMouseOverOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// BorderBrush color when the control is checked.
        /// </summary>
        public Brush BorderBrushOnChecked
        {
            get => (Brush)GetValue(BorderBrushOnCheckedProperty);
            set => SetValue(BorderBrushOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnCheckedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(EToggleButton));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// Actual BorderBrush color of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(EToggleButton));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// Foreground color when the control is checked and the mouse is over the control.
        /// </summary>
        public Brush ForegroundOnMouseOverOnChecked
        {
            get => (Brush)GetValue(ForegroundOnMouseOverOnCheckedProperty);
            set => SetValue(ForegroundOnMouseOverOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnMouseOverOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnChecked), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// Foreground color when the control is checked.
        /// </summary>
        public Brush ForegroundOnChecked
        {
            get => (Brush)GetValue(ForegroundOnCheckedProperty);
            set => SetValue(ForegroundOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnCheckedProperty =
            DependencyProperty.Register(nameof(ForegroundOnChecked), typeof(Brush), typeof(EToggleButton));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(EToggleButton));

        /// <summary>
        /// Actual Foreground color of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(EToggleButton));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(EToggleButton));

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
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(EToggleButton));

        /// <summary>
        /// Set if the button is activable-only by click, or deactivable-only by click, or both.
        /// </summary>
        public ToggleType ClickToggleType
        {
            get => (ToggleType)GetValue(ClickToggleTypeProperty);
            set => SetValue(ClickToggleTypeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ClickToggleType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ClickToggleTypeProperty =
            DependencyProperty.Register(nameof(ClickToggleType), typeof(ToggleType), typeof(EToggleButton), new PropertyMetadata(ToggleType.Complete));
        
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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(EToggleButton));


        /// <summary>
        /// Creates a new <see cref="EToggleButton"/>.
        /// </summary>
        static EToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EToggleButton), new FrameworkPropertyMetadata(typeof(EToggleButton)));
            IsEnabledProperty.OverrideMetadata(typeof(EToggleButton), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((EToggleButton)d).OnEnabledChanged((bool)e.NewValue))));
            IsCheckedProperty.OverrideMetadata(typeof(EToggleButton), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((EToggleButton)d).OnCheckedChanged((bool?)e.NewValue))));
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            loaded = true;
            ReloadBackground();
        }

        /// <summary>
        /// Called by the <see cref="ToggleButton.OnClick"/> method to implement toggle behavior.
        /// </summary>
        protected override void OnToggle()
        {
            switch (ClickToggleType)
            {
                case ToggleType.Activate:
                    if (IsChecked != true) base.OnToggle();
                    break;
                case ToggleType.Deactivate:
                    if (IsChecked == true) base.OnToggle();
                    break;
                case ToggleType.Complete:
                    base.OnToggle();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background color.</param>
        protected virtual void OnActualBackgroundChanged(Brush actualBackground) { }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState)
        {
            ReloadBackground();
        }

        /// <summary>
        /// Called when the <see cref="ToggleButton.IsChecked"/> is changed.
        /// </summary>
        /// <param name="checkedState">Actual state of <see cref="ToggleButton.IsChecked"/>.</param>

        protected virtual void OnCheckedChanged(bool? checkedState)
        {
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
        /// Apply the correct background to the control, based on its state.
        /// </summary>
        private void ReloadBackground()
        {
            if (!loaded) return;
            if (!IsEnabled) //Disabled state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnDisabled, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnDisabled, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnDisabled, TimeSpan.Zero);
            }
            else if (IsMouseOver) //MouseOver state
            {
                if (IsChecked == true)
                {
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOverOnChecked, TimeSpan.Zero);
                }
                else
                {
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOver, TimeSpan.Zero);
                }
            }
            else if (IsChecked == true) //Checked state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnChecked, AnimationTime);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnChecked, AnimationTime);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnChecked, TimeSpan.Zero);
            }
            else //Normal state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            }
        }
    }
}
