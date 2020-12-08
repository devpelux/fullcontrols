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
    /// <para>Represents a button that can be selected, but not cleared, by a user.</para>
    /// <para>The <see cref="ToggleButton.IsChecked"/> property of a <see cref="RadioButton"/> can be set by clicking it, but it can only be cleared programmatically.</para>
    /// </summary>
    public class ERadioButton : RadioButton
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// Actual Background color of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(ERadioButton),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((ERadioButton)d).OnActualBackgroundChanged((Brush)e.NewValue))));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// Actual BorderBrush color of the control.
        /// </summary>
        public Brush ActualBorderBrush
        {
            get => (Brush)GetValue(ActualBorderBrushProperty);
            set => SetValue(ActualBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnChecked), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(ForegroundOnChecked), typeof(Brush), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// Actual Foreground color of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// ForeColor of the control.
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
            DependencyProperty.Register(nameof(ForeColor), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// ForeColor when the mouse is over the control.
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
            DependencyProperty.Register(nameof(ForeColorOnMouseOver), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// ForeColor when the control is checked and the mouse is over the control.
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
            DependencyProperty.Register(nameof(ForeColorOnMouseOverOnChecked), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// ForeColor when the control is checked.
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
            DependencyProperty.Register(nameof(ForeColorOnChecked), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// ForeColor when the control is disabled.
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
            DependencyProperty.Register(nameof(ForeColorOnDisabled), typeof(Brush), typeof(ERadioButton));

        /// <summary>
        /// Actual ForeColor of the control.
        /// </summary>
        public Brush ActualForeColor => (Brush)GetValue(ActualForeColorProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForeColorProperty =
            DependencyProperty.Register(nameof(ActualForeColor), typeof(Brush), typeof(ERadioButton));

        #region CheckMark

        /// <summary>
        /// Content of the icon displayed if <see cref="ToggleButton.IsChecked"/> is true.
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
            DependencyProperty.Register(nameof(CheckMark), typeof(object), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(CheckSize), typeof(double), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(CheckFont), typeof(FontFamily), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(InsideCornerRadius), typeof(CornerRadius), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(InsideMargin), typeof(Thickness), typeof(ERadioButton));

        /// <summary>
        /// Scale of Check Background.
        /// </summary>
        public double CheckScale => (double)GetValue(CheckScaleProperty);

        /// <summary>
        /// Identifies the <see cref="CheckScale"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleProperty =
            DependencyProperty.Register(nameof(CheckScale), typeof(double), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(ERadioButton));

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
            DependencyProperty.Register(nameof(CheckAnimationTime), typeof(TimeSpan), typeof(ERadioButton));


        /// <summary>
        /// Creates a new <see cref="ERadioButton"/>.
        /// </summary>
        static ERadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ERadioButton), new FrameworkPropertyMetadata(typeof(ERadioButton)));
            IsEnabledProperty.OverrideMetadata(typeof(ERadioButton), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ERadioButton)d).OnEnabledChanged((bool)e.NewValue))));
            IsCheckedProperty.OverrideMetadata(typeof(ERadioButton), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((ERadioButton)d).OnCheckedChanged((bool?)e.NewValue))));
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
            Utility.AnimateBrush(this, ActualForeColorProperty, ForeColor, TimeSpan.Zero);
            Utility.AnimateDouble(this, CheckScaleProperty, 0, TimeSpan.Zero);
            loaded = true;
            ReloadBackground();
            ReloadCheckScale();
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
            ReloadCheckScale();
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
                Utility.AnimateBrush(this, ActualForeColorProperty, ForeColorOnDisabled, TimeSpan.Zero);
            }
            else if (IsMouseOver) //MouseOver state
            {
                if (IsChecked == true)
                {
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOverOnChecked, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOverOnChecked, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForeColorProperty, ForeColorOnMouseOverOnChecked, TimeSpan.Zero);
                }
                else
                {
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnMouseOver, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOver, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForeColorProperty, ForeColorOnMouseOver, TimeSpan.Zero);
                }
            }
            else if (IsChecked == true) //Checked state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnChecked, AnimationTime);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnChecked, AnimationTime);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnChecked, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForeColorProperty, ForeColorOnChecked, TimeSpan.Zero);
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
