using System;
using System.Windows;
using FullControls.Common;

namespace FullControls.Utils
{
    /// <summary>
    /// Incapsulates a <see cref="Window"/> to be displayed as dialog and, in the end, returns a result.
    /// </summary>
    public class DialogWindow<T>
    {
        private readonly Window window;


        /// <summary>
        /// Initializes a new instance of <see cref="DialogWindow{T}"/>.
        /// </summary>
        /// <param name="window">The <see cref="Window"/> to be shown as dialog. (Must implement <see cref="IDialog{T}"/>)</param>
        /// <exception cref="InvalidCastException"/>
        public DialogWindow(Window window)
            => this.window = window is IDialog<T> ? window :
            throw new InvalidCastException($"{window} must be non null and implement {nameof(IDialog<T>)}<{typeof(T)}>.");

        /// <summary>
        /// Displays the dialog and, in the end, returns a result.
        /// </summary>
        public T? Show()
        {
            _ = window.ShowDialog();
            return ((IDialog<T>)window).GetResult();
        }
    }
}
