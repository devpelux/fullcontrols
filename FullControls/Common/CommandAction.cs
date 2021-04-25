using System.Windows.Input;

namespace FullControls.Common
{
    /// <summary>
    /// Action executed by a command.
    /// </summary>
    public class CommandAction : IAction
    {
        /// <inheritdoc/>
        public string ActionName { get; }

        /// <summary>
        /// Command that executed the action.
        /// </summary>
        public ICommand Command { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="CommandAction"/> with a specified action and command.
        /// </summary>
        /// <param name="actionName">The name of the action.</param>
        /// <param name="command">The command that executed the action.</param>
        public CommandAction(string actionName, ICommand command)
        {
            ActionName = actionName;
            Command = command;
        }
    }
}
