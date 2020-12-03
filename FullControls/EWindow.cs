﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Shell;
using System.Windows.Media;
using System.Windows.Interop;
using FullControls.Core;
using FullControls.Extra;

namespace FullControls
{
    /// <summary>
    /// Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.
    /// </summary>
    public class EWindow : Window
    {
        private WindowState beforeState;
        private WindowChrome windowChrome, maxWindowChrome;
        private bool canMove = true;

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
                new PropertyMetadata(new Thickness(), new PropertyChangedCallback((d, e) => ((EWindow)d).OnResizeThicknessChanged((Thickness)e.NewValue))));

        #region BorderMargin

        /// <summary>
        /// Margin of the window used to display the shadow.
        /// </summary>
        internal Thickness BorderMargin => (Thickness)GetValue(BorderMarginProperty);

        /// <summary>
        /// Identifies the <see cref="BorderMargin"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty BorderMarginProperty =
            DependencyProperty.Register(nameof(BorderMargin), typeof(Thickness), typeof(EWindow), new PropertyMetadata(new Thickness()));

        #endregion

        /// <summary>
        /// Radius of the shadow behind the window.
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
                new PropertyMetadata(0d, new PropertyChangedCallback((d, e) => d.SetValue(BorderMarginProperty, new Thickness((double)e.NewValue)))));

        /// <summary>
        /// Opacity of the shadow behind the window.
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
        /// Depth of the shadow behind the window.
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
            DependencyProperty.Register(nameof(ShadowDepth), typeof(double), typeof(EWindow));

        /// <summary>
        /// Color of the shadow behind the window.
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

        /// <summary>
        /// Enables the minimize button.
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
            DependencyProperty.Register(nameof(EnableMinimizeButton), typeof(bool), typeof(EWindow));

        /// <summary>
        /// Enables the maximize/restore button.
        /// </summary>
        public bool EnableMaximizeRestoreButton
        {
            get => (bool)GetValue(EnableMaximizeRestoreButtonProperty);
            set => SetValue(EnableMaximizeRestoreButtonProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnableMaximizeRestoreButton"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMaximizeRestoreButtonProperty =
            DependencyProperty.Register(nameof(EnableMaximizeRestoreButton), typeof(bool), typeof(EWindow));

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
            DependencyProperty.Register(nameof(EnableCloseButton), typeof(bool), typeof(EWindow));

        /// <summary>
        /// <para>Merge the toolbar with the content.</para>
        /// <para>The toolbar becomes transparent and is displayed above the content.</para>
        /// <para>Suggestion 1: Use <see cref="ToolbarHitZoneMargin"/> to resize the clickable part if you want insert a menu in the toolbar.</para>
        /// <para>Suggestion 2: Customize the colors of the caption buttons.</para>
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
            DependencyProperty.Register(nameof(MergeToolbarAndContent), typeof(bool), typeof(EWindow));

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
            DependencyProperty.Register(nameof(EnableToolbarHitZone), typeof(bool), typeof(EWindow));

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
        /// <para>Background color of the toolbar.</para>
        /// <para>Note: If <see cref="MergeToolbarAndContent"/> is true this property has no effect.</para>
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
        /// Background color of the caption buttons.
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
        /// Background color of the caption buttons when the mouse is over them.
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
        /// Background color of the caption buttons when they are pressed.
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
        /// Foreground color of the caption buttons.
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
        /// Foreground color of the caption buttons when the mouse is over them.
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
        /// Foreground color of the caption buttons when they are pressed.
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
        /// <para>Fix the height and the width of the window to be the same as in designer of Visual Studio.</para>
        /// <para>(Has effect only on initialization)</para>
        /// </summary>
        public bool FixVSDesigner
        {
            get => (bool)GetValue(FixVSDesignerProperty);
            set => SetValue(FixVSDesignerProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="FixVSDesigner"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FixVSDesignerProperty =
            DependencyProperty.Register(nameof(FixVSDesigner), typeof(bool), typeof(EWindow), new PropertyMetadata(false));


        /// <summary>
        /// Creates a new <see cref="EWindow"/>.
        /// </summary>
        static EWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EWindow), new FrameworkPropertyMetadata(typeof(EWindow)));
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            LoadWindowChromes();
            ((HwndSource)PresentationSource.FromVisual(this)).AddHook(new HwndSourceHook(HandleMessages));
            Loaded += FullWindow_Loaded;
            ((Button)Template.FindName("PART_MinimizeButton", this)).Click += PART_MinimizeButton_Click;
            ((Button)Template.FindName("PART_MaximizeButton", this)).Click += PART_MaximizeButton_Click;
            ((Button)Template.FindName("PART_RestoreButton", this)).Click += PART_RestoreButton_Click;
            ((Button)Template.FindName("PART_CloseButton", this)).Click += PART_CloseButton_Click;
            ((Grid)Template.FindName("PART_ToolbarHitZone", this)).MouseMove += PART_ToolbarHitZone_MouseMove;
            ((Grid)Template.FindName("PART_ToolbarHitZone", this)).TouchMove += PART_ToolbarHitZone_TouchMove;
            ((Grid)Template.FindName("PART_ToolbarHitZone", this)).MouseLeftButtonDown += PART_ToolbarHitZone_MouseLeftButtonDown;
            ((Grid)Template.FindName("PART_ToolbarHitZone", this)).MouseRightButtonDown += PART_ToolbarHitZone_MouseRightButtonDown;
            ((Grid)Template.FindName("PART_Icon", this)).MouseDown += PART_Icon_MouseDown;
            if (FixVSDesigner)
            {
                Height += VSDesignerHeightOffset();
                Width += VSDesignerWidthOffset();
                MinHeight += VSDesignerHeightOffset();
                MinWidth += VSDesignerWidthOffset();
            }
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

        /// <summary>
        /// Called when the window is loaded.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void FullWindow_Loaded(object sender, RoutedEventArgs e)
        {
            EnterAnimation();
        }

        /// <summary>
        /// Called when minimize button is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Minimize();
        }

        /// <summary>
        /// Called when maximize button is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            Maximize();
        }

        /// <summary>
        /// Called when restore button is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            Restore();
        }

        /// <summary>
        /// Called when close button is clicked.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void PART_CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

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
            if (e.ClickCount >= 2 && (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip))
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

        /// <summary>
        /// Called when the window changed state.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            if (beforeState == WindowState.Minimized) AntiMinimizeAnimation();
            ApplyWindowChrome();
            beforeState = WindowState;
        }

        /// <summary>
        /// Handles the window messages
        /// </summary>
        private IntPtr HandleMessages(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == EWindowCore.WM_GETMINMAXINFO) EWindowCore.WmGetMinMaxInfo(hwnd, lParam);
            else if (msg == EWindowCore.WM_SYSCOMMAND && ((int)wParam & 0xFFF0) == EWindowCore.SC_MINIMIZE)
            {
                handled = true;
                Minimize();
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
            else WindowState = WindowState.Minimized;
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
            beforeState = WindowState.Normal;
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
            else base.Close();
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
            ExitAnimation();
        }

        /// <summary>
        /// Minimize the window.
        /// </summary>
        public void Minimize()
        {
            MinimizeAnimation();
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

        /// <summary>
        /// Offset of height between Visual Stuio designer and reality.
        /// </summary>
        /// <returns>Offset of height.</returns>
        private double VSDesignerHeightOffset() => BorderMargin.Top + BorderMargin.Bottom + (!MergeToolbarAndContent ? TOOLBAR_HEIGHT : 0);

        /// <summary>
        /// Offset of width between Visual Stuio designer and reality.
        /// </summary>
        /// <returns>Offset of width.</returns>
        private double VSDesignerWidthOffset() => BorderMargin.Left + BorderMargin.Right;
    }
}
