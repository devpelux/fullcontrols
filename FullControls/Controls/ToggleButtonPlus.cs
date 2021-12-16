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
    /// Represents a control that can switch states, such as <see cref="CheckBox"/>.
    /// </summary>
    public class ToggleButtonPlus : ToggleButton
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnPressed), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnPressedOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabledOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(ToggleButtonPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(ToggleButtonPlus),
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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnPressed), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnPressedOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabledOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(ToggleButtonPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(ToggleButtonPlus),
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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnPressed), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnPressedOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(ToggleButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabledOnChecked), typeof(Brush), typeof(ToggleButtonPlus));

        /// <summary>
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(ToggleButtonPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(ToggleButtonPlus),
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ToggleButtonPlus));

        /// <summary>
        /// Gets or sets if the button is activable-only by click, or deactivable-only by click, or both.
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
            DependencyProperty.Register(nameof(ClickToggleType), typeof(ToggleType), typeof(ToggleButtonPlus),
                new PropertyMetadata(ToggleType.Complete));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(ToggleButtonPlus));


        static ToggleButtonPlus()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButtonPlus),
                new FrameworkPropertyMetadata(typeof(ToggleButtonPlus)));

            IsEnabledProperty.OverrideMetadata(typeof(ToggleButtonPlus),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((ToggleButtonPlus)d).OnEnabledChanged((bool)e.NewValue))));

            IsCheckedProperty.OverrideMetadata(typeof(ToggleButtonPlus),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((ToggleButtonPlus)d).OnCheckedChanged((bool?)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ToggleButtonPlus"/>.
        /// </summary>
        public ToggleButtonPlus() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            loaded = true;
            OnVStateChanged(VStateOverride(), true);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnVStateChanged(VStateOverride());

        /// <inheritdoc/>
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
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when the <see cref="ToggleButton.IsChecked"/> is changed.
        /// </summary>
        /// <param name="checkedState">Actual state of <see cref="ToggleButton.IsChecked"/>.</param>
        protected virtual void OnCheckedChanged(bool? checkedState) => OnVStateChanged(VStateOverride());

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
            if (!IsEnabled)
            {
                if (IsChecked == true) return "DisabledOnChecked";
                else return "Disabled";
            }
            else if (IsPressed)
            {
                if (IsChecked == true) return "PressedOnChecked";
                else return "Pressed";
            }
            else if (IsMouseOver)
            {
                if (IsChecked == true) return "MouseOverOnChecked";
                else return "MouseOver";
            }
            else if (IsChecked == true) return "Checked";
            else return "Normal";
        }

        /// <summary>
        /// Called when the <b>v-state</b> of the control changed, is used to execute custom animations on certain contitions changing.
        /// </summary>
        /// <remarks>Is called <b>v-state</b> because is not related to the VisualState of the control.</remarks>
        /// <param name="vstate">Actual <b>v-state</b> of the control.</param>
        /// <param name="initial">Specifies if this is the first <b>v-state</b> applied to the control.</param>
        protected virtual void OnVStateChanged(string vstate, bool initial = false)
        {
            switch (vstate)
            {
                case "Normal":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, Background, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, TimeSpan.Zero);
                    break;
                case "Checked":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnChecked, TimeSpan.Zero);
                    break;
                case "MouseOver":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOver, TimeSpan.Zero);
                    break;
                case "MouseOverOnChecked":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOverOnChecked, TimeSpan.Zero);
                    break;
                case "Pressed":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnPressed, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnPressed, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnPressed, TimeSpan.Zero);
                    break;
                case "PressedOnChecked":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnPressedOnChecked, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnPressedOnChecked, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnPressedOnChecked, TimeSpan.Zero);
                    break;
                case "Disabled":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabled, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabled, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabled, TimeSpan.Zero);
                    break;
                case "DisabledOnChecked":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabledOnChecked, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabledOnChecked, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabledOnChecked, TimeSpan.Zero);
                    break;
                default:
                    break;
            }
        }
    }
}
