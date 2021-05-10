using FullControls.Core.Service;
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
        /// <returns>Cursor position.</returns>
        public static Point GetCursorPos()
        {
            Extern.GetCursorPos(out POINT lMousePosition);
            return new Point(lMousePosition.X, lMousePosition.Y);
        }

        /// <summary>
        /// Gets the current active window.
        /// </summary>
        /// <returns>Active window.</returns>
        public static Window GetActiveWindow()
            => Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
    }
}
