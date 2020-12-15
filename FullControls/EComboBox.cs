using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FullControls.Extra;

namespace FullControls
{
    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    [TemplatePart(Name = PartToggleButton, Type = typeof(EToggleButton))]
    public class EComboBox : ComboBox
    {
        /// <summary>
        /// ToggleButton template part.
        /// </summary>
        protected const string PartToggleButton = "PART_ToggleButton";

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// Actual Background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// BorderBrush when the mouse is over the control.
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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColor), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColorOnMouseOver), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColorOnMouseOverOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColorOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColorOnDisabled), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// Actual ForeColor brush of the control.
        /// </summary>
        public Brush ActualForeColor => (Brush)GetValue(ActualForeColorProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForeColorProperty =
            DependencyProperty.Register(nameof(ActualForeColor), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(EComboBox));

        #region Arrow

        /// <summary>
        /// Arrow displayed on the button part.
        /// </summary>
        public object Arrow
        {
            get => GetValue(ArrowProperty);
            set => SetValue(ArrowProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Arrow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowProperty =
            DependencyProperty.Register(nameof(Arrow), typeof(object), typeof(EComboBox));

        /// <summary>
        /// Size of the arrow.
        /// </summary>
        public double ArrowSize
        {
            get => (double)GetValue(ArrowSizeProperty);
            set => SetValue(ArrowSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowSizeProperty =
            DependencyProperty.Register(nameof(ArrowSize), typeof(double), typeof(EComboBox));

        /// <summary>
        /// Font of the arrow (if used a character).
        /// </summary>
        public FontFamily ArrowFont
        {
            get => (FontFamily)GetValue(ArrowFontProperty);
            set => SetValue(ArrowFontProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowFont"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowFontProperty =
            DependencyProperty.Register(nameof(ArrowFont), typeof(FontFamily), typeof(EComboBox));

        #endregion

        /// <summary>
        /// Padding of the control toggle button.
        /// </summary>
        public Thickness TogglePadding
        {
            get => (Thickness)GetValue(TogglePaddingProperty);
            set => SetValue(TogglePaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TogglePadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TogglePaddingProperty =
            DependencyProperty.Register(nameof(TogglePadding), typeof(Thickness), typeof(EComboBox));

        /// <summary>
        /// Vertical alignment of the control toggle button content.
        /// </summary>
        public VerticalAlignment ToggleVerticalContentAlignment
        {
            get => (VerticalAlignment)GetValue(ToggleVerticalContentAlignmentProperty);
            set => SetValue(ToggleVerticalContentAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ToggleVerticalContentAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToggleVerticalContentAlignmentProperty =
            DependencyProperty.Register(nameof(ToggleVerticalContentAlignment), typeof(VerticalAlignment), typeof(EComboBox));

        /// <summary>
        /// Horizontal alignment of the control toggle button content.
        /// </summary>
        public HorizontalAlignment ToggleHorizontalContentAlignment
        {
            get => (HorizontalAlignment)GetValue(ToggleHorizontalContentAlignmentProperty);
            set => SetValue(ToggleHorizontalContentAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ToggleHorizontalContentAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToggleHorizontalContentAlignmentProperty =
            DependencyProperty.Register(nameof(ToggleHorizontalContentAlignment), typeof(HorizontalAlignment), typeof(EComboBox));

        /// <summary>
        /// Text alignment of the control text element.
        /// </summary>
        public TextAlignment TextAlignment
        {
            get => (TextAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TextAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(EComboBox));
        
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
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(EComboBox));

        /// <summary>
        /// Brush of the caret of the textbox.
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
            DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// Brush of the highlighted part of the textbox text.
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
            DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// Opacity of the highlighted part of the textbox text.
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
            DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(EComboBox));

        #region Popup

        /// <summary>
        /// Border thickness of the popup.
        /// </summary>
        public Thickness PopupBorderThickness
        {
            get => (Thickness)GetValue(PopupBorderThicknessProperty);
            set => SetValue(PopupBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupBorderThicknessProperty =
            DependencyProperty.Register(nameof(PopupBorderThickness), typeof(Thickness), typeof(EComboBox));

        /// <summary>
        /// BorderBrush of the popup.
        /// </summary>
        public Brush PopupBorderBrush
        {
            get => (Brush)GetValue(PopupBorderBrushProperty);
            set => SetValue(PopupBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupBorderBrushProperty =
            DependencyProperty.Register(nameof(PopupBorderBrush), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// Background of the popup.
        /// </summary>
        public Brush PopupBackground
        {
            get => (Brush)GetValue(PopupBackgroundProperty);
            set => SetValue(PopupBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.Register(nameof(PopupBackground), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// Padding of the popup.
        /// </summary>
        public Thickness PopupPadding
        {
            get => (Thickness)GetValue(PopupPaddingProperty);
            set => SetValue(PopupPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupPaddingProperty =
            DependencyProperty.Register(nameof(PopupPadding), typeof(Thickness), typeof(EComboBox));

        /// <summary>
        /// Animation type of the popup.
        /// </summary>
        public PopupAnimation PopupAnimation
        {
            get => (PopupAnimation)GetValue(PopupAnimationProperty);
            set => SetValue(PopupAnimationProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupAnimation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupAnimationProperty =
            DependencyProperty.Register(nameof(PopupAnimation), typeof(PopupAnimation), typeof(EComboBox));

        /// <summary>
        /// Enables the shadow of the popup.
        /// </summary>
        public bool EnablePopupShadow
        {
            get => (bool)GetValue(EnablePopupShadowProperty);
            set => SetValue(EnablePopupShadowProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnablePopupShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnablePopupShadowProperty =
            DependencyProperty.Register(nameof(EnablePopupShadow), typeof(bool), typeof(EComboBox));

        #endregion

        /// <summary>
        /// Style of the scroll viewer used if there are too many items.
        /// </summary>
        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollViewerStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollViewerStyleProperty =
            DependencyProperty.Register(nameof(ScrollViewerStyle), typeof(Style), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(EComboBox));


        /// <summary>
        /// Creates a new <see cref="EComboBox"/>.
        /// </summary>
        static EComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EComboBox), new FrameworkPropertyMetadata(typeof(EComboBox)));
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            EToggleButton toggleButton = (EToggleButton)Template.FindName(PartToggleButton, this);
            if (toggleButton != null)
            {
                DependencyPropertyDescriptor.FromProperty(EToggleButton.ActualForegroundProperty, typeof(EToggleButton))
                    ?.AddValueChanged(toggleButton, (s, e) => SetValue(ActualForeColorProperty, toggleButton.ActualForeground));
                DependencyPropertyDescriptor.FromProperty(EToggleButton.ActualBackgroundProperty, typeof(EToggleButton))
                    ?.AddValueChanged(toggleButton, (s, e) => SetValue(ActualBackgroundProperty, toggleButton.ActualBackground));
                SetValue(ActualForeColorProperty, IsEnabled ? IsDropDownOpen ? ForeColorOnChecked : ForeColor : ForeColorOnDisabled);
                SetValue(ActualBackgroundProperty, IsEnabled ? IsDropDownOpen ? BackgroundOnChecked : Background : BackgroundOnDisabled);
            }
            else
            {
                SetValue(ActualForeColorProperty, IsEnabled ? ForeColor : ForeColorOnDisabled);
                SetValue(ActualBackgroundProperty, IsEnabled ? Background : BackgroundOnDisabled);
            }
        }

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        protected virtual void OnActualBackgroundChanged(Brush actualBackground)
        {
            SetValue(ActualBackgroundProperty, actualBackground);
            AdaptForeColors(actualBackground);
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
                if (AdaptCaretBrushAutomatically) CaretBrush = inverseBrush;
            }
        }
    }
}
