using System.Runtime.InteropServices;
using System.Windows;

namespace FullControls.Extra
{
    /// <summary>
    /// Contains a set of static functions.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Get the current cursor position on display.
        /// </summary>
        /// <returns>Cursor position.</returns>
        public static Point GetCursorPos()
        {
            GetCursorPos(out POINT lMousePosition);
            return new Point(lMousePosition.X, lMousePosition.Y);
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
