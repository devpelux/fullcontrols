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
        internal static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

        [DllImport("user32.dll")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        internal static extern bool DwmIsCompositionEnabled();

        internal delegate int DwmExtendFrameIntoClientAreaDelegate(IntPtr hwnd, ref MARGINS margins);

        internal static int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins)
        {
            var hModule = LoadLibrary("dwmapi");
            if (hModule == IntPtr.Zero) return 0;

            var procAddress = GetProcAddress(hModule, "DwmExtendFrameIntoClientArea");
            if (procAddress == IntPtr.Zero) return 0;

            var delegateForFunctionPointer = (DwmExtendFrameIntoClientAreaDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DwmExtendFrameIntoClientAreaDelegate));
            return delegateForFunctionPointer(hwnd, ref margins);
        }

        internal static bool IsDwmAvailable() => LoadLibrary("dwmapi") != IntPtr.Zero;
    }
}
