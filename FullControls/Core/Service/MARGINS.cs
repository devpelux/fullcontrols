using System.Runtime.InteropServices;
using System.Windows;

namespace FullControls.Core.Service
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MARGINS
    {
        public int LeftWidth;
        public int RightWidth;
        public int TopHeight;
        public int BottomHeight;

        public MARGINS(int leftWidth, int rightWidth, int topHeight, int bottomHeight)
        {
            LeftWidth = leftWidth;
            RightWidth = rightWidth;
            TopHeight = topHeight;
            BottomHeight = bottomHeight;
        }

        public MARGINS(Thickness thickness) : this((int)thickness.Left, (int)thickness.Right, (int)thickness.Top, (int)thickness.Bottom) { }
    }
}
