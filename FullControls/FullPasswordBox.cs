﻿using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    /// <summary>
    /// Represents a control designed for entering and handling passwords.
    /// </summary>
    public sealed class FullPasswordBox : Control
    {
        private PasswordBox passwordBox = null;
        private TextBlock peek = null;
        private string _tempPassword = null;

        /// <summary>
        /// Background color when the control is selected.
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
            DependencyProperty.Register(nameof(BackgroundOnSelected), typeof(Brush), typeof(FullPasswordBox));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Actual Background color of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FullPasswordBox));

        #region BackgroundBack

        /// <summary>
        /// Actual Background color of the control.
        /// </summary>
        internal Brush BackgroundBack
        {
            get => (Brush)GetValue(BackgroundBackProperty);
            set => SetValue(BackgroundBackProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundBack"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty BackgroundBackProperty =
            DependencyProperty.Register(nameof(BackgroundBack), typeof(Brush), typeof(FullPasswordBox),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) =>
                {
                    d.SetValue(ActualBackgroundProperty, e.NewValue);
                    ((FullPasswordBox)d).OnActualBackgroundChanged(new BackgroundChangedEventArgs((Brush)e.NewValue));
                })));

        #endregion

        /// <summary>
        /// BorderBrush color when the control is selected.
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
            DependencyProperty.Register(nameof(BorderBrushOnSelected), typeof(Brush), typeof(FullPasswordBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        #region BorderBrushBack

        /// <summary>
        /// Actual BorderBrush color of the control.
        /// </summary>
        internal Brush BorderBrushBack
        {
            get => (Brush)GetValue(BorderBrushBackProperty);
            set => SetValue(BorderBrushBackProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushBack"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty BorderBrushBackProperty =
            DependencyProperty.Register(nameof(BorderBrushBack), typeof(Brush), typeof(FullPasswordBox));

        #endregion

        /// <summary>
        /// Brush of the caret of the passwordbox.
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
            DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Brush of the highlighted part of the passwordbox text.
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
            DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Brush of the selected text.
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
            DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Opacity of the highlighted part of the passwordbox text.
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
            DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(FullPasswordBox));

        /// <summary>
        /// Horizontal alignment of the passwordbox content.
        /// </summary>
        public HorizontalAlignment TextAlignment
        {
            get => (HorizontalAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TextAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register(nameof(TextAlignment), typeof(HorizontalAlignment), typeof(FullPasswordBox));

        /// <summary>
        /// Specifies if adapt automatically the foreground to the actual background of the control.
        /// </summary>
        public bool AdaptForegroundAutomatically
        {
            get => (bool)GetValue(AdaptForegroundAutomaticallyProperty);
            set => SetValue(AdaptForegroundAutomaticallyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AdaptForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Specifies if adapt automatically the caret brush to the actual background of the control.
        /// </summary>
        public bool AdaptCaretBrushAutomatically
        {
            get => (bool)GetValue(AdaptCaretBrushAutomaticallyProperty);
            set => SetValue(AdaptCaretBrushAutomaticallyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AdaptCaretBrushAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptCaretBrushAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(FullPasswordBox));

        #region Hint

        /// <summary>
        /// Specifies if to display or not the hint.
        /// </summary>
        public bool ShowHint
        {
            get => (bool)GetValue(ShowHintProperty);
            set => SetValue(ShowHintProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShowHint"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowHintProperty =
            DependencyProperty.Register(nameof(ShowHint), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Foreground of the hint.
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
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Opacity of the hint.
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
            DependencyProperty.Register(nameof(HintOpacity), typeof(double), typeof(FullPasswordBox));

        /// <summary>
        /// Specifies if adapt automatically the hint foreground to the actual background of the control.
        /// </summary>
        public bool AdaptHintForegroundAutomatically
        {
            get => (bool)GetValue(AdaptHintForegroundAutomaticallyProperty);
            set => SetValue(AdaptHintForegroundAutomaticallyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AdaptHintForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptHintForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptHintForegroundAutomatically), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Suggestion that will displayed if there is no text inside the passwordbox.
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
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(FullPasswordBox));

        #endregion

        #region PeekButton

        /// <summary>
        /// Specifies if to display or not a button that show the password while is pressed.
        /// </summary>
        public bool EnablePeekButton
        {
            get => (bool)GetValue(EnablePeekButtonProperty);
            set => SetValue(EnablePeekButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnablePeekButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnablePeekButtonProperty =
            DependencyProperty.Register(nameof(EnablePeekButton), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Foreground of the text showing the password.
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
            DependencyProperty.Register(nameof(PeekForeground), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Foreground of the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonForeground), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Specifies if adapt automatically the peek foreground to the actual background of the control.
        /// </summary>
        public bool AdaptPeekForegroundAutomatically
        {
            get => (bool)GetValue(AdaptPeekForegroundAutomaticallyProperty);
            set => SetValue(AdaptPeekForegroundAutomaticallyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AdaptPeekForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptPeekForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptPeekForegroundAutomatically), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Specifies if adapt automatically the peek button foreground to the actual background of the control.
        /// </summary>
        public bool AdaptPeekButtonForegroundAutomatically
        {
            get => (bool)GetValue(AdaptPeekButtonForegroundAutomaticallyProperty);
            set => SetValue(AdaptPeekButtonForegroundAutomaticallyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AdaptPeekButtonForegroundAutomatically"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AdaptPeekButtonForegroundAutomaticallyProperty =
            DependencyProperty.Register(nameof(AdaptPeekButtonForegroundAutomatically), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Size of the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonSize), typeof(double), typeof(FullPasswordBox));

        /// <summary>
        /// FontFamily of the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonFontFamily), typeof(FontFamily), typeof(FullPasswordBox));

        /// <summary>
        /// FontSize of the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonFontSize), typeof(double), typeof(FullPasswordBox));

        /// <summary>
        /// FontStretch of the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonFontStretch), typeof(FontStretch), typeof(FullPasswordBox));

        /// <summary>
        /// FontStyle of the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonFontStyle), typeof(FontStyle), typeof(FullPasswordBox));

        /// <summary>
        /// FontWeight of the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonFontWeight), typeof(FontWeight), typeof(FullPasswordBox));

        /// <summary>
        /// Cursor when the mouse is over the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonCursor), typeof(Cursor), typeof(FullPasswordBox));

        /// <summary>
        /// Content of the peek button.
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
            DependencyProperty.Register(nameof(PeekButtonContent), typeof(object), typeof(FullPasswordBox));

        #endregion

        #region CopyButton

        /// <summary>
        /// Specifies if to display or not a button that copies the password on the Clipboard when clicked.
        /// </summary>
        public bool EnableCopyButton
        {
            get => (bool)GetValue(EnableCopyButtonProperty);
            set => SetValue(EnableCopyButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableCopyButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableCopyButtonProperty =
            DependencyProperty.Register(nameof(EnableCopyButton), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Size of the copy button.
        /// </summary>
        public double CopyButtonSize
        {
            get => (double)GetValue(CopyButtonSizeProperty);
            set => SetValue(CopyButtonSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonSizeProperty =
            DependencyProperty.Register(nameof(CopyButtonSize), typeof(double), typeof(FullPasswordBox));

        /// <summary>
        /// FontFamily of the copy button.
        /// </summary>
        public FontFamily CopyButtonFontFamily
        {
            get => (FontFamily)GetValue(CopyButtonFontFamilyProperty);
            set => SetValue(CopyButtonFontFamilyProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontFamily"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontFamilyProperty =
            DependencyProperty.Register(nameof(CopyButtonFontFamily), typeof(FontFamily), typeof(FullPasswordBox));

        /// <summary>
        /// Font size of the copy button.
        /// </summary>
        public double CopyButtonFontSize
        {
            get => (double)GetValue(CopyButtonFontSizeProperty);
            set => SetValue(CopyButtonFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontSizeProperty =
            DependencyProperty.Register(nameof(CopyButtonFontSize), typeof(double), typeof(FullPasswordBox));

        /// <summary>
        /// FontStretch of the copy button.
        /// </summary>
        public FontStretch CopyButtonFontStretch
        {
            get => (FontStretch)GetValue(CopyButtonFontStretchProperty);
            set => SetValue(CopyButtonFontStretchProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontStretch"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontStretchProperty =
            DependencyProperty.Register(nameof(CopyButtonFontStretch), typeof(FontStretch), typeof(FullPasswordBox));

        /// <summary>
        /// FontStyle of the copy button.
        /// </summary>
        public FontStyle CopyButtonFontStyle
        {
            get => (FontStyle)GetValue(CopyButtonFontStyleProperty);
            set => SetValue(CopyButtonFontStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontStyleProperty =
            DependencyProperty.Register(nameof(CopyButtonFontStyle), typeof(FontStyle), typeof(FullPasswordBox));

        /// <summary>
        /// FontWeight of the copy button.
        /// </summary>
        public FontWeight CopyButtonFontWeight
        {
            get => (FontWeight)GetValue(CopyButtonFontWeightProperty);
            set => SetValue(CopyButtonFontWeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonFontWeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonFontWeightProperty =
            DependencyProperty.Register(nameof(CopyButtonFontWeight), typeof(FontWeight), typeof(FullPasswordBox));

        /// <summary>
        /// Margin of the copy button.
        /// </summary>
        public Thickness CopyButtonMargin
        {
            get => (Thickness)GetValue(CopyButtonMarginProperty);
            set => SetValue(CopyButtonMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonMarginProperty =
            DependencyProperty.Register(nameof(CopyButtonMargin), typeof(Thickness), typeof(FullPasswordBox));

        /// <summary>
        /// Content of the copy button.
        /// </summary>
        public object CopyButtonContent
        {
            get => GetValue(CopyButtonContentProperty);
            set => SetValue(CopyButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonContentProperty =
            DependencyProperty.Register(nameof(CopyButtonContent), typeof(object), typeof(FullPasswordBox));

        /// <summary>
        /// Background of the copy button.
        /// </summary>
        public Brush CopyButtonBackground
        {
            get => (Brush)GetValue(CopyButtonBackgroundProperty);
            set => SetValue(CopyButtonBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBackgroundProperty =
            DependencyProperty.Register(nameof(CopyButtonBackground), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Background of the copy button when the mouse is over it.
        /// </summary>
        public Brush CopyButtonBackgroundOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnMouseOverProperty);
            set => SetValue(CopyButtonBackgroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBackgroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnMouseOver), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Background of the copy button when is pressed.
        /// </summary>
        public Brush CopyButtonBackgroundOnPressed
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnPressedProperty);
            set => SetValue(CopyButtonBackgroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBackgroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnPressed), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Background of the copy button when is disabled.
        /// </summary>
        public Brush CopyButtonBackgroundOnDisabled
        {
            get => (Brush)GetValue(CopyButtonBackgroundOnDisabledProperty);
            set => SetValue(CopyButtonBackgroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBackgroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonBackgroundOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// BorderBrush of the copy button.
        /// </summary>
        public Brush CopyButtonBorderBrush
        {
            get => (Brush)GetValue(CopyButtonBorderBrushProperty);
            set => SetValue(CopyButtonBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderBrushProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrush), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// BorderBrush of the copy button when the mouse is over it.
        /// </summary>
        public Brush CopyButtonBorderBrushOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnMouseOverProperty);
            set => SetValue(CopyButtonBorderBrushOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderBrushOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnMouseOver), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// BorderBrush of the copy button when is pressed.
        /// </summary>
        public Brush CopyButtonBorderBrushOnPressed
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnPressedProperty);
            set => SetValue(CopyButtonBorderBrushOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderBrushOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderBrushOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnPressed), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// BorderBrush of the copy button when is disabled.
        /// </summary>
        public Brush CopyButtonBorderBrushOnDisabled
        {
            get => (Brush)GetValue(CopyButtonBorderBrushOnDisabledProperty);
            set => SetValue(CopyButtonBorderBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderBrushOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Foreground of the copy button.
        /// </summary>
        public Brush CopyButtonForeground
        {
            get => (Brush)GetValue(CopyButtonForegroundProperty);
            set => SetValue(CopyButtonForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonForegroundProperty =
            DependencyProperty.Register(nameof(CopyButtonForeground), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Foreground of the copy button when the mouse is over it.
        /// </summary>
        public Brush CopyButtonForegroundOnMouseOver
        {
            get => (Brush)GetValue(CopyButtonForegroundOnMouseOverProperty);
            set => SetValue(CopyButtonForegroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonForegroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnMouseOver), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Foreground of the copy button when is pressed.
        /// </summary>
        public Brush CopyButtonForegroundOnPressed
        {
            get => (Brush)GetValue(CopyButtonForegroundOnPressedProperty);
            set => SetValue(CopyButtonForegroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonForegroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnPressed), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// Foreground of the copy button when is disabled.
        /// </summary>
        public Brush CopyButtonForegroundOnDisabled
        {
            get => (Brush)GetValue(CopyButtonForegroundOnDisabledProperty);
            set => SetValue(CopyButtonForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(CopyButtonForegroundOnDisabled), typeof(Brush), typeof(FullPasswordBox));

        /// <summary>
        /// CornerRadius of the copy button.
        /// </summary>
        public CornerRadius CopyButtonCornerRadius
        {
            get => (CornerRadius)GetValue(CopyButtonCornerRadiusProperty);
            set => SetValue(CopyButtonCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonCornerRadiusProperty =
            DependencyProperty.Register(nameof(CopyButtonCornerRadius), typeof(CornerRadius), typeof(FullPasswordBox));

        /// <summary>
        /// Border thickness of the copy button.
        /// </summary>
        public Thickness CopyButtonBorderThickness
        {
            get => (Thickness)GetValue(CopyButtonBorderThicknessProperty);
            set => SetValue(CopyButtonBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonBorderThicknessProperty =
            DependencyProperty.Register(nameof(CopyButtonBorderThickness), typeof(Thickness), typeof(FullPasswordBox));

        /// <summary>
        /// Duration of the copy button animation when it changes state.
        /// </summary>
        public TimeSpan CopyButtonAnimationTime
        {
            get => (TimeSpan)GetValue(CopyButtonAnimationTimeProperty);
            set => SetValue(CopyButtonAnimationTimeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CopyButtonAnimationTime"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyButtonAnimationTimeProperty =
            DependencyProperty.Register(nameof(CopyButtonAnimationTime), typeof(TimeSpan), typeof(FullPasswordBox));

        #endregion

        #region Icon

        /// <summary>
        /// Specifies if to display or not the icon.
        /// </summary>
        public bool ShowIcon
        {
            get => (bool)GetValue(ShowIconProperty);
            set => SetValue(ShowIconProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShowIcon"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register(nameof(ShowIcon), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Max size of the icon.
        /// </summary>
        public double MaxIconSize
        {
            get => (double)GetValue(MaxIconSizeProperty);
            set => SetValue(MaxIconSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="MaxIconSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaxIconSizeProperty =
            DependencyProperty.Register(nameof(MaxIconSize), typeof(double), typeof(FullPasswordBox));

        /// <summary>
        /// Icon that is displayed to the left of the text box.
        /// </summary>
        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Icon"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(FullPasswordBox));

        #endregion

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FullPasswordBox));

        /// <summary>
        /// Masking character for the password.
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
            DependencyProperty.Register(nameof(PasswordChar), typeof(char), typeof(FullPasswordBox));

        /// <summary>
        /// Max length of the password.
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
            DependencyProperty.Register(nameof(MaxLength), typeof(int), typeof(FullPasswordBox));

        /// <summary>
        /// Indicates if the passwordbox displays selected text when does not have focus.
        /// </summary>
        public bool IsInactiveSelectionHighlightEnabled
        {
            get => (bool)GetValue(IsInactiveSelectionHighlightEnabledProperty);
            set => SetValue(IsInactiveSelectionHighlightEnabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IsInactiveSelectionHighlightEnabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsInactiveSelectionHighlightEnabledProperty =
            DependencyProperty.Register(nameof(IsInactiveSelectionHighlightEnabled), typeof(bool), typeof(FullPasswordBox));

        /// <summary>
        /// Value of the password as <see cref="SecureString"/>.
        /// </summary>
        public SecureString SecurePassword => GetSecurePassword();

        /// <summary>
        /// Value of the password.
        /// </summary>
        public string Password
        {
            get => GetPassword();
            set => SetPassword(value);
        }

        /// <summary>
        /// Length of the password.
        /// </summary>
        public int PasswordLength => Password.Length;

        /// <summary>
        /// Indicates if the passwordbox has focus and selected text.
        /// </summary>
        public bool IsSelectionActive => passwordBox != null && passwordBox.IsSelectionActive;

        /// <summary>
        /// Gets a value that determines if the passwordbox has the focus.
        /// </summary>
        public new bool IsFocused => passwordBox != null && passwordBox.IsFocused;

        /// <summary>
        /// Raised when the password is changed.
        /// </summary>
        public event RoutedEventHandler PasswordChanged;

        /// <summary>
        /// Raised when the background is changed.
        /// </summary>
        public event EventHandler<BackgroundChangedEventArgs> BackgroundChanged;


        /// <summary>
        /// Creates a new <see cref="FullPasswordBox"/>.
        /// </summary>
        static FullPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullPasswordBox), new FrameworkPropertyMetadata(typeof(FullPasswordBox)));
        }

        /// <summary>
        /// Clears the value of the <see cref="Password"/> property.
        /// </summary>
        public void Clear() => passwordBox?.Clear();

        /// <summary>
        /// Copy the value of the <see cref="Password"/> property on the Clipboard.
        /// </summary>
        public void CopyAll() => Clipboard.SetText(Password);

        /// <summary>
        /// Replaces the current selection with the contents of the Clipboard.
        /// </summary>
        public void Paste() => passwordBox?.Paste();

        /// <summary>
        /// Select the entire content.
        /// </summary>
        public void SelectAll() => passwordBox?.SelectAll();

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            passwordBox = (PasswordBox)Template.FindName("PART_PasswordBox", this);
            peek = (TextBlock)Template.FindName("PART_Peek", this);
            Grid peekButton = (Grid)Template.FindName("PART_PeekButton", this);
            peekButton.MouseLeftButtonDown += PeekButton_MouseLeftButtonDown;
            peekButton.MouseLeftButtonUp += PeekButton_MouseLeftButtonUp;
            peekButton.MouseLeave += PeekButton_MouseLeave;
            ((Button)Template.FindName("PART_CopyButton", this)).Click += (s, e) => CopyAll();
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            passwordBox.GotFocus += PasswordBox_GotFocus;
            passwordBox.LostFocus += PasswordBox_LostFocus;
            UpdateHintState();
            IsEnabledChanged += (s, e) => OnEnabledChanged();
            SetValue(BackgroundBackProperty, Background);
            SetValue(BorderBrushBackProperty, BorderBrush);
            ReloadBackground();
            OnInitialized();
        }

        /// <summary>
        /// Executed when the control is initialized after the <see cref="OnApplyTemplate"/> method.
        /// </summary>
        private void OnInitialized()
        {
            if (_tempPassword != null)
            {
                SetPassword(_tempPassword);
                _tempPassword = null;
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
            else _tempPassword = password;
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <returns>Password.</returns>
        private string GetPassword() => passwordBox != null ? passwordBox.Password : "";

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="e">Data of the <see cref="BackgroundChanged"/> event.</param>
        private void OnActualBackgroundChanged(BackgroundChangedEventArgs e)
        {
            AdaptForeColors(e.ActualBackground);
            BackgroundChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        private void OnEnabledChanged()
        {
            ReloadBackground();
        }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            PasswordChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Called when the <see cref="PasswordBox"/> got the focus.
        /// </summary>
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            _ = VisualStateManager.GoToState(this, "Focused", true);
            ReloadBackground();
        }

        /// <summary>
        /// Called when the <see cref="PasswordBox"/> lose the focus.
        /// </summary>
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateHintState();
            _ = VisualStateManager.GoToState(this, IsMouseOver ? "MouseOver" : "Normal", true);
            ReloadBackground();
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsFocused)
            {
                _ = VisualStateManager.GoToState(this, "MouseOver", true);
                ReloadBackground();
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!IsFocused)
            {
                _ = VisualStateManager.GoToState(this, "Normal", true);
                ReloadBackground();
            }
        }

        /// <summary>
        /// Called when the peek button is clicked down.
        /// </summary>
        private void PeekButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            peek.Text = Password;
            _ = VisualStateManager.GoToState(this, "Peeked", true);
        }

        /// <summary>
        /// Called when the peek button is clicked up.
        /// </summary>
        private void PeekButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            peek.Text = "";
            _ = VisualStateManager.GoToState(this, "Unpeeked", true);
        }

        /// <summary>
        /// Called when the mouse leave the peek button.
        /// </summary>
        private void PeekButton_MouseLeave(object sender, MouseEventArgs e)
        {
            peek.Text = "";
            _ = VisualStateManager.GoToState(this, "Unpeeked", true);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            passwordBox?.Focus();
        }

        /// <summary>
        /// Update the visualstate to "Hinted" or "Unhinted" if is necessary to display or hide the hint.
        /// </summary>
        private void UpdateHintState()
        {
            _ = VisualStateManager.GoToState(this, PasswordLength == 0 && !IsFocused && ShowHint ? "Hinted" : "Unhinted", true);
        }

        /// <summary>
        /// Adapt some colors to the actual background of the control.
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

        /// <summary>
        /// Apply the correct background to the control, based on its state.
        /// </summary>
        private void ReloadBackground()
        {
            if (!IsEnabled) //Disabled state
            {
                SetValue(BackgroundBackProperty, BackgroundOnDisabled);
                SetValue(BorderBrushBackProperty, BorderBrushOnDisabled);
            }
            else if (IsFocused) //Selected state
            {
                Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnSelected, AnimationTime);
                Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnSelected, AnimationTime);
            }
            else if (IsMouseOver) //Selected state
            {
                Utility.AnimateBrush(this, BackgroundBackProperty, BackgroundOnSelected, AnimationTime);
                Utility.AnimateBrush(this, BorderBrushBackProperty, BorderBrushOnSelected, AnimationTime);
            }
            else //Normal state
            {
                SetValue(BackgroundBackProperty, Background);
                SetValue(BorderBrushBackProperty, BorderBrush);
            }
        }
    }
}
