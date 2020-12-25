using System.ComponentModel;

namespace FullControls
{
    /// <summary>
    /// Provides data for a cancelable action event.
    /// </summary>
    public class ActionEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Name of the action.
        /// </summary>
        public string ActionName { get; init; }


        /// <summary>
        /// Initialize a new instance of <see cref="ActionEventArgs"/>.
        /// </summary>
        public ActionEventArgs() : this("") { }

        /// <summary>
        /// Initialize a new instance of <see cref="ActionEventArgs"/> indicating the name of the action.
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        public ActionEventArgs(string actionName) : base() => ActionName = actionName;

        /// <summary>
        /// Initialize a new instance of <see cref="ActionEventArgs"/>
        /// indicating the name of the action and whether the event should be canceled.
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="cancel">True to cancel the event, otherwise, false.</param>
        public ActionEventArgs(string actionName, bool cancel) : base(cancel) => ActionName = actionName;
    }
}
