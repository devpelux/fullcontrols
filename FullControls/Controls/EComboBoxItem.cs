using FullControls.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Implements a selectable item inside a <see cref="ComboBox"/>.
    /// </summary>
    public class EComboBoxItem : ComboBoxItem
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the background brush when the control is selected and the mouse is over the control.
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnSelected), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the background brush when the control is selected.
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
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the background brush when the control is focused.
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
            DependencyProperty.Register(nameof(BackgroundOnFocused), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the background brush when the control is focused and selected.
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
            DependencyProperty.Register(nameof(BackgroundOnFocusedOnSelected), typeof(Brush), typeof(EComboBoxItem));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(EComboBoxItem),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((EComboBoxItem)d).OnActualBackgroundChanged((Brush)e.NewValue))));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the border brush when the control is selected and the mouse is over the control.
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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnSelected), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the border brush when the control is selected.
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
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the border brush when the control is focused.
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
            DependencyProperty.Register(nameof(BorderBrushOnFocused), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the border brush when the control is focused and selected.
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
            DependencyProperty.Register(nameof(BorderBrushOnFocusedOnSelected), typeof(Brush), typeof(EComboBoxItem));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(EComboBoxItem));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the foreground brush when the control is selected and the mouse is over the control.
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
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnSelected), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the foreground brush when the control is selected.
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
            DependencyProperty.Register(nameof(ForegroundOnSelected), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the foreground brush when the control is focused.
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
            DependencyProperty.Register(nameof(ForegroundOnFocused), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets or sets the foreground brush when the control is focused and selected.
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
            DependencyProperty.Register(nameof(ForegroundOnFocusedOnSelected), typeof(Brush), typeof(EComboBoxItem));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(EComboBoxItem));

        /// <summary>
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(EComboBoxItem));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(EComboBoxItem));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(EComboBoxItem));


        /// <summary>
        /// Creates a new <see cref="EComboBoxItem"/>.
        /// </summary>
        static EComboBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EComboBoxItem), new FrameworkPropertyMetadata(typeof(EComboBoxItem)));
            IsEnabledProperty.OverrideMetadata(typeof(EComboBoxItem), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((EComboBoxItem)d).OnEnabledChanged((bool)e.NewValue))));
            IsSelectedProperty.OverrideMetadata(typeof(EComboBoxItem), new FrameworkPropertyMetadata(false,
                new PropertyChangedCallback((d, e) => ((EComboBoxItem)d).OnSelectedChanged((bool)e.NewValue))));
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            loaded = true;
            OnVStateChanged(VStateOverride());
        }

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        protected virtual void OnActualBackgroundChanged(Brush actualBackground) { }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

        /// <inheritdoc/>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            OnVStateChanged(VStateOverride());
        }

        /// <inheritdoc/>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
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
        /// Called when the <see cref="ListBoxItem.IsSelected"/> is changed.
        /// </summary>
        /// <param name="selectedState">Actual state of <see cref="ListBoxItem.IsSelected"/>.</param>
        protected virtual void OnSelectedChanged(bool selectedState) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called to calculate the <b>v-state</b> of the control.
        /// </summary>
        protected virtual string VStateOverride()
        {
            if (!loaded) return "Undefined";
            if (!IsEnabled) return "Disabled";
            else if (IsMouseOver)
            {
                if (IsSelected) return "MouseOverOnSelected";
                else return "MouseOver";
            }
            else if (IsFocused)
            {
                if (IsSelected) return "FocusedOnSelected";
                else return "Focused";
            }
            else if (IsSelected) return "Selected";
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
                    Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
                    break;
                case "Selected":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnSelected, AnimationTime);
                    break;
                case "Focused":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnFocused, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnFocused, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnFocused, AnimationTime);
                    break;
                case "FocusedOnSelected":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnFocusedOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnFocusedOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnFocusedOnSelected, AnimationTime);
                    break;
                case "MouseOver":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOver, AnimationTime);
                    break;
                case "MouseOverOnSelected":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOverOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOverOnSelected, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOverOnSelected, AnimationTime);
                    break;
                case "Disabled":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnDisabled, TimeSpan.Zero);
                    break;
                default:
                    break;
            }
        }
    }
}
