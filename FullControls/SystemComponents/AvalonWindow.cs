using FullControls.Core;
using System;
using System.Windows;
using System.Windows.Shell;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.
    /// </summary>
    public class AvalonWindow : WindowPlus
    {
        /// <summary>
        /// Gets the corner radius of the control.
        /// </summary>
        public CornerRadius CornerRadius => (CornerRadius)GetValue(CornerRadiusProperty);

        #region CornerRadiusProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="CornerRadius"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey CornerRadiusPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CornerRadius), typeof(CornerRadius), typeof(AvalonWindow),
                new FrameworkPropertyMetadata(default(CornerRadius)));

        /// <summary>
        /// Identifies the <see cref="CornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = CornerRadiusPropertyKey.DependencyProperty;

        #endregion


        static AvalonWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AvalonWindow),
                new FrameworkPropertyMetadata(typeof(AvalonWindow)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AvalonWindow"/>.
        /// </summary>
        public AvalonWindow() : base() { }

        /// <inheritdoc/>
        protected override void OnInitializing()
        {
            base.OnInitializing();
            WindowChrome wc = new()
            {
                GlassFrameThickness = new Thickness(0, 0, 0, 1),
                NonClientFrameEdges = NonClientFrameEdges.Bottom,
                UseAeroCaptionButtons = false,
                CaptionHeight = EnableTitlebar ? TITLEBAR_HEIGHT : 0,
                ResizeBorderThickness = ResizeThickness,
                CornerRadius = new CornerRadius()
            };
            WindowChrome.SetWindowChrome(this, wc);

            //Sets round corners for Windows 11.
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Build >= 22000)
            {
                SetValue(CornerRadiusPropertyKey, WIN11_CORNER_RADIUS);
            }
        }

        /// <inheritdoc/>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            this.AddHook(HandleGlassFrame);
        }

        /// <inheritdoc/>
        protected override Thickness CalcOutsideMargin()
            => WindowCore.CalcAvalonWindowOutsideMargin(WindowState);

        /// <inheritdoc/>
        protected override void OnResizeThicknessChanged(Thickness thickness)
        {
            base.OnResizeThicknessChanged(thickness);
            WindowChrome wc = WindowChrome.GetWindowChrome(this);
            if (wc != null) wc.ResizeBorderThickness = thickness;
        }

        #region Hooks

        /// <summary>
        /// Handles the glass frame.
        /// </summary>
        private IntPtr HandleGlassFrame(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WindowCore.WM_NCPAINT)
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
