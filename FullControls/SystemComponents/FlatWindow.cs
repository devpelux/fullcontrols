using FullControls.Common;
using FullControls.Core;
using FullControls.Extra;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
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
    [TemplatePart(Name = PartTitleBar, Type = typeof(TitleBar))]
    public class FlatWindow : Window
    {
        private WindowState beforeState;
        private WindowChrome windowChrome, maxWindowChrome;

        /// <summary>
        /// TitleBar template part.
        /// </summary>
        protected const string PartTitleBar = "PART_TitleBar";

        /// <summary>
        /// Height of the toolbar.
        /// </summary>
        public const double TOOLBAR_HEIGHT = 32;

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
            DependencyProperty.Register(nameof(ResizeThickness), typeof(Thickness), typeof(FlatWindow),
                new FrameworkPropertyMetadata(new Thickness(), new PropertyChangedCallback((d, e) => ((FlatWindow)d).OnResizeThicknessChanged((Thickness)e.NewValue))));

        #region Shadow

        /// <summary>
        /// Gets or sets the color of the shadow.
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
            DependencyProperty.Register(nameof(ShadowColor), typeof(Color), typeof(FlatWindow));

        /// <summary>
        /// Gets or sets the opacity of the shadow.
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
            DependencyProperty.Register(nameof(ShadowOpacity), typeof(double), typeof(FlatWindow));

        /// <summary>
        /// Gets or sets the radius of the shadow.
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
            DependencyProperty.Register(nameof(ShadowRadius), typeof(double), typeof(FlatWindow),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateMarginForShadow(d))));

        /// <summary>
        /// Gets or sets the depth of the shadow.
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
            DependencyProperty.Register(nameof(ShadowDepth), typeof(double), typeof(FlatWindow),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateMarginForShadow(d))));

        #region MarginForShadow

        /// <summary>
        /// Gets the margin used to display the shadow.
        /// </summary>
        public Thickness MarginForShadow => (Thickness)GetValue(MarginForShadowProperty);

        #region MarginForShadowProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="MarginForShadow"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey MarginForShadowPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(MarginForShadow), typeof(Thickness), typeof(FlatWindow),
                new FrameworkPropertyMetadata(new Thickness()));

        /// <summary>
        /// Identifies the <see cref="MarginForShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MarginForShadowProperty = MarginForShadowPropertyKey.DependencyProperty;

        #endregion

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FlatWindow));

        /// <summary>
        /// Gets or sets a value indicating if enable the minimize action using the taskbar.
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
            DependencyProperty.Register(nameof(EnableMinimizeByTaskbar), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the maximize and restore action by double click on toolbar.
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
            DependencyProperty.Register(nameof(EnableDoubleClickMaximizeRestore), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

        #region Titlebar properties

        /// <summary>
        /// <para>Gets or sets a value indicating if merge the titlebar with the content.</para>
        /// <para>The titlebar becomes transparent and is displayed above the content.</para>
        /// <para>Suggestion 1: Use <see cref="DragAreaMargin"/> to resize the clickable part if you want insert a menu in the titlebar.</para>
        /// <para>Suggestion 2: Customize the brushes of the caption buttons.</para>
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
            DependencyProperty.Register(nameof(MergeTitlebarAndContent), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.False));

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
            DependencyProperty.Register(nameof(TitlebarMargin), typeof(Thickness), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(TitlebarBackground), typeof(Brush), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(TitleMargin), typeof(Thickness), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(IconBackground), typeof(Brush), typeof(FlatWindow));

        /// <summary>
        /// Gets or sets a value indicating if enable the titlebar drag area.
        /// </summary>
        public bool EnableDragArea
        {
            get => (bool)GetValue(EnableDragAreaProperty);
            set => SetValue(EnableDragAreaProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableDragArea"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableDragAreaProperty =
            DependencyProperty.Register(nameof(EnableDragArea), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets the margin of the titlebar drag area.
        /// </summary>
        public Thickness DragAreaMargin
        {
            get => (Thickness)GetValue(DragAreaMarginProperty);
            set => SetValue(DragAreaMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DragAreaMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DragAreaMarginProperty =
            DependencyProperty.Register(nameof(DragAreaMargin), typeof(Thickness), typeof(FlatWindow));

        /// <summary>
        /// Gets or sets the background brush of the titlebar drag area.
        /// </summary>
        public Brush DragAreaBackground
        {
            get => (Brush)GetValue(DragAreaBackgroundProperty);
            set => SetValue(DragAreaBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DragAreaBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DragAreaBackgroundProperty =
            DependencyProperty.Register(nameof(DragAreaBackground), typeof(Brush), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(ButtonsAreaMargin), typeof(Thickness), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(ButtonsAreaBackground), typeof(Brush), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(TitlebarContextMenu), typeof(ContextMenu), typeof(FlatWindow));

        #region Caption buttons

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
            DependencyProperty.Register(nameof(MinimizeButtonStyle), typeof(Style), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(MaximizeButtonStyle), typeof(Style), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(RestoreButtonStyle), typeof(Style), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(CloseButtonStyle), typeof(Style), typeof(FlatWindow));

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
            DependencyProperty.Register(nameof(EnableMinimizeButton), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

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
            DependencyProperty.Register(nameof(EnableMaximizeButton), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

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
            DependencyProperty.Register(nameof(EnableRestoreButton), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

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
            DependencyProperty.Register(nameof(EnableCloseButton), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

        #endregion

        #endregion

        /// <summary>
        /// Gets or sets a value indicating if start the window hided.
        /// </summary>
        public bool StartHided
        {
            get => (bool)GetValue(StartHidedProperty);
            set => SetValue(StartHidedProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="StartHided"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty StartHidedProperty =
            DependencyProperty.Register(nameof(StartHided), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.False));

        /// <summary>
        /// Gets a value indicating if the window is docked.
        /// </summary>
        public bool IsDocked => (bool)GetValue(IsDockedProperty);

        #region IsDockedProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="IsDocked"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey IsDockedPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsDocked), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.False));

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
            DependencyProperty.RegisterReadOnly(nameof(IsHided), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Identifies the <see cref="IsHided"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsHidedProperty = IsHidedPropertyKey.DependencyProperty;

        #endregion

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FlatWindow));

        /// <summary>
        /// Gets or sets a value indicating if fix the height and the width of the window to be the same as in designer of Visual Studio.
        /// </summary>
        /// <remarks>(Has effect only on initialization)</remarks>
        public bool FixVSDesigner
        {
            get => (bool)GetValue(FixVSDesignerProperty);
            set => SetValue(FixVSDesignerProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="FixVSDesigner"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FixVSDesignerProperty =
            DependencyProperty.Register(nameof(FixVSDesigner), typeof(bool), typeof(FlatWindow), new PropertyMetadata(BoolBox.True));

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


        static FlatWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatWindow), new FrameworkPropertyMetadata(typeof(FlatWindow)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FlatWindow"/>.
        /// </summary>
        public FlatWindow() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
            LoadCommands();
        }



        #region Commands

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

            //MaximizeRestore command
            CommandBinding maximizeRestore = new(WindowCommands.MaximizeRestore);
            maximizeRestore.CanExecute += MaximizeRestore_CanExecute;
            maximizeRestore.Executed += MaximizeRestore_Executed;
            CommandBindings.Add(maximizeRestore);

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

        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void Minimize_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            //e.CanExecute = WindowState != WindowState.Minimized;
        }

        private void Minimize_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Minimize();
        }

        private void Maximize_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            //e.CanExecute = WindowState != WindowState.Maximized;
        }

        private void Maximize_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Maximize();
        }

        private void Restore_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            //e.CanExecute = WindowState == WindowState.Maximized || WindowState == WindowState.Minimized;
        }

        private void Restore_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Restore();
        }

        private void MaximizeRestore_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = EnableDoubleClickMaximizeRestore && (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip);
        }

        private void MaximizeRestore_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized) Restore();
            else Maximize();
        }

        private void Hide_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            //e.CanExecute = !IsHided;
        }

        private void Hide_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Hide();
        }

        private void Show_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            //e.CanExecute = IsHided;
        }

        private void Show_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Show();
        }

        private void Drag_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Drag_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DragMove();
        }

        private void Action_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Action_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string actionName = e.Parameter is string parameter ? parameter : "ACTION_UNKNOWN";
            OnActionExecuted(new CommandAction(actionName, e.Command));
        }

        #endregion

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ((HwndSource)PresentationSource.FromVisual(this)).AddHook(new HwndSourceHook(HandleMessages));
            LoadWindowChromes();
            LoadInitialState();
        }

        /// <summary>
        /// Loads the initial window state.
        /// </summary>
        private void LoadInitialState()
        {
            Opacity = 0; //Initial state
            beforeState = WindowState;
        }

        /// <summary>
        /// Called when an action is executed.
        /// </summary>
        /// <param name="action">Action executed.</param>
        protected virtual void OnActionExecuted(IAction action)
        {
            ActionExecuted?.Invoke(this, new ActionEventArgs(action));
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
                GlassFrameThickness = new Thickness(0),
                ResizeBorderThickness = ResizeThickness
            };
            maxWindowChrome = new WindowChrome()
            {
                CaptionHeight = 0,
                CornerRadius = new CornerRadius(0),
                GlassFrameThickness = new Thickness(0),
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
                GlassFrameThickness = new Thickness(0),
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

        /// <summary>
        /// Called when the window is loaded.
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
            SetValue(IsDockedPropertyKey, BoolBox.Box(WindowState == WindowState.Normal && Width != RestoreBounds.Width && Height != RestoreBounds.Height));
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
            PreviewClose?.Invoke(this, e);
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
            PreviewMinimize?.Invoke(this, e);
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

        /// <summary>
        /// Allows a window to be dragged by a mouse with its left button down over an exposed area of the window's client area.
        /// </summary>
        /// <exception cref="InvalidOperationException">The left mouse button is not down.</exception>
        public new void DragMove()
        {
            if (WindowState == WindowState.Maximized)
            {
                Point curpos = Tools.GetCursorPos();
                double targetVertical = TOOLBAR_HEIGHT / 2;
                double targetHorizontal = curpos.X < RestoreBounds.Width / 2 ? curpos.X
                                        : curpos.X > ActualWidth - (RestoreBounds.Width / 2) ? RestoreBounds.Width - (ActualWidth - curpos.X)
                                        : RestoreBounds.Width / 2;

                WindowState = WindowState.Normal;

                Top = curpos.Y - targetVertical - MarginForShadow.Left;
                Left = curpos.X - targetHorizontal - MarginForShadow.Top;
            }
            base.DragMove();
        }

        #endregion

        #region VSDesignerFix

        /// <summary>
        /// Offset of height between Visual Stuio designer and reality.
        /// </summary>
        /// <returns>Offset of height.</returns>
        private double VSDesignerHeightOffset() => MarginForShadow.Top + MarginForShadow.Bottom + (!MergeTitlebarAndContent ? TOOLBAR_HEIGHT : 0);

        /// <summary>
        /// Offset of width between Visual Stuio designer and reality.
        /// </summary>
        /// <returns>Offset of width.</returns>
        private double VSDesignerWidthOffset() => MarginForShadow.Left + MarginForShadow.Right;

        #endregion
    }
}
