using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace FullControls.Controls
{
    /// <summary>
    /// Similar to the tab control, but without tabs.
    /// Control which view to display via code behind.
    /// </summary>
    [TemplatePart(Name = PartContentHost, Type = typeof(Decorator))]
    public class SelectiveView : SimpleItemsControl<ObservableCollection<UIElement>>
    {
        //Container for the items.
        private Grid container = new();

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Gets or sets the index of the current visible item.
        /// </summary>
        public int VisibleIndex
        {
            get => (int)GetValue(VisibleIndexProperty);
            set => SetValue(VisibleIndexProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VisibleIndex"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VisibleIndexProperty =
            DependencyProperty.Register(nameof(VisibleIndex), typeof(int), typeof(SelectiveView), new PropertyMetadata(0, VisibleIndexChanged));

        #region VisibleIndexPropertyCallbacks

        //Executed when the index of the current visible item is changed.
        private static void VisibleIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((SelectiveView)d).OnVisibleIndexChanged((int)e.NewValue);

        #endregion

        /// <summary>
        /// Gets the current visible item, or null if no item is visible.
        /// </summary>
        public UIElement? VisibleItem => VisibleIndex < ItemsCount && VisibleIndex > -1 ? Items[VisibleIndex] : null;

        static SelectiveView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectiveView),
                new FrameworkPropertyMetadata(typeof(SelectiveView)));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public SelectiveView() : base() { }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //Attach the items container.
            if (Template.FindName(PartContentHost, this) is Decorator decorator) decorator.Child = container;

            ReloadVisibleItem();
        }

        /// <inheritdoc/>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            UIElementCollection children = container.Children;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    children.Insert(e.NewStartingIndex, (UIElement?)e.NewItems![0]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    children.RemoveAt(e.OldStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    children.RemoveAt(e.OldStartingIndex);
                    children.Insert(e.OldStartingIndex, (UIElement?)e.NewItems![0]);
                    break;
                case NotifyCollectionChangedAction.Move:
                    children.RemoveAt(e.OldStartingIndex);
                    children.Insert(e.NewStartingIndex, (UIElement?)e.NewItems![0]);
                    break;
                default:
                    children.Clear();
                    foreach (UIElement item in e.NewItems!) children.Add(item);
                    break;
            }

            ReloadVisibleItem();
        }
        
        /// <summary>
        /// Executed when the selected view is changed.
        /// </summary>
        protected virtual void OnVisibleIndexChanged(int index)
        {
            ReloadVisibleItem();
        }

        //Sets the visible item as child of the container part.
        private void ReloadVisibleItem()
        {
            for (int i = 0; i < ItemsCount; i++)
            {
                Items[i].Visibility = i == VisibleIndex ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
