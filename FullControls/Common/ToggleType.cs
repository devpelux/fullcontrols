using FullControls.Controls;

namespace FullControls.Common
{
    /// <summary>
    /// Specifies the allowed toggle behaviours in a <see cref="ToggleButtonPlus"/>.
    /// </summary>
    public enum ToggleType
    {
        /// <summary>
        /// Can activate only.
        /// </summary>
        Activate,

        /// <summary>
        /// Can deactivate only.
        /// </summary>
        Deactivate,

        /// <summary>
        /// Can activate and deactivate.
        /// </summary>
        Complete,

        /// <summary>
        /// Cannot neither activate or deactivate.
        /// </summary>
        None
    }
}
