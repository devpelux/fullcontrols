using FullControls.Common;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control that contains a stacked list of items.
    /// Each item can be <b>expanded</b> or <b>collapsed</b> to reveal the content associated with that item.
    /// </summary>
    [TemplatePart(Name = PartContentHost, Type = typeof(Decorator))]
    [DefaultEvent(nameof(ItemIsExpandedChanged))]
    [ContentProperty(nameof(Items))]
    [DefaultProperty(nameof(Items))]
    public class Accordion : Control
    {
        private readonly ItemsControl itemsControl;

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Gets or sets a collection of <see cref="AccordionItem"/> to display inside the <see cref="Accordion"/>.
        /// </summary>
        public AccordionItemCollection Items
        {
            get => (AccordionItemCollection)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Items"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(AccordionItemCollection), typeof(Accordion),
                new PropertyMetadata(null, new PropertyChangedCallback((d, e)
                    => ((Accordion)d).OnItemsInstanceChanged((AccordionItemCollection)e.NewValue, (AccordionItemCollection)e.OldValue))));

        /// <summary>
        /// Gets the number of elements actually contained inside the <see cref="Accordion"/>.
        /// </summary>
        public int ItemsCount => Items != null ? Items.Count : 0;

        /// <summary>
        /// Gets a value indicating if the <see cref="Accordion"/> has items.
        /// </summary>
        public bool HasItems => ItemsCount > 0;

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
            itemsControl = new ItemsControl();
            Items = new();
        }

        /// <summary>
        /// Reset the <see cref="Accordion"/> by setting <see cref="Items"/> to a new instance.
        /// </summary>
        public void Reset() => Items = new();

        /// <summary>
        /// Clear the <see cref="Accordion"/> by removing all the <see cref="AccordionItem"/> from <see cref="Items"/>,
        /// and setting <see cref="Items"/> to a new instance.
        /// </summary>
        public void Clear()
        {
            Items.Clear();
            Reset();
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Decorator contentHost = (Decorator)Template.FindName(PartContentHost, this);
            if (contentHost != null) contentHost.Child = itemsControl;
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) { }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) { }

        /// <summary>
        /// Called when in an item <see cref="AccordionItem.IsExpanded"/> is changed.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnItemExpandedChanged(ItemExpandedChangedEventArgs e) => ItemIsExpandedChanged?.Invoke(this, e);

        /// <summary>
        /// Called when the instance of the <see cref="Items"/> collection is changed.
        /// </summary>
        /// <param name="newItems">The new <see cref="Items"/> collection.</param>
        /// <param name="oldItems">The old <see cref="Items"/> collection.</param>
        protected virtual void OnItemsInstanceChanged(AccordionItemCollection newItems, AccordionItemCollection oldItems)
        {
            if (oldItems != null) oldItems.CollectionChanged -= OnItemsChanged;
            if (newItems != null) newItems.CollectionChanged += OnItemsChanged;
            ReloadItems();
        }

        /// <summary>
        /// Called when the <see cref="Items"/> collection is internally changed.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
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
        /// Reloads all the <see cref="Items"/>.
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

        #endregion

        #region EventHandlers

        private void OnItemsChanged(object? s, NotifyCollectionChangedEventArgs e) => OnItemsChanged(e);

        private void OnItemExpandedChanged(object? s, ItemExpandedChangedEventArgs e) => OnItemExpandedChanged(e);

        #endregion
    }
}
