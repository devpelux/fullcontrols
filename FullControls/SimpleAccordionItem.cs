using FullControls.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// Simple <see cref="AccordionItem"/> with header and content.
    /// </summary>
    [TemplatePart(Name = PartHeader, Type = typeof(UIElement))]
    [TemplatePart(Name = PartContent, Type = typeof(CollapsableGrid))]
    [DefaultEvent(nameof(ExpandedChanged))]
    [ContentProperty(nameof(Content))]
    [DefaultProperty(nameof(Content))]
    public class SimpleAccordionItem : AccordionItem
    {
        private bool loaded = false;
        private UIElement header;
        private CollapsableGrid content;

        /// <summary>
        /// Header template part.
        /// </summary>
        protected const string PartHeader = "PART_Header";

        /// <summary>
        /// Content template part.
        /// </summary>
        protected const string PartContent = "PART_Content";

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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(SimpleAccordionItem));

        /// <summary>
        /// Foreground brush when <see cref="AccordionItem.IsExpanded"/> is true.
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
            DependencyProperty.Register(nameof(ForegroundOnExpanded), typeof(Brush), typeof(SimpleAccordionItem));

        /// <summary>
        /// Foreground brush when the mouse is over the control and <see cref="AccordionItem.IsExpanded"/> is true.
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
            DependencyProperty.Register(nameof(ForegroundOnMouseOverOnExpanded), typeof(Brush), typeof(SimpleAccordionItem));

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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(SimpleAccordionItem));

        /// <summary>
        /// Actual Foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(SimpleAccordionItem));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(SimpleAccordionItem));

        /// <summary>
        /// Duration of the control animation when <see cref="AccordionItem.IsExpanded"/> is changed.
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
            DependencyProperty.Register(nameof(ExpandingAnimationTime), typeof(TimeSpan), typeof(SimpleAccordionItem));

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
            DependencyProperty.Register(nameof(HeaderHeight), typeof(double), typeof(SimpleAccordionItem));

        /// <summary>
        /// Content of the expanding part.
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

        /// <summary>
        /// Specifies if expanding or collapsing anination is currently executing.
        /// </summary>
        public bool IsAnimating => content != null && content.IsAnimating;

        /// <summary>
        /// Gets a value indicating whether the mouse pointer is located over the header element
        /// (including his child elements in the visual tree).
        /// </summary>
        public bool IsMouseOverHeader => header != null && header.IsMouseOver;


        /// <summary>
        /// Creates a new <see cref="SimpleAccordionItem"/>.
        /// </summary>
        static SimpleAccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimpleAccordionItem), new FrameworkPropertyMetadata(typeof(SimpleAccordionItem)));
            IsExpandedProperty.OverrideMetadata(typeof(SimpleAccordionItem), new PropertyMetadata(true, null,
                new CoerceValueCallback((d, o) => ((SimpleAccordionItem)d).IsAnimating ? d.GetValue(IsExpandedProperty) : o)));
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            content = (CollapsableGrid)Template.FindName(PartContent, this);
            header = (UIElement)Template.FindName(PartHeader, this);
            header.MouseLeftButtonDown += (o, e) => OnHeaderMouseLeftButtonDown(e);
            header.MouseEnter += (o, e) => OnHeaderMouseEnter(e);
            header.MouseLeave += (o, e) => OnHeaderMouseLeave(e);
            Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            loaded = true;
            ReloadBrushes();
        }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected override void OnEnabledChanged(bool enabledState)
        {
            base.OnEnabledChanged(enabledState);
            ReloadBrushes();
        }

        /// <summary>
        /// Called when <see cref="AccordionItem.IsExpanded"/> is changed.
        /// </summary>
        /// <param name="newValue">Actual state of <see cref="AccordionItem.IsExpanded"/>.</param>
        protected override void OnExpandedChanged(bool newValue)
        {
            base.OnExpandedChanged(newValue);
            ReloadBrushes();
        }

        /// <summary>
        /// Called when the mouse left button is pressed when the mouse is over the header control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnHeaderMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            IsExpanded ^= true;
        }

        /// <summary>
        /// Called when the mouse enter the header control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnHeaderMouseEnter(MouseEventArgs e)
        {
            ReloadBrushes();
        }

        /// <summary>
        /// Called when the mouse leave the header control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnHeaderMouseLeave(MouseEventArgs e)
        {
            ReloadBrushes();
        }

        /// <summary>
        /// Apply the correct brushes to the control, based on its state.
        /// </summary>
        private void ReloadBrushes()
        {
            if (!loaded) return;
            if (!IsEnabled) //Disabled state
            {
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnDisabled, TimeSpan.Zero);
            }
            else if (IsMouseOverHeader) //MouseOver state
            {
                if (IsExpanded == true)
                {
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOverOnExpanded, TimeSpan.Zero);
                }
                else
                {
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnMouseOver, TimeSpan.Zero);
                }
            }
            else if (IsExpanded == true) //Expanded state
            {
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnExpanded, TimeSpan.Zero);
            }
            else //Normal state
            {
                Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            }
        }
    }
}
