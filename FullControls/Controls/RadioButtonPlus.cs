﻿using FullControls.Common;
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
    /// <para>Represents a control that a user can select and clear.</para>
    /// <para>Multiple radio buttons can be grouped, so only one of the group can stay selected on the same time.</para>
    /// </summary>
    public class RadioButtonPlus : RadioButton, IVState
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnPressed), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnPressedOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabledOnChecked), typeof(Brush), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(RadioButtonPlus),
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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnPressed), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnPressedOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabledOnChecked), typeof(Brush), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(RadioButtonPlus),
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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnPressed), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnPressedOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabledOnChecked), typeof(Brush), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualForegroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the forecolor brush of the control.
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
            DependencyProperty.Register(nameof(ForeColor), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForeColorOnMouseOver), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForeColorOnMouseOverOnChecked), typeof(Brush), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the forecolor brush when the control is pressed.
        /// </summary>
        public Brush ForeColorOnPressed
        {
            get => (Brush)GetValue(ForeColorOnPressedProperty);
            set => SetValue(ForeColorOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForeColorOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForeColorOnPressedProperty =
            DependencyProperty.Register(nameof(ForeColorOnPressed), typeof(Brush), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the forecolor brush when the control is checked and is pressed.
        /// </summary>
        public Brush ForeColorOnPressedOnChecked
        {
            get => (Brush)GetValue(ForeColorOnPressedOnCheckedProperty);
            set => SetValue(ForeColorOnPressedOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForeColorOnPressedOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForeColorOnPressedOnCheckedProperty =
            DependencyProperty.Register(nameof(ForeColorOnPressedOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForeColorOnChecked), typeof(Brush), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ForeColorOnDisabled), typeof(Brush), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the forecolor brush when the control is checked and is disabled.
        /// </summary>
        public Brush ForeColorOnDisabledOnChecked
        {
            get => (Brush)GetValue(ForeColorOnDisabledOnCheckedProperty);
            set => SetValue(ForeColorOnDisabledOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForeColorOnDisabledOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForeColorOnDisabledOnCheckedProperty =
            DependencyProperty.Register(nameof(ForeColorOnDisabledOnChecked), typeof(Brush), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets the actual forecolor brush of the control.
        /// </summary>
        public Brush ActualForeColor => (Brush)GetValue(ActualForeColorProperty);

        #region ActualForeColorProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForeColorPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeColor), typeof(Brush), typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForeColorProperty = ActualForeColorPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForeColorPropertyProxy =
            DependencyProperty.Register("ActualForeColorProxy", typeof(Brush), typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualForeColorPropertyKey, e.NewValue))));

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
            DependencyProperty.Register(nameof(CheckMark), typeof(object), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(CheckSize), typeof(double), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(CheckFont), typeof(FontFamily), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(CheckWeight), typeof(FontWeight), typeof(RadioButtonPlus));

        #region CheckScale

        /// <summary>
        /// Gets or sets the scale of the check mark of the control.
        /// </summary>
        public double CheckScale
        {
            get => (double)GetValue(CheckScaleProperty);
            set => SetValue(CheckScaleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckScale"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleProperty =
            DependencyProperty.Register(nameof(CheckScale), typeof(double), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the scale of the check mark when the mouse is over the control.
        /// </summary>
        public double CheckScaleOnMouseOver
        {
            get => (double)GetValue(CheckScaleOnMouseOverProperty);
            set => SetValue(CheckScaleOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckScaleOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleOnMouseOverProperty =
            DependencyProperty.Register(nameof(CheckScaleOnMouseOver), typeof(double), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the scale of the check mark when the control is checked and the mouse is over the control.
        /// </summary>
        public double CheckScaleOnMouseOverOnChecked
        {
            get => (double)GetValue(CheckScaleOnMouseOverOnCheckedProperty);
            set => SetValue(CheckScaleOnMouseOverOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckScaleOnMouseOverOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleOnMouseOverOnCheckedProperty =
            DependencyProperty.Register(nameof(CheckScaleOnMouseOverOnChecked), typeof(double), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the scale of the check mark when the control is pressed.
        /// </summary>
        public double CheckScaleOnPressed
        {
            get => (double)GetValue(CheckScaleOnPressedProperty);
            set => SetValue(CheckScaleOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckScaleOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleOnPressedProperty =
            DependencyProperty.Register(nameof(CheckScaleOnPressed), typeof(double), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the scale of the check mark when the control is checked and is pressed.
        /// </summary>
        public double CheckScaleOnPressedOnChecked
        {
            get => (double)GetValue(CheckScaleOnPressedOnCheckedProperty);
            set => SetValue(CheckScaleOnPressedOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckScaleOnPressedOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleOnPressedOnCheckedProperty =
            DependencyProperty.Register(nameof(CheckScaleOnPressedOnChecked), typeof(double), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the scale of the check mark when the control is checked.
        /// </summary>
        public double CheckScaleOnChecked
        {
            get => (double)GetValue(CheckScaleOnCheckedProperty);
            set => SetValue(CheckScaleOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckScaleOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleOnCheckedProperty =
            DependencyProperty.Register(nameof(CheckScaleOnChecked), typeof(double), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the scale of the check mark when the control is disabled.
        /// </summary>
        public double CheckScaleOnDisabled
        {
            get => (double)GetValue(CheckScaleOnDisabledProperty);
            set => SetValue(CheckScaleOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckScaleOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleOnDisabledProperty =
            DependencyProperty.Register(nameof(CheckScaleOnDisabled), typeof(double), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets or sets the scale of the check mark when the control is checked and is disabled.
        /// </summary>
        public double CheckScaleOnDisabledOnChecked
        {
            get => (double)GetValue(CheckScaleOnDisabledOnCheckedProperty);
            set => SetValue(CheckScaleOnDisabledOnCheckedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckScaleOnDisabledOnChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckScaleOnDisabledOnCheckedProperty =
            DependencyProperty.Register(nameof(CheckScaleOnDisabledOnChecked), typeof(double), typeof(RadioButtonPlus));

        /// <summary>
        /// Gets the actual scale of the check mark.
        /// </summary>
        public double ActualCheckScale => (double)GetValue(ActualCheckScaleProperty);

        #region ActualCheckScaleProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualCheckScale"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualCheckScalePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualCheckScale), typeof(double), typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(0d));

        /// <summary>
        /// Identifies the <see cref="ActualCheckScale"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualCheckScaleProperty = ActualCheckScalePropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualCheckScale"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualCheckScalePropertyProxy =
            DependencyProperty.Register("ActualCheckScaleProxy", typeof(double), typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualCheckScalePropertyKey, e.NewValue))));

        #endregion

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(InsideCornerRadius), typeof(CornerRadius), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(InsideMargin), typeof(Thickness), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(ClickToggleType), typeof(ToggleType), typeof(RadioButtonPlus),
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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(RadioButtonPlus));

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
            DependencyProperty.Register(nameof(CheckAnimationTime), typeof(TimeSpan), typeof(RadioButtonPlus));


        static RadioButtonPlus()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioButtonPlus), new FrameworkPropertyMetadata(typeof(RadioButtonPlus)));

            IsEnabledProperty.OverrideMetadata(typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((RadioButtonPlus)d).OnEnabledChanged((bool)e.NewValue))));

            IsCheckedProperty.OverrideMetadata(typeof(RadioButtonPlus),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((RadioButtonPlus)d).OnCheckedChanged((bool?)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="RadioButtonPlus"/>.
        /// </summary>
        public RadioButtonPlus() : base()
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
        protected virtual void OnCheckedChanged(bool? checkedState)
        {
            OnVStateChanged(GetCurrentVState());
        }

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
                Util.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColor, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateDouble(this, ActualCheckScalePropertyProxy, CheckScale, initial ? TimeSpan.Zero : CheckAnimationTime);
            }
            else if (vstate == VStates.CHECKED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateDouble(this, ActualCheckScalePropertyProxy, CheckScaleOnChecked, initial ? TimeSpan.Zero : CheckAnimationTime);
            }
            else if (vstate == VStates.MOUSE_OVER)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateDouble(this, ActualCheckScalePropertyProxy, CheckScaleOnMouseOver, initial ? TimeSpan.Zero : CheckAnimationTime);
            }
            else if (vstate == VStates.MOUSE_OVER_ON_CHECKED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnMouseOverOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateDouble(this, ActualCheckScalePropertyProxy, CheckScaleOnMouseOverOnChecked, initial ? TimeSpan.Zero : CheckAnimationTime);
            }
            else if (vstate == VStates.PRESSED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnPressed, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnPressed, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnPressed, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnPressed, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateDouble(this, ActualCheckScalePropertyProxy, CheckScaleOnPressed, initial ? TimeSpan.Zero : CheckAnimationTime);
            }
            else if (vstate == VStates.PRESSED_ON_CHECKED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnPressedOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnPressedOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnPressedOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnPressedOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateDouble(this, ActualCheckScalePropertyProxy, CheckScaleOnPressedOnChecked, initial ? TimeSpan.Zero : CheckAnimationTime);
            }
            else if (vstate == VStates.DISABLED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateDouble(this, ActualCheckScalePropertyProxy, CheckScaleOnDisabled, initial ? TimeSpan.Zero : CheckAnimationTime);
            }
            else if (vstate == VStates.DISABLED_ON_CHECKED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabledOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabledOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabledOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForeColorPropertyProxy, ForeColorOnDisabledOnChecked, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateDouble(this, ActualCheckScalePropertyProxy, CheckScaleOnDisabledOnChecked, initial ? TimeSpan.Zero : CheckAnimationTime);
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
            public static readonly VState DEFAULT = new(nameof(DEFAULT), typeof(RadioButtonPlus));

            /// <summary>
            /// The control is checked.
            /// </summary>
            public static readonly VState CHECKED = new(nameof(CHECKED), typeof(RadioButtonPlus));

            /// <summary>
            /// The mouse is over the control.
            /// </summary>
            public static readonly VState MOUSE_OVER = new(nameof(MOUSE_OVER), typeof(RadioButtonPlus));

            /// <summary>
            /// The mouse is over the control while the control is checked.
            /// </summary>
            public static readonly VState MOUSE_OVER_ON_CHECKED = new(nameof(MOUSE_OVER_ON_CHECKED), typeof(RadioButtonPlus));

            /// <summary>
            /// The control is pressed.
            /// </summary>
            public static readonly VState PRESSED = new(nameof(PRESSED), typeof(RadioButtonPlus));

            /// <summary>
            /// The control is pressed while is checked.
            /// </summary>
            public static readonly VState PRESSED_ON_CHECKED = new(nameof(PRESSED_ON_CHECKED), typeof(RadioButtonPlus));

            /// <summary>
            /// The control is disabled.
            /// </summary>
            public static readonly VState DISABLED = new(nameof(DISABLED), typeof(RadioButtonPlus));

            /// <summary>
            /// The control is disabled while is checked.
            /// </summary>
            public static readonly VState DISABLED_ON_CHECKED = new(nameof(DISABLED_ON_CHECKED), typeof(RadioButtonPlus));
        }
    }
}
