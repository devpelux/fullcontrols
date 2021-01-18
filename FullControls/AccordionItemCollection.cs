using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FullControls
{
    /// <summary>
    /// Represents a list of <see cref="AccordionItem"/>.
    /// </summary>
    public class AccordionItemCollection : ObservableCollection<AccordionItem>
    {
        /// <inheritdoc/>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    ResetIndexes(e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    ResetIndexes(e.OldStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    ResetIndexes(e.OldStartingIndex, e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Move:
                    ResetIndexes(e.OldStartingIndex, e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ResetIndexes();
                    break;
                default:
                    ResetIndexes();
                    break;
            }
            base.OnCollectionChanged(e);
        }

        /// <summary>
        /// Reset the indexes of the items starting at a specified index.
        /// </summary>
        /// <param name="startIndex">The zero-based index of the start item of the reset process.</param>
        private void ResetIndexes(int startIndex = 0) => ResetIndexes(startIndex, Count - 1);

        /// <summary>
        /// Reset the indexes of the items starting at a specified index and ending at a specified index.
        /// </summary>
        /// <param name="startIndex">The zero-based index of the start item of the reset process.</param>
        /// <param name="endIndex">The zero-based index of the end item of the reset process.</param>
        private void ResetIndexes(int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++) this[i].Index = i;
        }
    }
}
