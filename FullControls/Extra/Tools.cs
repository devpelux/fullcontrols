using FullControls.Core.Service;
using System.Windows;

namespace FullControls.Extra
{
    /// <summary>
    /// Provides a set of static functions.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Get the current cursor position on display.
        /// </summary>
        /// <returns>Cursor position.</returns>
        public static Point GetCursorPos()
        {
            Extern.GetCursorPos(out POINT lMousePosition);
            return new Point(lMousePosition.X, lMousePosition.Y);
        }
    }
}
