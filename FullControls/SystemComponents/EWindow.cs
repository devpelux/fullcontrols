using FullControls.Core;
using FullControls.Extra;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shell;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.
    /// </summary>
    [TemplatePart(Name = PartMinimizeButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PartMaximizeButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PartRestoreButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PartCloseButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PartToolbarHitZone, Type = typeof(UIElement))]
    [TemplatePart(Name = PartIcon, Type = typeof(UIElement))]
    public class EWindow : Window
    {
        private WindowState beforeState;
        private WindowChrome windowChrome, maxWindowChrome;
        private bool canMove = true;

        /// <summary>
        /// MinimizeButton template part.
        /// </summary>
        protected const string PartMinimizeButton = "PART_MinimizeButton";

        /// <summary>
        /// MaximizeButton template part.
        /// </summary>
        protected const string PartMaximizeButton = "PART_MaximizeButton";

        /// <summary>
        /// RestoreButton template part.
        /// </summary>
        protected const string PartRestoreButton = "PART_RestoreButton";

        /// <summary>
        /// CloseButton template part.
        /// </summary>
        protected const string PartCloseButton = "PART_CloseButton";

        /// <summary>
        /// ToolbarHitZone template part.
        /// </summary>
        protected const string PartToolbarHitZone = "PART_ToolbarHitZone";

        /// <summary>
        /// Icon template part.
        /// </summary>
        protected const string PartIcon = "PART_Icon";

        /// <summary>
        /// Height of the toolbar.
        /// </summary>
        public const double TOOLBAR_HEIGHT = 32;

        /// <summary>
        /// Thickness of the resize border.
        /// </summary>
        public Thickness ResizeThickness
        {
            get => (Thickness)GetValue(ResizeThicknessProperty);
            set => SetValue(ResizeThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ResizeThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ResizeThicknessProperty =
            DependencyProperty.Register(nameof(ResizeThickness), typeof(Thickness), typeof(EWindow),
                new FrameworkPropertyMetadata(new Thickness(), new PropertyChangedCallback((d, e) => ((EWindow)d).OnResizeThicknessChanged((Thickness)e.NewValue))));

        #region Shadow

        /// <summary>
        /// Color of the shadow.
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
            DependencyProperty.Register(nameof(ShadowColor), typeof(Color), typeof(EWindow));

        /// <summary>
        /// Opacity of the shadow.
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
            DependencyProperty.Register(nameof(ShadowOpacity), typeof(double), typeof(EWindow));

        /// <summary>
        /// Radius of the shadow.
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
            DependencyProperty.Register(nameof(ShadowRadius), typeof(double), typeof(EWindow),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateMarginForShadow(d))));

        /// <summary>
        /// Depth of the shadow.
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
            DependencyProperty.Register(nameof(ShadowDepth), typeof(double), typeof(EWindow),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateMarginForShadow(d))));

        #region MarginForShadow

        /// <summary>
        /// Margin used to display the shadow.
        /// </summary>
        public Thickness MarginForShadow => (Thickness)GetValue(MarginForShadowProperty);

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="MarginForShadow"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey MarginForShadowPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(MarginForShadow), typeof(Thickness), typeof(EWindow),
                new FrameworkPropertyMetadata(new Thickness()));

        /// <summary>
        /// Identifies the <see cref="MarginForShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MarginForShadowProperty = MarginForShadowPropertyKey.DependencyProperty;

        /// <summary>
        /// Calculates the margin used to display the shadow.
        /// </summary>
        private static void CalculateMarginForShadow(DependencyObject d)
        {
            double margin = (double)d.GetValue(ShadowRadiusProperty) / 2;
            double offset = (double)d.GetValue(ShadowDepthProperty);
            d.SetValue(MarginForShadowPropertyKey, new Thickness(Math.Max(0, Math.Ceiling(margin - offset)),
                                                                 Math.Max(0, Math.Ceiling(margin - offset)),
                                                                 Math.Max(0, Math.Ceiling(margin + offset)),
                                                                 Math.Max(0, Math.Ceiling(margin + offset))));
        }

        #endregion

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(EWindow));

        #region CaptionButtons general properties

        /// <summary>
        /// Enables the minimize action and button.
        /// </summary>
        /// <remarks>(It has no effect if <see cref="Window.ResizeMode"/> is set to <see cref="ResizeMode.NoResize"/>)</remarks>
        public bool EnableMinimizeButton
        {
            get => (bool)GetValue(EnableMinimizeButtonProperty);
            set => SetValue(EnableMinimizeButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableMinimizeButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMinimizeButtonProperty =
            DependencyProperty.Register(nameof(EnableMinimizeButton), typeof(bool), typeof(EWindow), new PropertyMetadata(true));

        /// <summary>
        /// Enables the maximize/restore button.
        /// </summary>
        /// <remarks>(It has no effect if <see cref="Window.ResizeMode"/> is set to <see cref="ResizeMode.CanMinimize"/> or <see cref="ResizeMode.NoResize"/>)</remarks>
        public bool EnableMaximizeRestoreButton
        {
            get => (bool)GetValue(EnableMaximizeRestoreButtonProperty);
            set => SetValue(EnableMaximizeRestoreButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableMaximizeRestoreButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMaximizeRestoreButtonProperty =
            DependencyProperty.Register(nameof(EnableMaximizeRestoreButton), typeof(bool), typeof(EWindow), new PropertyMetadata(true));

        /// <summary>
        /// Enables the close button.
        /// </summary>
        public bool EnableCloseButton
        {
            get => (bool)GetValue(EnableCloseButtonProperty);
            set => SetValue(EnableCloseButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableCloseButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableCloseButtonProperty =
            DependencyProperty.Register(nameof(EnableCloseButton), typeof(bool), typeof(EWindow), new PropertyMetadata(true));

        /// <summary>
        /// Width of the caption buttons.
        /// </summary>
        public double CaptionButtonsWidth
        {
            get => (double)GetValue(CaptionButtonsWidthProperty);
            set => SetValue(CaptionButtonsWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsWidthProperty =
            DependencyProperty.Register(nameof(CaptionButtonsWidth), typeof(double), typeof(EWindow), new PropertyMetadata(32d));

        /// <summary>
        /// Height of the caption buttons.
        /// </summary>
        public double CaptionButtonsHeight
        {
            get => (double)GetValue(CaptionButtonsHeightProperty);
            set => SetValue(CaptionButtonsHeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsHeightProperty =
            DependencyProperty.Register(nameof(CaptionButtonsHeight), typeof(double), typeof(EWindow), new PropertyMetadata(32d));

        /// <summary>
        /// Margin of the caption buttons.
        /// </summary>
        public Thickness CaptionButtonsMargin
        {
            get => (Thickness)GetValue(CaptionButtonsMarginProperty);
            set => SetValue(CaptionButtonsMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsMarginProperty =
            DependencyProperty.Register(nameof(CaptionButtonsMargin), typeof(Thickness), typeof(EWindow));

        /// <summary>
        /// CornerRadius of the caption buttons.
        /// </summary>
        public CornerRadius CaptionButtonsCornerRadius
        {
            get => (CornerRadius)GetValue(CaptionButtonsCornerRadiusProperty);
            set => SetValue(CaptionButtonsCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsCornerRadiusProperty =
            DependencyProperty.Register(nameof(CaptionButtonsCornerRadius), typeof(CornerRadius), typeof(EWindow));

        /// <summary>
        /// Border thickness of the caption buttons.
        /// </summary>
        public Thickness CaptionButtonsBorderThickness
        {
            get => (Thickness)GetValue(CaptionButtonsBorderThicknessProperty);
            set => SetValue(CaptionButtonsBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsBorderThicknessProperty =
            DependencyProperty.Register(nameof(CaptionButtonsBorderThickness), typeof(Thickness), typeof(EWindow));

        /// <summary>
        /// Background brush of the caption buttons.
        /// </summary>
        public Brush CaptionButtonsBackground
        {
            get => (Brush)GetValue(CaptionButtonsBackgroundProperty);
            set => SetValue(CaptionButtonsBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsBackgroundProperty =
            DependencyProperty.Register(nameof(CaptionButtonsBackground), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Background brush of the caption buttons when the mouse is over them.
        /// </summary>
        public Brush CaptionButtonsBackgroundOnMouseOver
        {
            get => (Brush)GetValue(CaptionButtonsBackgroundOnMouseOverProperty);
            set => SetValue(CaptionButtonsBackgroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsBackgroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsBackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CaptionButtonsBackgroundOnMouseOver), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Background brush of the caption buttons when they are pressed.
        /// </summary>
        public Brush CaptionButtonsBackgroundOnPressed
        {
            get => (Brush)GetValue(CaptionButtonsBackgroundOnPressedProperty);
            set => SetValue(CaptionButtonsBackgroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsBackgroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsBackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(CaptionButtonsBackgroundOnPressed), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// BorderBrush brush of the caption buttons.
        /// </summary>
        public Brush CaptionButtonsBorderBrush
        {
            get => (Brush)GetValue(CaptionButtonsBorderBrushProperty);
            set => SetValue(CaptionButtonsBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsBorderBrushProperty =
            DependencyProperty.Register(nameof(CaptionButtonsBorderBrush), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// BorderBrush brush of the caption buttons when the mouse is over them.
        /// </summary>
        public Brush CaptionButtonsBorderBrushOnMouseOver
        {
            get => (Brush)GetValue(CaptionButtonsBorderBrushOnMouseOverProperty);
            set => SetValue(CaptionButtonsBorderBrushOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsBorderBrushOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsBorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(CaptionButtonsBorderBrushOnMouseOver), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// BorderBrush brush of the caption buttons when they are pressed.
        /// </summary>
        public Brush CaptionButtonsBorderBrushOnPressed
        {
            get => (Brush)GetValue(CaptionButtonsBorderBrushOnPressedProperty);
            set => SetValue(CaptionButtonsBorderBrushOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsBorderBrushOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsBorderBrushOnPressedProperty =
            DependencyProperty.Register(nameof(CaptionButtonsBorderBrushOnPressed), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Foreground brush of the caption buttons.
        /// </summary>
        public Brush CaptionButtonsForeground
        {
            get => (Brush)GetValue(CaptionButtonsForegroundProperty);
            set => SetValue(CaptionButtonsForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsForegroundProperty =
            DependencyProperty.Register(nameof(CaptionButtonsForeground), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Foreground brush of the caption buttons when the mouse is over them.
        /// </summary>
        public Brush CaptionButtonsForegroundOnMouseOver
        {
            get => (Brush)GetValue(CaptionButtonsForegroundOnMouseOverProperty);
            set => SetValue(CaptionButtonsForegroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsForegroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CaptionButtonsForegroundOnMouseOver), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Foreground brush of the caption buttons when they are pressed.
        /// </summary>
        public Brush CaptionButtonsForegroundOnPressed
        {
            get => (Brush)GetValue(CaptionButtonsForegroundOnPressedProperty);
            set => SetValue(CaptionButtonsForegroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsForegroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(CaptionButtonsForegroundOnPressed), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// FontSize of the caption buttons.
        /// </summary>
        public double CaptionButtonsFontSize
        {
            get => (double)GetValue(CaptionButtonsFontSizeProperty);
            set => SetValue(CaptionButtonsFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CaptionButtonsFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionButtonsFontSizeProperty =
            DependencyProperty.Register(nameof(CaptionButtonsFontSize), typeof(double), typeof(EWindow), new PropertyMetadata(10d));

        #endregion

        #region CloseButton properties

        /// <summary>
        /// Width of the close button.
        /// </summary>
        public double CloseButtonWidth
        {
            get => (double)GetValue(CloseButtonWidthProperty);
            set => SetValue(CloseButtonWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonWidthProperty =
            DependencyProperty.Register(nameof(CloseButtonWidth), typeof(double), typeof(EWindow), new PropertyMetadata(32d));

        /// <summary>
        /// Height of the close button.
        /// </summary>
        public double CloseButtonHeight
        {
            get => (double)GetValue(CloseButtonHeightProperty);
            set => SetValue(CloseButtonHeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonHeightProperty =
            DependencyProperty.Register(nameof(CloseButtonHeight), typeof(double), typeof(EWindow), new PropertyMetadata(32d));

        /// <summary>
        /// Margin of the close button.
        /// </summary>
        public Thickness CloseButtonMargin
        {
            get => (Thickness)GetValue(CloseButtonMarginProperty);
            set => SetValue(CloseButtonMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonMarginProperty =
            DependencyProperty.Register(nameof(CloseButtonMargin), typeof(Thickness), typeof(EWindow));

        /// <summary>
        /// Background brush of the close button.
        /// </summary>
        public Brush CloseButtonBackground
        {
            get => (Brush)GetValue(CloseButtonBackgroundProperty);
            set => SetValue(CloseButtonBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonBackgroundProperty =
            DependencyProperty.Register(nameof(CloseButtonBackground), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Background brush of the close button when the mouse is over them.
        /// </summary>
        public Brush CloseButtonBackgroundOnMouseOver
        {
            get => (Brush)GetValue(CloseButtonBackgroundOnMouseOverProperty);
            set => SetValue(CloseButtonBackgroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonBackgroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonBackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CloseButtonBackgroundOnMouseOver), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Background brush of the close button when they are pressed.
        /// </summary>
        public Brush CloseButtonBackgroundOnPressed
        {
            get => (Brush)GetValue(CloseButtonBackgroundOnPressedProperty);
            set => SetValue(CloseButtonBackgroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonBackgroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonBackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(CloseButtonBackgroundOnPressed), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// BorderBrush brush of the close button.
        /// </summary>
        public Brush CloseButtonBorderBrush
        {
            get => (Brush)GetValue(CloseButtonBorderBrushProperty);
            set => SetValue(CloseButtonBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonBorderBrushProperty =
            DependencyProperty.Register(nameof(CloseButtonBorderBrush), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// BorderBrush brush of the close button when the mouse is over them.
        /// </summary>
        public Brush CloseButtonBorderBrushOnMouseOver
        {
            get => (Brush)GetValue(CloseButtonBorderBrushOnMouseOverProperty);
            set => SetValue(CloseButtonBorderBrushOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonBorderBrushOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonBorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(CloseButtonBorderBrushOnMouseOver), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// BorderBrush brush of the close button when they are pressed.
        /// </summary>
        public Brush CloseButtonBorderBrushOnPressed
        {
            get => (Brush)GetValue(CloseButtonBorderBrushOnPressedProperty);
            set => SetValue(CloseButtonBorderBrushOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonBorderBrushOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonBorderBrushOnPressedProperty =
            DependencyProperty.Register(nameof(CloseButtonBorderBrushOnPressed), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Foreground brush of the close button.
        /// </summary>
        public Brush CloseButtonForeground
        {
            get => (Brush)GetValue(CloseButtonForegroundProperty);
            set => SetValue(CloseButtonForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonForegroundProperty =
            DependencyProperty.Register(nameof(CloseButtonForeground), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Foreground brush of the close button when the mouse is over them.
        /// </summary>
        public Brush CloseButtonForegroundOnMouseOver
        {
            get => (Brush)GetValue(CloseButtonForegroundOnMouseOverProperty);
            set => SetValue(CloseButtonForegroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonForegroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(CloseButtonForegroundOnMouseOver), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Foreground brush of the close button when they are pressed.
        /// </summary>
        public Brush CloseButtonForegroundOnPressed
        {
            get => (Brush)GetValue(CloseButtonForegroundOnPressedProperty);
            set => SetValue(CloseButtonForegroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonForegroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(CloseButtonForegroundOnPressed), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// FontSize of the close button.
        /// </summary>
        public double CloseButtonFontSize
        {
            get => (double)GetValue(CloseButtonFontSizeProperty);
            set => SetValue(CloseButtonFontSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonFontSizeProperty =
            DependencyProperty.Register(nameof(CloseButtonFontSize), typeof(double), typeof(EWindow), new PropertyMetadata(10d));

        #endregion

        /// <summary>
        /// Enables the minimize action using the taskbar.
        /// </summary>
        /// <remarks>(It has no effect if <see cref="Window.ResizeMode"/> is set to <see cref="ResizeMode.NoResize"/>)</remarks>
        public bool EnableMinimizeByTaskbar
        {
            get => (bool)GetValue(EnableMinimizeByTaskbarProperty);
            set => SetValue(EnableMinimizeByTaskbarProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableMinimizeByTaskbar"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMinimizeByTaskbarProperty =
            DependencyProperty.Register(nameof(EnableMinimizeByTaskbar), typeof(bool), typeof(EWindow), new PropertyMetadata(true));

        /// <summary>
        /// Enables the maximize and restore action by double click on toolbar.
        /// </summary>
        /// <remarks>(It has no effect if <see cref="Window.ResizeMode"/> is set to <see cref="ResizeMode.CanMinimize"/> or <see cref="ResizeMode.NoResize"/>)</remarks>
        public bool EnableDoubleClickMaximizeRestore
        {
            get => (bool)GetValue(EnableDoubleClickMaximizeRestoreProperty);
            set => SetValue(EnableDoubleClickMaximizeRestoreProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableDoubleClickMaximizeRestore"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableDoubleClickMaximizeRestoreProperty =
            DependencyProperty.Register(nameof(EnableDoubleClickMaximizeRestore), typeof(bool), typeof(EWindow), new PropertyMetadata(true));

        #region Toolbar properties

        /// <summary>
        /// <para>Merge the toolbar with the content.</para>
        /// <para>The toolbar becomes transparent and is displayed above the content.</para>
        /// <para>Suggestion 1: Use <see cref="ToolbarHitZoneMargin"/> to resize the clickable part if you want insert a menu in the toolbar.</para>
        /// <para>Suggestion 2: Customize the brushes of the caption buttons.</para>
        /// </summary>
        public bool MergeToolbarAndContent
        {
            get => (bool)GetValue(MergeToolbarAndContentProperty);
            set => SetValue(MergeToolbarAndContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="MergeToolbarAndContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MergeToolbarAndContentProperty =
            DependencyProperty.Register(nameof(MergeToolbarAndContent), typeof(bool), typeof(EWindow), new PropertyMetadata(false));

        /// <summary>
        /// <para>Background brush of the toolbar.</para>
        /// <para>Note: If <see cref="MergeToolbarAndContent"/> is <see langword="true"/> this property has no effect.</para>
        /// </summary>
        public Brush ToolbarBackground
        {
            get => (Brush)GetValue(ToolbarBackgroundProperty);
            set => SetValue(ToolbarBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ToolbarBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToolbarBackgroundProperty =
            DependencyProperty.Register(nameof(ToolbarBackground), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Margin of the toolbar.
        /// </summary>
        public Thickness ToolbarMargin
        {
            get => (Thickness)GetValue(ToolbarMarginProperty);
            set => SetValue(ToolbarMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ToolbarMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToolbarMarginProperty =
            DependencyProperty.Register(nameof(ToolbarMargin), typeof(Thickness), typeof(EWindow));

        /// <summary>
        /// Enable the toolbar to handles inputs.
        /// </summary>
        public bool EnableToolbarHitZone
        {
            get => (bool)GetValue(EnableToolbarHitZoneProperty);
            set => SetValue(EnableToolbarHitZoneProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableToolbarHitZone"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableToolbarHitZoneProperty =
            DependencyProperty.Register(nameof(EnableToolbarHitZone), typeof(bool), typeof(EWindow), new PropertyMetadata(true));

        /// <summary>
        /// Background of the toolbar part that handles inputs.
        /// </summary>
        public Brush ToolbarHitZoneBackground
        {
            get => (Brush)GetValue(ToolbarHitZoneBackgroundProperty);
            set => SetValue(ToolbarHitZoneBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ToolbarHitZoneBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToolbarHitZoneBackgroundProperty =
            DependencyProperty.Register(nameof(ToolbarHitZoneBackground), typeof(Brush), typeof(EWindow));

        /// <summary>
        /// Margin of the toolbar hit zone.
        /// </summary>
        public Thickness ToolbarHitZoneMargin
        {
            get => (Thickness)GetValue(ToolbarHitZoneMarginProperty);
            set => SetValue(ToolbarHitZoneMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ToolbarHitZoneMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToolbarHitZoneMarginProperty =
            DependencyProperty.Register(nameof(ToolbarHitZoneMargin), typeof(Thickness), typeof(EWindow));

        /// <summary>
        /// The menu that is shown at right click on toolbar.
        /// </summary>
        public ContextMenu ToolbarMenu
        {
            get => (ContextMenu)GetValue(ToolbarMenuProperty);
            set => SetValue(ToolbarMenuProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ToolbarMenu"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToolbarMenuProperty =
            DependencyProperty.Register(nameof(ToolbarMenu), typeof(ContextMenu), typeof(EWindow));

        #endregion

        /// <summary>
        /// Specifies if to start the window hided.
        /// </summary>
        public bool StartHided
        {
            get => (bool)GetValue(StartHidedProperty);
            set => SetValue(StartHidedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="StartHided"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty StartHidedProperty =
            DependencyProperty.Register(nameof(StartHided), typeof(bool), typeof(EWindow), new PropertyMetadata(false));

        /// <summary>
        /// Indicates if the window is docked.
        /// </summary>
        public bool IsDocked => (bool)GetValue(IsDockedProperty);

        /// <summary>
        /// Identifies the <see cref="IsDocked"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty IsDockedProperty =
            DependencyProperty.Register(nameof(IsDocked), typeof(bool), typeof(EWindow));

        /// <summary>
        /// Duration of the state change animations.
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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(EWindow));

        /// <summary>
        /// Fix the height and the width of the window to be the same as in designer of Visual Studio.
        /// </summary>
        /// <remarks>(Has effect only on initialization)</remarks>
        public bool FixVSDesigner
        {
            get => (bool)GetValue(FixVSDesignerProperty);
            set => SetValue(FixVSDesignerProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="FixVSDesigner"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FixVSDesignerProperty =
            DependencyProperty.Register(nameof(FixVSDesigner), typeof(bool), typeof(EWindow), new PropertyMetadata(true));

        /// <summary>
        /// Raised immediately before <see cref="Close"/> is executed.
        /// </summary>
        public event EventHandler<CancelEventArgs> BeforeClosing;

        /// <summary>
        /// Raised immediately before <see cref="Minimize"/> is executed.
        /// </summary>
        public event EventHandler<CancelEventArgs> BeforeMinimizing;


        static EWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EWindow), new FrameworkPropertyMetadata(typeof(EWindow)));
        }

        /// <summary>
        /// Creates a new <see cref="EWindow"/>.
        /// </summary>
        public EWindow() : base()
        {
            Loaded -= OnLoaded;
            Loaded += OnLoaded;
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            LoadWindowChromes();
            ((HwndSource)PresentationSource.FromVisual(this)).AddHook(new HwndSourceHook(HandleMessages));
            ButtonBase minimizeButton = (ButtonBase)Template.FindName(PartMinimizeButton, this);
            if (minimizeButton != null) minimizeButton.Click += PART_MinimizeButton_Click;
            ButtonBase maximizeButton = (ButtonBase)Template.FindName(PartMaximizeButton, this);
            if (maximizeButton != null) maximizeButton.Click += PART_MaximizeButton_Click;
            ButtonBase restoreButton = (ButtonBase)Template.FindName(PartRestoreButton, this);
            if (restoreButton != null) restoreButton.Click += PART_RestoreButton_Click;
            ButtonBase closeButton = (ButtonBase)Template.FindName(PartCloseButton, this);
            if (closeButton != null) closeButton.Click += PART_CloseButton_Click;
            UIElement toolbarHitZone = (UIElement)Template.FindName(PartToolbarHitZone, this);
            if (toolbarHitZone != null)
            {
                toolbarHitZone.MouseMove += PART_ToolbarHitZone_MouseMove;
                toolbarHitZone.TouchMove += PART_ToolbarHitZone_TouchMove;
                toolbarHitZone.MouseLeftButtonDown += PART_ToolbarHitZone_MouseLeftButtonDown;
                toolbarHitZone.MouseRightButtonDown += PART_ToolbarHitZone_MouseRightButtonDown;
            }
            UIElement icon = (UIElement)Template.FindName(PartIcon, this);
            if (icon != null) icon.MouseDown += PART_Icon_MouseDown;
            Opacity = 0; //Initial state
            beforeState = WindowState;
        }

        /// <summary>
        /// Initializes the window chromes used.
        /// </summary>
        private void LoadWindowChromes()
        {
            windowChrome = new WindowChrome()
            {
                CaptionHeight = 0,
                CornerRadius = new CornerRadius(0),
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = ResizeThickness
            };
            maxWindowChrome = new WindowChrome()
            {
                CaptionHeight = 0,
                CornerRadius = new CornerRadius(0),
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = new Thickness(0)
            };
            ApplyWindowChrome();
        }

        /// <summary>
        /// Apply the correct window chrome based on the window state.
        /// </summary>
        private void ApplyWindowChrome()
        {
            if (WindowState == WindowState.Maximized) WindowChrome.SetWindowChrome(this, maxWindowChrome);
            else WindowChrome.SetWindowChrome(this, windowChrome);
        }

        /// <summary>
        /// Called when <see cref="ResizeThickness"/> is changed.
        /// </summary>
        /// <param name="newValue">New <see cref="ResizeThickness"/> value.</param>
        private void OnResizeThicknessChanged(Thickness newValue)
        {
            windowChrome = new WindowChrome()
            {
                CaptionHeight = 0,
                CornerRadius = new CornerRadius(0),
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = newValue
            };
            ApplyWindowChrome();
        }

        #region CaptionButtonsClicks

        /// <summary>
        /// Called when close button is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        /// <summary>
        /// Called when minimize button is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_MinimizeButton_Click(object sender, RoutedEventArgs e) => Minimize();

        /// <summary>
        /// Called when maximize button is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_MaximizeButton_Click(object sender, RoutedEventArgs e) => Maximize();

        /// <summary>
        /// Called when restore button is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_RestoreButton_Click(object sender, RoutedEventArgs e) => Restore();

        #endregion

        #region ToolbarEvents

        /// <summary>
        /// Called when the icon is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_Icon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ToolbarMenu != null) ToolbarMenu.IsOpen = true;
        }

        /// <summary>
        /// Called when the toolbar hit zone is clicked by the mouse right button.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_ToolbarHitZone_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ToolbarMenu != null) ToolbarMenu.IsOpen = true;
        }

        /// <summary>
        /// Called when the toolbar hit zone is clicked by the mouse left button.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_ToolbarHitZone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2 && EnableDoubleClickMaximizeRestore &&
                (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip))
            {
                if (WindowState == WindowState.Maximized) Restore();
                else Maximize();
            }
        }

        /// <summary>
        /// Called when the moused is moved above the toolbar hit zone.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_ToolbarHitZone_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove(e.GetPosition((Grid)sender));
        }

        /// <summary>
        /// Called when the touch is moved above the toolbar hit zone.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_ToolbarHitZone_TouchMove(object sender, TouchEventArgs e)
        {
            DragMove(e.GetTouchPoint(this).Position);
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="FrameworkElement.Loaded"/> event.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e)
        {
            if (FixVSDesigner)
            {
                Height += VSDesignerHeightOffset();
                Width += VSDesignerWidthOffset();
                MinHeight += VSDesignerHeightOffset();
                MinWidth += VSDesignerWidthOffset();
            }
            if (WindowState != WindowState.Minimized) EnterAnimation();
            beforeState = WindowState;
            if (StartHided) Hide();
        }

        /// <inheritdoc/>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            SetValue(IsDockedProperty, WindowState == WindowState.Normal && Width != RestoreBounds.Width && Height != RestoreBounds.Height);
        }

        /// <inheritdoc/>
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            if (beforeState == WindowState.Minimized) AntiMinimizeAnimation();
            ApplyWindowChrome();
            beforeState = WindowState;
        }

        /// <summary>
        /// Handles the window messages.
        /// </summary>
        private IntPtr HandleMessages(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == EWindowCore.WM_GETMINMAXINFO) EWindowCore.WmGetMinMaxInfo(hwnd, lParam);
            else if (msg == EWindowCore.WM_SYSCOMMAND && ((int)wParam & 0xFFF0) == EWindowCore.SC_MINIMIZE)
            {
                handled = true;
                if (EnableMinimizeByTaskbar) Minimize();
            }
            return IntPtr.Zero;
        }

        #region Animations

        /// <summary>
        /// Start the animation used to minimize the window.
        /// </summary>
        private void MinimizeAnimation()
        {
            if (AnimationTime > TimeSpan.Zero)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation(1, 0, new Duration(AnimationTime));
                doubleAnimation.Completed += MinimizeAnimation_Completed;
                BeginAnimation(OpacityProperty, doubleAnimation);
            }
            else
            {
                Opacity = 0;
                WindowState = WindowState.Minimized;
            }
        }

        /// <summary>
        /// Called when the animation used to minimize the window ended.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void MinimizeAnimation_Completed(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Start the animation used to restore the window after was minimized.
        /// </summary>
        private void AntiMinimizeAnimation()
        {
            if (AnimationTime > TimeSpan.Zero)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new Duration(AnimationTime));
                BeginAnimation(OpacityProperty, doubleAnimation);
            }
            else
            {
                Opacity = 1;
            }
        }

        /// <summary>
        /// Start the animation used to start the window.
        /// </summary>
        private void EnterAnimation()
        {
            if (AnimationTime > TimeSpan.Zero)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new Duration(AnimationTime));
                BeginAnimation(OpacityProperty, doubleAnimation);
            }
            else
            {
                Opacity = 1;
            }
        }

        /// <summary>
        /// Start the animation used to close the window.
        /// </summary>
        private void ExitAnimation()
        {
            if (AnimationTime > TimeSpan.Zero)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation(1, 0, new Duration(AnimationTime));
                doubleAnimation.Completed += ExitAnimation_Completed;
                BeginAnimation(OpacityProperty, doubleAnimation);
            }
            else
            {
                Opacity = 0;
                base.Close();
            }
        }

        /// <summary>
        /// Called when the animation used to close the window ended.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void ExitAnimation_Completed(object sender, EventArgs e)
        {
            base.Close();
        }

        #endregion

        #region Commands

        /// <summary>
        /// Close the window.
        /// </summary>
        public new void Close()
        {
            CancelEventArgs e = new CancelEventArgs();
            BeforeClosing?.Invoke(this, e);
            if (!e.Cancel)
            {
                ExitAnimation();
            }
        }

        /// <summary>
        /// Minimize the window.
        /// </summary>
        public void Minimize()
        {
            CancelEventArgs e = new CancelEventArgs();
            BeforeMinimizing?.Invoke(this, e);
            if (!e.Cancel)
            {
                MinimizeAnimation();
            }
        }

        /// <summary>
        /// Maximize the window.
        /// </summary>
        public void Maximize()
        {
            canMove = false;
            WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// Restore the window.
        /// </summary>
        public void Restore()
        {
            WindowState = WindowState.Normal;
        }

        /// <summary>
        /// Move the window.
        /// </summary>
        public void DragMove(Point mousepos)
        {
            if (canMove)
            {
                if (WindowState == WindowState.Maximized)
                {
                    double targetHorizontal = (RestoreBounds.Width * (mousepos.X / ActualWidth)) + ShadowRadius;
                    double targetVertical = (mousepos.Y > 32 ? (RestoreBounds.Height * (mousepos.Y / ActualHeight)) : mousepos.Y) + ShadowRadius;

                    WindowState = WindowState.Normal;

                    Point curpos = Tools.GetCursorPos();
                    Left = curpos.X - targetHorizontal;
                    Top = curpos.Y - targetVertical;
                }
                DragMove();
            }
            canMove = true;
        }

        #endregion

        #region VSDesignerFix

        /// <summary>
        /// Offset of height between Visual Stuio designer and reality.
        /// </summary>
        /// <returns>Offset of height.</returns>
        private double VSDesignerHeightOffset() => MarginForShadow.Top + MarginForShadow.Bottom + (!MergeToolbarAndContent ? TOOLBAR_HEIGHT : 0);

        /// <summary>
        /// Offset of width between Visual Stuio designer and reality.
        /// </summary>
        /// <returns>Offset of width.</returns>
        private double VSDesignerWidthOffset() => MarginForShadow.Left + MarginForShadow.Right;

        #endregion

        #region EventHandlers

        private void OnLoaded(object sender, RoutedEventArgs e) => OnLoaded(e);

        #endregion
    }
}
