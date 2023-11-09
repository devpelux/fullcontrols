using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FullControls.Controls
{
    /// <summary>
    /// Similar to the tab control, but without tabs.
    /// Control which view to display via code behind.
    /// </summary>
    [TemplatePart(Name = PartContentHost, Type = typeof(Decorator))]
    [ContentProperty(nameof(Items))]
    [DefaultProperty(nameof(Items))]
    public class SelectiveView : SimpleItemsControl<ObservableCollection<UIElement>>
    {
        //Container for the items.
        private readonly Grid itemsContainer = new();

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Gets or sets the current selected view.
        /// </summary>
        public int SelectedView
        {
            get => (int)GetValue(SelectedViewProperty);
            set => SetValue(SelectedViewProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SelectedView"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedViewProperty =
            DependencyProperty.Register(nameof(SelectedView), typeof(int), typeof(SelectiveView), new PropertyMetadata(-2, SelectedViewChanged, SelectedViewCoerce));

        #region SelectedViewPropertyCallbacks

        //Executed when the selected view is changed.
        private static void SelectedViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((SelectiveView)d).OnSelectedViewChanged((int)e.NewValue);

        //Adapt the index to avoid overflows.
        private static object SelectedViewCoerce(DependencyObject d, object value) => Math.Max(-1, Math.Min((int)value, ((SelectiveView)d).ItemsCount - 1));

        #endregion

        static SelectiveView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectiveView),
                new FrameworkPropertyMetadata(typeof(SelectiveView)));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public SelectiveView() : base()
        {
            SelectedView = -1;
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //Adds the items container.
            if (Template.FindName(PartContentHost, this) is Decorator contentHost) contentHost.Child = itemsContainer;
        }

        /// <inheritdoc/>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            itemsContainer.Children.Clear();
            if (Items != null)
            {
                foreach (UIElement item in Items) itemsContainer.Children.Add(item);
            }
        }

        /// <summary>
        /// Executed when the selected view is changed.
        /// </summary>
        public void OnSelectedViewChanged(int index)
        {
            for (int i = 0; i < ItemsCount; i++)
            {
                Items[i].Visibility = index == i ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
