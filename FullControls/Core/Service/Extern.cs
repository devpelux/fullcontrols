using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace FullControls.Core.Service
{
    /// <summary>
    /// External methods.
    /// </summary>
    internal static class Extern
    {
        [DllImport("user32.dll", SetLastError = true, ExactSpelling = true, EntryPoint = "GetDC", CharSet = CharSet.Auto)]
        private static extern IntPtr IntGetDC(HandleRef hWnd);

        internal static IntPtr GetDC(HandleRef hWnd)
        {
            IntPtr hDc = IntGetDC(hWnd);
            if (hDc == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            return HandleCollector.Add(hDc, CommonHandles.HDC);
        }

        [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "ReleaseDC", CharSet = CharSet.Auto)]
        private static extern int IntReleaseDC(HandleRef hWnd, HandleRef hDC);

        internal static int ReleaseDC(HandleRef hWnd, HandleRef hDC)
        {
            HandleCollector.Remove((IntPtr)hDC, CommonHandles.HDC);
            return IntReleaseDC(hWnd, hDC);
        }

        [DllImport("gdi32.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        internal static extern int GetDeviceCaps(HandleRef hDC, int nIndex);

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(SM nIndex);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(out IntPoint lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr MonitorFromPoint(IntPoint pt, MonitorOptions dwFlags);

        [DllImport("user32.dll")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MonitorInfo lpmi);
    }
}
