﻿using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FullControls
{
    /// <summary>
    /// Represents a control that contains a stacked list of items.
    /// Each item can be "expanded" or "collapsed" to reveal the content associated with that item.
    /// </summary>
    [DefaultEvent(nameof(ItemExpandedChanged))]
    [ContentProperty(nameof(Items))]
    [DefaultProperty(nameof(Items))]
    public class Accordion : Control
    {
        private readonly ItemsControl itemsControl;

        /// <summary>
        /// Collection of <see cref="AccordionItem"/> to display inside the <see cref="Accordion"/>.
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
                    => ((Accordion)d).OnItemsInstanceChanged((AccordionItemCollection)e.NewValue))));

        /// <summary>
        /// Gets the number of elements actually contained inside the <see cref="Accordion"/>.
        /// </summary>
        public int ItemCount => Items.Count;

        /// <summary>
        /// Gets a value indicating if the <see cref="Accordion"/> has items.
        /// </summary>
        public bool HasItems => ItemCount > 0;

        /// <summary>
        /// Occurs when in an item <see cref="AccordionItem.IsExpanded"/> is changed.
        /// </summary>
        public event EventHandler<ItemExpandedEventArgs> ItemExpandedChanged;


        /// <summary>
        /// Creates a new <see cref="Accordion"/>.
        /// </summary>
        static Accordion()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Accordion), new FrameworkPropertyMetadata(typeof(Accordion)));
            IsEnabledProperty.OverrideMetadata(typeof(Accordion), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((Accordion)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Creates a new <see cref="Accordion"/>.
        /// </summary>
        public Accordion()
        {
            itemsControl = new ItemsControl();
            Items = new();
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ((Grid)Template.FindName("PART_ContentHost", this))?.Children.Add(itemsControl);
        }

        /// <summary>
        /// Called when in an item <see cref="AccordionItem.IsExpanded"/> is changed.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event data.</param>
        protected virtual void OnItemExpandedChanged(object sender, ItemExpandedEventArgs e) => ItemExpandedChanged?.Invoke(this, e);

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) { }

        /// <summary>
        /// Called when the instance of the <see cref="Items"/> collection is changed.
        /// </summary>
        /// <param name="items">The new <see cref="Items"/> collection.</param>
        protected virtual void OnItemsInstanceChanged(AccordionItemCollection items)
        {
            items.CollectionChanged -= OnItemsChanged;
            items.CollectionChanged += OnItemsChanged;
            ReloadItems();
        }

        /// <summary>
        /// Called when the <see cref="Items"/> collection is internally changed.
        /// </summary>
        /// <param name="s">Object that raised the event.</param>
        /// <param name="e">Event data.</param>
        protected virtual void OnItemsChanged(object s, NotifyCollectionChangedEventArgs e)
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
            RemoveExpandedChangedHandler(0, Items.Count - 1);
            itemsControl.Items.Clear();
            foreach (AccordionItem item in Items) itemsControl.Items.Add(item);
            SetExpandedChangedHandler(0, Items.Count - 1);
        }

        #region ExpandedChangedHandler

        private void SetExpandedChangedHandler(int index)
        {
            ((AccordionItem)itemsControl.Items[index]).ExpandedChanged -= OnItemExpandedChanged;
            ((AccordionItem)itemsControl.Items[index]).ExpandedChanged += OnItemExpandedChanged;
        }

        private void SetExpandedChangedHandler(int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++) SetExpandedChangedHandler(i);
        }

        private void RemoveExpandedChangedHandler(int index)
            => ((AccordionItem)itemsControl.Items[index]).ExpandedChanged -= OnItemExpandedChanged;

        private void RemoveExpandedChangedHandler(int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++) RemoveExpandedChangedHandler(i);
        }

        #endregion
    }
}
