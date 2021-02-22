using System;

namespace FullControls.Common
{
    /// <summary>
    /// Provides data for ExpandedChanged events.
    /// </summary>
    public class ExpandedChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Specifies if the object is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).
        /// </summary>
        public bool IsExpanded { get; set; }


        /// <summary>
        /// Initializes a new instance of <see cref="ExpandedChangedEventArgs"/>.
        /// </summary>
        public ExpandedChangedEventArgs() : this(false) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ExpandedChangedEventArgs"/>
        /// specifying if the object is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).
        /// </summary>
        /// <param name="isExpanded">Specifies if the object is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).</param>
        public ExpandedChangedEventArgs(bool isExpanded) : base() => IsExpanded = isExpanded;
    }
}
