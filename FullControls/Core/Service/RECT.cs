using System.Drawing;
using System.Runtime.InteropServices;

namespace FullControls.Core.Service
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

        public RECT(Rectangle rectangle) : this(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom) { }

        public static RECT FromXYWH(int x, int y, int width, int height) => new(x, y, x + width, y + height);
    }
}
