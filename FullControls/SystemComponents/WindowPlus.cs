using FullControls.Common;
using FullControls.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.
    /// </summary>
    public abstract class WindowPlus : Window, IVState
    {
        private bool loaded = false;
        private WindowState previousState = WindowState.Normal;

        /// <summary>
        /// <see cref="CornerRadius"/> used in Windows 11.
        /// </summary>
        public static readonly CornerRadius WIN11_CORNER_RADIUS = new(8);

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
            DependencyProperty.Register(nameof(BorderBrushOnActive), typeof(Brush), typeof(WindowPlus));

        /// <summary>
        /// Gets the actual border brush of the control.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        #region ActualBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBorderBrush), typeof(Brush), typeof(WindowPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty = ActualBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualBorderBrushProxy", typeof(Brush), typeof(WindowPlus),
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
            DependencyProperty.Register(nameof(ForegroundOnActive), typeof(Brush), typeof(WindowPlus));

        /// <summary>
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(WindowPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(WindowPlus),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualForegroundPropertyKey, e.NewValue))));

        #endregion

        #region Titlebar properties

        /// <summary>
        /// Gets or sets a value indicating if enable the titlebar.
        /// </summary>
        public bool EnableTitlebar
        {
            get => (bool)GetValue(EnableTitlebarProperty);
            set => SetValue(EnableTitlebarProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableTitlebar"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableTitlebarProperty =
            DependencyProperty.Register(nameof(EnableTitlebar), typeof(bool), typeof(WindowPlus),
                new FrameworkPropertyMetadata(BoolBox.True, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// <para>Gets or sets a value indicating if merge the titlebar with the content.</para>
        /// <para>The titlebar becomes transparent and is displayed above the content.</para>
        /// </summary>
        public bool MergeTitlebarAndContent
        {
            get => (bool)GetValue(MergeTitlebarAndContentProperty);
            set => SetValue(MergeTitlebarAndContentProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="MergeTitlebarAndContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MergeTitlebarAndContentProperty =
            DependencyProperty.Register(nameof(MergeTitlebarAndContent), typeof(bool), typeof(WindowPlus),
                new FrameworkPropertyMetadata(BoolBox.False, FrameworkPropertyMetadataOptions.AffectsMeasure));

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
            DependencyProperty.Register(nameof(TitlebarContextMenu), typeof(ContextMenu), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(TitlebarMargin), typeof(Thickness), typeof(WindowPlus),
                new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure));

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
            DependencyProperty.Register(nameof(TitlebarBackground), typeof(Brush), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(TitlebarBackgroundOnActive), typeof(Brush), typeof(WindowPlus));

        /// <summary>
        /// Gets the actual background brush of the titlebar.
        /// </summary>
        public Brush ActualTitlebarBackground => (Brush)GetValue(ActualTitlebarBackgroundProperty);

        #region ActualTitlebarBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualTitlebarBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualTitlebarBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualTitlebarBackground), typeof(Brush), typeof(WindowPlus),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualTitlebarBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualTitlebarBackgroundProperty = ActualTitlebarBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualTitlebarBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualTitlebarBackgroundPropertyProxy =
            DependencyProperty.Register("ActualTitlebarBackgroundProxy", typeof(Brush), typeof(WindowPlus),
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
            DependencyProperty.Register(nameof(TitleMargin), typeof(Thickness), typeof(WindowPlus),
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
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(IconBackground), typeof(Brush), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(ButtonsAreaMargin), typeof(Thickness), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(ButtonsAreaBackground), typeof(Brush), typeof(WindowPlus));

        #region Caption buttons properties

        /// <summary>
        /// Gets or sets a value indicating if enable the minimize button.
        /// </summary>
        public bool EnableMinimizeButton
        {
            get => (bool)GetValue(EnableMinimizeButtonProperty);
            set => SetValue(EnableMinimizeButtonProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableMinimizeButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMinimizeButtonProperty =
            DependencyProperty.Register(nameof(EnableMinimizeButton), typeof(bool), typeof(WindowPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the maximize button.
        /// </summary>
        public bool EnableMaximizeButton
        {
            get => (bool)GetValue(EnableMaximizeButtonProperty);
            set => SetValue(EnableMaximizeButtonProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableMaximizeButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMaximizeButtonProperty =
            DependencyProperty.Register(nameof(EnableMaximizeButton), typeof(bool), typeof(WindowPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the restore button.
        /// </summary>
        public bool EnableRestoreButton
        {
            get => (bool)GetValue(EnableRestoreButtonProperty);
            set => SetValue(EnableRestoreButtonProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableRestoreButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableRestoreButtonProperty =
            DependencyProperty.Register(nameof(EnableRestoreButton), typeof(bool), typeof(WindowPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the close button.
        /// </summary>
        public bool EnableCloseButton
        {
            get => (bool)GetValue(EnableCloseButtonProperty);
            set => SetValue(EnableCloseButtonProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableCloseButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableCloseButtonProperty =
            DependencyProperty.Register(nameof(EnableCloseButton), typeof(bool), typeof(WindowPlus),
                new PropertyMetadata(BoolBox.True));

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
            DependencyProperty.Register(nameof(MinimizeButtonStyle), typeof(Style), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(MaximizeButtonStyle), typeof(Style), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(RestoreButtonStyle), typeof(Style), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(CloseButtonStyle), typeof(Style), typeof(WindowPlus));

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
            DependencyProperty.Register(nameof(ResizeThickness), typeof(Thickness), typeof(WindowPlus),
                new FrameworkPropertyMetadata(new Thickness(4d), FrameworkPropertyMetadataOptions.AffectsMeasure,
                    new PropertyChangedCallback((d, e) => ((WindowPlus)d).OnResizeThicknessChanged((Thickness)e.NewValue))));

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
            DependencyProperty.Register(nameof(EnableMinimizeByTaskbar), typeof(bool), typeof(WindowPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets the outside margin of the window.
        /// </summary>
        public Thickness OutsideMargin => (Thickness)GetValue(OutsideMarginProperty);

        #region OutsideMarginProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="OutsideMargin"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey OutsideMarginPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(OutsideMargin), typeof(Thickness), typeof(WindowPlus),
                new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure,
                    new PropertyChangedCallback((d, e) => ((WindowPlus)d).OnOutsideMarginChanged((Thickness)e.NewValue))));

        /// <summary>
        /// Identifies the <see cref="OutsideMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OutsideMarginProperty = OutsideMarginPropertyKey.DependencyProperty;

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
            DependencyProperty.RegisterReadOnly(nameof(IsDocked), typeof(bool), typeof(WindowPlus),
                new PropertyMetadata(BoolBox.False, new PropertyChangedCallback((d, e)
                    => ((WindowPlus)d).OnIsDockedChanged((bool)e.NewValue))));

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
            DependencyProperty.RegisterReadOnly(nameof(IsHided), typeof(bool), typeof(WindowPlus),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Identifies the <see cref="IsHided"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsHidedProperty = IsHidedPropertyKey.DependencyProperty;

        #endregion

        #region Preview events

        /// <summary>
        /// Occurs immediately before <see cref="Close"/> is executed.
        /// </summary>
        public event EventHandler<CancelEventArgs>? PreviewClose;

        /// <summary>
        /// Occurs immediately before <see cref="Minimize"/> is executed.
        /// </summary>
        public event EventHandler<CancelEventArgs>? PreviewMinimize;

        #endregion

        #region Commands events

        /// <summary>
        /// <para>Occurs when the <see cref="WindowCommands.Close"/> command is sended to the window.</para>
        /// <para>It occurs immediately after the user clicks the close button,
        /// allowing to distinguish between clicking the button and close the window via code behind.</para>
        /// </summary>
        public event EventHandler<EventArgs>? CloseCommandExecuting;

        /// <summary>
        /// <para>Occurs when the <see cref="WindowCommands.Minimize"/> command is sended to the window.</para>
        /// <para>It occurs immediately after the user clicks the minimize button,
        /// allowing to distinguish between clicking the button and close the window via code behind.</para>
        /// </summary>
        public event EventHandler<EventArgs>? MinimizeCommandExecuting;

        /// <summary>
        /// <para>Occurs when the <see cref="WindowCommands.Maximize"/> command is sended to the window.</para>
        /// <para>It occurs immediately after the user clicks the maximize button,
        /// allowing to distinguish between clicking the button and close the window via code behind.</para>
        /// </summary>
        public event EventHandler<EventArgs>? MaximizeCommandExecuting;

        /// <summary>
        /// <para>Occurs when the <see cref="WindowCommands.Restore"/> command is sended to the window.</para>
        /// <para>It occurs immediately after the user clicks the restore button,
        /// allowing to distinguish between clicking the button and close the window via code behind.</para>
        /// </summary>
        public event EventHandler<EventArgs>? RestoreCommandExecuting;

        #endregion

        /// <summary>
        /// Occurs when an <see cref="IAction"/> is executed.
        /// </summary>
        public event EventHandler<ActionEventArgs>? ActionExecuted;


        static WindowPlus()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowPlus),
                new FrameworkPropertyMetadata(typeof(WindowPlus)));

            IsEnabledProperty.OverrideMetadata(typeof(WindowPlus),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((WindowPlus)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WindowPlus"/>.
        /// </summary>
        public WindowPlus() : base()
        {
            Initialize();
            OnInitializing();
        }

        #region Initialization

        private void Initialize()
        {
            Loaded += (o, e) => OnLoaded(e);
            DependencyPropertyDescriptor.FromProperty(IsActiveProperty, typeof(WindowPlus))
                ?.AddValueChanged(this, (s, e) => OnActiveChanged(IsActive));
            InitializeCommands();
        }

        private void InitializeCommands()
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

        /// <summary>
        /// Executed when the object is initializing (is called directly in the main constructor).
        /// </summary>
        protected virtual void OnInitializing() { }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateOutsideMargin();
            loaded = true;
            OnVStateChanged(GetCurrentVState(), true);
        }

        /// <inheritdoc/>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            this.AddHook(HandleMinimize);
            this.AddHook(HandleSystemMenu);
        }

        /// <summary>
        /// Called when the window is loaded.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnVStateChanged(GetCurrentVState());

        /// <summary>
        /// Called when <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(GetCurrentVState());

        /// <summary>
        /// Called when <see cref="Window.IsActive"/> is changed.
        /// </summary>
        /// <param name="activeState">Actual state of <see cref="Window.IsActive"/>.</param>
        protected virtual void OnActiveChanged(bool activeState) => OnVStateChanged(GetCurrentVState());

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
            CommandManager.InvalidateRequerySuggested();
            OnStateChanged(WindowState, previousState);
            previousState = WindowState;
        }

        /// <summary>
        /// Called when <see cref="Window.WindowState"/> is changed.
        /// </summary>
        /// <param name="state">Current <see cref="WindowState"/>.</param>
        /// <param name="previousState">Previous <see cref="WindowState"/>.</param>
        protected virtual void OnStateChanged(WindowState state, WindowState previousState) => UpdateOutsideMargin();

        /// <summary>
        /// Called when <see cref="IsDocked"/> is changed.
        /// </summary>
        /// <param name="isDocked">Actual state of <see cref="IsDocked"/>.</param>
        protected virtual void OnIsDockedChanged(bool isDocked) => UpdateOutsideMargin();

        /// <summary>
        /// Force the update of <see cref="OutsideMargin"/>.
        /// </summary>
        protected void UpdateOutsideMargin() => SetValue(OutsideMarginPropertyKey, CalcOutsideMargin());

        /// <summary>
        /// Override this method to change the calculation of <see cref="OutsideMargin"/>.
        /// </summary>
        /// <returns><see cref="OutsideMargin"/> thickness.</returns>
        protected abstract Thickness CalcOutsideMargin();

        /// <summary>
        /// Called when <see cref="ResizeThickness"/> is changed.
        /// </summary>
        /// <param name="thickness">New thickness value.</param>
        protected virtual void OnResizeThicknessChanged(Thickness thickness) { }

        /// <summary>
        /// Called when <see cref="OutsideMargin"/> is changed.
        /// </summary>
        /// <param name="thickness">New thickness value.</param>
        protected virtual void OnOutsideMarginChanged(Thickness thickness) { }

        /// <summary>
        /// Called when an action is executed.
        /// </summary>
        /// <param name="action">Action executed.</param>
        protected virtual void OnActionExecuted(IAction action)
            => ActionExecuted?.Invoke(this, new ActionEventArgs(action));

        /// <inheritdoc/>
        public VState GetCurrentVState()
        {
            if (!loaded) return VState.UNSET;
            if (!IsEnabled) return VStates.DISABLED;
            else if (!IsActive) return VStates.INACTIVE;
            else return VStates.ACTIVE;
        }

        /// <summary>
        /// Called when the current <see cref="VState"/> is changed.
        /// </summary>
        /// <param name="vstate">Current <see cref="VState"/>.</param>
        /// <param name="initial">Specifies if this is the initial <see cref="VState"/>.</param>
        protected virtual void OnVStateChanged(VState vstate, bool initial = false)
        {
            if (vstate == VStates.ACTIVE)
            {
                Util.AnimateBrush(this, ActualTitlebarBackgroundPropertyProxy, TitlebarBackgroundOnActive, TimeSpan.Zero);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrushOnActive, TimeSpan.Zero);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnActive, TimeSpan.Zero);
            }
            else if (vstate == VStates.INACTIVE)
            {
                Util.AnimateBrush(this, ActualTitlebarBackgroundPropertyProxy, TitlebarBackground, TimeSpan.Zero);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, TimeSpan.Zero);
            }
            else if (vstate == VStates.DISABLED)
            {
                Util.AnimateBrush(this, ActualTitlebarBackgroundPropertyProxy, TitlebarBackground, TimeSpan.Zero);
                Util.AnimateBrush(this, ActualBorderBrushPropertyProxy, BorderBrush, TimeSpan.Zero);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, TimeSpan.Zero);
            }
        }

        #region WindowHandlers

        /// <summary>
        /// Close the window.
        /// </summary>
        public new virtual void Close()
        {
            if (RequestClose()) PerformClose();
        }

        /// <summary>
        /// Minimize the window.
        /// </summary>
        public virtual void Minimize()
        {
            if (RequestMinimize()) PerformMinimize();
        }

        /// <summary>
        /// Maximize the window.
        /// </summary>
        public virtual void Maximize() => PerformMaximize();

        /// <summary>
        /// Restore the window.
        /// </summary>
        public virtual void Restore() => PerformRestore();

        /// <summary>
        /// Makes the window invisible.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        public new virtual void Hide() => PerformHide();

        /// <summary>
        /// Opens the window and returns without waiting for the newly opened window to close.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        public new virtual void Show() => PerformShow();

        /// <summary>
        /// Opens the window and returns only when the newly opened window is closed.
        /// </summary>
        /// <returns>A <see cref="Nullable{T}"/> value of type <see cref="bool"/> that specifies
        /// whether the activity was accepted (<see langword="true"/>) or canceled (<see langword="false"/>).
        /// The return value is the value of the <see cref="Window.DialogResult"/> property before a window closes.</returns>
        /// <exception cref="InvalidOperationException"/>
        public new virtual bool? ShowDialog() => PerformShowDialog();

        #region Commands performers

        /// <summary>
        /// Actually closes the window.
        /// </summary>
        protected void PerformClose()
        {
            SetValue(IsHidedPropertyKey, BoolBox.True);
            base.Close();
        }

        /// <summary>
        /// Actually minimizes the window.
        /// </summary>
        protected void PerformMinimize() => WindowState = WindowState.Minimized;

        /// <summary>
        /// Actually maximimizes the window.
        /// </summary>
        protected void PerformMaximize() => WindowState = WindowState.Maximized;

        /// <summary>
        /// Actually restores the window.
        /// </summary>
        protected void PerformRestore() => WindowState = WindowState.Normal;

        /// <summary>
        /// Actually hides the window.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        protected void PerformHide()
        {
            SetValue(IsHidedPropertyKey, BoolBox.True);
            base.Hide();
        }

        /// <summary>
        /// Actually shows the window.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        protected void PerformShow()
        {
            SetValue(IsHidedPropertyKey, BoolBox.False);
            base.Show();
        }

        /// <summary>
        /// Actually shows the window as a dialog.
        /// </summary>
        /// <returns>A <see cref="Nullable{T}"/> value of type <see cref="bool"/> that specifies
        /// whether the activity was accepted (<see langword="true"/>) or canceled (<see langword="false"/>).
        /// The return value is the value of the <see cref="Window.DialogResult"/> property before a window closes.</returns>
        /// <exception cref="InvalidOperationException"/>
        protected bool? PerformShowDialog()
        {
            SetValue(IsHidedPropertyKey, BoolBox.False);
            return base.ShowDialog();
        }

        #endregion

        #region Commands requesters

        //Request for commands that could be canceled.

        /// <summary>
        /// Request if close the window.
        /// </summary>
        /// <returns><see langword="true"/> if the close operation can be performed, <see langword="false"/> otherwise.</returns>
        protected bool RequestClose()
        {
            CancelEventArgs e = new();
            PreviewClose?.Invoke(this, e);
            return !e.Cancel;
        }

        /// <summary>
        /// Request if minimize the window.
        /// </summary>
        /// <returns><see langword="true"/> if the minimize operation can be performed, <see langword="false"/> otherwise.</returns>
        protected bool RequestMinimize()
        {
            CancelEventArgs e = new();
            PreviewMinimize?.Invoke(this, e);
            return !e.Cancel && WindowState != WindowState.Minimized;
        }

        #endregion

        #endregion

        #region EventHandlers

        #region Commands handlers

        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Minimize_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = ResizeMode != ResizeMode.NoResize &&
                              WindowState != WindowState.Minimized;

        private void Maximize_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip) &&
                              WindowState != WindowState.Maximized;

        private void Restore_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = ResizeMode != ResizeMode.NoResize &&
                              WindowState != WindowState.Normal;

        private void Hide_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Show_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Drag_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Action_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CloseCommandExecuting?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void Minimize_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MinimizeCommandExecuting?.Invoke(this, EventArgs.Empty);
            Minimize();
        }

        private void Maximize_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MaximizeCommandExecuting?.Invoke(this, EventArgs.Empty);
            Maximize();
        }

        private void Restore_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RestoreCommandExecuting?.Invoke(this, EventArgs.Empty);
            Restore();
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

        #region Hooks

        /// <summary>
        /// Handles the minimization.
        /// </summary>
        private IntPtr HandleMinimize(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WindowCore.WM_SYSCOMMAND && ((long)wParam & 0xFFF0) == WindowCore.SC_MINIMIZE)
            {
                handled = true;
                if (EnableMinimizeByTaskbar) Minimize();
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Hides the system menu.
        /// </summary>
        private IntPtr HandleSystemMenu(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if ((long)wParam == WindowCore.WP_SYSTEMMENU && (msg == WindowCore.VK_LMENU || msg == WindowCore.VK_RMENU))
            {
                handled = true;
            }

            return IntPtr.Zero;
        }

        #endregion

        #endregion


        /// <summary>
        /// Window v-states.
        /// </summary>
        public static class VStates
        {
            /// <summary>
            /// The window is active.
            /// </summary>
            public static readonly VState ACTIVE = new(nameof(ACTIVE), typeof(WindowPlus));

            /// <summary>
            /// The window is inactive.
            /// </summary>
            public static readonly VState INACTIVE = new(nameof(INACTIVE), typeof(WindowPlus));

            /// <summary>
            /// The window is disabled.
            /// </summary>
            public static readonly VState DISABLED = new(nameof(DISABLED), typeof(WindowPlus));
        }
    }
}
