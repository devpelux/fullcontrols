using System.Runtime.InteropServices;

namespace FullControls.Core.Service
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MinMaxInfo
    {
        public IntPoint ptReserved;
        public IntPoint ptMaxSize;
        public IntPoint ptMaxPosition;
        public IntPoint ptMinTrackSize;
        public IntPoint ptMaxTrackSize;
    };
}
