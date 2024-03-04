using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control similar to <see cref="ItemsControl"/>, but only with essential features, such as items changing events.
    /// The collection of items is of the type specified (T), and must implement IList and INotifyCollectionChanged.
    /// </summary>
    [ContentProperty(nameof(Items))]
    [DefaultProperty(nameof(Items))]
    public abstract class SimpleItemsControl<T> : Control where T : INotifyCollectionChanged, IList, new()
    {
        /// <summary>
        /// Gets or sets the collection of items of the control.
        /// </summary>
        public T Items { get; } = new T();

        /// <summary>
        /// Gets the number of elements actually contained inside the control.
        /// </summary>
        public int ItemsCount => Items.Count;

        /// <summary>
        /// Gets a value indicating if the control has items.
        /// </summary>
        public bool HasItems => ItemsCount > 0;


        static SimpleItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimpleItemsControl<T>),
                new FrameworkPropertyMetadata(typeof(SimpleItemsControl<T>)));

            IsEnabledProperty.OverrideMetadata(typeof(SimpleItemsControl<T>),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((SimpleItemsControl<T>)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public SimpleItemsControl() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
            Items.CollectionChanged += (s, e) => OnItemsChanged(e);
        }

        /// <summary>
        /// Removes all the items
        /// </summary>
        public void Clear() => Items.Clear();

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        protected virtual void OnLoaded(RoutedEventArgs e) { }

        /// <summary>
        /// Called when the enabled stste is changed.
        /// </summary>
        protected virtual void OnEnabledChanged(bool enabledState) { }

        /// <summary>
        /// Called when the items collection is changed.
        /// </summary>
        protected virtual void OnItemsChanged(NotifyCollectionChangedEventArgs e) { }
    }
}
