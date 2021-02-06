using FullControls.Core;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// <see cref="AccordionItem"/> with header and content, where the main content is an <see cref="ItemsControl"/>.
    /// </summary>
    [ContentProperty(nameof(Items))]
    [DefaultProperty(nameof(Items))]
    public class ItemsControlAccordionItem : AccordionItem
    {
        private readonly ItemsControl itemsControl;

        /// <summary>
        /// Foreground brush when the mouse is over the control.
        /// </summary>
        public Brush ForegroundOnMouseOver
        {
            get => (Brush)GetValue(ForegroundOnMouseOverProperty);
            set => SetValue(ForegroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Foreground brush when <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public Brush ForegroundOnExpanded
        {
            get => (Brush)GetValue(ForegroundOnExpandedProperty);
            set => SetValue(ForegroundOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnExpandedProperty =
            DependencyProperty.Register(nameof(ForegroundOnExpanded), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Foreground brush when the mouse is over the control and <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public Brush ForegroundOnMouseOverOnExpanded
        {
            get => (Brush)GetValue(ForegroundOnMouseOverOnExpandedProperty);
            set => SetValue(ForegroundOnMouseOverOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnMouseOverOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnMouseOverOnExpandedProperty =
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnExpanded), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Foreground brush when the control is disabled.
        /// </summary>
        public Brush ForegroundOnDisabled
        {
            get => (Brush)GetValue(ForegroundOnDisabledProperty);
            set => SetValue(ForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Actual Foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// FontWeight brush when the mouse is over the control.
        /// </summary>
        public FontWeight FontWeightOnMouseOver
        {
            get => (FontWeight)GetValue(FontWeightOnMouseOverProperty);
            set => SetValue(FontWeightOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="FontWeightOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FontWeightOnMouseOverProperty =
            DependencyProperty.Register(nameof(FontWeightOnMouseOver), typeof(FontWeight), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// FontWeight brush when <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public FontWeight FontWeightOnExpanded
        {
            get => (FontWeight)GetValue(FontWeightOnExpandedProperty);
            set => SetValue(FontWeightOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="FontWeightOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FontWeightOnExpandedProperty =
            DependencyProperty.Register(nameof(FontWeightOnExpanded), typeof(FontWeight), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// FontWeight brush when the mouse is over the control and <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public FontWeight FontWeightOnMouseOverOnExpanded
        {
            get => (FontWeight)GetValue(FontWeightOnMouseOverOnExpandedProperty);
            set => SetValue(FontWeightOnMouseOverOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="FontWeightOnMouseOverOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FontWeightOnMouseOverOnExpandedProperty =
            DependencyProperty.Register(nameof(FontWeightOnMouseOverOnExpanded), typeof(FontWeight), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// FontWeight brush when the control is disabled.
        /// </summary>
        public FontWeight FontWeightOnDisabled
        {
            get => (FontWeight)GetValue(FontWeightOnDisabledProperty);
            set => SetValue(FontWeightOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="FontWeightOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FontWeightOnDisabledProperty =
            DependencyProperty.Register(nameof(FontWeightOnDisabled), typeof(FontWeight), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Actual FontWeight of the control.
        /// </summary>
        public FontWeight ActualFontWeight => (FontWeight)GetValue(ActualFontWeightProperty);

        /// <summary>
        /// Identifies the <see cref="ActualFontWeight"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualFontWeightProperty =
            DependencyProperty.Register(nameof(ActualFontWeight), typeof(FontWeight), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Vertical alignment of the header.
        /// </summary>
        public VerticalAlignment VerticalHeaderAlignment
        {
            get => (VerticalAlignment)GetValue(VerticalHeaderAlignmentProperty);
            set => SetValue(VerticalHeaderAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="VerticalHeaderAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalHeaderAlignmentProperty =
            DependencyProperty.Register(nameof(VerticalHeaderAlignment), typeof(VerticalAlignment), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Horizontal alignment of the header.
        /// </summary>
        public HorizontalAlignment HorizontalHeaderAlignment
        {
            get => (HorizontalAlignment)GetValue(HorizontalHeaderAlignmentProperty);
            set => SetValue(HorizontalHeaderAlignmentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HorizontalHeaderAlignment"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalHeaderAlignmentProperty =
            DependencyProperty.Register(nameof(HorizontalHeaderAlignment), typeof(HorizontalAlignment), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Duration of the control animation when it changes state.
        /// </summary>
        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AnimationTime"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(ItemsControlAccordionItem));

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
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(ItemsControlAccordionItem), new PropertyMetadata(null));

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
            DependencyProperty.Register(nameof(ItemTemplate), typeof(DataTemplate), typeof(ItemsControlAccordionItem), new PropertyMetadata(null));

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
            DependencyProperty.Register(nameof(ItemsPanel), typeof(ItemsPanelTemplate), typeof(ItemsControlAccordionItem), new PropertyMetadata(null));

        /// <summary>
        /// Gets the collection used to generate the content of the <see cref="ItemsControl"/>.
        /// </summary>
        public ItemCollection Items => itemsControl.Items;


        /// <summary>
        /// Creates a new <see cref="ItemsControlAccordionItem"/>.
        /// </summary>
        static ItemsControlAccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemsControlAccordionItem), new FrameworkPropertyMetadata(typeof(ItemsControlAccordionItem)));
        }

        /// <summary>
        /// Creates a new <see cref="ItemsControlAccordionItem"/>.
        /// </summary>
        public ItemsControlAccordionItem()
        {
            itemsControl = new ItemsControl();
            SetItemsControlBindings();
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Collapsable collapsable = (Collapsable)Template.FindName(PartCollapsable, this);
            if (collapsable != null) collapsable.Child = itemsControl;
            Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            SetValue(ActualFontWeightProperty, FontWeight);
        }

        /// <inheritdoc/>
        protected override void OnVStateChanged(string vstate)
        {
            switch (vstate)
            {
                case "Normal":
                    Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, AnimationTime);
                    SetValue(ActualFontWeightProperty, FontWeight);
                    break;
                case "Expanded":
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnExpanded, AnimationTime);
                    SetValue(ActualFontWeightProperty, FontWeightOnExpanded);
                    break;
                case "MouseOverHeader":
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOver, AnimationTime);
                    SetValue(ActualFontWeightProperty, FontWeightOnMouseOver);
                    break;
                case "MouseOverHeaderOnExpanded":
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOverOnExpanded, AnimationTime);
                    SetValue(ActualFontWeightProperty, FontWeightOnMouseOverOnExpanded);
                    break;
                case "Disabled":
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnDisabled, TimeSpan.Zero);
                    SetValue(ActualFontWeightProperty, FontWeightOnDisabled);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the bindings to <see cref="itemsControl"/>.
        /// </summary>
        private void SetItemsControlBindings()
        {
            itemsControl.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(ItemsSource)) { Source = this });
            itemsControl.SetBinding(ItemsControl.ItemTemplateProperty, new Binding(nameof(ItemTemplate)) { Source = this });
            itemsControl.SetBinding(ItemsControl.ItemsPanelProperty, new Binding(nameof(ItemsPanel)) { Source = this });
            itemsControl.SetBinding(MarginProperty, new Binding(nameof(Padding)) { Source = this });
            itemsControl.SetBinding(HorizontalAlignmentProperty, new Binding(nameof(HorizontalContentAlignment)) { Source = this });
            itemsControl.SetBinding(VerticalAlignmentProperty, new Binding(nameof(VerticalContentAlignment)) { Source = this });
        }
    }
}
