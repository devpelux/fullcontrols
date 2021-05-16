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
#pragma warning disable CS0618 // The type or the member is obsolete
            => this.window = window != null ? window is Common.IDialog or IDialog ? window
#pragma warning restore CS0618 // The type or the member is obsolete
            : throw new InvalidCastException($"{window} must implement {nameof(Common.IDialog)}.")
            : throw new ArgumentNullException(nameof(window));

        /// <summary>
        /// Displays the dialog and, in the end, return an <see cref="object"/> as result.
        /// </summary>
        /// <returns>Result object.</returns>
        public object Show()
        {
            _ = window.ShowDialog();
#pragma warning disable CS0618 // The type or the member is obsolete
            return window is Common.IDialog dialog ? dialog.GetResult() : ((IDialog)window).GetResult();
#pragma warning restore CS0618 // The type or the member is obsolete
        }
    }
}
