﻿using FullControls.Core;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control that raises its <see cref="ButtonBase.Click"/> event repeatedly from the time it is pressed until it is released.
    /// </summary>
    public class ERepeatButton : RepeatButton
    {
        private bool loaded = false;

        /// <summary>
        /// Gets or sets the background brush when the mouse is over the control.
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
        /// Gets or sets the background brush when the control is pressed.
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
        /// Gets or sets the background brush when the control is disabled.
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
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(ERepeatButton), new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(ERepeatButton),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => d.SetValue(ActualBackgroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the border brush when the mouse is over the control.
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
        /// Gets or sets the border brush when the control is pressed.
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
        /// Gets or sets the border brush when the control is disabled.
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
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(ERepeatButton), new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(ERepeatButton),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => d.SetValue(ActualBorderBrushPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the foreground brush when the mouse is over the control.
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
        /// Gets or sets the foreground brush when the control is pressed.
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
        /// Gets or sets the foreground brush when the control is disabled.
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
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(ERepeatButton), new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(ERepeatButton),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => d.SetValue(ActualForegroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the corner radius of the control.
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
        /// Gets or sets the duration of the control animation when it changes state.
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


        static ERepeatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ERepeatButton), new FrameworkPropertyMetadata(typeof(ERepeatButton)));
            IsEnabledProperty.OverrideMetadata(typeof(ERepeatButton), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ERepeatButton)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ERepeatButton"/>.
        /// </summary>
        public ERepeatButton() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, Background, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, TimeSpan.Zero);
            loaded = true;
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

        /// <inheritdoc/>
        protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsPressedChanged(e);
            OnVStateChanged(VStateOverride());
        }

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            OnVStateChanged(VStateOverride());
        }

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            OnVStateChanged(VStateOverride());
        }

        /// <summary>
        /// Called to calculate the <b>v-state</b> of the control.
        /// </summary>
        protected virtual string VStateOverride()
        {
            if (!loaded) return "Undefined";
            if (!IsEnabled) return "Disabled";
            else if (IsPressed) return "Pressed";
            else if (IsMouseOver) return "MouseOver";
            else return "Normal";
        }

        /// <summary>
        /// Called when the <b>v-state</b> of the control changed.
        /// </summary>
        /// <remarks>Is called <b>v-state</b> because is not related to the VisualState of the control.</remarks>
        /// <param name="vstate">Actual <b>v-state</b> of the control.</param>
        protected virtual void OnVStateChanged(string vstate)
        {
            switch (vstate)
            {
                case "Normal":
                    Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, Background, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, TimeSpan.Zero);
                    break;
                case "MouseOver":
                    Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOver, TimeSpan.Zero);
                    break;
                case "Pressed":
                    Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnPressed, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnPressed, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnPressed, TimeSpan.Zero);
                    break;
                case "Disabled":
                    Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabled, TimeSpan.Zero);
                    break;
                default:
                    break;
            }
        }
    }
}
