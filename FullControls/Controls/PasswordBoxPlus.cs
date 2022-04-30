using FullControls.Common;
using FullControls.Core;
using System;
using System.ComponentModel;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using WpfCoreTools.Extensions;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control designed for entering and handling passwords.
    /// </summary>
    [TemplatePart(Name = PartContentHost, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = PartPeekButton, Type = typeof(UIElement))]
    public sealed class PasswordBoxPlus : Control, IVState
    {
        private bool loaded = false;
        private readonly PasswordBox passwordBox;

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        private const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// PeekButton template part.
        /// </summary>
        private const string PartPeekButton = "PART_PeekButton";

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
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(PasswordBoxPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => ((PasswordBoxPlus)d).OnActualBackgroundChanged((Brush)e.NewValue))));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBackgroundPropertyKey, e.NewValue))));

        #endregion

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
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(PasswordBoxPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBorderBrushPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the underline brush when the control is selected.
        /// </summary>
        public Brush UnderlineBrush
        {
            get => (Brush)GetValue(UnderlineBrushProperty);
            set => SetValue(UnderlineBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineBrushProperty =
            DependencyProperty.Register(nameof(UnderlineBrush), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the underline brush when the control is selected.
        /// </summary>
        public Brush UnderlineBrushOnSelected
        {
            get => (Brush)GetValue(UnderlineBrushOnSelectedProperty);
            set => SetValue(UnderlineBrushOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineBrushOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineBrushOnSelectedProperty =
            DependencyProperty.Register(nameof(UnderlineBrushOnSelected), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the underline brush when the control is disabled.
        /// </summary>
        public Brush UnderlineBrushOnDisabled
        {
            get => (Brush)GetValue(UnderlineBrushOnDisabledProperty);
            set => SetValue(UnderlineBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(UnderlineBrushOnDisabled), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets the actual underline brush of the control.
        /// </summary>
        public Brush ActualUnderlineBrush => (Brush)GetValue(ActualUnderlineBrushProperty);

        #region ActualUnderlineBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualUnderlineBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualUnderlineBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualUnderlineBrush), typeof(Brush), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualUnderlineBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualUnderlineBrushProperty = ActualUnderlineBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualUnderlineBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualUnderlineBrushPropertyProxy =
            DependencyProperty.Register("ActualUnderlineBrushProxy", typeof(Brush), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualUnderlineBrushPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the underline thickness when the control is selected.
        /// </summary>
        public Thickness UnderlineThickness
        {
            get => (Thickness)GetValue(UnderlineThicknessProperty);
            set => SetValue(UnderlineThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineThicknessProperty =
            DependencyProperty.Register(nameof(UnderlineThickness), typeof(Thickness), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the underline thickness when the control is selected.
        /// </summary>
        public Thickness UnderlineThicknessOnSelected
        {
            get => (Thickness)GetValue(UnderlineThicknessOnSelectedProperty);
            set => SetValue(UnderlineThicknessOnSelectedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineThicknessOnSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineThicknessOnSelectedProperty =
            DependencyProperty.Register(nameof(UnderlineThicknessOnSelected), typeof(Thickness), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the underline thickness when the control is disabled.
        /// </summary>
        public Thickness UnderlineThicknessOnDisabled
        {
            get => (Thickness)GetValue(UnderlineThicknessOnDisabledProperty);
            set => SetValue(UnderlineThicknessOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UnderlineThicknessOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UnderlineThicknessOnDisabledProperty =
            DependencyProperty.Register(nameof(UnderlineThicknessOnDisabled), typeof(Thickness), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets the actual underline thickness of the control.
        /// </summary>
        public Thickness ActualUnderlineThickness => (Thickness)GetValue(ActualUnderlineThicknessProperty);

        #region ActualUnderlineThicknessProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualUnderlineThickness"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualUnderlineThicknessPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualUnderlineThickness), typeof(Thickness), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(default(Thickness)));

        /// <summary>
        /// Identifies the <see cref="ActualUnderlineThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualUnderlineThicknessProperty = ActualUnderlineThicknessPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets or sets the brush of the caret.
        /// </summary>
        public Brush CaretBrush
        {
            get => (Brush)GetValue(CaretBrushProperty);
            set => SetValue(CaretBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaretBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the brush of the highlighted part of the password.
        /// </summary>
        public Brush SelectionBrush
        {
            get => (Brush)GetValue(SelectionBrushProperty);
            set => SetValue(SelectionBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SelectionBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectionBrushProperty =
            DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the brush of the selected password.
        /// </summary>
        public Brush SelectionTextBrush
        {
            get => (Brush)GetValue(SelectionTextBrushProperty);
            set => SetValue(SelectionTextBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SelectionTextBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectionTextBrushProperty =
            DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the opacity of the highlighted part of the password.
        /// </summary>
        public double SelectionOpacity
        {
            get => (double)GetValue(SelectionOpacityProperty);
            set => SetValue(SelectionOpacityProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SelectionOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectionOpacityProperty =
            DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the foreground brush to the actual background brush of the control.
        /// </summary>
        public bool AdaptForegroundAutomatically
        {
            get => (bool)GetValue(AdaptForegroundAutomaticallyProperty);
            set => SetValue(AdaptForegroundAutomaticallyProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AdaptForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(PasswordBoxPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the caret brush to the actual background brush of the control.
        /// </summary>
        public bool AdaptCaretBrushAutomatically
        {
            get => (bool)GetValue(AdaptCaretBrushAutomaticallyProperty);
            set => SetValue(AdaptCaretBrushAutomaticallyProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AdaptCaretBrushAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptCaretBrushAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(PasswordBoxPlus),
                new PropertyMetadata(BoolBox.True));

        #region Hint

        /// <summary>
        /// Gets or sets the suggestion displayed if <see cref="Password"/> is empty.
        /// </summary>
        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Hint"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => ((PasswordBoxPlus)d).UpdateHintState())));

        /// <summary>
        /// Gets a value indicating if the hint is displayed.
        /// </summary>
        public bool IsHintDisplayed => (bool)GetValue(IsHintDisplayedProperty);

        #region IsHintDisplayedProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="IsHintDisplayed"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey IsHintDisplayedPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsHintDisplayed), typeof(bool), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(BoolBox.False));

        /// <summary>
        /// Identifies the <see cref="IsHintDisplayed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsHintDisplayedProperty = IsHintDisplayedPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets or sets the foreground brush of the hint.
        /// </summary>
        public Brush HintForeground
        {
            get => (Brush)GetValue(HintForegroundProperty);
            set => SetValue(HintForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HintForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintForegroundProperty =
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the opacity of the hint.
        /// </summary>
        public double HintOpacity
        {
            get => (double)GetValue(HintOpacityProperty);
            set => SetValue(HintOpacityProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HintOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintOpacityProperty =
            DependencyProperty.Register(nameof(HintOpacity), typeof(double), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the hint foreground brush to the actual background brush of the control.
        /// </summary>
        public bool AdaptHintForegroundAutomatically
        {
            get => (bool)GetValue(AdaptHintForegroundAutomaticallyProperty);
            set => SetValue(AdaptHintForegroundAutomaticallyProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AdaptHintForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptHintForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptHintForegroundAutomatically), typeof(bool), typeof(PasswordBoxPlus),
                new PropertyMetadata(BoolBox.True));

        #endregion

        #region Peek

        /// <summary>
        /// Contains the password when the peek button is clicked.
        /// </summary>
        public string Peek => (string)GetValue(PeekProperty);

        #region PeekProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="Peek"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey PeekPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(Peek), typeof(string), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => ((PasswordBoxPlus)d).UpdatePeekState())));

        /// <summary>
        /// Identifies the <see cref="Peek"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekProperty = PeekPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets a value indicating if the password is displayed as peek.
        /// </summary>
        public bool IsPeekDisplayed => (bool)GetValue(IsPeekDisplayedProperty);

        #region IsPeekDisplayedProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="IsPeekDisplayed"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey IsPeekDisplayedPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsPeekDisplayed), typeof(bool), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(BoolBox.False));

        /// <summary>
        /// Identifies the <see cref="IsPeekDisplayed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsPeekDisplayedProperty = IsPeekDisplayedPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets or sets a value indicating if to display or not a button that show the password while is pressed.
        /// </summary>
        public bool EnablePeekButton
        {
            get => (bool)GetValue(EnablePeekButtonProperty);
            set => SetValue(EnablePeekButtonProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnablePeekButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnablePeekButtonProperty =
            DependencyProperty.Register(nameof(EnablePeekButton), typeof(bool), typeof(PasswordBoxPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets the foreground of the text showing the password.
        /// </summary>
        public Brush PeekForeground
        {
            get => (Brush)GetValue(PeekForegroundProperty);
            set => SetValue(PeekForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekForegroundProperty =
            DependencyProperty.Register(nameof(PeekForeground), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the foreground of the peek button.
        /// </summary>
        public Brush PeekButtonForeground
        {
            get => (Brush)GetValue(PeekButtonForegroundProperty);
            set => SetValue(PeekButtonForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonForegroundProperty =
            DependencyProperty.Register(nameof(PeekButtonForeground), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the peek foreground to the actual background of the control.
        /// </summary>
        public bool AdaptPeekForegroundAutomatically
        {
            get => (bool)GetValue(AdaptPeekForegroundAutomaticallyProperty);
            set => SetValue(AdaptPeekForegroundAutomaticallyProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AdaptPeekForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptPeekForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptPeekForegroundAutomatically), typeof(bool), typeof(PasswordBoxPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the peek button foreground to the actual background of the control.
        /// </summary>
        public bool AdaptPeekButtonForegroundAutomatically
        {
            get => (bool)GetValue(AdaptPeekButtonForegroundAutomaticallyProperty);
            set => SetValue(AdaptPeekButtonForegroundAutomaticallyProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AdaptPeekButtonForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptPeekButtonForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptPeekButtonForegroundAutomatically), typeof(bool), typeof(PasswordBoxPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets the size of the peek button.
        /// </summary>
        public double PeekButtonSize
        {
            get => (double)GetValue(PeekButtonSizeProperty);
            set => SetValue(PeekButtonSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonSizeProperty =
            DependencyProperty.Register(nameof(PeekButtonSize), typeof(double), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font family of the peek button.
        /// </summary>
        public FontFamily PeekButtonFontFamily
        {
            get => (FontFamily)GetValue(PeekButtonFontFamilyProperty);
            set => SetValue(PeekButtonFontFamilyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonFontFamily"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonFontFamilyProperty =
            DependencyProperty.Register(nameof(PeekButtonFontFamily), typeof(FontFamily), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font size of the peek button.
        /// </summary>
        public double PeekButtonFontSize
        {
            get => (double)GetValue(PeekButtonFontSizeProperty);
            set => SetValue(PeekButtonFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonFontSizeProperty =
            DependencyProperty.Register(nameof(PeekButtonFontSize), typeof(double), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font stretch of the peek button.
        /// </summary>
        public FontStretch PeekButtonFontStretch
        {
            get => (FontStretch)GetValue(PeekButtonFontStretchProperty);
            set => SetValue(PeekButtonFontStretchProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonFontStretch"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonFontStretchProperty =
            DependencyProperty.Register(nameof(PeekButtonFontStretch), typeof(FontStretch), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font style of the peek button.
        /// </summary>
        public FontStyle PeekButtonFontStyle
        {
            get => (FontStyle)GetValue(PeekButtonFontStyleProperty);
            set => SetValue(PeekButtonFontStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonFontStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonFontStyleProperty =
            DependencyProperty.Register(nameof(PeekButtonFontStyle), typeof(FontStyle), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font weight of the peek button.
        /// </summary>
        public FontWeight PeekButtonFontWeight
        {
            get => (FontWeight)GetValue(PeekButtonFontWeightProperty);
            set => SetValue(PeekButtonFontWeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonFontWeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonFontWeightProperty =
            DependencyProperty.Register(nameof(PeekButtonFontWeight), typeof(FontWeight), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the cursor when the mouse is over the peek button.
        /// </summary>
        public Cursor PeekButtonCursor
        {
            get => (Cursor)GetValue(PeekButtonCursorProperty);
            set => SetValue(PeekButtonCursorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonCursor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonCursorProperty =
            DependencyProperty.Register(nameof(PeekButtonCursor), typeof(Cursor), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the content of the peek button.
        /// </summary>
        public object PeekButtonContent
        {
            get => GetValue(PeekButtonContentProperty);
            set => SetValue(PeekButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PeekButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PeekButtonContentProperty =
            DependencyProperty.Register(nameof(PeekButtonContent), typeof(object), typeof(PasswordBoxPlus));

        #endregion

        #region Label

        /// <summary>
        /// Gets or sets the label displayed alongside the control.
        /// </summary>
        public object Label
        {
            get => GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Label"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(object), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => d.SetValue(LabelTypePropertyKey, CurrentLabelType(d)))));

        /// <summary>
        /// Gets or sets the icon displayed alongside the control.
        /// </summary>
        /// <remarks>The icon will be displayed only if <see cref="Label"/> is <see langword="null"/>.</remarks>
        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Icon"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => d.SetValue(LabelTypePropertyKey, CurrentLabelType(d)))));

        /// <summary>
        /// Gets a value indicating the actual label type.
        /// </summary>
        public LabelType LabelType => (LabelType)GetValue(LabelTypeProperty);

        #region LabelTypeProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="LabelType"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey LabelTypePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(LabelType), typeof(LabelType), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(LabelType.Undefined));

        /// <summary>
        /// Identifies the <see cref="LabelType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelTypeProperty = LabelTypePropertyKey.DependencyProperty;

        /// <summary>
        /// Calculates the current label type based on the values of <see cref="Label"/> and <see cref="Icon"/>.
        /// </summary>
        private static LabelType CurrentLabelType(DependencyObject d)
        {
            bool label = d.IsNotNull(LabelProperty);
            bool icon = d.IsNotNull(IconProperty);

            //Visualization predominance: Label -> Icon -> Nothing
            return label ? LabelType.Content : icon ? LabelType.Icon : LabelType.Undefined;
        }

        #endregion

        /// <summary>
        /// Gets or sets the placement of the label.
        /// </summary>
        public Dock LabelPlacement
        {
            get => (Dock)GetValue(LabelPlacementProperty);
            set => SetValue(LabelPlacementProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelPlacement"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelPlacementProperty =
            DependencyProperty.Register(nameof(LabelPlacement), typeof(Dock), typeof(PasswordBoxPlus),
                new PropertyMetadata(Dock.Top));

        /// <summary>
        /// Gets or sets the width of the label.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double LabelWidth
        {
            get => (double)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register(nameof(LabelWidth), typeof(double), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(double.NaN),
                new ValidateValueCallback(Util.IsWidthHeightValid));

        /// <summary>
        /// Gets or sets the height of the label.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double LabelHeight
        {
            get => (double)GetValue(LabelHeightProperty);
            set => SetValue(LabelHeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelHeightProperty =
            DependencyProperty.Register(nameof(LabelHeight), typeof(double), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(double.NaN),
                new ValidateValueCallback(Util.IsWidthHeightValid));

        /// <summary>
        /// Gets or sets the max width of the label.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double LabelMaxWidth
        {
            get => (double)GetValue(LabelMaxWidthProperty);
            set => SetValue(LabelMaxWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelMaxWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelMaxWidthProperty =
            DependencyProperty.Register(nameof(LabelMaxWidth), typeof(double), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(double.PositiveInfinity),
                new ValidateValueCallback(Util.IsMaxWidthHeightValid));

        /// <summary>
        /// Gets or sets the max height of the label.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double LabelMaxHeight
        {
            get => (double)GetValue(LabelMaxHeightProperty);
            set => SetValue(LabelMaxHeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelMaxHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelMaxHeightProperty =
            DependencyProperty.Register(nameof(LabelMaxHeight), typeof(double), typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(double.PositiveInfinity),
                new ValidateValueCallback(Util.IsMaxWidthHeightValid));

        /// <summary>
        /// Gets or sets the margin of the label.
        /// </summary>
        public Thickness LabelMargin
        {
            get => (Thickness)GetValue(LabelMarginProperty);
            set => SetValue(LabelMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelMarginProperty =
            DependencyProperty.Register(nameof(LabelMargin), typeof(Thickness), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the vertical alignment of the label.
        /// </summary>
        public VerticalAlignment LabelVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(LabelVerticalAlignmentProperty);
            set => SetValue(LabelVerticalAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelVerticalAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(LabelVerticalAlignment), typeof(VerticalAlignment), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the horizontal alignment of the label.
        /// </summary>
        public HorizontalAlignment LabelHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(LabelHorizontalAlignmentProperty);
            set => SetValue(LabelHorizontalAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelHorizontalAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(LabelHorizontalAlignment), typeof(HorizontalAlignment), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the foreground brush of the label.
        /// </summary>
        public Brush LabelForeground
        {
            get => (Brush)GetValue(LabelForegroundProperty);
            set => SetValue(LabelForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelForegroundProperty =
            DependencyProperty.Register(nameof(LabelForeground), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font size of the label.
        /// </summary>
        public double LabelFontSize
        {
            get => (double)GetValue(LabelFontSizeProperty);
            set => SetValue(LabelFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register(nameof(LabelFontSize), typeof(double), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font family of the label.
        /// </summary>
        public FontFamily LabelFontFamily
        {
            get => (FontFamily)GetValue(LabelFontFamilyProperty);
            set => SetValue(LabelFontFamilyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontFamily"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontFamilyProperty =
            DependencyProperty.Register(nameof(LabelFontFamily), typeof(FontFamily), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font stretch of the label.
        /// </summary>
        public FontStretch LabelFontStretch
        {
            get => (FontStretch)GetValue(LabelFontStretchProperty);
            set => SetValue(LabelFontStretchProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontStretch"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontStretchProperty =
            DependencyProperty.Register(nameof(LabelFontStretch), typeof(FontStretch), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font style of the label.
        /// </summary>
        public FontStyle LabelFontStyle
        {
            get => (FontStyle)GetValue(LabelFontStyleProperty);
            set => SetValue(LabelFontStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontStyleProperty =
            DependencyProperty.Register(nameof(LabelFontStyle), typeof(FontStyle), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the font weight of the label.
        /// </summary>
        public FontWeight LabelFontWeight
        {
            get => (FontWeight)GetValue(LabelFontWeightProperty);
            set => SetValue(LabelFontWeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LabelFontWeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelFontWeightProperty =
            DependencyProperty.Register(nameof(LabelFontWeight), typeof(FontWeight), typeof(PasswordBoxPlus));

        #endregion

        #region ExternalOutline

        /// <summary>
        /// Gets or sets the background brush of the external outline.
        /// </summary>
        public Brush ExternalBackground
        {
            get => (Brush)GetValue(ExternalBackgroundProperty);
            set => SetValue(ExternalBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalBackgroundProperty =
            DependencyProperty.Register(nameof(ExternalBackground), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the border brush of the external outline.
        /// </summary>
        public Brush ExternalBorderBrush
        {
            get => (Brush)GetValue(ExternalBorderBrushProperty);
            set => SetValue(ExternalBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalBorderBrushProperty =
            DependencyProperty.Register(nameof(ExternalBorderBrush), typeof(Brush), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the border thickness of the external outline.
        /// </summary>
        public Thickness ExternalBorderThickness
        {
            get => (Thickness)GetValue(ExternalBorderThicknessProperty);
            set => SetValue(ExternalBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalBorderThicknessProperty =
            DependencyProperty.Register(nameof(ExternalBorderThickness), typeof(Thickness), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the padding of the external outline.
        /// </summary>
        public Thickness ExternalPadding
        {
            get => (Thickness)GetValue(ExternalPaddingProperty);
            set => SetValue(ExternalPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalPaddingProperty =
            DependencyProperty.Register(nameof(ExternalPadding), typeof(Thickness), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the corner radius of the external outline.
        /// </summary>
        public CornerRadius ExternalCornerRadius
        {
            get => (CornerRadius)GetValue(ExternalCornerRadiusProperty);
            set => SetValue(ExternalCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExternalCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExternalCornerRadiusProperty =
            DependencyProperty.Register(nameof(ExternalCornerRadius), typeof(CornerRadius), typeof(PasswordBoxPlus));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the width of the text area.
        /// </summary>
        public double TextViewSize
        {
            get => (double)GetValue(TextViewSizeProperty);
            set => SetValue(TextViewSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TextViewSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextViewSizeProperty =
            DependencyProperty.Register(nameof(TextViewSize), typeof(double), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets a value indicating if enable automatic adjustement of margins between all text controls in the same group.
        /// </summary>
        public bool AutoMargin
        {
            get => (bool)GetValue(AutoMarginProperty);
            set => SetValue(AutoMarginProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="AutoMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoMarginProperty =
            DependencyProperty.Register(nameof(AutoMargin), typeof(bool), typeof(PasswordBoxPlus),
                new PropertyMetadata(BoolBox.False));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the masking character for <see cref="Password"/>.
        /// </summary>
        public char PasswordChar
        {
            get => (char)GetValue(PasswordCharProperty);
            set => SetValue(PasswordCharProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PasswordChar"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PasswordCharProperty =
            DependencyProperty.Register(nameof(PasswordChar), typeof(char), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets the max length of <see cref="Password"/>.
        /// </summary>
        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="MaxLength"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register(nameof(MaxLength), typeof(int), typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets or sets a value indicating if the control displays selected text when does not have focus.
        /// </summary>
        public bool IsInactiveSelectionHighlightEnabled
        {
            get => (bool)GetValue(IsInactiveSelectionHighlightEnabledProperty);
            set => SetValue(IsInactiveSelectionHighlightEnabledProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="IsInactiveSelectionHighlightEnabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsInactiveSelectionHighlightEnabledProperty =
            TextBoxBase.IsInactiveSelectionHighlightEnabledProperty.AddOwner(typeof(PasswordBoxPlus));

        /// <summary>
        /// Gets the value of <see cref="Password"/> as <see cref="SecureString"/>.
        /// </summary>
        public SecureString SecurePassword => passwordBox.SecurePassword;

        /// <summary>
        /// Gets or sets the value of the password.
        /// </summary>
        public string Password
        {
            get => passwordBox.Password;
            set => passwordBox.Password = value;
        }

        /// <summary>
        /// Gets the length of the password (SecurePassword.Length).
        /// </summary>
        public int PasswordLength => SecurePassword != null ? SecurePassword.Length : 0;

        /// <summary>
        /// Gets a value indicating if the control has focus and selected text.
        /// </summary>
        public bool IsSelectionActive => passwordBox.IsSelectionActive;

        /// <summary>
        /// Gets a value indicating if the control has the focus.
        /// </summary>
        public new bool IsFocused => passwordBox.IsFocused;

        /// <summary>
        /// Raised when <see cref="Password"/> is changed.
        /// </summary>
        public event RoutedEventHandler PasswordChanged
        {
            add { AddHandler(PasswordChangedEvent, value); }
            remove { RemoveHandler(PasswordChangedEvent, value); }
        }

        /// <summary>
        /// Identifies the <see cref="PasswordChanged"/> routed event.
        /// </summary>
        public static readonly RoutedEvent PasswordChangedEvent =
            EventManager.RegisterRoutedEvent(nameof(PasswordChanged), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PasswordBoxPlus));


        static PasswordBoxPlus()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(typeof(PasswordBoxPlus)));

            IsEnabledProperty.OverrideMetadata(typeof(PasswordBoxPlus),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((PasswordBoxPlus)d).OnEnabledChanged())));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PasswordBoxPlus"/>.
        /// </summary>
        public PasswordBoxPlus() : base()
        {
            Loaded += (o, e) => OnLoaded();
            passwordBox = PreparePasswordBoxChild();
        }

        /// <summary>
        /// Clears the value of the <see cref="Password"/> property.
        /// </summary>
        public void Clear() => passwordBox.Clear();

        /// <summary>
        /// Copy the value of the <see cref="Password"/> property on the <see cref="Clipboard"/>.
        /// </summary>
        public void CopyAll() => Clipboard.SetText(Password);

        /// <summary>
        /// Replaces the current selection with the contents of the <see cref="Clipboard"/>.
        /// </summary>
        public void Paste() => passwordBox.Paste();

        /// <summary>
        /// Select the entire content.
        /// </summary>
        public void SelectAll() => passwordBox.SelectAll();

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AttachPasswordBoxChild();
            if (Template.FindName(PartPeekButton, this) is UIElement peekButton)
            {
                peekButton.PreviewMouseLeftButtonDown += PeekButton_MouseLeftButtonDown;
                peekButton.PreviewMouseLeftButtonUp += PeekButton_MouseLeftButtonUp;
                peekButton.MouseLeave += PeekButton_MouseLeave;
            }
            UpdateHintState();
            loaded = true;
            OnVStateChanged(GetCurrentVState(), true);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        private void OnLoaded()
        {
            AdaptForeColors(ActualBackground);
            OnVStateChanged(GetCurrentVState());
        }

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        private void OnActualBackgroundChanged(Brush actualBackground) => AdaptForeColors(actualBackground);

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        private void OnEnabledChanged() => OnVStateChanged(GetCurrentVState());

        /// <inheritdoc/>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            passwordBox.Focus();
        }

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsFocused)
            {
                _ = VisualStateManager.GoToState(this, "MouseOver", true);
                OnVStateChanged(GetCurrentVState());
            }
        }

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!IsFocused)
            {
                _ = VisualStateManager.GoToState(this, "Normal", true);
                OnVStateChanged(GetCurrentVState());
            }
        }

        /// <inheritdoc/>
        public VState GetCurrentVState()
        {
            if (!loaded) return VState.UNSET;
            if (!IsEnabled) return VStates.DISABLED;
            else if (IsFocused) return VStates.FOCUSED;
            else if (IsMouseOver) return VStates.MOUSE_OVER;
            else return VStates.DEFAULT;
        }

        /// <summary>
        /// Called when the current <see cref="VState"/> is changed.
        /// </summary>
        /// <param name="vstate">Current <see cref="VState"/>.</param>
        /// <param name="initial">Specifies if this is the initial <see cref="VState"/>.</param>
        private void OnVStateChanged(VState vstate, bool initial = false)
        {
            if (vstate == VStates.DEFAULT)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, Background, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualUnderlineBrushPropertyProxy, UnderlineBrush, initial ? TimeSpan.Zero : AnimationTime);
                SetValue(ActualUnderlineThicknessPropertyKey, UnderlineThickness);
            }
            else if (vstate == VStates.MOUSE_OVER)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualUnderlineBrushPropertyProxy, UnderlineBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                SetValue(ActualUnderlineThicknessPropertyKey, UnderlineThicknessOnSelected);
            }
            else if (vstate == VStates.FOCUSED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualUnderlineBrushPropertyProxy, UnderlineBrushOnSelected, initial ? TimeSpan.Zero : AnimationTime);
                SetValue(ActualUnderlineThicknessPropertyKey, UnderlineThicknessOnSelected);
            }
            else if (vstate == VStates.DISABLED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualUnderlineBrushPropertyProxy, UnderlineBrushOnDisabled, initial ? TimeSpan.Zero : AnimationTime);
                SetValue(ActualUnderlineThicknessPropertyKey, UnderlineThicknessOnDisabled);
            }
        }

        /// <summary>
        /// Update the visualstate to <see langword="Hinted"/> or <see langword="Unhinted"/> if is necessary to display or hide the hint.
        /// </summary>
        private void UpdateHintState()
        {
            bool hinted = PasswordLength == 0 && !IsFocused && !string.IsNullOrEmpty(Hint);
            SetValue(IsHintDisplayedPropertyKey, BoolBox.Box(hinted));
            _ = VisualStateManager.GoToState(this, hinted ? "Hinted" : "Unhinted", true);
        }

        /// <summary>
        /// Update the visualstate to <see langword="Peeked"/> or <see langword="Unpeeked"/> if is necessary to display or hide the hint.
        /// </summary>
        private void UpdatePeekState()
        {
            bool peeked = !string.IsNullOrEmpty(Peek);
            SetValue(IsPeekDisplayedPropertyKey, BoolBox.Box(peeked));
            _ = VisualStateManager.GoToState(this, peeked ? "Peeked" : "Unpeeked", true);
        }

        /// <summary>
        /// Adapt some brushes to the actual background of the control.
        /// </summary>
        /// <param name="backgroundBrush">Actual background of the control.</param>
        private void AdaptForeColors(Brush backgroundBrush)
        {
            if (backgroundBrush is SolidColorBrush brush)
            {
                SolidColorBrush inverseBrush = new(brush.Color.Invert());
                if (AdaptForegroundAutomatically) Foreground = inverseBrush;
                if (AdaptHintForegroundAutomatically) HintForeground = inverseBrush;
                if (AdaptPeekForegroundAutomatically) PeekForeground = inverseBrush;
                if (AdaptPeekButtonForegroundAutomatically) PeekButtonForeground = inverseBrush;
                if (AdaptCaretBrushAutomatically) CaretBrush = inverseBrush;
            }
        }

        #region PasswordBox events

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            UpdateHintState();
            RaiseEvent(new RoutedEventArgs(PasswordChangedEvent));
        }

        /// <summary>
        /// Called when the <see cref="PasswordBox"/> got the focus.
        /// </summary>
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            _ = VisualStateManager.GoToState(this, "Focused", true);
            OnVStateChanged(GetCurrentVState());
        }

        /// <summary>
        /// Called when the <see cref="PasswordBox"/> lose the focus.
        /// </summary>
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            _ = VisualStateManager.GoToState(this, IsMouseOver ? "MouseOver" : "Normal", true);
            OnVStateChanged(GetCurrentVState());
        }

        #endregion

        #region PeekButton events

        /// <summary>
        /// Called when the peek button is clicked down.
        /// </summary>
        private void PeekButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => SetValue(PeekPropertyKey, Password);

        /// <summary>
        /// Called when the peek button is clicked up.
        /// </summary>
        private void PeekButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) => SetValue(PeekPropertyKey, null);

        /// <summary>
        /// Called when the mouse leave the peek button.
        /// </summary>
        private void PeekButton_MouseLeave(object sender, MouseEventArgs e) => SetValue(PeekPropertyKey, null);

        #endregion

        /// <summary>
        /// Prepares the <see cref="PasswordBox"/> child control.
        /// </summary>
        private PasswordBox PreparePasswordBoxChild()
        {
            PasswordBox passwordBox = new();

            //Setting events
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            passwordBox.GotFocus += PasswordBox_GotFocus;
            passwordBox.LostFocus += PasswordBox_LostFocus;
            //Setting properties
            passwordBox.Background = Brushes.Transparent;
            passwordBox.BorderThickness = new(0);
            passwordBox.Focusable = true;
            //Setting bindings
            passwordBox.SetBinding(PasswordBox.HorizontalContentAlignmentProperty, new Binding(nameof(HorizontalContentAlignment)) { Source = this });
            passwordBox.SetBinding(PasswordBox.VerticalContentAlignmentProperty, new Binding(nameof(VerticalContentAlignment)) { Source = this });
            passwordBox.SetBinding(PasswordBox.ForegroundProperty, new Binding(nameof(Foreground)) { Source = this });
            passwordBox.SetBinding(PasswordBox.CaretBrushProperty, new Binding(nameof(CaretBrush)) { Source = this });
            passwordBox.SetBinding(PasswordBox.SelectionBrushProperty, new Binding(nameof(SelectionBrush)) { Source = this });
            passwordBox.SetBinding(PasswordBox.SelectionTextBrushProperty, new Binding(nameof(SelectionTextBrush)) { Source = this });
            passwordBox.SetBinding(PasswordBox.SelectionOpacityProperty, new Binding(nameof(SelectionOpacity)) { Source = this });
            passwordBox.SetBinding(PasswordBox.ContextMenuProperty, new Binding(nameof(ContextMenu)) { Source = this });
            passwordBox.SetBinding(PasswordBox.PasswordCharProperty, new Binding(nameof(PasswordChar)) { Source = this });
            passwordBox.SetBinding(PasswordBox.MaxLengthProperty, new Binding(nameof(MaxLength)) { Source = this });
            passwordBox.SetBinding(PasswordBox.IsInactiveSelectionHighlightEnabledProperty, new Binding(nameof(IsInactiveSelectionHighlightEnabled)) { Source = this });
            passwordBox.SetBinding(PasswordBox.IsEnabledProperty, new Binding(nameof(IsEnabled)) { Source = this });
            passwordBox.SetBinding(PasswordBox.SnapsToDevicePixelsProperty, new Binding(nameof(SnapsToDevicePixels)) { Source = this });

            return passwordBox;
        }

        /// <summary>
        /// Attaches the <see cref="PasswordBox"/> child control to the <see cref="ContentPresenter"/> content host part.
        /// </summary>
        private void AttachPasswordBoxChild()
        {
            if (Template.FindName(PartContentHost, this) is ContentPresenter contentHost) contentHost.Content = passwordBox;
        }


        /// <summary>
        /// Control v-states.
        /// </summary>
        public static class VStates
        {
            /// <summary>
            /// Default state.
            /// </summary>
            public static readonly VState DEFAULT = new(nameof(DEFAULT), typeof(PasswordBoxPlus));

            /// <summary>
            /// The mouse is over the control.
            /// </summary>
            public static readonly VState MOUSE_OVER = new(nameof(MOUSE_OVER), typeof(PasswordBoxPlus));

            /// <summary>
            /// The control is focused.
            /// </summary>
            public static readonly VState FOCUSED = new(nameof(FOCUSED), typeof(PasswordBoxPlus));

            /// <summary>
            /// The control is disabled.
            /// </summary>
            public static readonly VState DISABLED = new(nameof(DISABLED), typeof(PasswordBoxPlus));
        }
    }
}
