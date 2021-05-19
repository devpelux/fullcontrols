using FullControls.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FullControls.Common
{
    /// <summary>
    /// Represents a list of <see cref="AccordionItem"/>.
    /// </summary>
    public class AccordionItemCollection : ObservableCollection<AccordionItem>
    {
        /// <summary>
        /// Initializes a new instance of an empty <see cref="AccordionItemCollection"/>.
        /// </summary>
        public AccordionItemCollection() : base() { }

        /// <summary>
        /// Copies the items to a new <see cref="AccordionItemCollection"/> instance.
        /// </summary>
        /// <remarks>The new <see cref="AccordionItemCollection"/> returned will contain the same items references of the old one,
        /// so changing an item in the old one will result in changing the same item in the new one.</remarks>
        /// <returns><see cref="AccordionItemCollection"/> instance with the same items contained in the cloned instance.</returns>
        public AccordionItemCollection ShallowClone()
        {
            AccordionItemCollection collection = new();
            foreach (AccordionItem item in this)
            {
                collection.Add(item);
            }

            return collection;
        }

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
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (this[i] != null) this[i].Index = i;
            }
        }

        #region Conversion functions

        /// <summary>
        /// Initializes a new instance of <see cref="AccordionItemCollection"/>
        /// and populates it with elements from a specified <see cref="List{T}"/> of <see cref="AccordionItem"/>.
        /// </summary>
        /// <param name="accordionItemList"><see cref="List{T}"/> of <see cref="AccordionItem"/> from which to get the items.</param>
        public static AccordionItemCollection FromList(List<AccordionItem> accordionItemList)
        {
            AccordionItemCollection accordionItemCollection = new();
            foreach (AccordionItem accordionItem in accordionItemList)
            {
                accordionItemCollection.Add(accordionItem);
            }
            return accordionItemCollection;
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="List{T}"/> of <see cref="AccordionItem"/>
        /// and populates it with elements from the current <see cref="AccordionItemCollection"/>.
        /// </summary>
        public List<AccordionItem> ToList()
        {
            List<AccordionItem> accordionItemsList = new();
            foreach (AccordionItem accordionItem in this)
            {
                accordionItemsList.Add(accordionItem);
            }
            return accordionItemsList;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Converts the <see cref="List{T}"/> of <see cref="AccordionItem"/> to an <see cref="AccordionItemCollection"/>.
        /// </summary>
        /// <param name="accordionItemList"><see cref="List{T}"/> of <see cref="AccordionItem"/> to convert.</param>
        public static explicit operator AccordionItemCollection(List<AccordionItem> accordionItemList)
            => FromList(accordionItemList);

        /// <summary>
        /// Converts the <see cref="AccordionItemCollection"/> to a <see cref="List{T}"/> of <see cref="AccordionItem"/>.
        /// </summary>
        /// <param name="accordionItemCollection"><see cref="AccordionItemCollection"/> to convert.</param>
        public static explicit operator List<AccordionItem>(AccordionItemCollection accordionItemCollection)
            => accordionItemCollection.ToList();

        #endregion
    }
}
