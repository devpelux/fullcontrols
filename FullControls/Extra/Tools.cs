using FullControls.Core.Service;
using System;
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
            Extern.GetCursorPos(out POINT lMousePosition);
            return lMousePosition;
        }

        /// <summary>
        /// Gets the current active window.
        /// </summary>
        /// <returns>Current active window.</returns>
        public static Window GetActiveWindow() => Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        /// <summary>
        /// Gets the current application executing directory path.
        /// </summary>
        /// <returns>Current application executing directory path.</returns>
        public static string GetExecutingDirectory() => Path.GetDirectoryName(AppContext.BaseDirectory);
    }
}
