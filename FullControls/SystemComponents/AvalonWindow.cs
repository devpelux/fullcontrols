using FullControls.Common;
using FullControls.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.
    /// </summary>
    public class AvalonWindow : Window
    {
        private bool loaded = false;

        /// <summary>
        /// Height of the titlebar.
        /// </summary>
        public const double TITLEBAR_HEIGHT = 32;

        /// <summary>
        /// Gets or sets the border brush when <see cref="Window.IsActive"/> is <see langword="true"/>.
        /// </summary>
        public Brush BorderBrushOnActive
        {
            get => (Brush)GetValue(BorderBrushOnActiveProperty);
            set => SetValue(BorderBrushOnActiveProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnActive"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnActiveProperty =
            DependencyProperty.Register(nameof(BorderBrushOnActive), typeof(Brush), typeof(AvalonWindow));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBorderBrushPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the foreground brush when <see cref="Window.IsActive"/> is <see langword="true"/>.
        /// </summary>
        public Brush ForegroundOnActive
        {
            get => (Brush)GetValue(ForegroundOnActiveProperty);
            set => SetValue(ForegroundOnActiveProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnActive"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnActiveProperty =
            DependencyProperty.Register(nameof(ForegroundOnActive), typeof(Brush), typeof(AvalonWindow));

        /// <summary>
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualForegroundPropertyKey, e.NewValue))));

        #endregion

        #region Titlebar properties

        /// <summary>
        /// <para>Gets or sets a value indicating if merge the titlebar with the content.</para>
        /// <para>The titlebar becomes transparent and is displayed above the content.</para>
        /// </summary>
        public bool MergeTitlebarAndContent
        {
            get => (bool)GetValue(MergeTitlebarAndContentProperty);
            set => SetValue(MergeTitlebarAndContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="MergeTitlebarAndContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MergeTitlebarAndContentProperty =
            DependencyProperty.Register(nameof(MergeTitlebarAndContent), typeof(bool), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(BoolBox.False, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// Gets or sets the margin of the titlebar.
        /// </summary>
        public Thickness TitlebarMargin
        {
            get => (Thickness)GetValue(TitlebarMarginProperty);
            set => SetValue(TitlebarMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TitlebarMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitlebarMarginProperty =
            DependencyProperty.Register(nameof(TitlebarMargin), typeof(Thickness), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// Gets or sets the background brush of the titlebar.
        /// </summary>
        /// <remarks>Has no effect if <see cref="MergeTitlebarAndContent"/> is <see langword="true"/>.</remarks>
        public Brush TitlebarBackground
        {
            get => (Brush)GetValue(TitlebarBackgroundProperty);
            set => SetValue(TitlebarBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TitlebarBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitlebarBackgroundProperty =
            DependencyProperty.Register(nameof(TitlebarBackground), typeof(Brush), typeof(AvalonWindow));

        /// <summary>
        /// Gets or sets the background brush of the titlebar when <see cref="Window.IsActive"/> is <see langword="true"/>.
        /// </summary>
        /// <remarks>Has no effect if <see cref="MergeTitlebarAndContent"/> is <see langword="true"/>.</remarks>
        public Brush TitlebarBackgroundOnActive
        {
            get => (Brush)GetValue(TitlebarBackgroundOnActiveProperty);
            set => SetValue(TitlebarBackgroundOnActiveProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TitlebarBackgroundOnActive"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitlebarBackgroundOnActiveProperty =
            DependencyProperty.Register(nameof(TitlebarBackgroundOnActive), typeof(Brush), typeof(AvalonWindow));

        /// <summary>
        /// Gets the actual background brush of the titlebar.
        /// </summary>
        public Brush ActualTitlebarBackground => (Brush)GetValue(ActualTitlebarBackgroundProperty);

        #region ActualTitlebarBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualTitlebarBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualTitlebarBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualTitlebarBackground), typeof(Brush), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualTitlebarBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualTitlebarBackgroundProperty = ActualTitlebarBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualTitlebarBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualTitlebarBackgroundPropertyProxy =
            DependencyProperty.Register("ActualTitlebarBackgroundProxy", typeof(Brush), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualTitlebarBackgroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the margin of the titlebar title.
        /// </summary>
        public Thickness TitleMargin
        {
            get => (Thickness)GetValue(TitleMarginProperty);
            set => SetValue(TitleMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TitleMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleMarginProperty =
            DependencyProperty.Register(nameof(TitleMargin), typeof(Thickness), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(new Thickness(5, 0, 5, 0)));

        /// <summary>
        /// Gets or sets the margin of the titlebar icon.
        /// </summary>
        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IconMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(AvalonWindow));

        /// <summary>
        /// Gets or sets the background brush of the titlebar icon.
        /// </summary>
        public Brush IconBackground
        {
            get => (Brush)GetValue(IconBackgroundProperty);
            set => SetValue(IconBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IconBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconBackgroundProperty =
            DependencyProperty.Register(nameof(IconBackground), typeof(Brush), typeof(AvalonWindow));

        /// <summary>
        /// Gets or sets the margin of the titlebar buttons area.
        /// </summary>
        public Thickness ButtonsAreaMargin
        {
            get => (Thickness)GetValue(ButtonsAreaMarginProperty);
            set => SetValue(ButtonsAreaMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsAreaMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsAreaMarginProperty =
            DependencyProperty.Register(nameof(ButtonsAreaMargin), typeof(Thickness), typeof(AvalonWindow));

        /// <summary>
        /// Gets or sets the background brush of the titlebar buttons area.
        /// </summary>
        public Brush ButtonsAreaBackground
        {
            get => (Brush)GetValue(ButtonsAreaBackgroundProperty);
            set => SetValue(ButtonsAreaBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ButtonsAreaBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsAreaBackgroundProperty =
            DependencyProperty.Register(nameof(ButtonsAreaBackground), typeof(Brush), typeof(AvalonWindow));

        /// <summary>
        /// Gets or sets the context menu of the titlebar.
        /// </summary>
        public ContextMenu TitlebarContextMenu
        {
            get => (ContextMenu)GetValue(TitlebarContextMenuProperty);
            set => SetValue(TitlebarContextMenuProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TitlebarContextMenu"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitlebarContextMenuProperty =
            DependencyProperty.Register(nameof(TitlebarContextMenu), typeof(ContextMenu), typeof(AvalonWindow));

        #region Caption buttons properties

        /// <summary>
        /// Gets or sets a value indicating if enable the minimize button.
        /// </summary>
        public bool EnableMinimizeButton
        {
            get => (bool)GetValue(EnableMinimizeButtonProperty);
            set => SetValue(EnableMinimizeButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableMinimizeButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMinimizeButtonProperty =
            DependencyProperty.Register(nameof(EnableMinimizeButton), typeof(bool), typeof(AvalonWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the maximize button.
        /// </summary>
        public bool EnableMaximizeButton
        {
            get => (bool)GetValue(EnableMaximizeButtonProperty);
            set => SetValue(EnableMaximizeButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableMaximizeButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMaximizeButtonProperty =
            DependencyProperty.Register(nameof(EnableMaximizeButton), typeof(bool), typeof(AvalonWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the restore button.
        /// </summary>
        public bool EnableRestoreButton
        {
            get => (bool)GetValue(EnableRestoreButtonProperty);
            set => SetValue(EnableRestoreButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableRestoreButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableRestoreButtonProperty =
            DependencyProperty.Register(nameof(EnableRestoreButton), typeof(bool), typeof(AvalonWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the close button.
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
            DependencyProperty.Register(nameof(EnableCloseButton), typeof(bool), typeof(AvalonWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets the style of the minimize button.
        /// </summary>
        public Style MinimizeButtonStyle
        {
            get => (Style)GetValue(MinimizeButtonStyleProperty);
            set => SetValue(MinimizeButtonStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="MinimizeButtonStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinimizeButtonStyleProperty =
            DependencyProperty.Register(nameof(MinimizeButtonStyle), typeof(Style), typeof(AvalonWindow));

        /// <summary>
        /// Gets or sets the style of the maximize button.
        /// </summary>
        public Style MaximizeButtonStyle
        {
            get => (Style)GetValue(MaximizeButtonStyleProperty);
            set => SetValue(MaximizeButtonStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="MaximizeButtonStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaximizeButtonStyleProperty =
            DependencyProperty.Register(nameof(MaximizeButtonStyle), typeof(Style), typeof(AvalonWindow));

        /// <summary>
        /// Gets or sets the style of the restore button.
        /// </summary>
        public Style RestoreButtonStyle
        {
            get => (Style)GetValue(RestoreButtonStyleProperty);
            set => SetValue(RestoreButtonStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="RestoreButtonStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RestoreButtonStyleProperty =
            DependencyProperty.Register(nameof(RestoreButtonStyle), typeof(Style), typeof(AvalonWindow));

        /// <summary>
        /// Gets or sets the style of the close button.
        /// </summary>
        public Style CloseButtonStyle
        {
            get => (Style)GetValue(CloseButtonStyleProperty);
            set => SetValue(CloseButtonStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CloseButtonStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonStyleProperty =
            DependencyProperty.Register(nameof(CloseButtonStyle), typeof(Style), typeof(AvalonWindow));

        #endregion

        #endregion

        /// <summary>
        /// Gets or sets the thickness of the resize border.
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
            DependencyProperty.Register(nameof(ResizeThickness), typeof(Thickness), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(new Thickness(4d), FrameworkPropertyMetadataOptions.AffectsMeasure,
                    new PropertyChangedCallback((d, e) => ((AvalonWindow)d).OnResizeThicknessChanged((Thickness)e.NewValue))));

        /// <summary>
        /// Gets or sets a value indicating if enable the minimize action by using the taskbar.
        /// </summary>
        /// <remarks>(Has no effect if <see cref="Window.ResizeMode"/> is set to <see cref="ResizeMode.NoResize"/>)</remarks>
        public bool EnableMinimizeByTaskbar
        {
            get => (bool)GetValue(EnableMinimizeByTaskbarProperty);
            set => SetValue(EnableMinimizeByTaskbarProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableMinimizeByTaskbar"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMinimizeByTaskbarProperty =
            DependencyProperty.Register(nameof(EnableMinimizeByTaskbar), typeof(bool), typeof(AvalonWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the maximize and restore action by double click on titlebar.
        /// </summary>
        /// <remarks>(Has no effect if <see cref="Window.ResizeMode"/> is set to <see cref="ResizeMode.CanMinimize"/> or <see cref="ResizeMode.NoResize"/>)</remarks>
        public bool EnableDoubleClickMaximizeRestore
        {
            get => (bool)GetValue(EnableDoubleClickMaximizeRestoreProperty);
            set => SetValue(EnableDoubleClickMaximizeRestoreProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableDoubleClickMaximizeRestore"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableDoubleClickMaximizeRestoreProperty =
            DependencyProperty.Register(nameof(EnableDoubleClickMaximizeRestore), typeof(bool), typeof(AvalonWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets the duration of the state change animations.
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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(AvalonWindow));

        /// <summary>
        /// Gets the overflow margin of the window.
        /// </summary>
        public Thickness OverflowMargin => (Thickness)GetValue(OverflowMarginProperty);

        #region OverflowMarginProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="OverflowMargin"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey OverflowMarginPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(OverflowMargin), typeof(Thickness), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// Identifies the <see cref="OverflowMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OverflowMarginProperty = OverflowMarginPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets a value indicating if the window is docked.
        /// </summary>
        public bool IsDocked => (bool)GetValue(IsDockedProperty);

        #region IsDockedProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="IsDocked"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey IsDockedPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsDocked), typeof(bool), typeof(AvalonWindow),
                new PropertyMetadata(BoolBox.False));

        /// <summary>
        /// Identifies the <see cref="IsDocked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsDockedProperty = IsDockedPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets a value indicating if the window is hided.
        /// </summary>
        public bool IsHided => (bool)GetValue(IsHidedProperty);

        #region IsHidedProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="IsHided"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey IsHidedPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsHided), typeof(bool), typeof(AvalonWindow),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Identifies the <see cref="IsHided"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsHidedProperty = IsHidedPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Occurs immediately before <see cref="Close"/> is executed.
        /// </summary>
        public event EventHandler<CancelEventArgs> PreviewClose;

        /// <summary>
        /// Occurs immediately before <see cref="Minimize"/> is executed.
        /// </summary>
        public event EventHandler<CancelEventArgs> PreviewMinimize;

        /// <summary>
        /// Occurs when an <see cref="IAction"/> is executed.
        /// </summary>
        public event EventHandler<ActionEventArgs> ActionExecuted;


        static AvalonWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AvalonWindow),
                new FrameworkPropertyMetadata(typeof(AvalonWindow)));

            IsEnabledProperty.OverrideMetadata(typeof(AvalonWindow),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((AvalonWindow)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AvalonWindow"/>.
        /// </summary>
        public AvalonWindow() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
            DependencyPropertyDescriptor.FromProperty(IsActiveProperty, typeof(AvalonWindow))
                ?.AddValueChanged(this, (s, e) => OnActiveChanged(IsActive));
            LoadCommands();
            OnInitializing();
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Util.AnimateBrush(this, ActualTitlebarBackgroundPropertyProxy, TitlebarBackgroundOnActive, TimeSpan.Zero);
            Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnActive, TimeSpan.Zero);
            Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnActive, TimeSpan.Zero);
            loaded = true;
        }

        /// <summary>
        /// Executed when the object is initializing (is called directly in the main constructor).
        /// </summary>
        protected virtual void OnInitializing()
        {
            WindowChrome wc = new()
            {
                GlassFrameThickness = new Thickness(0, 0, 0, 1),
                NonClientFrameEdges = NonClientFrameEdges.Bottom,
                UseAeroCaptionButtons = false,
                CaptionHeight = TITLEBAR_HEIGHT,
                ResizeBorderThickness = ResizeThickness,
                CornerRadius = new CornerRadius()
            };
            WindowChrome.SetWindowChrome(this, wc);
            SetValue(OverflowMarginPropertyKey, WindowCore.GetOverflowMargin(WindowState));
        }

        /// <inheritdoc/>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            WindowCore.GetHwndSource(this)?.AddHook(HandleMessages);
        }

        /// <summary>
        /// Called when the window is loaded.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when <see cref="Window.IsActive"/> is changed.
        /// </summary>
        /// <param name="activeState">Actual state of <see cref="Window.IsActive"/>.</param>
        protected virtual void OnActiveChanged(bool activeState) => OnVStateChanged(VStateOverride());

        /// <inheritdoc/>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            SetValue(IsDockedPropertyKey, BoolBox.Box(WindowState == WindowState.Normal
                && Width != RestoreBounds.Width && Height != RestoreBounds.Height));
        }

        /// <inheritdoc/>
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            SetValue(OverflowMarginPropertyKey, WindowCore.GetOverflowMargin(WindowState));
        }

        /// <summary>
        /// Called when <see cref="ResizeThickness"/> is changed.
        /// </summary>
        /// <param name="newValue">New thickness value.</param>
        protected virtual void OnResizeThicknessChanged(Thickness newValue)
        {
            WindowChrome wc = WindowChrome.GetWindowChrome(this);
            if (wc != null) wc.ResizeBorderThickness = newValue;
        }

        /// <summary>
        /// Called when an action is executed.
        /// </summary>
        /// <param name="action">Action executed.</param>
        protected virtual void OnActionExecuted(IAction action)
            => ActionExecuted?.Invoke(this, new ActionEventArgs(action));

        /// <summary>
        /// Called to calculate the <b>v-state</b> of the control.
        /// </summary>
        protected virtual string VStateOverride()
        {
            if (!loaded) return "Undefined";
            if (!IsEnabled) return "Disabled";
            else if (!IsActive) return "Inactive";
            else return "Active";
        }

        /// <summary>
        /// Called when the <b>v-state</b> of the control changed.
        /// </summary>
        /// <remarks>Is called <b>v-state</b> because is not related to the VisualState of the control.</remarks>
        /// <param name="vstate">Actual <b>v-state</b> of the control.</param>
        protected virtual void OnVStateChanged(string vstate)
        {
            switch (vstate)
            {
                case "Active":
                    Util.AnimateBrush(this, ActualTitlebarBackgroundPropertyProxy, TitlebarBackgroundOnActive, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnActive, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnActive, TimeSpan.Zero);
                    break;
                case "Inactive":
                    Util.AnimateBrush(this, ActualTitlebarBackgroundPropertyProxy, TitlebarBackground, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, TimeSpan.Zero);
                    break;
                case "Disabled":
                    Util.AnimateBrush(this, ActualTitlebarBackgroundPropertyProxy, TitlebarBackground, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, TimeSpan.Zero);
                    break;
                default:
                    break;
            }
        }

        #region Caption buttons events

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

        #region Window interaction functions

        /// <summary>
        /// Close the window.
        /// </summary>
        public new void Close()
        {
            CancelEventArgs e = new();
            PreviewClose?.Invoke(this, e);
            if (!e.Cancel)
            {
                SetValue(OverflowMarginPropertyKey, WindowCore.GetOverflowMargin(WindowState));
                base.Close();
            }
        }

        /// <summary>
        /// Minimize the window.
        /// </summary>
        public void Minimize()
        {
            if (WindowState != WindowState.Minimized)
            {
                CancelEventArgs e = new();
                PreviewMinimize?.Invoke(this, e);
                if (!e.Cancel)
                {
                    WindowState = WindowState.Minimized;
                }
            }
        }

        /// <summary>
        /// Maximize the window.
        /// </summary>
        public void Maximize()
        {
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
        /// Makes a window invisible.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        public new void Hide()
        {
            SetValue(IsHidedPropertyKey, BoolBox.True);
            base.Hide();
        }

        /// <summary>
        /// Opens a window and returns without waiting for the newly opened window to close.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        public new void Show()
        {
            SetValue(IsHidedPropertyKey, BoolBox.False);
            base.Show();
        }

        /// <summary>
        /// Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// <returns>A <see cref="Nullable{T}"/> value of type <see cref="bool"/> that specifies
        /// whether the activity was accepted (<see langword="true"/>) or canceled (<see langword="false"/>).
        /// The return value is the value of the <see cref="Window.DialogResult"/> property before a window closes.</returns>
        /// <exception cref="InvalidOperationException"/>
        public new bool? ShowDialog()
        {
            SetValue(IsHidedPropertyKey, BoolBox.False);
            return base.ShowDialog();
        }

        #endregion

        #region Commands handlers

        #region LoadCommands

        private void LoadCommands()
        {
            //Close command
            CommandBinding close = new(WindowCommands.Close);
            close.CanExecute += Close_CanExecute;
            close.Executed += Close_Executed;
            CommandBindings.Add(close);

            //Minimize command
            CommandBinding minimize = new(WindowCommands.Minimize);
            minimize.CanExecute += Minimize_CanExecute;
            minimize.Executed += Minimize_Executed;
            CommandBindings.Add(minimize);

            //Maximize command
            CommandBinding maximize = new(WindowCommands.Maximize);
            maximize.CanExecute += Maximize_CanExecute;
            maximize.Executed += Maximize_Executed;
            CommandBindings.Add(maximize);

            //Restore command
            CommandBinding restore = new(WindowCommands.Restore);
            restore.CanExecute += Restore_CanExecute;
            restore.Executed += Restore_Executed;
            CommandBindings.Add(restore);

            //SwitchState command
            CommandBinding switchState = new(WindowCommands.SwitchState);
            switchState.CanExecute += SwitchState_CanExecute;
            switchState.Executed += SwitchState_Executed;
            CommandBindings.Add(switchState);

            //Hide command
            CommandBinding hide = new(WindowCommands.Hide);
            hide.CanExecute += Hide_CanExecute;
            hide.Executed += Hide_Executed;
            CommandBindings.Add(hide);

            //Show command
            CommandBinding show = new(WindowCommands.Show);
            show.CanExecute += Show_CanExecute;
            show.Executed += Show_Executed;
            CommandBindings.Add(show);

            //Drag command
            CommandBinding drag = new(WindowCommands.Drag);
            drag.CanExecute += Drag_CanExecute;
            drag.Executed += Drag_Executed;
            CommandBindings.Add(drag);

            //Action command
            CommandBinding action = new(WindowCommands.Action);
            action.CanExecute += Action_CanExecute;
            action.Executed += Action_Executed;
            CommandBindings.Add(action);
        }

        #endregion

        #region Commands

        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Minimize_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = ResizeMode != ResizeMode.NoResize;

        private void Maximize_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip;

        private void Restore_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = ResizeMode != ResizeMode.NoResize;

        private void SwitchState_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = EnableDoubleClickMaximizeRestore && (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip);

        private void Hide_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Show_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Drag_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Action_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e) => Close();

        private void Minimize_Executed(object sender, ExecutedRoutedEventArgs e) => Minimize();

        private void Maximize_Executed(object sender, ExecutedRoutedEventArgs e) => Maximize();

        private void Restore_Executed(object sender, ExecutedRoutedEventArgs e) => Restore();

        private void SwitchState_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized) Restore();
            else Maximize();
        }

        private void Hide_Executed(object sender, ExecutedRoutedEventArgs e) => Hide();

        private void Show_Executed(object sender, ExecutedRoutedEventArgs e) => Show();

        private void Drag_Executed(object sender, ExecutedRoutedEventArgs e) => DragMove();

        private void Action_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string actionName = e.Parameter is string parameter ? parameter : "ACTION_UNKNOWN";
            OnActionExecuted(new CommandAction(actionName, e.Command));
        }

        #endregion

        /// <summary>
        /// Handles the window messages.
        /// </summary>
        private IntPtr HandleMessages(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WindowCore.WM_SYSCOMMAND && ((int)wParam & 0xFFF0) == WindowCore.SC_MINIMIZE)
            {
                handled = true;
                if (EnableMinimizeByTaskbar) Minimize();
            }
            else if (msg == WindowCore.WM_NCPAINT)
            {
                handled = false;
                WindowCore.RemoveFrame(this, new Thickness(0, 0, 0, 1));
            }
            else if (msg == WindowCore.WM_NCCALCSIZE)
            {
                handled = true;
                return WindowCore.WmNcCalcSize(wParam, lParam);
            }

            return IntPtr.Zero;
        }

        #endregion
    }
}
