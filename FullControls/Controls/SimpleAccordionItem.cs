using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;

namespace FullControls.Controls
{
    /// <summary>
    /// Implements a <see cref="TextHeaderAccordionItem"/> with simple content.
    /// </summary>
    [ContentProperty(nameof(Content))]
    [DefaultProperty(nameof(Content))]
    public class SimpleAccordionItem : TextHeaderAccordionItem
    {
        /// <summary>
        /// Gets or sets the content of the expanding part.
        /// </summary>
        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Content"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(nameof(Content), typeof(object), typeof(SimpleAccordionItem));


        static SimpleAccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimpleAccordionItem),
                new FrameworkPropertyMetadata(typeof(SimpleAccordionItem)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleAccordionItem"/>.
        /// </summary>
        public SimpleAccordionItem() : base() { }
    }
}
