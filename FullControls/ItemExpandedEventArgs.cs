using System;

namespace FullControls
{
    /// <summary>
    /// Provides data for ItemExpanded events.
    /// </summary>
    public class ItemExpandedEventArgs : EventArgs
    {
        /// <summary>
        /// The index of the item that was expanded or collapsed, if is in a collection, or -1 if not.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Specifies if the item was expanded (true) or collapsed (false).
        /// </summary>
        public bool IsExpanded { get; set; }


        /// <summary>
        /// Initializes a new instance of <see cref="ItemExpandedEventArgs"/>.
        /// </summary>
        /// <param name="isExpanded">Specifies if the item was expanded (true) or collapsed (false).</param>
        public ItemExpandedEventArgs(bool isExpanded) : this(-1, isExpanded) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ItemExpandedEventArgs"/>.
        /// </summary>
        /// <param name="index">The index of the item that was expanded or collapsed.</param>
        /// <param name="isExpanded">Specifies if the item was expanded (true) or collapsed (false).</param>
        public ItemExpandedEventArgs(int index, bool isExpanded)
        {
            Index = index;
            IsExpanded = isExpanded;
        }
    }
}
