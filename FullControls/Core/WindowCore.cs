using FullControls.Core.Services;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Shell;

namespace FullControls.Core
{
    /// <summary>
    /// Internal code used by custom windows.
    /// </summary>
    internal static class WindowCore
    {
        internal const int WM_SETCURSOR = 0x20;
        internal const int WM_NCCALCSIZE = 0x83;
        internal const int WM_NCPAINT = 0x85;
        internal const int WM_SYSCOMMAND = 0x0112;
        internal const int WM_GETMINMAXINFO = 0x0024;
        internal const int WP_SYSTEMMENU = 0x02;
        internal const int VK_LMENU = 0xA4;
        internal const int VK_RMENU = 0xA5;
        internal const int SC_CLOSE = 0xF060;
        internal const int SC_SIZE = 0xF000;
        internal const int SC_MOVE = 0xF010;
        internal const int SC_MAXIMIZE = 0xF030;
        internal const int SC_MINIMIZE = 0xF020;
        internal const int SC_RESTORE = 0xF120;

        internal const int MAXOWNERSATTACHED = 4;

        /// <summary>
        /// Frame thickness based on <see cref="SystemParameters.WindowResizeBorderThickness"/>
        /// when <see cref="WindowChrome.NonClientFrameEdges"/> is set to <see cref="NonClientFrameEdges.Bottom"/>.
        /// </summary>
        internal static Thickness WindowFrameThickness => SysParams.WindowFrameThickness;

        /// <summary>
        /// Standard thickness of the resize border of a window.
        /// </summary>
        internal static Thickness WindowResizeBorderThickness => SysParams.WindowResizeBorderThickness;


        /// <summary>
        /// Calculates the correct window size.
        /// </summary>
        internal static IntPtr WmNcCalcSize(IntPtr wParam, IntPtr lParam)
        {
            object? res = Marshal.PtrToStructure(lParam, typeof(RECT));
            RECT rcClientArea = res != null ? (RECT)res : RECT.Empty;
            rcClientArea.Bottom += (int)(SysParams.WindowResizeBorderThickness.Bottom / 2);
            Marshal.StructureToPtr(rcClientArea, lParam, false);

            return wParam == new IntPtr(1) ? new IntPtr((int)WVR.REDRAW) : IntPtr.Zero;
        }

        /// <summary>
        /// Removes the glass frame of the window by resizing the window to cover all the glass frame.
        /// </summary>
        internal static void RemoveFrame(Window window, Thickness frameThickness)
        {
            if (Environment.OSVersion.Version.Major >= 6 && InternalMethods.IsDwmAvailable())
            {
                if (NativeMethods.DwmIsCompositionEnabled() && SystemParameters.DropShadow)
                {
                    MARGINS margins = (MARGINS)frameThickness;
                    WindowInteropHelper helper = new(window);

                    InternalMethods.DwmExtendFrameIntoClientArea(helper.Handle, ref margins);
                }
            }
        }

        /// <summary>
        /// Adapts the window to the monitor size.
        /// </summary>
        internal static void WmGetMinMaxInfo(IntPtr lParam)
        {
            NativeMethods.GetCursorPos(out POINT lMousePosition);

            IntPtr lPrimaryScreen = NativeMethods.MonitorFromPoint(new POINT(0, 0), MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
            MONITORINFO lPrimaryScreenInfo = new();

            if (NativeMethods.GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false) return;

            IntPtr lCurrentScreen = NativeMethods.MonitorFromPoint(lMousePosition, MonitorOptions.MONITOR_DEFAULTTONEAREST);

            object? res = Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
            MINMAXINFO lMmi = res != null ? (MINMAXINFO)res : MINMAXINFO.Empty;

            if (lPrimaryScreen.Equals(lCurrentScreen) == true)
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcWork.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcWork.Right - lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcWork.Bottom - lPrimaryScreenInfo.rcWork.Top;
            }
            else
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcMonitor.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcMonitor.Right - lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcMonitor.Bottom - lPrimaryScreenInfo.rcMonitor.Top;
            }

            Marshal.StructureToPtr(lMmi, lParam, true);
        }

        /// <summary>
        /// Adds an event handler that receives all window messages.
        /// </summary>
        /// <param name="window">Window to which to add the handler.</param>
        /// <param name="hook">The handler implementation that receives the window messages.</param>
        internal static void AddHook(this Window window, HwndSourceHook hook)
            => GetHwndSource(window)?.AddHook(hook);

        /// <summary>
        /// Returns the <see cref="HwndSource"/> object of the specified window.
        /// </summary>
        /// <param name="window">The window from which to get the <see cref="HwndSource"/> object.</param>
        /// <returns>The <see cref="HwndSource"/> object for the window that is specified by the hwnd window handle.</returns>
        internal static HwndSource GetHwndSource(Window window)
            => HwndSource.FromHwnd(new WindowInteropHelper(window).EnsureHandle());

        /// <summary>
        /// Calculates the outside margin of a window based on its <see cref="WindowState"/>.
        /// (The part of the window that is not visible)
        /// </summary>
        /// <param name="windowState"><see cref="WindowState"/>.</param>
        /// <returns>Outside margin thickness.</returns>
        internal static Thickness CalcAvalonWindowOutsideMargin(WindowState windowState)
        {
            Thickness frame = SysParams.WindowFrameThickness;
            if (windowState == WindowState.Maximized)
            {
                //If the window is maximized, adds the resize border thickness.
                Thickness rb = SysParams.WindowResizeBorderThickness;
                frame = new(rb.Left + frame.Left, rb.Top + frame.Top, rb.Right + frame.Right, rb.Bottom + frame.Bottom);
            }

            return frame;
        }
    }
}
