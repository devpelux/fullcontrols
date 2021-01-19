namespace FullControls
{
    /// <summary>
    /// Provides data for ExpandedChanged events for objects with an index.
    /// </summary>
    public class ItemExpandedChangedEventArgs : ExpandedChangedEventArgs
    {
        /// <summary>
        /// The index of the object that was expanded or collapsed.
        /// </summary>
        public int Index { get; set; }


        /// <summary>
        /// Initializes a new instance of <see cref="ItemExpandedChangedEventArgs"/>.
        /// </summary>
        /// <param name="isExpanded">Specifies if the object was expanded (true) or collapsed (false).</param>
        public ItemExpandedChangedEventArgs(bool isExpanded) : this(-1, isExpanded) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ItemExpandedChangedEventArgs"/>.
        /// </summary>
        /// <param name="index">The index of the object that was expanded or collapsed.</param>
        /// <param name="isExpanded">Specifies if the object was expanded (true) or collapsed (false).</param>
        public ItemExpandedChangedEventArgs(int index, bool isExpanded) : base(isExpanded)
        {
            Index = index;
        }
    }
}
