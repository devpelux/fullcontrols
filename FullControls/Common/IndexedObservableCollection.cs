using FullControls.Controls;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FullControls.Common
{
    /// <summary>
    /// Represents an observable collection of indexed objects of type T.
    /// </summary>
    public class IndexedObservableCollection<T> : ObservableCollection<T> where T : IIndexed
    {
        /// <summary>
        /// Initializes a new empty collection.
        /// </summary>
        public IndexedObservableCollection() : base() { }

        /// <inheritdoc/>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    ResetIndexes(e.NewStartingIndex, Count - 1);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    ResetIndexes(e.OldStartingIndex, Count - 1);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    this[e.OldStartingIndex].Index = e.OldStartingIndex;
                    break;
                case NotifyCollectionChangedAction.Move:
                    ResetIndexes(Math.Min(e.OldStartingIndex, e.NewStartingIndex), Math.Max(e.OldStartingIndex, e.NewStartingIndex));
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ResetIndexes(0, Count - 1);
                    break;
                default:
                    ResetIndexes(0, Count - 1);
                    break;
            }
            base.OnCollectionChanged(e);
        }

        /// <summary>
        /// Reset the indexes of the items starting at a specified index and ending at a specified index.
        /// </summary>
        /// <param name="startIndex">The zero-based index of the start item of the reset process.</param>
        /// <param name="endIndex">The zero-based index of the end item of the reset process.</param>
        private void ResetIndexes(int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (this[i] != null) this[i].Index = i;
            }
        }
    }
}
