using System.Drawing;
using System.Runtime.InteropServices;

namespace FullControls.Core.Services
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public static RECT Empty;

        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public Size Size => new(Right - Left, Bottom - Top);


        static RECT() => Empty = new RECT();

        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public static RECT FromXYWH(int x, int y, int width, int height) => new(x, y, x + width, y + height);

        public static explicit operator Rectangle(RECT r) => Rectangle.FromLTRB(r.Left, r.Top, r.Right, r.Bottom);

        public static explicit operator RECT(Rectangle r) => new(r.Left, r.Top, r.Right, r.Bottom);
    }
}
