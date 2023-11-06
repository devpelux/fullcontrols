using FullControls.Core;
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
    [TemplatePart(Name = PartToggleButton, Type = typeof(ToggleButtonPlus))]
    public class ComboBoxPlus : ComboBox
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
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnMouseOverOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnPressed), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnPressedOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BackgroundOnDisabledOnChecked), typeof(Brush), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => ((ComboBoxPlus)d).OnActualBackgroundChanged((Brush)e.NewValue))));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOver), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnMouseOverOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnPressed), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnPressedOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(BorderBrushOnDisabledOnChecked), typeof(Brush), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnPressed), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnPressedOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnChecked), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabledOnChecked), typeof(Brush), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(Arrow), typeof(object), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ArrowSize), typeof(double), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ArrowFont), typeof(FontFamily), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(TogglePadding), typeof(Thickness), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ToggleVerticalContentAlignment), typeof(VerticalAlignment), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ToggleHorizontalContentAlignment), typeof(HorizontalAlignment), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(PopupBorderThickness), typeof(Thickness), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(PopupBorderBrush), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(PopupBackground), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(PopupPadding), typeof(Thickness), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets or sets the corner radius of the popup.
        /// </summary>
        public CornerRadius PopupCornerRadius
        {
            get => (CornerRadius)GetValue(PopupCornerRadiusProperty);
            set => SetValue(PopupCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupCornerRadiusProperty =
            DependencyProperty.Register(nameof(PopupCornerRadius), typeof(CornerRadius), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets or sets the placement of the popup.
        /// </summary>
        public PlacementMode PopupPlacement
        {
            get => (PlacementMode)GetValue(PopupPlacementProperty);
            set => SetValue(PopupPlacementProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupPlacement"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupPlacementProperty =
            DependencyProperty.Register(nameof(PopupPlacement), typeof(PlacementMode), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets or sets the vertical offset of the popup.
        /// </summary>
        public double PopupVerticalOffset
        {
            get => (double)GetValue(PopupVerticalOffsetProperty);
            set => SetValue(PopupVerticalOffsetProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupVerticalOffset"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupVerticalOffsetProperty =
            DependencyProperty.Register(nameof(PopupVerticalOffset), typeof(double), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateShadowOffsets(d))));

        /// <summary>
        /// Gets the actual vertical offset of the popup.
        /// </summary>
        public double ActualPopupVerticalOffset => (double)GetValue(ActualPopupVerticalOffsetProperty);

        #region ActualPopupVerticalOffsetProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualPopupVerticalOffset"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualPopupVerticalOffsetPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualPopupVerticalOffset), typeof(double), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(default(double)));

        /// <summary>
        /// Identifies the <see cref="ActualPopupVerticalOffset"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualPopupVerticalOffsetProperty = ActualPopupVerticalOffsetPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets or sets the horizontal offset of the popup.
        /// </summary>
        public double PopupHorizontalOffset
        {
            get => (double)GetValue(PopupHorizontalOffsetProperty);
            set => SetValue(PopupHorizontalOffsetProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupHorizontalOffset"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupHorizontalOffsetProperty =
            DependencyProperty.Register(nameof(PopupHorizontalOffset), typeof(double), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateShadowOffsets(d))));

        /// <summary>
        /// Gets the actual horizontal offset of the popup.
        /// </summary>
        public double ActualPopupHorizontalOffset => (double)GetValue(ActualPopupHorizontalOffsetProperty);

        #region ActualPopupHorizontalOffsetProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualPopupHorizontalOffset"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualPopupHorizontalOffsetPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualPopupHorizontalOffset), typeof(double), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(default(double)));

        /// <summary>
        /// Identifies the <see cref="ActualPopupHorizontalOffset"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualPopupHorizontalOffsetProperty = ActualPopupHorizontalOffsetPropertyKey.DependencyProperty;

        #endregion

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
            DependencyProperty.Register(nameof(PopupAnimation), typeof(PopupAnimation), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(ScrollViewerStyle), typeof(Style), typeof(ComboBoxPlus));

        #endregion

        #region Shadow

        /// <summary>
        /// Gets or sets a value that indicates whether the popup appears with a dropped shadow.
        /// </summary>
        public bool HasDropShadow
        {
            get => (bool)GetValue(HasDropShadowProperty);
            set => SetValue(HasDropShadowProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HasDropShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HasDropShadowProperty =
            DependencyProperty.Register(nameof(HasDropShadow), typeof(bool), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets or sets the color of the menu popup shadow.
        /// </summary>
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register(nameof(ShadowColor), typeof(Color), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets or sets the opacity of the menu popup shadow.
        /// </summary>
        public double ShadowOpacity
        {
            get => (double)GetValue(ShadowOpacityProperty);
            set => SetValue(ShadowOpacityProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowOpacityProperty =
            DependencyProperty.Register(nameof(ShadowOpacity), typeof(double), typeof(ComboBoxPlus));

        /// <summary>
        /// Gets or sets the direction of the shadow.
        /// </summary>
        public double ShadowDirection
        {
            get => (double)GetValue(ShadowDirectionProperty);
            set => SetValue(ShadowDirectionProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowDirection"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowDirectionProperty =
            DependencyProperty.Register(nameof(ShadowDirection), typeof(double), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(315d, new PropertyChangedCallback((d, e) => CalculateShadowOffsets(d))));

        /// <summary>
        /// Gets or sets the radius of the menu popup shadow.
        /// </summary>
        public double ShadowRadius
        {
            get => (double)GetValue(ShadowRadiusProperty);
            set => SetValue(ShadowRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowRadiusProperty =
            DependencyProperty.Register(nameof(ShadowRadius), typeof(double), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateShadowOffsets(d))));

        /// <summary>
        /// Gets or sets the depth of the menu popup shadow.
        /// </summary>
        public double ShadowDepth
        {
            get => (double)GetValue(ShadowDepthProperty);
            set => SetValue(ShadowDepthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowDepth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowDepthProperty =
            DependencyProperty.Register(nameof(ShadowDepth), typeof(double), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateShadowOffsets(d))));

        #region ShadowSize

        /// <summary>
        /// Gets the size of the drop shadow.
        /// <para>This property depends on <see cref="ShadowRadius"/> and <see cref="ShadowDepth"/>.</para>
        /// </summary>
        public Thickness ShadowSize => (Thickness)GetValue(ShadowSizeProperty);

        #region ShadowSizeProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ShadowSize"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ShadowSizePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ShadowSize), typeof(Thickness), typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(default(Thickness)));

        /// <summary>
        /// Identifies the <see cref="ShadowSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowSizeProperty = ShadowSizePropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Calculates the drop shadow offsets.
        /// </summary>
        private static void CalculateShadowOffsets(DependencyObject d)
        {
            double popupHorizontalOffset = (double)d.GetValue(PopupHorizontalOffsetProperty);
            double popupVerticalOffset = (double)d.GetValue(PopupVerticalOffsetProperty);

            double direction = (double)d.GetValue(ShadowDirectionProperty);
            double depth = (double)d.GetValue(ShadowDepthProperty);
            double radius = (double)d.GetValue(ShadowRadiusProperty) / 2;

            double horizontalOffset = Math.Cos(direction / 180 * Math.PI) * depth;
            double verticalOffset = Math.Sin(direction / 180 * Math.PI) * depth;

            double top = Math.Ceiling(Math.Max(radius + verticalOffset, 0));
            double bottom = Math.Ceiling(Math.Max(radius - verticalOffset, 0));
            double right = Math.Ceiling(Math.Max(radius + horizontalOffset, 0));
            double left = Math.Ceiling(Math.Max(radius - horizontalOffset, 0));

            d.SetValue(ShadowSizePropertyKey, new Thickness(left, top, right, bottom));

            d.SetValue(ActualPopupHorizontalOffsetPropertyKey, popupHorizontalOffset - left);
            d.SetValue(ActualPopupVerticalOffsetPropertyKey, popupVerticalOffset - top);
        }

        #endregion

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
            DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(AdaptCaretBrushAutomatically), typeof(bool), typeof(ComboBoxPlus),
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
            DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(TextPadding), typeof(Thickness), typeof(ComboBoxPlus));

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
            DependencyProperty.Register(nameof(TextContextMenu), typeof(ContextMenu), typeof(ComboBoxPlus),
                new PropertyMetadata(null));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(ComboBoxPlus));


        static ComboBoxPlus()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(typeof(ComboBoxPlus)));

            IsEnabledProperty.OverrideMetadata(typeof(ComboBoxPlus),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((ComboBoxPlus)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ComboBoxPlus"/>.
        /// </summary>
        public ComboBoxPlus() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Template.FindName(PartToggleButton, this) is ToggleButtonPlus toggleButton)
            {
                DependencyPropertyDescriptor.FromProperty(ToggleButtonPlus.ActualBackgroundProperty, typeof(ToggleButtonPlus))
                    ?.AddValueChanged(toggleButton, (s, e) => SetValue(ActualBackgroundPropertyKey, toggleButton.ActualBackground));
                DependencyPropertyDescriptor.FromProperty(ToggleButtonPlus.ActualBorderBrushProperty, typeof(ToggleButtonPlus))
                    ?.AddValueChanged(toggleButton, (s, e) => SetValue(ActualBorderBrushPropertyKey, toggleButton.ActualBorderBrush));
                DependencyPropertyDescriptor.FromProperty(ToggleButtonPlus.ActualForegroundProperty, typeof(ToggleButtonPlus))
                    ?.AddValueChanged(toggleButton, (s, e) => SetValue(ActualForegroundPropertyKey, toggleButton.ActualForeground));
            }

            SetValue(ActualBackgroundPropertyKey, Background);
            SetValue(ActualBorderBrushPropertyKey, BorderBrush);
            SetValue(ActualForegroundPropertyKey, Foreground);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnActualBackgroundChanged(ActualBackground);

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        private void OnActualBackgroundChanged(Brush actualBackground)
        {
            if (actualBackground is SolidColorBrush brush)
            {
                Color color = brush.Color;
                Color inverseColor = Color.FromRgb((byte)(255 - color.R), (byte)(255 - color.G), (byte)(255 - color.B));
                SolidColorBrush inverseBrush = new(inverseColor);
                if (AdaptCaretBrushAutomatically) CaretBrush = inverseBrush;
            }
        }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) { }
    }
}
