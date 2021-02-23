using System;
using System.Windows;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Incapsulates a <see cref="Window"/> to be displayed as dialog and, in the end, return an <see cref="object"/> as result.
    /// </summary>
    public class DialogWindow
    {
        private readonly Window window;


        /// <summary>
        /// Initializes a new instance of <see cref="DialogWindow"/>.
        /// </summary>
        /// <param name="window">
        /// <para>The <see cref="Window"/> to be shown as dialog.</para>
        /// <para>(Must implement <see cref="IDialog"/>)</para>
        /// </param>
        public DialogWindow(Window window)
            => this.window = window != null ? window is IDialog ? window : throw new InvalidCastException($"{window} must implement {nameof(IDialog)}.")
            : throw new ArgumentNullException(nameof(window));

        /// <summary>
        /// Displays the dialog and, in the end, return an <see cref="object"/> as result.
        /// </summary>
        /// <returns>Result object.</returns>
        public object Show()
        {
            _ = window.ShowDialog();
            return ((IDialog)window).GetResult();
        }
    }
}
