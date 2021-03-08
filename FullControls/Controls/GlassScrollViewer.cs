using FullControls.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a scrollable area that can contain other visible elements.
    /// </summary>
    public class GlassScrollViewer : ScrollViewer
    {
        #region Horizontal ScrollBar properties

        /// <summary>
        /// Gets or sets the thickness of the horizontal scrollbar.
        /// </summary>
        public double HorizontalScrollBarThickness
        {
            get => (double)GetValue(HorizontalScrollBarThicknessProperty);
            set => SetValue(HorizontalScrollBarThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarThicknessProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarThickness), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the padding of the area that contains the horizontal scrollbar.
        /// </summary>
        public Thickness HorizontalScrollBarAreaPadding
        {
            get => (Thickness)GetValue(HorizontalScrollBarAreaPaddingProperty);
            set => SetValue(HorizontalScrollBarAreaPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarAreaPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarAreaPaddingProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarAreaPadding), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the padding of the horizontal scrollbar.
        /// </summary>
        public Thickness HorizontalScrollBarPadding
        {
            get => (Thickness)GetValue(HorizontalScrollBarPaddingProperty);
            set => SetValue(HorizontalScrollBarPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarPaddingProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarPadding), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the corner radius of the horizontal scrollbar.
        /// </summary>
        public CornerRadius HorizontalScrollBarCornerRadius
        {
            get => (CornerRadius)GetValue(HorizontalScrollBarCornerRadiusProperty);
            set => SetValue(HorizontalScrollBarCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarCornerRadiusProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarCornerRadius), typeof(CornerRadius), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border thickness of the horizontal scrollbar.
        /// </summary>
        public Thickness HorizontalScrollBarBorderThickness
        {
            get => (Thickness)GetValue(HorizontalScrollBarBorderThicknessProperty);
            set => SetValue(HorizontalScrollBarBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarBorderThicknessProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarBorderThickness), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the background brush of the horizontal scrollbar.
        /// </summary>
        public Brush HorizontalScrollBarBackground
        {
            get => (Brush)GetValue(HorizontalScrollBarBackgroundProperty);
            set => SetValue(HorizontalScrollBarBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarBackgroundProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarBackground), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border brush of the horizontal scrollbar.
        /// </summary>
        public Brush HorizontalScrollBarBorderBrush
        {
            get => (Brush)GetValue(HorizontalScrollBarBorderBrushProperty);
            set => SetValue(HorizontalScrollBarBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarBorderBrushProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarBorderBrush), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the foreground brush of the horizontal scrollbar.
        /// </summary>
        public Brush HorizontalScrollBarForeground
        {
            get => (Brush)GetValue(HorizontalScrollBarForegroundProperty);
            set => SetValue(HorizontalScrollBarForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarForegroundProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarForeground), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the foreground brush of the horizontal scrollbar when the control is disabled.
        /// </summary>
        public Brush HorizontalScrollBarForegroundOnDisabled
        {
            get => (Brush)GetValue(HorizontalScrollBarForegroundOnDisabledProperty);
            set => SetValue(HorizontalScrollBarForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarForegroundOnDisabled), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the padding of the horizontal scrollbar thumb.
        /// </summary>
        public Thickness HorizontalScrollBarThumbPadding
        {
            get => (Thickness)GetValue(HorizontalScrollBarThumbPaddingProperty);
            set => SetValue(HorizontalScrollBarThumbPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarThumbPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarThumbPaddingProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarThumbPadding), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the corner radius of the horizontal scrollbar thumb.
        /// </summary>
        public CornerRadius HorizontalScrollBarThumbCornerRadius
        {
            get => (CornerRadius)GetValue(HorizontalScrollBarThumbCornerRadiusProperty);
            set => SetValue(HorizontalScrollBarThumbCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarThumbCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarThumbCornerRadiusProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarThumbCornerRadius), typeof(CornerRadius), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border thickness of the horizontal scrollbar thumb.
        /// </summary>
        public Thickness HorizontalScrollBarThumbBorderThickness
        {
            get => (Thickness)GetValue(HorizontalScrollBarThumbBorderThicknessProperty);
            set => SetValue(HorizontalScrollBarThumbBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarThumbBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarThumbBorderThicknessProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarThumbBorderThickness), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border brush of the horizontal scrollbar thumb.
        /// </summary>
        public Brush HorizontalScrollBarThumbBorderBrush
        {
            get => (Brush)GetValue(HorizontalScrollBarThumbBorderBrushProperty);
            set => SetValue(HorizontalScrollBarThumbBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarThumbBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarThumbBorderBrushProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarThumbBorderBrush), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the opacity of the horizontal scrollbar when in normal state.
        /// </summary>
        public double HorizontalScrollBarOpacityNormal
        {
            get => (double)GetValue(HorizontalScrollBarOpacityNormalProperty);
            set => SetValue(HorizontalScrollBarOpacityNormalProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarOpacityNormal"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarOpacityNormalProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarOpacityNormal), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the opacity of the horizontal scrollbar when the mouse is over the control.
        /// </summary>
        public double HorizontalScrollBarOpacityOnMouseOver
        {
            get => (double)GetValue(HorizontalScrollBarOpacityOnMouseOverProperty);
            set => SetValue(HorizontalScrollBarOpacityOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarOpacityOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarOpacityOnMouseOverProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarOpacityOnMouseOver), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the opacity of the horizontal scrollbar when is pressed.
        /// </summary>
        public double HorizontalScrollBarOpacityOnMouseDown
        {
            get => (double)GetValue(HorizontalScrollBarOpacityOnMouseDownProperty);
            set => SetValue(HorizontalScrollBarOpacityOnMouseDownProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarOpacityOnMouseDown"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarOpacityOnMouseDownProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarOpacityOnMouseDown), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the size of the horizontal scrollbar buttons.
        /// </summary>
        public double HorizontalScrollBarButtonsSize
        {
            get => (double)GetValue(HorizontalScrollBarButtonsSizeProperty);
            set => SetValue(HorizontalScrollBarButtonsSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsSizeProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsSize), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the font of the horizontal scrollbar buttons.
        /// </summary>
        public FontFamily HorizontalScrollBarButtonsFont
        {
            get => (FontFamily)GetValue(HorizontalScrollBarButtonsFontProperty);
            set => SetValue(HorizontalScrollBarButtonsFontProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsFont"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsFontProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsFont), typeof(FontFamily), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the size of the font of the horizontal scrollbar buttons.
        /// </summary>
        public double HorizontalScrollBarButtonsFontSize
        {
            get => (double)GetValue(HorizontalScrollBarButtonsFontSizeProperty);
            set => SetValue(HorizontalScrollBarButtonsFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsFontSizeProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsFontSize), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the corner radius of the horizontal scrollbar buttons.
        /// </summary>
        public CornerRadius HorizontalScrollBarButtonsCornerRadius
        {
            get => (CornerRadius)GetValue(HorizontalScrollBarButtonsCornerRadiusProperty);
            set => SetValue(HorizontalScrollBarButtonsCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsCornerRadiusProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsCornerRadius), typeof(CornerRadius), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the background brush of the horizontal scrollbar buttons.
        /// </summary>
        public Brush HorizontalScrollBarButtonsBackground
        {
            get => (Brush)GetValue(HorizontalScrollBarButtonsBackgroundProperty);
            set => SetValue(HorizontalScrollBarButtonsBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsBackgroundProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsBackground), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border brush of the horizontal scrollbar buttons.
        /// </summary>
        public Brush HorizontalScrollBarButtonsBorderBrush
        {
            get => (Brush)GetValue(HorizontalScrollBarButtonsBorderBrushProperty);
            set => SetValue(HorizontalScrollBarButtonsBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsBorderBrushProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsBorderBrush), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border thickness of the horizontal scrollbar buttons.
        /// </summary>
        public Thickness HorizontalScrollBarButtonsBorderThickness
        {
            get => (Thickness)GetValue(HorizontalScrollBarButtonsBorderThicknessProperty);
            set => SetValue(HorizontalScrollBarButtonsBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsBorderThicknessProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsBorderThickness), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the foreground brush of the horizontal scrollbar buttons.
        /// </summary>
        public Brush HorizontalScrollBarButtonsForeground
        {
            get => (Brush)GetValue(HorizontalScrollBarButtonsForegroundProperty);
            set => SetValue(HorizontalScrollBarButtonsForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsForegroundProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsForeground), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the foreground brush of the horizontal scrollbar buttons when the control is disabled.
        /// </summary>
        public Brush HorizontalScrollBarButtonsForegroundOnDisabled
        {
            get => (Brush)GetValue(HorizontalScrollBarButtonsForegroundOnDisabledProperty);
            set => SetValue(HorizontalScrollBarButtonsForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarButtonsForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarButtonsForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarButtonsForegroundOnDisabled), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the content of the horizontal scrollbar left button.
        /// </summary>
        public object LeftButtonContent
        {
            get => GetValue(LeftButtonContentProperty);
            set => SetValue(LeftButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="LeftButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonContentProperty =
            DependencyProperty.Register(nameof(LeftButtonContent), typeof(object), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the content of the horizontal scrollbar right button.
        /// </summary>
        public object RightButtonContent
        {
            get => GetValue(RightButtonContentProperty);
            set => SetValue(RightButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="RightButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RightButtonContentProperty =
            DependencyProperty.Register(nameof(RightButtonContent), typeof(object), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the <see cref="ContextMenu"/> of the horizontal scrollbar.
        /// </summary>
        public ContextMenu HorizontalScrollBarContextMenu
        {
            get => (ContextMenu)GetValue(HorizontalScrollBarContextMenuProperty);
            set => SetValue(HorizontalScrollBarContextMenuProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalScrollBarContextMenu"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarContextMenuProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarContextMenu), typeof(ContextMenu), typeof(GlassScrollViewer));

        #endregion

        #region Vertical ScrollBar properties

        /// <summary>
        /// Gets or sets the thickness of the vertical scrollbar.
        /// </summary>
        public double VerticalScrollBarThickness
        {
            get => (double)GetValue(VerticalScrollBarThicknessProperty);
            set => SetValue(VerticalScrollBarThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarThicknessProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarThickness), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the padding of the area that contains the vertical scrollbar.
        /// </summary>
        public Thickness VerticalScrollBarAreaPadding
        {
            get => (Thickness)GetValue(VerticalScrollBarAreaPaddingProperty);
            set => SetValue(VerticalScrollBarAreaPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarAreaPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarAreaPaddingProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarAreaPadding), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the padding of the vertical scrollbar.
        /// </summary>
        public Thickness VerticalScrollBarPadding
        {
            get => (Thickness)GetValue(VerticalScrollBarPaddingProperty);
            set => SetValue(VerticalScrollBarPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarPaddingProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarPadding), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the corner radius of the vertical scrollbar.
        /// </summary>
        public CornerRadius VerticalScrollBarCornerRadius
        {
            get => (CornerRadius)GetValue(VerticalScrollBarCornerRadiusProperty);
            set => SetValue(VerticalScrollBarCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarCornerRadiusProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarCornerRadius), typeof(CornerRadius), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border thickness of the vertical scrollbar.
        /// </summary>
        public Thickness VerticalScrollBarBorderThickness
        {
            get => (Thickness)GetValue(VerticalScrollBarBorderThicknessProperty);
            set => SetValue(VerticalScrollBarBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarBorderThicknessProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarBorderThickness), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the background brush of the vertical scrollbar.
        /// </summary>
        public Brush VerticalScrollBarBackground
        {
            get => (Brush)GetValue(VerticalScrollBarBackgroundProperty);
            set => SetValue(VerticalScrollBarBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarBackgroundProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarBackground), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border brush of the vertical scrollbar.
        /// </summary>
        public Brush VerticalScrollBarBorderBrush
        {
            get => (Brush)GetValue(VerticalScrollBarBorderBrushProperty);
            set => SetValue(VerticalScrollBarBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarBorderBrushProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarBorderBrush), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the foreground brush of the vertical scrollbar.
        /// </summary>
        public Brush VerticalScrollBarForeground
        {
            get => (Brush)GetValue(VerticalScrollBarForegroundProperty);
            set => SetValue(VerticalScrollBarForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarForegroundProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarForeground), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the foreground brush of the vertical scrollbar when the control is disabled.
        /// </summary>
        public Brush VerticalScrollBarForegroundOnDisabled
        {
            get => (Brush)GetValue(VerticalScrollBarForegroundOnDisabledProperty);
            set => SetValue(VerticalScrollBarForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarForegroundOnDisabled), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the padding of the vertical scrollbar thumb.
        /// </summary>
        public Thickness VerticalScrollBarThumbPadding
        {
            get => (Thickness)GetValue(VerticalScrollBarThumbPaddingProperty);
            set => SetValue(VerticalScrollBarThumbPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarThumbPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarThumbPaddingProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarThumbPadding), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the corner radius of the vertical scrollbar thumb.
        /// </summary>
        public CornerRadius VerticalScrollBarThumbCornerRadius
        {
            get => (CornerRadius)GetValue(VerticalScrollBarThumbCornerRadiusProperty);
            set => SetValue(VerticalScrollBarThumbCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarThumbCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarThumbCornerRadiusProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarThumbCornerRadius), typeof(CornerRadius), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border thickness of the vertical scrollbar thumb.
        /// </summary>
        public Thickness VerticalScrollBarThumbBorderThickness
        {
            get => (Thickness)GetValue(VerticalScrollBarThumbBorderThicknessProperty);
            set => SetValue(VerticalScrollBarThumbBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarThumbBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarThumbBorderThicknessProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarThumbBorderThickness), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border brush of the vertical scrollbar thumb.
        /// </summary>
        public Brush VerticalScrollBarThumbBorderBrush
        {
            get => (Brush)GetValue(VerticalScrollBarThumbBorderBrushProperty);
            set => SetValue(VerticalScrollBarThumbBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarThumbBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarThumbBorderBrushProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarThumbBorderBrush), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the opacity of the vertical scrollbar when in normal state.
        /// </summary>
        public double VerticalScrollBarOpacityNormal
        {
            get => (double)GetValue(VerticalScrollBarOpacityNormalProperty);
            set => SetValue(VerticalScrollBarOpacityNormalProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarOpacityNormal"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarOpacityNormalProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarOpacityNormal), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the opacity of the vertical scrollbar when the mouse is over the control.
        /// </summary>
        public double VerticalScrollBarOpacityOnMouseOver
        {
            get => (double)GetValue(VerticalScrollBarOpacityOnMouseOverProperty);
            set => SetValue(VerticalScrollBarOpacityOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarOpacityOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarOpacityOnMouseOverProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarOpacityOnMouseOver), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the opacity of the vertical scrollbar when is pressed.
        /// </summary>
        public double VerticalScrollBarOpacityOnMouseDown
        {
            get => (double)GetValue(VerticalScrollBarOpacityOnMouseDownProperty);
            set => SetValue(VerticalScrollBarOpacityOnMouseDownProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarOpacityOnMouseDown"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarOpacityOnMouseDownProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarOpacityOnMouseDown), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the size of the vertical scrollbar buttons.
        /// </summary>
        public double VerticalScrollBarButtonsSize
        {
            get => (double)GetValue(VerticalScrollBarButtonsSizeProperty);
            set => SetValue(VerticalScrollBarButtonsSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsSizeProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsSize), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the font of the vertical scrollbar buttons.
        /// </summary>
        public FontFamily VerticalScrollBarButtonsFont
        {
            get => (FontFamily)GetValue(VerticalScrollBarButtonsFontProperty);
            set => SetValue(VerticalScrollBarButtonsFontProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsFont"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsFontProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsFont), typeof(FontFamily), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the size of the font of the vertical scrollbar buttons.
        /// </summary>
        public double VerticalScrollBarButtonsFontSize
        {
            get => (double)GetValue(VerticalScrollBarButtonsFontSizeProperty);
            set => SetValue(VerticalScrollBarButtonsFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsFontSizeProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsFontSize), typeof(double), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the corner radius of the vertical scrollbar buttons.
        /// </summary>
        public CornerRadius VerticalScrollBarButtonsCornerRadius
        {
            get => (CornerRadius)GetValue(VerticalScrollBarButtonsCornerRadiusProperty);
            set => SetValue(VerticalScrollBarButtonsCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsCornerRadiusProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsCornerRadius), typeof(CornerRadius), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the background brush of the vertical scrollbar buttons.
        /// </summary>
        public Brush VerticalScrollBarButtonsBackground
        {
            get => (Brush)GetValue(VerticalScrollBarButtonsBackgroundProperty);
            set => SetValue(VerticalScrollBarButtonsBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsBackgroundProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsBackground), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border brush of the vertical scrollbar buttons.
        /// </summary>
        public Brush VerticalScrollBarButtonsBorderBrush
        {
            get => (Brush)GetValue(VerticalScrollBarButtonsBorderBrushProperty);
            set => SetValue(VerticalScrollBarButtonsBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsBorderBrushProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsBorderBrush), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border thickness of the vertical scrollbar buttons.
        /// </summary>
        public Thickness VerticalScrollBarButtonsBorderThickness
        {
            get => (Thickness)GetValue(VerticalScrollBarButtonsBorderThicknessProperty);
            set => SetValue(VerticalScrollBarButtonsBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsBorderThicknessProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsBorderThickness), typeof(Thickness), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the foreground brush of the vertical scrollbar buttons.
        /// </summary>
        public Brush VerticalScrollBarButtonsForeground
        {
            get => (Brush)GetValue(VerticalScrollBarButtonsForegroundProperty);
            set => SetValue(VerticalScrollBarButtonsForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsForegroundProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsForeground), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the foreground brush of the vertical scrollbar buttons when the control is disabled.
        /// </summary>
        public Brush VerticalScrollBarButtonsForegroundOnDisabled
        {
            get => (Brush)GetValue(VerticalScrollBarButtonsForegroundOnDisabledProperty);
            set => SetValue(VerticalScrollBarButtonsForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarButtonsForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarButtonsForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarButtonsForegroundOnDisabled), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the content of the vertical scrollbar up button.
        /// </summary>
        public object UpButtonContent
        {
            get => GetValue(UpButtonContentProperty);
            set => SetValue(UpButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="UpButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty UpButtonContentProperty =
            DependencyProperty.Register(nameof(UpButtonContent), typeof(object), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the content of the vertical scrollbar down button.
        /// </summary>
        public object DownButtonContent
        {
            get => GetValue(DownButtonContentProperty);
            set => SetValue(DownButtonContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DownButtonContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DownButtonContentProperty =
            DependencyProperty.Register(nameof(DownButtonContent), typeof(object), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the <see cref="ContextMenu"/> of the vertical scrollbar.
        /// </summary>
        public ContextMenu VerticalScrollBarContextMenu
        {
            get => (ContextMenu)GetValue(VerticalScrollBarContextMenuProperty);
            set => SetValue(VerticalScrollBarContextMenuProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalScrollBarContextMenu"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarContextMenuProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarContextMenu), typeof(ContextMenu), typeof(GlassScrollViewer));

        #endregion

        #region Common ScrollBar properties

        /// <summary>
        /// Gets or sets a value indicating if place the scrollbars inside the content area.
        /// </summary>
        public bool PlaceScrollBarsInside
        {
            get => (bool)GetValue(PlaceScrollBarsInsideProperty);
            set => SetValue(PlaceScrollBarsInsideProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="PlaceScrollBarsInside"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PlaceScrollBarsInsideProperty =
            DependencyProperty.Register(nameof(PlaceScrollBarsInside), typeof(bool), typeof(GlassScrollViewer),
                new PropertyMetadata(BoolBox.False));

        /// <summary>
        /// Gets or sets a value indicating if enable the scrollbars buttons.
        /// </summary>
        public bool EnableButtons
        {
            get => (bool)GetValue(EnableButtonsProperty);
            set => SetValue(EnableButtonsProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableButtons"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableButtonsProperty =
            DependencyProperty.Register(nameof(EnableButtons), typeof(bool), typeof(GlassScrollViewer),
                new PropertyMetadata(BoolBox.False));

        /// <summary>
        /// Gets or sets the amount of time, in milliseconds, the sctollbars waits while they are pressed before they starts scrolling. The value must be non-negative.
        /// </summary>
        public int ScrollDelay
        {
            get => (int)GetValue(ScrollDelayProperty);
            set => SetValue(ScrollDelayProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollDelay"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollDelayProperty =
            DependencyProperty.Register(nameof(ScrollDelay), typeof(int), typeof(GlassScrollViewer),
                new FrameworkPropertyMetadata(Util.GetKeyboardDelay()),
                new ValidateValueCallback(GlassScrollBar.IsScrollDelayValid));

        /// <summary>
        /// Gets or sets the amount of time, in milliseconds, the sctollbars repeats scrolling once repeating starts. The value must be non-negative.
        /// </summary>
        public int ScrollInterval
        {
            get => (int)GetValue(ScrollIntervalProperty);
            set => SetValue(ScrollIntervalProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollInterval"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollIntervalProperty =
            DependencyProperty.Register(nameof(ScrollInterval), typeof(int), typeof(GlassScrollViewer),
                new FrameworkPropertyMetadata(Util.GetKeyboardSpeed()),
                new ValidateValueCallback(GlassScrollBar.IsScrollIntervalValid));

        #endregion

        /// <summary>
        /// Gets or sets the border brush of the content area.
        /// </summary>
        public Brush InsideBorderBrush
        {
            get => (Brush)GetValue(InsideBorderBrushProperty);
            set => SetValue(InsideBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="InsideBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty InsideBorderBrushProperty =
            DependencyProperty.Register(nameof(InsideBorderBrush), typeof(Brush), typeof(GlassScrollViewer));

        /// <summary>
        /// Gets or sets the border thickness of the content area.
        /// </summary>
        public Thickness InsideBorderThickness
        {
            get => (Thickness)GetValue(InsideBorderThicknessProperty);
            set => SetValue(InsideBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="InsideBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty InsideBorderThicknessProperty =
            DependencyProperty.Register(nameof(InsideBorderThickness), typeof(Thickness), typeof(GlassScrollViewer));


        static GlassScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassScrollViewer),
                new FrameworkPropertyMetadata(typeof(GlassScrollViewer)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GlassScrollViewer"/>.
        /// </summary>
        public GlassScrollViewer() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) { }
    }
}
