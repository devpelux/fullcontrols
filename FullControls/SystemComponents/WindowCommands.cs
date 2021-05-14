using System.Windows.Input;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Provides a list of commands to control a window.
    /// </summary>
    public static class WindowCommands
    {
        private static readonly RoutedUICommand _close = new("Close", "Close", typeof(WindowCommands));
        private static readonly RoutedUICommand _minimize = new("Minimize", "Minimize", typeof(WindowCommands));
        private static readonly RoutedUICommand _maximize = new("Maximize", "Maximize", typeof(WindowCommands));
        private static readonly RoutedUICommand _restore = new("Restore", "Restore", typeof(WindowCommands));
        private static readonly RoutedUICommand _hide = new("Hide", "Hide", typeof(WindowCommands));
        private static readonly RoutedUICommand _show = new("Show", "Show", typeof(WindowCommands));
        private static readonly RoutedUICommand _drag = new("Drag", "Drag", typeof(WindowCommands));
        private static readonly RoutedUICommand _action = new("Action", "Action", typeof(WindowCommands));

        /// <summary>
        /// Close the window.
        /// </summary>
        public static RoutedUICommand Close => _close;

        /// <summary>
        /// Minimize the window.
        /// </summary>
        public static RoutedUICommand Minimize => _minimize;

        /// <summary>
        /// Maximize the window.
        /// </summary>
        public static RoutedUICommand Maximize => _maximize;

        /// <summary>
        /// Restore the window.
        /// </summary>
        public static RoutedUICommand Restore => _restore;

        /// <summary>
        /// Hide the window.
        /// </summary>
        public static RoutedUICommand Hide => _hide;

        /// <summary>
        /// Show the window.
        /// </summary>
        public static RoutedUICommand Show => _show;

        /// <summary>
        /// Drag the window.
        /// </summary>
        public static RoutedUICommand Drag => _drag;

        /// <summary>
        /// Send a custom action to the window.
        /// </summary>
        public static RoutedUICommand Action => _action;
    }
}
