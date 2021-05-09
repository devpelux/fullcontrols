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
        }

        /// <inheritdoc/>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            this.AddHook(HookGlassFrame);
        }

        /// <inheritdoc/>
        protected override Thickness CalcOverflowMargin() => WindowCore.CalcAvalonWindowOverflowMargin(WindowState);

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
        private IntPtr HookGlassFrame(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
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
