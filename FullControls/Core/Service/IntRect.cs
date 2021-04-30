using System.Runtime.InteropServices;

namespace FullControls.Core.Service
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IntRect
    {
        public int Left, Top, Right, Bottom;

        public IntRect(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}
