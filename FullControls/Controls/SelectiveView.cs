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
        //Container for the visible item.
        private Decorator? itemContainer;

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Gets or sets the current visible item.
        /// </summary>
        public int VisibleItem
        {
            get => (int)GetValue(VisibleItemProperty);
            set => SetValue(VisibleItemProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VisibleItem"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VisibleItemProperty =
            DependencyProperty.Register(nameof(VisibleItem), typeof(int), typeof(SelectiveView), new PropertyMetadata(0, VisibleItemChanged));

        #region VisibleItemPropertyCallbacks

        //Executed when the visible item is changed.
        private static void VisibleItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((SelectiveView)d).OnVisibleItemChanged((int)e.NewValue);

        #endregion

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

            //Finds the visible item container.
            itemContainer = Template.FindName(PartContentHost, this) as Decorator;
            ReloadVisibleItem();
        }

        /// <inheritdoc/>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            ReloadVisibleItem();
        }

        /// <summary>
        /// Executed when the selected view is changed.
        /// </summary>
        protected virtual void OnVisibleItemChanged(int index)
        {
            ReloadVisibleItem();
        }

        //Sets the visible item as child of the container part.
        private void ReloadVisibleItem()
        {
            if (itemContainer != null)
            {
                itemContainer.Child = VisibleItem < ItemsCount && VisibleItem > -1 ? Items[VisibleItem] : null;
            }
        }
    }
}
