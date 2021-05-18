using FullControls.Core.Services;
using System.IO;
using System.Linq;
using System.Windows;

namespace FullControls.Extra
{
    /// <summary>
    /// Provides a set of static functions.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Gets the current cursor position on display.
        /// </summary>
        /// <returns>Current cursor position on display.</returns>
        public static Point GetCursorPos()
        {
            NativeMethods.GetCursorPos(out POINT lMousePosition);
            return lMousePosition;
        }

        /// <summary>
        /// Gets the current active window.
        /// </summary>
        /// <returns>Current active window.</returns>
        public static Window GetActiveWindow() => Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        /// <summary>
        /// Gets the current application executing file.
        /// </summary>
        /// <returns>Current application executing file.</returns>
        public static FileInfo GetExecutingFile() => new(InternalMethods.GetExecutablePath());

        /// <summary>
        /// Gets the current application executing directory.
        /// </summary>
        /// <returns>Current application executing directory.</returns>
        public static DirectoryInfo GetExecutingDirectory() => GetExecutingFile().Directory;
    }
}
