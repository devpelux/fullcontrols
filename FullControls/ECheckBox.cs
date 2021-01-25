using FullControls.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// Represents a control that a user can select and clear.
    /// </summary>
    public class ECheckBox : CheckBox
    {
        private bool loaded = false;

        /// <summary>
        /// Background brush when the mouse is over the control.
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
        /// Background brush when the control is checked and the mouse is over the control.
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
        /// Background brush when the control is checked.
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
        /// Background brush when the control is disabled.
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
        /// Actual Background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(ECheckBox),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((ECheckBox)d).OnActualBackgroundChanged((Brush)e.NewValue))));

        /// <summary>
        /// BorderBrush brush when the mouse is over the control.
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
        /// BorderBrush when the control is checked and the mouse is over the control.
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
        /// BorderBrush when the control is checked.
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
        /// BorderBrush when the control is disabled.
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
        /// Actual BorderBrush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// Foreground brush when the mouse is over the control.
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
        /// Foreground brush when the control is checked and the mouse is over the control.
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
        /// Foreground brush when the control is checked.
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
        /// Foreground brush when the control is disabled.
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
        /// Actual Foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(ECheckBox));

        /// <summary>
        /// ForeColor brush of the control.
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
        /// ForeColor brush when the mouse is over the control.
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
        /// ForeColor brush when the control is checked and the mouse is over the control.
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
        /// ForeColor brush when the control is checked.
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
        /// ForeColor brush when the control is disabled.
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
        /// Actual ForeColor brush of the control.
        /// </summary>
        public Brush ActualForeColor => (Brush)GetValue(ActualForeColorProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForeColorProperty =
            DependencyProperty.Register(nameof(ActualForeColor), typeof(Brush), typeof(ECheckBox));

        #region CheckMark

        /// <summary>
        /// Content of the icon displayed if <see cref="ToggleButton.IsChecked"/> is <see langword="true"/>.
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
        /// Size of the check icon.
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
        /// Font of the check icon.
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
        /// FontWeight of the check icon.
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
        /// Scale of Check Background.
        /// </summary>
        public double CheckScale => (double)GetValue(CheckScaleProperty);

        /// <summary>
        /// Identifies the <see cref="CheckScale"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty CheckScaleProperty =
            DependencyProperty.Register(nameof(CheckScale), typeof(double), typeof(ECheckBox));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ECheckBox));

        /// <summary>
        /// CornerRadius of inside part of the control.
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
        /// Margin of the <see cref="CheckMark"/>.
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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(ECheckBox));

        /// <summary>
        /// Duration of the check size animation when the control changes state.
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


        /// <summary>
        /// Creates a new <see cref="ECheckBox"/>.
        /// </summary>
        static ECheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ECheckBox), new FrameworkPropertyMetadata(typeof(ECheckBox)));
            IsEnabledProperty.OverrideMetadata(typeof(ECheckBox), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ECheckBox)d).OnEnabledChanged((bool)e.NewValue))));
            IsCheckedProperty.OverrideMetadata(typeof(ECheckBox), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ECheckBox)d).OnCheckedChanged((bool?)e.NewValue))));
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualForeColorProperty, ForeColor, TimeSpan.Zero);
            Utility.AnimateDouble(this, CheckScaleProperty, 0, TimeSpan.Zero);
            loaded = true;
            ReloadBrushes();
            ReloadCheckScale();
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
        protected virtual void OnEnabledChanged(bool enabledState)
        {
            ReloadBrushes();
        }

        /// <summary>
        /// Called when the <see cref="ToggleButton.IsChecked"/> is changed.
        /// </summary>
        /// <param name="checkedState">Actual state of <see cref="ToggleButton.IsChecked"/>.</param>
        protected virtual void OnCheckedChanged(bool? checkedState)
        {
            ReloadBrushes();
            ReloadCheckScale();
        }

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ReloadBrushes();
        }

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            ReloadBrushes();
        }

        /// <summary>
        /// Apply the correct brushes to the control, based on its state.
        /// </summary>
        private void ReloadBrushes()
        {
            if (!loaded) return;
            if (!IsEnabled) //Disabled state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnDisabled, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnDisabled, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnDisabled, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForeColorProperty, ForeColorOnDisabled, TimeSpan.Zero);
            }
            else if (IsMouseOver) //MouseOver state
            {
                if (IsChecked == true)
                {
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOverOnChecked, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForeColorProperty, ForeColorOnMouseOverOnChecked, AnimationTime);
                }
                else
                {
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOver, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForeColorProperty, ForeColorOnMouseOver, AnimationTime);
                }
            }
            else if (IsChecked == true) //Checked state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnChecked, AnimationTime);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnChecked, AnimationTime);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnChecked, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForeColorProperty, ForeColorOnChecked, AnimationTime);
            }
            else //Normal state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForeColorProperty, ForeColor, TimeSpan.Zero);
            }
        }

        /// <summary>
        /// Apply the correct check scale to the control, based on its state.
        /// </summary>
        private void ReloadCheckScale()
        {
            if (!loaded) return;
            Utility.AnimateDouble(this, CheckScaleProperty, IsChecked == true ? 1 : 0, CheckAnimationTime);
        }
    }
}
