using System.Runtime.InteropServices;
using System.Windows;

namespace FullControls.Core.Services
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public int X;
        public int Y;


        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Point(POINT p) => new(p.X, p.Y);

        public static explicit operator POINT(Point p) => new(checked((int)p.X), checked((int)p.Y));
    }
}
