using System;

namespace FullControls.Common
{
    /// <summary>
    /// Provides data for an action event.
    /// </summary>
    public class ActionEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating the <see cref="IAction"/> executed.
        /// </summary>
        public IAction Action { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="ActionEventArgs"/>.
        /// </summary>
        public ActionEventArgs() : this(null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ActionEventArgs"/> specifying the <see cref="IAction"/> executed.
        /// </summary>
        /// <param name="action">Specifies the <see cref="IAction"/> executed.</param>
        public ActionEventArgs(IAction action) : base() => Action = action;
    }
}
