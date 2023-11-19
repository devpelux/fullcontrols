using FullControls.Common;
using FullControls.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// <para>Represents a button that a user can select and clear.</para>
    /// <para>Multiple switchers can be grouped, so only one of the group can stay selected on the same time.</para>
    /// </summary>
    public class Switcher : RadioButton, IVState
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the background brush when the control is checked and the mouse is over the control.
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(Switcher));

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
            DependencyProperty.Register(nameof(BackgroundOnPressed), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the background brush when the control is checked and is pressed.
        /// </summary>
        public Brush BackgroundOnPressedOnChecked
        {
            get => (Brush)GetValue(BackgroundOnPressedOnCheckedProperty);
            set => SetValue(BackgroundOnPressedOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnPressedOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnPressedOnCheckedProperty =
            DependencyProperty.Register(nameof(BackgroundOnPressedOnChecked), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the background brush when the control is checked.
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
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(Switcher));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the background brush when the control is checked and is disabled.
        /// </summary>
        public Brush BackgroundOnDisabledOnChecked
        {
            get => (Brush)GetValue(BackgroundOnDisabledOnCheckedProperty);
            set => SetValue(BackgroundOnDisabledOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnDisabledOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnDisabledOnCheckedProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabledOnChecked), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(Switcher),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(Switcher),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBackgroundPropertyKey, e.NewValue))));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the border brush when the control is checked and the mouse is over the control.
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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(Switcher));

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
            DependencyProperty.Register(nameof(BorderBrushOnPressed), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the border brush when the control is checked and is pressed.
        /// </summary>
        public Brush BorderBrushOnPressedOnChecked
        {
            get => (Brush)GetValue(BorderBrushOnPressedOnCheckedProperty);
            set => SetValue(BorderBrushOnPressedOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnPressedOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnPressedOnCheckedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnPressedOnChecked), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the border brush when the control is checked.
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
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(Switcher));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the border brush when the control is checked and is disabled.
        /// </summary>
        public Brush BorderBrushOnDisabledOnChecked
        {
            get => (Brush)GetValue(BorderBrushOnDisabledOnCheckedProperty);
            set => SetValue(BorderBrushOnDisabledOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnDisabledOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnDisabledOnCheckedProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabledOnChecked), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(Switcher),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(Switcher),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBorderBrushPropertyKey, e.NewValue))));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the foreground brush when the control is checked and the mouse is over the control.
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
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnChecked), typeof(Brush), typeof(Switcher));

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
            DependencyProperty.Register(nameof(ForegroundOnPressed), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the foreground brush when the control is checked and is pressed.
        /// </summary>
        public Brush ForegroundOnPressedOnChecked
        {
            get => (Brush)GetValue(ForegroundOnPressedOnCheckedProperty);
            set => SetValue(ForegroundOnPressedOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnPressedOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnPressedOnCheckedProperty =
            DependencyProperty.Register(nameof(ForegroundOnPressedOnChecked), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the foreground brush when the control is checked.
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
            DependencyProperty.Register(nameof(ForegroundOnChecked), typeof(Brush), typeof(Switcher));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets or sets the foreground brush when the control is checked and is disabled.
        /// </summary>
        public Brush ForegroundOnDisabledOnChecked
        {
            get => (Brush)GetValue(ForegroundOnDisabledOnCheckedProperty);
            set => SetValue(ForegroundOnDisabledOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnDisabledOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnDisabledOnCheckedProperty =
            DependencyProperty.Register(nameof(ForegroundOnDisabledOnChecked), typeof(Brush), typeof(Switcher));

        /// <summary>
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(Switcher),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(Switcher),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualForegroundPropertyKey, e.NewValue))));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(Switcher));

        /// <summary>
        /// Gets or sets if the control is activable-only by click, or deactivable-only by click, or both.
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
            DependencyProperty.Register(nameof(ClickToggleType), typeof(ToggleType), typeof(Switcher),
                new PropertyMetadata(ToggleType.Activate));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(Switcher));


        static Switcher()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Switcher),
                new FrameworkPropertyMetadata(typeof(Switcher)));

            IsEnabledProperty.OverrideMetadata(typeof(Switcher),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((Switcher)d).OnEnabledChanged((bool)e.NewValue))));

            IsCheckedProperty.OverrideMetadata(typeof(Switcher),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((Switcher)d).OnCheckedChanged((bool?)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Switcher"/>.
        /// </summary>
        public Switcher() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            loaded = true;
            OnVStateChanged(GetCurrentVState(), true);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnVStateChanged(GetCurrentVState());

        /// <inheritdoc/>
        protected override void OnToggle() => SetCurrentValue(IsCheckedProperty, Util.ToggleCycle(IsChecked, IsThreeState, ClickToggleType));

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(GetCurrentVState());

        /// <inheritdoc/>
        protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsPressedChanged(e);
            OnVStateChanged(GetCurrentVState());
        }

        /// <summary>
        /// Called when the <see cref="ToggleButton.IsChecked"/> is changed.
        /// </summary>
        /// <param name="checkedState">Actual state of <see cref="ToggleButton.IsChecked"/>.</param>
        protected virtual void OnCheckedChanged(bool? checkedState) => OnVStateChanged(GetCurrentVState());

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            OnVStateChanged(GetCurrentVState());
        }

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            OnVStateChanged(GetCurrentVState());
        }

        /// <inheritdoc/>
        public VState GetCurrentVState()
        {
            if (!loaded) return VState.UNSET;
            if (!IsEnabled)
            {
                if (IsChecked == true) return VStates.DISABLED_ON_CHECKED;
                else return VStates.DISABLED;
            }
            else if (IsPressed)
            {
                if (IsChecked == true) return VStates.PRESSED_ON_CHECKED;
                else return VStates.PRESSED;
            }
            else if (IsMouseOver)
            {
                if (IsChecked == true) return VStates.MOUSE_OVER_ON_CHECKED;
                else return VStates.MOUSE_OVER;
            }
            else if (IsChecked == true) return VStates.CHECKED;
            else return VStates.DEFAULT;
        }

        /// <summary>
        /// Called when the current <see cref="VState"/> is changed.
        /// </summary>
        /// <param name="vstate">Current <see cref="VState"/>.</param>
        /// <param name="initial">Specifies if this is the initial <see cref="VState"/>.</param>
        protected virtual void OnVStateChanged(VState vstate, bool initial = false)
        {
            if (vstate == VStates.DEFAULT)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, Background, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.CHECKED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnChecked, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.MOUSE_OVER)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.MOUSE_OVER_ON_CHECKED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.PRESSED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnPressed, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnPressed, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnPressed, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.PRESSED_ON_CHECKED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnPressedOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnPressedOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnPressedOnChecked, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.DISABLED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.DISABLED_ON_CHECKED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabledOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabledOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabledOnChecked, initial ? TimeSpan.Zero : AnimationTime);
            }
        }


        /// <summary>
        /// Control v-states.
        /// </summary>
        public static class VStates
        {
            /// <summary>
            /// Default state.
            /// </summary>
            public static readonly VState DEFAULT = new(nameof(DEFAULT), typeof(Switcher));

            /// <summary>
            /// The control is checked.
            /// </summary>
            public static readonly VState CHECKED = new(nameof(CHECKED), typeof(Switcher));

            /// <summary>
            /// The mouse is over the control.
            /// </summary>
            public static readonly VState MOUSE_OVER = new(nameof(MOUSE_OVER), typeof(Switcher));

            /// <summary>
            /// The mouse is over the control while the control is checked.
            /// </summary>
            public static readonly VState MOUSE_OVER_ON_CHECKED = new(nameof(MOUSE_OVER_ON_CHECKED), typeof(Switcher));

            /// <summary>
            /// The control is pressed.
            /// </summary>
            public static readonly VState PRESSED = new(nameof(PRESSED), typeof(Switcher));

            /// <summary>
            /// The control is pressed while is checked.
            /// </summary>
            public static readonly VState PRESSED_ON_CHECKED = new(nameof(PRESSED_ON_CHECKED), typeof(Switcher));

            /// <summary>
            /// The control is disabled.
            /// </summary>
            public static readonly VState DISABLED = new(nameof(DISABLED), typeof(Switcher));

            /// <summary>
            /// The control is disabled while is checked.
            /// </summary>
            public static readonly VState DISABLED_ON_CHECKED = new(nameof(DISABLED_ON_CHECKED), typeof(Switcher));
        }
    }
}
