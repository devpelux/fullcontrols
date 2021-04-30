using System.Runtime.InteropServices;

namespace FullControls.Core.Service
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IntPoint
    {
        public int X;
        public int Y;

        public IntPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
