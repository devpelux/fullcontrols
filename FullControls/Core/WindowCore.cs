using FullControls.Core.Service;
using FullControls.Extra.Extensions;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace FullControls.Core
{
    /// <summary>
    /// Methods used by windows.
    /// </summary>
    internal static class WindowCore
    {
        internal const int WM_NCCALCSIZE = 0x83;
        internal const int WM_NCPAINT = 0x85;
        internal const int WM_SYSCOMMAND = 0x0112;
        internal const int WM_GETMINMAXINFO = 0x0024;
        internal const int SC_CLOSE = 0xF060;
        internal const int SC_SIZE = 0xF000;
        internal const int SC_MOVE = 0xF010;
        internal const int SC_MAXIMIZE = 0xF030;
        internal const int SC_MINIMIZE = 0xF020;
        internal const int SC_RESTORE = 0xF120;


        internal static Window GetActiveWindow() => Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        internal static IntPtr WmNcCalcSize(IntPtr wParam, IntPtr lParam)
        {
            RECT rcClientArea = (RECT)Marshal.PtrToStructure(lParam, typeof(RECT));
            rcClientArea.Bottom += (int)(SysParams.WindowResizeBorderThickness.Bottom / 2);
            Marshal.StructureToPtr(rcClientArea, lParam, false);

            return wParam == new IntPtr(1) ? new IntPtr((int)WVR.REDRAW) : IntPtr.Zero;
        }

        internal static void RemoveFrame(Window window, Thickness frameThickness)
        {
            if (Environment.OSVersion.Version.Major >= 6 && Extern.IsDwmAvailable())
            {
                if (Extern.DwmIsCompositionEnabled() && SystemParameters.DropShadow)
                {
                    MARGINS margins = new(frameThickness);
                    WindowInteropHelper helper = new(window);

                    Extern.DwmExtendFrameIntoClientArea(helper.Handle, ref margins);
                }
            }
        }

        internal static void WmGetMinMaxInfo(IntPtr lParam)
        {
            Extern.GetCursorPos(out POINT lMousePosition);

            IntPtr lPrimaryScreen = Extern.MonitorFromPoint(new POINT(0, 0), MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
            MONITORINFO lPrimaryScreenInfo = new();

            if (Extern.GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false) return;

            IntPtr lCurrentScreen = Extern.MonitorFromPoint(lMousePosition, MonitorOptions.MONITOR_DEFAULTTONEAREST);

            MINMAXINFO lMmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

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

        internal static HwndSource GetHwndSource(Window window)
            => HwndSource.FromHwnd(new WindowInteropHelper(window).EnsureHandle());

        internal static Thickness GetOverflowMargin(WindowState windowState)
            => windowState == WindowState.Maximized ? SysParams.WindowResizeBorderThickness.Add(SysParams.LayoutOffsetThickness)
                                                    : SysParams.LayoutOffsetThickness;
    }
}
