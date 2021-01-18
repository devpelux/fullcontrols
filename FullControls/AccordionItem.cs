using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FullControls
{
    /// <summary>
    /// Represents a generic <see cref="Accordion"/> item.
    /// </summary>
    [DefaultEvent(nameof(ExpandedChanged))]
    public abstract class AccordionItem : Control
    {
        /// <summary>
        /// The header of the item.
        /// </summary>
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Header"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(string), typeof(AccordionItem), new PropertyMetadata(null));

        /// <summary>
        /// Specify if the item is expanded (true) or collapsed (false).
        /// </summary>
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IsExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(AccordionItem),
                new PropertyMetadata(true, new PropertyChangedCallback((d, e) => ((AccordionItem)d).OnExpandedChanged((bool)e.NewValue))));

        /// <summary>
        /// The index of the <see cref="AccordionItem"/> when in an <see cref="AccordionItemCollection"/>.
        /// </summary>
        public int Index { get; set; } = -1;

        /// <summary>
        /// Occurs when <see cref="IsExpanded"/> is changed.
        /// </summary>
        public event EventHandler<ItemExpandedEventArgs> ExpandedChanged;


        /// <summary>
        /// Creates a new <see cref="AccordionItem"/>.
        /// </summary>
        static AccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccordionItem), new FrameworkPropertyMetadata(typeof(AccordionItem)));
            IsEnabledProperty.OverrideMetadata(typeof(AccordionItem), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((AccordionItem)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) { }

        /// <summary>
        /// Called when <see cref="IsExpanded"/> is changed.
        /// </summary>
        /// <param name="newValue">Actual state of <see cref="IsExpanded"/>.</param>
        protected virtual void OnExpandedChanged(bool newValue)
            => ExpandedChanged?.Invoke(this, new ItemExpandedEventArgs(Index, newValue));

        /// <summary>
        /// Returns the string representation of a <see cref="AccordionItem"/> object.
        /// </summary>
        /// <remarks>Is possible to specify if to add or not the index at the end of the string.</remarks>
        /// <param name="addIndex">Specifies it to add or not the index at the end of the string.</param>
        /// <returns>A string that represents the object.</returns>
        protected virtual string ToString(bool addIndex) => addIndex ? base.ToString() + " " + Index.ToString() : base.ToString();

        /// <summary>
        /// Returns the string representation of a <see cref="AccordionItem"/> object.
        /// </summary>
        /// <returns>A string that represents the object.</returns>
        public override string ToString() => ToString(true);
    }
}
