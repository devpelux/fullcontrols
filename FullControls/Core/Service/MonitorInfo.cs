using System.Runtime.InteropServices;

namespace FullControls.Core.Service
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal class MonitorInfo
    {
        public int cbSize = Marshal.SizeOf(typeof(MonitorInfo));
        public IntRect rcMonitor = new();
        public IntRect rcWork = new();
        public int dwFlags = 0;
    }
}
