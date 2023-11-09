using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a control similar to <see cref="ItemsControl"/>, but only with essential features, such as items changing events.
    /// </summary>
    public abstract class SimpleItemsControl<T> : Control where T : INotifyCollectionChanged, IList, new()
    {
        /// <summary>
        /// Gets or sets the collection of items of the control.
        /// </summary>
        public T Items
        {
            get => (T)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Items"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(T), typeof(SimpleItemsControl<T>), new PropertyMetadata(new T(), ItemsInstanceChanged, CoerceItemsValue));

        #region ItemsPropertyCallbacks

        //Executed when items instance is changed.
        private static void ItemsInstanceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SimpleItemsControl<T>)d).OnItemsInstanceChanged((T)e.NewValue, (T)e.OldValue);
        }

        //Avoids null values to items instance.
        private static object CoerceItemsValue(DependencyObject d, object baseValue)
        {
            return baseValue ?? new T();
        }

        #endregion

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
            Items = new T();
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

        //Called when items are internally changed.
        private void OnItemsChanged(object? s, NotifyCollectionChangedEventArgs e) => OnItemsChanged(e);

        /// <summary>
        /// Called when the items collection is changed.
        /// </summary>
        protected virtual void OnItemsChanged(NotifyCollectionChangedEventArgs e) { }

        //Called when the items instance is changed.
        private void OnItemsInstanceChanged(T newItems, T oldItems)
        {
            oldItems.CollectionChanged -= OnItemsChanged;
            newItems.CollectionChanged += OnItemsChanged;
            OnItemsChanged(new(NotifyCollectionChangedAction.Reset));
        }
    }
}
