using FullControls.Common;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control that contains a stacked list of items.
    /// Each item can be <b>expanded</b> or <b>collapsed</b> to reveal the content associated with that item.
    /// </summary>
    [TemplatePart(Name = PartContentHost, Type = typeof(Decorator))]
    [DefaultEvent(nameof(ItemIsExpandedChanged))]
    public class Accordion : SimpleItemsControl<IndexedObservableCollection<AccordionItem>>
    {
        private readonly ItemsControl itemsControl;

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Occurs when in an item <see cref="AccordionItem.IsExpanded"/> is changed.
        /// </summary>
        public event EventHandler<ItemExpandedChangedEventArgs>? ItemIsExpandedChanged;


        static Accordion()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Accordion),
                new FrameworkPropertyMetadata(typeof(Accordion)));

            IsEnabledProperty.OverrideMetadata(typeof(Accordion),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((Accordion)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Accordion"/>.
        /// </summary>
        public Accordion() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
            itemsControl = new();
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Template.FindName(PartContentHost, this) is Decorator contentHost) contentHost.Child = itemsControl;
        }

        /// <summary>
        /// Called when in an item <see cref="AccordionItem.IsExpanded"/> is changed.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnItemExpandedChanged(ItemExpandedChangedEventArgs e) => ItemIsExpandedChanged?.Invoke(this, e);

        /// <inheritdoc/>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    itemsControl.Items.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                    SetExpandedChangedHandler(e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveExpandedChangedHandler(e.OldStartingIndex);
                    itemsControl.Items.RemoveAt(e.OldStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveExpandedChangedHandler(e.OldStartingIndex);
                    itemsControl.Items[e.OldStartingIndex] = Items[e.NewStartingIndex];
                    SetExpandedChangedHandler(e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Move:
                    itemsControl.Items.RemoveAt(e.OldStartingIndex);
                    itemsControl.Items.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ReloadItems();
                    break;
                default:
                    ReloadItems();
                    break;
            }
        }

        /// <summary>
        /// Reloads all the items.
        /// </summary>
        private void ReloadItems()
        {
            RemoveExpandedChangedHandler(0, itemsControl.Items.Count - 1);
            itemsControl.Items.Clear();
            if (Items != null)
            {
                foreach (AccordionItem item in Items) itemsControl.Items.Add(item);
                SetExpandedChangedHandler(0, itemsControl.Items.Count - 1);
            }
        }

        #region ExpandedChangedHandler setters

        /// <summary>
        /// Set the ExpandedChanged handler to an item.
        /// </summary>
        /// <param name="index">Item index.</param>
        private void SetExpandedChangedHandler(int index)
        {
            if (itemsControl.Items[index] != null)
            {
                ((AccordionItem)itemsControl.Items[index]).IsExpandedChanged -= OnItemExpandedChanged;
                ((AccordionItem)itemsControl.Items[index]).IsExpandedChanged += OnItemExpandedChanged;
            }
        }

        /// <summary>
        /// Remove the ExpandedChanged handler to some items.
        /// </summary>
        /// <param name="startIndex">First item index.</param>
        /// <param name="endIndex">Last item index.</param>
        private void SetExpandedChangedHandler(int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++) SetExpandedChangedHandler(i);
        }

        /// <summary>
        /// Remove the ExpandedChanged handler to an item.
        /// </summary>
        /// <param name="index">Item index.</param>
        private void RemoveExpandedChangedHandler(int index)
        {
            if (itemsControl.Items[index] != null)
            {
                ((AccordionItem)itemsControl.Items[index]).IsExpandedChanged -= OnItemExpandedChanged;
            }
        }

        /// <summary>
        /// Remove the ExpandedChanged handler to some items.
        /// </summary>
        /// <param name="startIndex">First item index.</param>
        /// <param name="endIndex">Last item index.</param>
        private void RemoveExpandedChangedHandler(int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++) RemoveExpandedChangedHandler(i);
        }

        private void OnItemExpandedChanged(object? s, ItemExpandedChangedEventArgs e) => OnItemExpandedChanged(e);

        #endregion
    }
}
