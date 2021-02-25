namespace FullControls.Common
{
    /// <summary>
    /// Provides data for ExpandedChanged events for objects with an index.
    /// </summary>
    public class ItemExpandedChangedEventArgs : ExpandedChangedEventArgs
    {
        /// <summary>
        /// Gets a value indicating the index of the object.
        /// </summary>
        public int Index { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="ItemExpandedChangedEventArgs"/>.
        /// </summary>
        public ItemExpandedChangedEventArgs() : this(false) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ItemExpandedChangedEventArgs"/>
        /// specifying if the object is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).
        /// </summary>
        /// <param name="isExpanded">Specifies if the object is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).</param>
        public ItemExpandedChangedEventArgs(bool isExpanded) : this(-1, isExpanded) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ItemExpandedChangedEventArgs"/>
        /// specifying if the object is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>)
        /// and the index of the object.
        /// </summary>
        /// <param name="index">The index of the object.</param>
        /// <param name="isExpanded">Specifies if the object is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).</param>
        public ItemExpandedChangedEventArgs(int index, bool isExpanded) : base(isExpanded) => Index = index;
    }
}
