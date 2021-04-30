using System.Windows;
using System.Windows.Shell;

namespace FullControls.Extra.Extensions
{
    /// <summary>
    /// Provides a set of <see cref="string"/> extensions.
    /// </summary>
    public static class WindowChromeExtensions
    {
        private static readonly WindowChrome _defaultWindowChrome = new()
        {
            GlassFrameThickness = new Thickness(0, 0, 0, 1),
            UseAeroCaptionButtons = false,
            CaptionHeight = 0,
            CornerRadius = new CornerRadius()
        };


        /// <summary>
        /// Gets the default window chrome for chromeless windows.
        /// </summary>
        public static WindowChrome DefaultWindowChrome => (WindowChrome)_defaultWindowChrome.CloneCurrentValue();

        /// <summary>
        /// Gets the current <see cref="WindowChrome"/> from the specified <see cref="Window"/>
        /// or creates a new <see cref="WindowChrome"/>, sets the <see cref="WindowChrome"/> to the specified <see cref="Window"/>,
        /// and returns it.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static WindowChrome CloneOrCreateWindowChrome(Window window)
        {
            WindowChrome wc = WindowChrome.GetWindowChrome(window);
            if (wc is WindowChrome) return (WindowChrome)wc.CloneCurrentValue();
            else
            {
                wc = new();
                WindowChrome.SetWindowChrome(window, wc);
                return (WindowChrome)wc.CloneCurrentValue();
            }
        }
    }
}
