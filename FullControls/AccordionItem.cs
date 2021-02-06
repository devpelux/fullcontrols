﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FullControls
{
    /// <summary>
    /// Represents a generic <see cref="Accordion"/> item.
    /// </summary>
    [TemplatePart(Name = PartHeader, Type = typeof(UIElement))]
    [TemplatePart(Name = PartCollapsable, Type = typeof(Collapsable))]
    [DefaultEvent(nameof(IsExpandedChanged))]
    public abstract class AccordionItem : Control
    {
        private bool loaded = false;
        private UIElement header;
        private Collapsable collapsable;

        /// <summary>
        /// Header template part.
        /// </summary>
        protected const string PartHeader = "PART_Header";

        /// <summary>
        /// Collapsable template part.
        /// </summary>
        protected const string PartCollapsable = "PART_Collapsable";

        /// <summary>
        /// The header of the item.
        /// </summary>
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Header"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(object), typeof(AccordionItem), new PropertyMetadata(null));

        /// <summary>
        /// Height of the header.
        /// </summary>
        public double HeaderHeight
        {
            get => (double)GetValue(HeaderHeightProperty);
            set => SetValue(HeaderHeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register(nameof(HeaderHeight), typeof(double), typeof(AccordionItem));

        /// <summary>
        /// Margin of the header.
        /// </summary>
        public Thickness HeaderMargin
        {
            get => (Thickness)GetValue(HeaderMarginProperty);
            set => SetValue(HeaderMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderMarginProperty =
            DependencyProperty.Register(nameof(HeaderMargin), typeof(Thickness), typeof(AccordionItem));

        /// <summary>
        /// Specify if the item is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).
        /// </summary>
        /// <remarks>If <see cref="IsAnimating"/> is <see langword="true"/> the value is reverted to the previous value.</remarks>
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
                new PropertyMetadata(true, new PropertyChangedCallback((d, e) => ((AccordionItem)d).OnExpandedChanged((bool)e.NewValue)),
                    new CoerceValueCallback((d, o) => ((AccordionItem)d).IsAnimating ? d.GetValue(IsExpandedProperty) : o)));

        /// <summary>
        /// Duration of the control animation when <see cref="IsExpanded"/> is changed.
        /// </summary>
        public TimeSpan ExpandingAnimationTime
        {
            get => (TimeSpan)GetValue(ExpandingAnimationTimeProperty);
            set => SetValue(ExpandingAnimationTimeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExpandingAnimationTime"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExpandingAnimationTimeProperty =
            DependencyProperty.Register(nameof(ExpandingAnimationTime), typeof(TimeSpan), typeof(AccordionItem));

        /// <summary>
        /// The index of the <see cref="AccordionItem"/> when in an <see cref="AccordionItemCollection"/>.
        /// </summary>
        public int Index { get; set; } = -1;

        /// <summary>
        /// Specifies if expanding or collapsing anination is currently executing.
        /// </summary>
        [Bindable(true)]
        public bool IsAnimating => collapsable != null && collapsable.IsAnimating;

        /// <summary>
        /// Gets a value indicating whether the mouse pointer is located over the header element
        /// (including his child elements in the visual tree).
        /// </summary>
        public bool IsMouseOverHeader => header != null && header.IsMouseOver;

        /// <summary>
        /// Occurs when <see cref="IsExpanded"/> is changed.
        /// </summary>
        public event EventHandler<ItemExpandedChangedEventArgs> IsExpandedChanged;


        /// <summary>
        /// Creates a new <see cref="AccordionItem"/>.
        /// </summary>
        static AccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccordionItem), new FrameworkPropertyMetadata(typeof(AccordionItem)));
            IsEnabledProperty.OverrideMetadata(typeof(AccordionItem), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((AccordionItem)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            collapsable = (Collapsable)Template.FindName(PartCollapsable, this);
            header = (UIElement)Template.FindName(PartHeader, this);
            if (header != null)
            {
                header.MouseLeftButtonDown += (o, e) => OnHeaderMouseLeftButtonDown(e);
                header.MouseEnter += (o, e) => OnHeaderMouseEnter(e);
                header.MouseLeave += (o, e) => OnHeaderMouseLeave(e);
            }
            loaded = true;
            OnVStateChanged(VStateOverride());
        }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when <see cref="IsExpanded"/> is changed.
        /// </summary>
        /// <param name="newValue">Actual state of <see cref="IsExpanded"/>.</param>
        protected virtual void OnExpandedChanged(bool newValue)
        {
            IsExpandedChanged?.Invoke(this, new ItemExpandedChangedEventArgs(Index, newValue));
            OnVStateChanged(VStateOverride());
        }

        /// <summary>
        /// Called when the mouse left button is pressed when the mouse is over the header control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnHeaderMouseLeftButtonDown(MouseButtonEventArgs e) => IsExpanded = !IsExpanded;

        /// <summary>
        /// Called when the mouse enter the header control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnHeaderMouseEnter(MouseEventArgs e) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when the mouse leave the header control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnHeaderMouseLeave(MouseEventArgs e) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called to calculate the <b>v-state</b> of the control.
        /// </summary>
        protected virtual string VStateOverride()
        {
            if (!loaded) return "Undefined";
            if (!IsEnabled) return "Disabled";
            else if (IsMouseOverHeader)
            {
                if (IsExpanded == true) return "MouseOverHeaderOnExpanded";
                else return "MouseOverHeader";
            }
            else if (IsExpanded == true) return "Expanded";
            else return "Normal";
        }

        /// <summary>
        /// Called when the <b>v-state</b> of the control changed.
        /// </summary>
        /// <remarks>Is called <b>v-state</b> because is not related to the VisualState of the control.</remarks>
        /// <param name="vstate">Actual <b>v-state</b> of the control.</param>
        protected virtual void OnVStateChanged(string vstate) { }

        /// <summary>
        /// Returns the string representation of a <see cref="AccordionItem"/> object.
        /// </summary>
        /// <remarks>Is possible to specify if to add or not the index at the end of the string.</remarks>
        /// <param name="addIndex">Specifies it to add or not the index at the end of the string.</param>
        /// <returns>A string that represents the object.</returns>
        protected virtual string ToString(bool addIndex) => addIndex ? base.ToString() + " " + Index.ToString() : base.ToString();

        /// <inheritdoc/>
        public override string ToString() => ToString(true);
    }
}
