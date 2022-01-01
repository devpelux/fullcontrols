using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace FullControls.Core.Services
{
    /// <summary>
    /// Internal service methods.
    /// </summary>
    internal static class InternalMethods
    {
        internal static IntPtr GetDC(HandleRef hWnd)
        {
            IntPtr hDc = NativeMethods.IntGetDC(hWnd);
            if (hDc == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            return HandleCollector.Add(hDc, CommonHandles.HDC);
        }

        internal static int ReleaseDC(HandleRef hWnd, HandleRef hDC)
        {
            HandleCollector.Remove((IntPtr)hDC, CommonHandles.HDC);
            return NativeMethods.IntReleaseDC(hWnd, hDC);
        }

        internal delegate int DwmExtendFrameIntoClientAreaDelegate(IntPtr hwnd, ref MARGINS margins);

        internal static int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins)
        {
            var hModule = NativeMethods.LoadLibrary("dwmapi");
            if (hModule == IntPtr.Zero) return 0;

            var procAddress = NativeMethods.GetProcAddress(hModule, "DwmExtendFrameIntoClientArea");
            if (procAddress == IntPtr.Zero) return 0;

            var delegateForFunctionPointer = (DwmExtendFrameIntoClientAreaDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(DwmExtendFrameIntoClientAreaDelegate));
            return delegateForFunctionPointer(hwnd, ref margins);
        }

        internal static bool IsDwmAvailable() => NativeMethods.LoadLibrary("dwmapi") != IntPtr.Zero;
    }
}
