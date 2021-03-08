using FullControls.Common;
using FullControls.Core;
using FullControls.Extra;
using System;
using System.ComponentModel;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control designed for entering and handling passwords.
    /// </summary>
    [TemplatePart(Name = PartPasswordBox, Type = typeof(PasswordBox))]
    [TemplatePart(Name = PartPeekButton, Type = typeof(UIElement))]
    public sealed class EPasswordBox : Control
    {
        private bool loaded = false;
        private PasswordBox passwordBox = null;
        private string tempPassword = null;

        /// <summary>
        /// PasswordBox template part.
        /// </summary>
        private const string PartPasswordBox = "PART_PasswordBox";

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
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(EPasswordBox));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(EPasswordBox),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => ((EPasswordBox)d).OnActualBackgroundChanged((Brush)e.NewValue))));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(EPasswordBox));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(EPasswordBox),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(EPasswordBox),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBorderBrushPropertyKey, e.NewValue))));

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
            DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(EPasswordBox),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => ((EPasswordBox)d).UpdateHintState())));

        /// <summary>
        /// Gets a value indicating if the hint is displayed.
        /// </summary>
        public bool IsHintDisplayed => (bool)GetValue(IsHintDisplayedProperty);

        #region IsHintDisplayedProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="IsHintDisplayed"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey IsHintDisplayedPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsHintDisplayed), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(HintOpacity), typeof(double), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(AdaptHintForegroundAutomatically), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.RegisterReadOnly(nameof(Peek), typeof(string), typeof(EPasswordBox),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => ((EPasswordBox)d).UpdatePeekState())));

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
            DependencyProperty.RegisterReadOnly(nameof(IsPeekDisplayed), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(EnablePeekButton), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(PeekForeground), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PeekButtonForeground), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(AdaptPeekForegroundAutomatically), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(AdaptPeekButtonForegroundAutomatically), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(PeekButtonSize), typeof(double), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PeekButtonFontFamily), typeof(FontFamily), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PeekButtonFontSize), typeof(double), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PeekButtonFontStretch), typeof(FontStretch), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PeekButtonFontStyle), typeof(FontStyle), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PeekButtonFontWeight), typeof(FontWeight), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PeekButtonCursor), typeof(Cursor), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PeekButtonContent), typeof(object), typeof(EPasswordBox));

        #endregion

        #region Label

        /// <summary>
        /// Gets or sets the label displayed on the left or top of the control.
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
            DependencyProperty.Register(nameof(Label), typeof(object), typeof(EPasswordBox),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => d.SetValue(LabelTypePropertyKey, CurrentLabelType(d)))));

        /// <summary>
        /// Gets or sets the icon displayed on the left or top of the control.
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
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(EPasswordBox),
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
            DependencyProperty.RegisterReadOnly(nameof(LabelType), typeof(LabelType), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(LabelPlacement), typeof(Dock), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(LabelWidth), typeof(double), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(LabelHeight), typeof(double), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(LabelMaxWidth), typeof(double), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(LabelMaxHeight), typeof(double), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(LabelMargin), typeof(Thickness), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(LabelVerticalAlignment), typeof(VerticalAlignment), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(LabelHorizontalAlignment), typeof(HorizontalAlignment), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(LabelForeground), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(LabelFontSize), typeof(double), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(LabelFontFamily), typeof(FontFamily), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(LabelFontStretch), typeof(FontStretch), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(LabelFontStyle), typeof(FontStyle), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(LabelFontWeight), typeof(FontWeight), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(ExternalBackground), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(ExternalBorderBrush), typeof(Brush), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(ExternalBorderThickness), typeof(Thickness), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(ExternalPadding), typeof(Thickness), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(ExternalCornerRadius), typeof(CornerRadius), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(TextViewSize), typeof(double), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(AutoMargin), typeof(bool), typeof(EPasswordBox),
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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(PasswordChar), typeof(char), typeof(EPasswordBox));

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
            DependencyProperty.Register(nameof(MaxLength), typeof(int), typeof(EPasswordBox));

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
            TextBoxBase.IsInactiveSelectionHighlightEnabledProperty.AddOwner(typeof(EPasswordBox));

        /// <summary>
        /// Gets the value of <see cref="Password"/> as <see cref="SecureString"/>.
        /// </summary>
        public SecureString SecurePassword => GetSecurePassword();

        /// <summary>
        /// Gets or sets the value of the password.
        /// </summary>
        public string Password
        {
            get => GetPassword();
            set => SetPassword(value);
        }

        /// <summary>
        /// Gets the length of the password (SecurePassword.Length).
        /// </summary>
        public int PasswordLength => SecurePassword != null ? SecurePassword.Length : 0;

        /// <summary>
        /// Gets a value indicating if the control has focus and selected text.
        /// </summary>
        public bool IsSelectionActive => passwordBox != null && passwordBox.IsSelectionActive;

        /// <summary>
        /// Gets a value indicating if the control has the focus.
        /// </summary>
        public new bool IsFocused => passwordBox != null && passwordBox.IsFocused;

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
            EventManager.RegisterRoutedEvent(nameof(PasswordChanged), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(EPasswordBox));


        static EPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EPasswordBox),
                new FrameworkPropertyMetadata(typeof(EPasswordBox)));

            IsEnabledProperty.OverrideMetadata(typeof(EPasswordBox),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((EPasswordBox)d).OnEnabledChanged())));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EPasswordBox"/>.
        /// </summary>
        public EPasswordBox() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <summary>
        /// Clears the value of the <see cref="Password"/> property.
        /// </summary>
        public void Clear() => passwordBox?.Clear();

        /// <summary>
        /// Copy the value of the <see cref="Password"/> property on the <see cref="Clipboard"/>.
        /// </summary>
        public void CopyAll() => Clipboard.SetText(Password);

        /// <summary>
        /// Replaces the current selection with the contents of the <see cref="Clipboard"/>.
        /// </summary>
        public void Paste() => passwordBox?.Paste();

        /// <summary>
        /// Select the entire content.
        /// </summary>
        public void SelectAll() => passwordBox?.SelectAll();

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            passwordBox = (PasswordBox)Template.FindName(PartPasswordBox, this);
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                passwordBox.GotFocus += PasswordBox_GotFocus;
                passwordBox.LostFocus += PasswordBox_LostFocus;
            }
            UIElement peekButton = (UIElement)Template.FindName(PartPeekButton, this);
            if (peekButton != null)
            {
                peekButton.PreviewMouseLeftButtonDown += PeekButton_MouseLeftButtonDown;
                peekButton.PreviewMouseLeftButtonUp += PeekButton_MouseLeftButtonUp;
                peekButton.MouseLeave += PeekButton_MouseLeave;
            }
            UpdateHintState();
            Util.AnimateBrush(this, ActualBackgroundPropertyProxy, Background, TimeSpan.Zero);
            Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
            loaded = true;
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        private void OnLoaded(RoutedEventArgs e)
        {
            Initialize();
            AdaptForeColors(ActualBackground);
            OnVStateChanged(VStateOverride());
        }

        /// <summary>
        /// Set the initial password.
        /// </summary>
        private void Initialize()
        {
            if (tempPassword != null)
            {
                SetPassword(tempPassword);
                tempPassword = null;
            }
        }

        /// <summary>
        /// Gets the password as a <see cref="SecureString"/>.
        /// </summary>
        /// <returns>The password as <see cref="SecureString"/>.</returns>
        private SecureString GetSecurePassword() => passwordBox != null ? passwordBox.SecurePassword : new SecureString();

        /// <summary>
        /// Sets the password.
        /// </summary>
        /// <param name="password">Password.</param>
        private void SetPassword(string password)
        {
            if (passwordBox != null) passwordBox.Password = password;
            else tempPassword = password;
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <returns>Password.</returns>
        private string GetPassword() => passwordBox != null ? passwordBox.Password : "";

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        private void OnActualBackgroundChanged(Brush actualBackground) => AdaptForeColors(actualBackground);

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        private void OnEnabledChanged() => OnVStateChanged(VStateOverride());

        /// <inheritdoc/>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            passwordBox?.Focus();
        }

        /// <inheritdoc/>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsFocused)
            {
                _ = VisualStateManager.GoToState(this, "MouseOver", true);
                OnVStateChanged(VStateOverride());
            }
        }

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!IsFocused)
            {
                _ = VisualStateManager.GoToState(this, "Normal", true);
                OnVStateChanged(VStateOverride());
            }
        }

        /// <summary>
        /// Called to calculate the <b>v-state</b> of the control.
        /// </summary>
        private string VStateOverride()
        {
            if (!loaded) return "Undefined";
            if (!IsEnabled) return "Disabled";
            else if (IsFocused) return "Focused";
            else if (IsMouseOver) return "MouseOver";
            else return "Normal";
        }

        /// <summary>
        /// Called when the <b>v-state</b> of the control changed.
        /// </summary>
        /// <remarks>Is called <b>v-state</b> because is not related to the VisualState of the control.</remarks>
        /// <param name="vstate">Actual <b>v-state</b> of the control.</param>
        private void OnVStateChanged(string vstate)
        {
            switch (vstate)
            {
                case "Normal":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, Background, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
                    break;
                case "MouseOver":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnSelected, AnimationTime);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnSelected, AnimationTime);
                    break;
                case "Focused":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnSelected, AnimationTime);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnSelected, AnimationTime);
                    break;
                case "Disabled":
                    Util.AnimateBrush(this, ActualBackgroundPropertyProxy, BackgroundOnDisabled, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnDisabled, TimeSpan.Zero);
                    break;
                default:
                    break;
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
                SolidColorBrush inverseBrush = new SolidColorBrush(brush.Color.Invert());
                if (AdaptForegroundAutomatically) Foreground = inverseBrush;
                if (AdaptHintForegroundAutomatically) HintForeground = inverseBrush;
                if (AdaptPeekForegroundAutomatically) PeekForeground = inverseBrush;
                if (AdaptPeekButtonForegroundAutomatically) PeekButtonForeground = inverseBrush;
                if (AdaptCaretBrushAutomatically) CaretBrush = inverseBrush;
            }
        }

        #region Internal PasswordBox events

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
            OnVStateChanged(VStateOverride());
        }

        /// <summary>
        /// Called when the <see cref="PasswordBox"/> lose the focus.
        /// </summary>
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            _ = VisualStateManager.GoToState(this, IsMouseOver ? "MouseOver" : "Normal", true);
            OnVStateChanged(VStateOverride());
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
    }
}
