using FullControls.Windows;
using System;
using System.Windows;

namespace FullControls.Utils
{
    /// <summary>
    /// Represents an exception that can be easily displayed with a message window.
    /// </summary>
    public class VisualizableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="VisualizableException"/>.
        /// </summary>
        public VisualizableException() { }

        /// <summary>
        /// Initializes a new instance of <see cref="VisualizableException"/> with the specified message.
        /// </summary>
        public VisualizableException(string? message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of <see cref="VisualizableException"/> with the specified message
        /// and the exception that caused this exception.
        /// </summary>
        public VisualizableException(string? message, Exception? innerException) : base(message, innerException) { }

        /// <summary>
        /// Displays a message window that shows the details of the exception.
        /// </summary>
        public void ShowDialog(Window? owner = null) => ShowDialog(MessageWindow.Theme.Light, owner);

        /// <summary>
        /// Displays a message window that shows the details of the exception, by specifying the window theme too.
        /// </summary>
        public void ShowDialog(MessageWindow.Theme theme, Window? owner = null)
        {
            string message = InnerException != null ? $"{Message}\n\nInternal error: {InnerException.Message}" : Message;

            MessageWindow.ShowError(message, theme, owner);
        }
    }
}
