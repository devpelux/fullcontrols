using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Core;

namespace FullControls
{
    /// <summary>
    /// Represents a control that raises its <see cref="ButtonBase.Click"/> event repeatedly from the time it is pressed until it is released.
    /// </summary>
    public class ERepeatButton : RepeatButton
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(ERepeatButton));

        /// <summary>
        /// Background color when the control is pressed.
        /// </summary>
        public Brush BackgroundOnPressed
        {
            get => (Brush)GetValue(BackgroundOnPressedProperty);
            set => SetValue(BackgroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(BackgroundOnPressed), typeof(Brush), typeof(ERepeatButton));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(ERepeatButton));

        /// <summary>
        /// Actual Background color of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(ERepeatButton),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((ERepeatButton)d).OnActualBackgroundChanged((Brush)e.NewValue))));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(ERepeatButton));

        /// <summary>
        /// BorderBrush color when the control is pressed.
        /// </summary>
        public Brush BorderBrushOnPressed
        {
            get => (Brush)GetValue(BorderBrushOnPressedProperty);
            set => SetValue(BorderBrushOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnPressedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnPressed), typeof(Brush), typeof(ERepeatButton));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(ERepeatButton));

        /// <summary>
        /// Actual BorderBrush color of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(ERepeatButton));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(ERepeatButton));

        /// <summary>
        /// Foreground color when the control is pressed.
        /// </summary>
        public Brush ForegroundOnPressed
        {
            get => (Brush)GetValue(ForegroundOnPressedProperty);
            set => SetValue(ForegroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(ForegroundOnPressed), typeof(Brush), typeof(ERepeatButton));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(ERepeatButton));

        /// <summary>
        /// Actual Foreground color of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(ERepeatButton));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ERepeatButton));

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
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(ERepeatButton));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(ERepeatButton));


        /// <summary>
        /// Creates a new <see cref="ERepeatButton"/>.
        /// </summary>
        static ERepeatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ERepeatButton), new FrameworkPropertyMetadata(typeof(ERepeatButton)));
            IsEnabledProperty.OverrideMetadata(typeof(ERepeatButton), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ERepeatButton)d).OnEnabledChanged((bool)e.NewValue))));
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
        /// Called when <see cref="ButtonBase.IsPressed"/> property changes.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsPressedChanged(e);
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
            else if (IsPressed) //Pressed state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnPressed, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnPressed, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnPressed, TimeSpan.Zero);
            }
            else if (IsMouseOver) //MouseOver state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOver, AnimationTime);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOver, AnimationTime);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOver, TimeSpan.Zero);
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
