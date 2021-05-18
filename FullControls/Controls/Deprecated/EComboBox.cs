using FullControls.Core;
using FullControls.Extra.Extensions;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    [Obsolete("EComboBox has been renamed to ComboBoxPlus. This is legacy and will no longer maintained.", false)]
    [DesignTimeVisible(false)]
    [TemplatePart(Name = PartToggleButton, Type = typeof(EToggleButton))]
    public class EComboBox : ComboBox
    {
        /// <summary>
        /// ToggleButton template part.
        /// </summary>
        protected const string PartToggleButton = "PART_ToggleButton";

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(EComboBox),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => ((EComboBox)d).OnActualBackgroundChanged((Brush)e.NewValue))));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColor), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColorOnMouseOver), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColorOnMouseOverOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColorOnChecked), typeof(Brush), typeof(EComboBox));

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
            DependencyProperty.Register(nameof(ForeColorOnDisabled), typeof(Brush), typeof(EComboBox));

        /// <summary>
        /// Gets the actual forecolor brush of the control.
        /// </summary>
        public Brush ActualForeColor => (Brush)GetValue(ActualForeColorProperty);

        #region ActualForeColorProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForeColorPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeColor), typeof(Brush), typeof(EComboBox),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForeColorProperty = ActualForeColorPropertyKey.DependencyProperty;

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(EComboBox));

        #region Arrow

        /// <summary>
        /// Gets or sets the arrow displayed on the button part.
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
        /// Gets or sets the size of the arrow.
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
        /// Gets or sets the font of the arrow (if used a character).
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

        #region ToggleButton

        /// <summary>
        /// Gets or sets the padding of the control toggle button.
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
        /// Gets or sets the vertical alignment of the control toggle button content.
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
        /// Gets or sets the horizontal alignment of the control toggle button content.
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

        #endregion

        #region Popup

        /// <summary>
        /// Gets or sets the border thickness of the popup.
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
        /// Gets or sets the border brush of the popup.
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
        /// Gets or sets the background brush of the popup.
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
        /// Gets or sets the padding of the popup.
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
        /// Gets or sets the animation type of the popup.
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
        /// Gets or sets a value indicating if the shadow of the popup is enabled.
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

        /// <summary>
        /// Gets or sets the style of the scroll viewer used if there are too many items.
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

        #endregion

        #region TextArea

        /// <summary>
        /// Gets or sets the text alignment of the text area.
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
        /// Gets or sets a value indicating if adapt automatically the foreground to the actual background of the control.
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
            DependencyProperty.Register(nameof(AdaptForegroundAutomatically), typeof(bool), typeof(EComboBox),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if adapt automatically the caret brush to the actual background of the control.
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
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(EComboBox),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets the brush of the caret of the textbox.
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
        /// Gets or sets the brush of the text area highlighted text.
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
        /// Gets or sets the brush of the text area selected text.
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
        /// Gets or sets the opacity of the text area highlighted text.
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

        /// <summary>
        /// Gets or sets the padding of the text area.
        /// </summary>
        public Thickness TextPadding
        {
            get => (Thickness)GetValue(TextPaddingProperty);
            set => SetValue(TextPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TextPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextPaddingProperty =
            DependencyProperty.Register(nameof(TextPadding), typeof(Thickness), typeof(EComboBox));

        /// <summary>
        /// Gets or sets the context menu of the text area.
        /// </summary>
        public ContextMenu TextContextMenu
        {
            get => (ContextMenu)GetValue(TextContextMenuProperty);
            set => SetValue(TextContextMenuProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TextContextMenu"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextContextMenuProperty =
            DependencyProperty.Register(nameof(TextContextMenu), typeof(ContextMenu), typeof(EComboBox),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the background brush of the text area.
        /// </summary>
        /// <remarks>
        /// After setting this value, may be useful disable <see cref="AdaptCaretBrushAutomatically"/> and <see cref="AdaptForegroundAutomatically"/>,
        /// and set <see cref="CaretBrush"/> and <see cref="Control.Foreground"/> properties.
        /// </remarks>
        public Brush TextBackground
        {
            get => (Brush)GetValue(TextBackgroundProperty);
            set => SetValue(TextBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TextBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextBackgroundProperty =
            DependencyProperty.Register(nameof(TextBackground), typeof(Brush), typeof(EComboBox));

        #endregion

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(EComboBox));


        static EComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EComboBox),
                new FrameworkPropertyMetadata(typeof(EComboBox)));

            IsEnabledProperty.OverrideMetadata(typeof(EComboBox),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((EComboBox)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EComboBox"/>.
        /// </summary>
        public EComboBox() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            EToggleButton toggleButton = (EToggleButton)Template.FindName(PartToggleButton, this);
            if (toggleButton != null)
            {
                DependencyPropertyDescriptor.FromProperty(EToggleButton.ActualBackgroundProperty, typeof(EToggleButton))
                    ?.AddValueChanged(toggleButton, (s, e) => SetValue(ActualBackgroundPropertyKey, toggleButton.ActualBackground));
                DependencyPropertyDescriptor.FromProperty(EToggleButton.ActualForegroundProperty, typeof(EToggleButton))
                    ?.AddValueChanged(toggleButton, (s, e) => SetValue(ActualForeColorPropertyKey, toggleButton.ActualForeground));
                SetValue(ActualBackgroundPropertyKey, IsEnabled ? IsDropDownOpen ? BackgroundOnChecked : Background : BackgroundOnDisabled);
                SetValue(ActualForeColorPropertyKey, IsEnabled ? IsDropDownOpen ? ForeColorOnChecked : ForeColor : ForeColorOnDisabled);
            }
            else
            {
                SetValue(ActualBackgroundPropertyKey, IsEnabled ? Background : BackgroundOnDisabled);
                SetValue(ActualForeColorPropertyKey, IsEnabled ? ForeColor : ForeColorOnDisabled);
            }
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => AdaptForeColors(ActualBackground);

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        private void OnActualBackgroundChanged(Brush actualBackground) => AdaptForeColors(actualBackground);

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) { }

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
                if (AdaptCaretBrushAutomatically) CaretBrush = inverseBrush;
            }
        }
    }
}
