using FullControls.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Represents a standard window title bar with an icon, a title, and four caption buttons.
    /// </summary>
    [TemplatePart(Name = PartDragArea, Type = typeof(UIElement))]
    public class WindowTitleBar : TitleBar
    {
        /// <summary>
        /// TitleBar template part.
        /// </summary>
        protected const string PartDragArea = "PART_DragArea";

        /// <summary>
        /// Gets or sets the margin of the title.
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
            DependencyProperty.Register(nameof(TitleMargin), typeof(Thickness), typeof(WindowTitleBar));

        /// <summary>
        /// Gets or sets the icon.
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
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(WindowTitleBar));

        /// <summary>
        /// Gets or sets the margin of the icon.
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
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(WindowTitleBar));

        /// <summary>
        /// Gets or sets the background brush of the icon.
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
            DependencyProperty.Register(nameof(IconBackground), typeof(Brush), typeof(WindowTitleBar),
                new FrameworkPropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Gets or sets a value indicating if enable the drag area.
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
            DependencyProperty.Register(nameof(EnableDragArea), typeof(bool), typeof(WindowTitleBar),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets the margin of the drag area.
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
            DependencyProperty.Register(nameof(DragAreaMargin), typeof(Thickness), typeof(WindowTitleBar));

        /// <summary>
        /// Gets or sets the background brush of the drag area.
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
            DependencyProperty.Register(nameof(DragAreaBackground), typeof(Brush), typeof(WindowTitleBar),
                new FrameworkPropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Gets or sets the context menu of the title bar.
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
            DependencyProperty.Register(nameof(TitlebarContextMenu), typeof(ContextMenu), typeof(WindowTitleBar));

        /// <summary>
        /// Gets or sets the margin of the buttons area.
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
            DependencyProperty.Register(nameof(ButtonsAreaMargin), typeof(Thickness), typeof(WindowTitleBar));

        /// <summary>
        /// Gets or sets the background brush of the buttons area.
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
            DependencyProperty.Register(nameof(ButtonsAreaBackground), typeof(Brush), typeof(WindowTitleBar));

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
            DependencyProperty.Register(nameof(EnableMinimizeButton), typeof(bool), typeof(WindowTitleBar),
                new PropertyMetadata(BoolBox.True));

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
            DependencyProperty.Register(nameof(EnableMaximizeButton), typeof(bool), typeof(WindowTitleBar),
                new PropertyMetadata(BoolBox.True));

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
            DependencyProperty.Register(nameof(EnableRestoreButton), typeof(bool), typeof(WindowTitleBar),
                new PropertyMetadata(BoolBox.True));

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
            DependencyProperty.Register(nameof(EnableCloseButton), typeof(bool), typeof(WindowTitleBar),
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
            DependencyProperty.Register(nameof(MinimizeButtonStyle), typeof(Style), typeof(WindowTitleBar));

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
            DependencyProperty.Register(nameof(MaximizeButtonStyle), typeof(Style), typeof(WindowTitleBar));

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
            DependencyProperty.Register(nameof(RestoreButtonStyle), typeof(Style), typeof(WindowTitleBar));

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
            DependencyProperty.Register(nameof(CloseButtonStyle), typeof(Style), typeof(WindowTitleBar));

        #endregion


        static WindowTitleBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowTitleBar),
                new FrameworkPropertyMetadata(typeof(WindowTitleBar)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="WindowTitleBar"/>.
        /// </summary>
        public WindowTitleBar() : base() { }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UIElement dragArea = (UIElement)Template.FindName(PartDragArea, this);
            if (dragArea != null)
            {
                dragArea.MouseLeftButtonDown += PART_DragArea_MouseLeftButtonDown;
                dragArea.MouseMove += PART_DragArea_MouseMove;
                dragArea.TouchMove += PART_DragArea_TouchMove;
            }
        }

        #region Drag area event handlers

        /// <summary>
        /// Called when the drag area is clicked by the mouse left button.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_DragArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            if (e.ClickCount >= 2) WindowCommands.SwitchState.Execute(null, this);
        }

        /// <summary>
        /// Called when the mouse is moved above the drag area.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_DragArea_MouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
            if (e.LeftButton == MouseButtonState.Pressed) WindowCommands.Drag.Execute(null, this);
        }

        /// <summary>
        /// Called when the touch is moved above the drag area.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_DragArea_TouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
            WindowCommands.Drag.Execute(null, this);
        }

        #endregion
    }
}
