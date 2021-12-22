using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace FullControls.Controls
{
    /// <summary>
    /// Implements a <see cref="TextHeaderAccordionItem"/> where the main content is an <see cref="ItemsControl"/>.
    /// </summary>
    [ContentProperty(nameof(Items))]
    [DefaultProperty(nameof(Items))]
    [TemplatePart(Name = PartContentHost, Type = typeof(ContentPresenter))]
    public class ItemsControlAccordionItem : TextHeaderAccordionItem
    {
        private readonly ItemsControl itemsControl;

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        private const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Gets or sets a collection used to generate the content of the <see cref="ItemsControl"/>.
        /// </summary>
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ItemsSource"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(ItemsControlAccordionItem),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used to display each item of the <see cref="ItemsControl"/>.
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ItemTemplate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(nameof(ItemTemplate), typeof(DataTemplate), typeof(ItemsControlAccordionItem),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the template that defines the panel that controls the layout of the <see cref="ItemsControl"/> items.
        /// </summary>
        public ItemsPanelTemplate ItemsPanel
        {
            get => (ItemsPanelTemplate)GetValue(ItemsPanelProperty);
            set => SetValue(ItemsPanelProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ItemsPanel"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsPanelProperty =
            DependencyProperty.Register(nameof(ItemsPanel), typeof(ItemsPanelTemplate), typeof(ItemsControlAccordionItem),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets the collection used to generate the content of the <see cref="ItemsControl"/>.
        /// </summary>
        public ItemCollection Items => itemsControl.Items;


        static ItemsControlAccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(typeof(ItemsControlAccordionItem)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ItemsControlAccordionItem"/>.
        /// </summary>
        public ItemsControlAccordionItem() : base()
        {
            itemsControl = new ItemsControl();
            PrepareItemsControl();
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AttachItemsControl();
        }

        /// <summary>
        /// Attaches the <see cref="ItemsControl"/> to the <see cref="Collapsible"/> part.
        /// </summary>
        private void AttachItemsControl()
        {
            if (Template.FindName(PartContentHost, this) is ContentPresenter contentHost) contentHost.Content = itemsControl;
        }

        /// <summary>
        /// Prepare the <see cref="ItemsControl"/> part.
        /// </summary>
        private void PrepareItemsControl()
        {
            itemsControl.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(ItemsSource)) { Source = this });
            itemsControl.SetBinding(ItemsControl.ItemTemplateProperty, new Binding(nameof(ItemTemplate)) { Source = this });
            itemsControl.SetBinding(ItemsControl.ItemsPanelProperty, new Binding(nameof(ItemsPanel)) { Source = this });
        }
    }
}
