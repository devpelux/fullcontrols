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
    /// Represents a control that a user can select and clear.
    /// </summary>
    public class ECheckBox : CheckBox
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(ECheckBox), new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(ECheckBox),
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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(ECheckBox), new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(ECheckBox),
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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnChecked), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(ForegroundOnChecked), typeof(Brush), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(ECheckBox), new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(ECheckBox),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => d.SetValue(ActualForegroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the forecolor brush. (The color of the check mark)
        /// </summary>
        public Brush ForeColor
        {
            get => (Brush)GetValue(ForeColorProperty);
            set => SetValue(ForeColorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForeColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register(nameof(ForeColor), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the forecolor brush when the mouse is over the control.
        /// </summary>
        public Brush ForeColorOnMouseOver
        {
            get => (Brush)GetValue(ForeColorOnMouseOverProperty);
            set => SetValue(ForeColorOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForeColorOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForeColorOnMouseOverProperty =
            DependencyProperty.Register(nameof(ForeColorOnMouseOver), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the forecolor brush when the control is checked and the mouse is over the control.
        /// </summary>
        public Brush ForeColorOnMouseOverOnChecked
        {
            get => (Brush)GetValue(ForeColorOnMouseOverOnCheckedProperty);
            set => SetValue(ForeColorOnMouseOverOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForeColorOnMouseOverOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForeColorOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(ForeColorOnMouseOverOnChecked), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the forecolor brush when the control is checked.
        /// </summary>
        public Brush ForeColorOnChecked
        {
            get => (Brush)GetValue(ForeColorOnCheckedProperty);
            set => SetValue(ForeColorOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForeColorOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForeColorOnCheckedProperty =
            DependencyProperty.Register(nameof(ForeColorOnChecked), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the forecolor brush when the control is disabled.
        /// </summary>
        public Brush ForeColorOnDisabled
        {
            get => (Brush)GetValue(ForeColorOnDisabledProperty);
            set => SetValue(ForeColorOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForeColorOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForeColorOnDisabledProperty =
            DependencyProperty.Register(nameof(ForeColorOnDisabled), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Gets the actual forecolor brush of the control.
        /// </summary>
        public Brush ActualForeColor => (Brush)GetValue(ActualForeColorProperty);

        #region ActualForeColorProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForeColorPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeColor), typeof(Brush), typeof(ECheckBox), new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForeColorProperty = ActualForeColorPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForeColorPropertyProxy =
            DependencyProperty.Register("ActualForeColorProxy", typeof(Brush), typeof(ECheckBox),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => d.SetValue(ActualForeColorPropertyKey, e.NewValue))));

        #endregion

        #region CheckMark

        /// <summary>
        /// Gets or sets the content of the icon displayed if <see cref="ToggleButton.IsChecked"/> is <see langword="true"/>.
        /// </summary>
        public object CheckMark
        {
            get => GetValue(CheckMarkProperty);
            set => SetValue(CheckMarkProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckMark"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckMarkProperty =
            DependencyProperty.Register(nameof(CheckMark), typeof(object), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the size of the check icon.
        /// </summary>
        public double CheckSize
        {
            get => (double)GetValue(CheckSizeProperty);
            set => SetValue(CheckSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckSizeProperty =
            DependencyProperty.Register(nameof(CheckSize), typeof(double), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the font of the check icon.
        /// </summary>
        public FontFamily CheckFont
        {
            get => (FontFamily)GetValue(CheckFontProperty);
            set => SetValue(CheckFontProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckFont"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckFontProperty =
            DependencyProperty.Register(nameof(CheckFont), typeof(FontFamily), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the fontweight of the check icon.
        /// </summary>
        public FontWeight CheckWeight
        {
            get => (FontWeight)GetValue(CheckWeightProperty);
            set => SetValue(CheckWeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckWeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckWeightProperty =
            DependencyProperty.Register(nameof(CheckWeight), typeof(FontWeight), typeof(ECheckBox));

        /// <summary>
        /// Gets the scale of the check mark.
        /// </summary>
        public double CheckScale => (double)GetValue(CheckScaleProperty);

        #region CheckScaleProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="CheckScale"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey CheckScalePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CheckScale), typeof(double), typeof(ECheckBox), new FrameworkPropertyMetadata(0d));

        /// <summary>
        /// Identifies the <see cref="CheckScale"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleProperty = CheckScalePropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="CheckScale"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty CheckScalePropertyProxy =
            DependencyProperty.Register("CheckScaleProxy", typeof(double), typeof(ECheckBox),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => d.SetValue(CheckScalePropertyKey, e.NewValue))));

        #endregion

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the corner radius of the inside part of the control.
        /// </summary>
        public CornerRadius InsideCornerRadius
        {
            get => (CornerRadius)GetValue(InsideCornerRadiusProperty);
            set => SetValue(InsideCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="InsideCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty InsideCornerRadiusProperty =
            DependencyProperty.Register(nameof(InsideCornerRadius), typeof(CornerRadius), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the margin of the <see cref="CheckMark"/>.
        /// </summary>
        public Thickness InsideMargin
        {
            get => (Thickness)GetValue(InsideMarginProperty);
            set => SetValue(InsideMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="InsideMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty InsideMarginProperty =
            DependencyProperty.Register(nameof(InsideMargin), typeof(Thickness), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(ECheckBox));

        /// <summary>
        /// Gets or sets the duration of the check size animation when the control changes state.
        /// </summary>
        public TimeSpan CheckAnimationTime
        {
            get => (TimeSpan)GetValue(CheckAnimationTimeProperty);
            set => SetValue(CheckAnimationTimeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckAnimationTime"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckAnimationTimeProperty =
            DependencyProperty.Register(nameof(CheckAnimationTime), typeof(TimeSpan), typeof(ECheckBox));


        static ECheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ECheckBox), new FrameworkPropertyMetadata(typeof(ECheckBox)));
            IsEnabledProperty.OverrideMetadata(typeof(ECheckBox), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ECheckBox)d).OnEnabledChanged((bool)e.NewValue))));
            IsCheckedProperty.OverrideMetadata(typeof(ECheckBox), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ECheckBox)d).OnCheckedChanged((bool?)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ECheckBox"/>.
        /// </summary>
        public ECheckBox() : base()
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
            Utility.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColor, TimeSpan.Zero);
            Utility.AnimateDouble(this, CheckScalePropertyProxy, IsChecked == true ? 1 : 0, TimeSpan.Zero);
            loaded = true;
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when <see cref="ToggleButton.IsChecked"/> is changed.
        /// </summary>
        /// <param name="checkedState">Actual state of <see cref="ToggleButton.IsChecked"/>.</param>
        protected virtual void OnCheckedChanged(bool? checkedState)
        {
            OnVStateChanged(VStateOverride());
            if (loaded) Utility.AnimateDouble(this, CheckScalePropertyProxy, IsChecked == true ? 1 : 0, CheckAnimationTime);
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
            else if (IsMouseOver)
            {
                if (IsChecked == true) return "MouseOverOnChecked";
                else return "MouseOver";
            }
            else if (IsChecked == true) return "Checked";
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
                    Utility.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColor, TimeSpan.Zero);
                    break;
                case "Checked":
                    Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnChecked, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnChecked, AnimationTime);
                    break;
                case "MouseOver":
                    Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOver, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnMouseOver, AnimationTime);
                    break;
                case "MouseOverOnChecked":
                    Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOverOnChecked, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnMouseOverOnChecked, AnimationTime);
                    break;
                case "Disabled":
                    Utility.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnDisabled, TimeSpan.Zero);
                    break;
                default:
                    break;
            }
        }
    }
}
