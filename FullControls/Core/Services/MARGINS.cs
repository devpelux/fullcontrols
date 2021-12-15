using System.Runtime.InteropServices;
using System.Windows;

namespace FullControls.Core.Services
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MARGINS
    {
        public static MARGINS Empty;

        public int LeftWidth;
        public int RightWidth;
        public int TopHeight;
        public int BottomHeight;


        static MARGINS() => Empty = new MARGINS();

        public MARGINS(int leftWidth, int rightWidth, int topHeight, int bottomHeight)
        {
            LeftWidth = leftWidth;
            RightWidth = rightWidth;
            TopHeight = topHeight;
            BottomHeight = bottomHeight;
        }

        public static explicit operator Thickness(MARGINS m) => new(m.LeftWidth, m.TopHeight, m.RightWidth, m.BottomHeight);

        public static explicit operator MARGINS(Thickness t) => new(checked((int)t.Left), checked((int)t.Right), checked((int)t.Top), checked((int)t.Bottom));
    }
}
