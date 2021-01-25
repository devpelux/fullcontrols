using System;

namespace FullControls
{
    /// <summary>
    /// Provides data for ExpandedChanged events.
    /// </summary>
    public class ExpandedChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Specifies if the object was expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).
        /// </summary>
        public bool IsExpanded { get; set; }


        /// <summary>
        /// Initializes a new instance of <see cref="ExpandedChangedEventArgs"/>.
        /// </summary>
        /// <param name="isExpanded">Specifies if the object was expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).</param>
        public ExpandedChangedEventArgs(bool isExpanded)
        {
            IsExpanded = isExpanded;
        }
    }
}
