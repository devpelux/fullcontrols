using System.Runtime.InteropServices;

namespace FullControls.Core.Services
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MINMAXINFO
    {
        public static MINMAXINFO Empty;

        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;


        static MINMAXINFO() => Empty = new MINMAXINFO();
    };
}
