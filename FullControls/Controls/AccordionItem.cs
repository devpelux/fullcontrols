using FullControls.Common;
using FullControls.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a generic <see cref="Accordion"/> item with a header and a <see cref="Collapsible"/>.
    /// </summary>
    [TemplatePart(Name = PartHeader, Type = typeof(UIElement))]
    [TemplatePart(Name = PartCollapsible, Type = typeof(Collapsible))]
    [DefaultEvent(nameof(IsExpandedChanged))]
    public abstract class AccordionItem : Control
    {
        private bool loaded = false;
        private UIElement header;

        /// <summary>
        /// Header template part.
        /// </summary>
        protected const string PartHeader = "PART_Header";

        /// <summary>
        /// Collapsible template part.
        /// </summary>
        protected const string PartCollapsible = "PART_Collapsible";

        /// <summary>
        /// Gets or sets the header of the item.
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
            DependencyProperty.Register(nameof(Header), typeof(object), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the height of the header.
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

        #region HeaderBackground

        /// <summary>
        /// Gets or sets the background brush of the header.
        /// </summary>
        public Brush HeaderBackground
        {
            get => (Brush)GetValue(HeaderBackgroundProperty);
            set => SetValue(HeaderBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register(nameof(HeaderBackground), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the background brush of the header when the mouse is over the header.
        /// </summary>
        public Brush HeaderBackgroundOnMouseOver
        {
            get => (Brush)GetValue(HeaderBackgroundOnMouseOverProperty);
            set => SetValue(HeaderBackgroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBackgroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(HeaderBackgroundOnMouseOver), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the background brush of the header when <see cref="IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public Brush HeaderBackgroundOnExpanded
        {
            get => (Brush)GetValue(HeaderBackgroundOnExpandedProperty);
            set => SetValue(HeaderBackgroundOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBackgroundOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBackgroundOnExpandedProperty =
            DependencyProperty.Register(nameof(HeaderBackgroundOnExpanded), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the background brush of the header when the mouse is over the header and <see cref="IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public Brush HeaderBackgroundOnMouseOverOnExpanded
        {
            get => (Brush)GetValue(HeaderBackgroundOnMouseOverOnExpandedProperty);
            set => SetValue(HeaderBackgroundOnMouseOverOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBackgroundOnMouseOverOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBackgroundOnMouseOverOnExpandedProperty =
            DependencyProperty.Register(nameof(HeaderBackgroundOnMouseOverOnExpanded), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the background brush of the header when the control is disabled.
        /// </summary>
        public Brush HeaderBackgroundOnDisabled
        {
            get => (Brush)GetValue(HeaderBackgroundOnDisabledProperty);
            set => SetValue(HeaderBackgroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBackgroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(HeaderBackgroundOnDisabled), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets the actual background brush of the header.
        /// </summary>
        public Brush ActualHeaderBackground => (Brush)GetValue(ActualHeaderBackgroundProperty);

        #region ActualHeaderBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualHeaderBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualHeaderBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualHeaderBackground), typeof(Brush), typeof(AccordionItem),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualHeaderBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualHeaderBackgroundProperty = ActualHeaderBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualHeaderBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualHeaderBackgroundPropertyProxy =
            DependencyProperty.Register("ActualHeaderBackgroundProxy", typeof(Brush), typeof(AccordionItem),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualHeaderBackgroundPropertyKey, e.NewValue))));

        #endregion

        #endregion

        #region HeaderBorderBrush

        /// <summary>
        /// Gets or sets the border brush of the header.
        /// </summary>
        public Brush HeaderBorderBrush
        {
            get => (Brush)GetValue(HeaderBorderBrushProperty);
            set => SetValue(HeaderBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBorderBrushProperty =
            DependencyProperty.Register(nameof(HeaderBorderBrush), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the border brush of the header when the mouse is over the header.
        /// </summary>
        public Brush HeaderBorderBrushOnMouseOver
        {
            get => (Brush)GetValue(HeaderBorderBrushOnMouseOverProperty);
            set => SetValue(HeaderBorderBrushOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBorderBrushOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBorderBrushOnMouseOverProperty =
            DependencyProperty.Register(nameof(HeaderBorderBrushOnMouseOver), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the border brush of the header when <see cref="IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public Brush HeaderBorderBrushOnExpanded
        {
            get => (Brush)GetValue(HeaderBorderBrushOnExpandedProperty);
            set => SetValue(HeaderBorderBrushOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBorderBrushOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBorderBrushOnExpandedProperty =
            DependencyProperty.Register(nameof(HeaderBorderBrushOnExpanded), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the border brush of the header when the mouse is over the header and <see cref="IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public Brush HeaderBorderBrushOnMouseOverOnExpanded
        {
            get => (Brush)GetValue(HeaderBorderBrushOnMouseOverOnExpandedProperty);
            set => SetValue(HeaderBorderBrushOnMouseOverOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBorderBrushOnMouseOverOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBorderBrushOnMouseOverOnExpandedProperty =
            DependencyProperty.Register(nameof(HeaderBorderBrushOnMouseOverOnExpanded), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the border brush of the header when the control is disabled.
        /// </summary>
        public Brush HeaderBorderBrushOnDisabled
        {
            get => (Brush)GetValue(HeaderBorderBrushOnDisabledProperty);
            set => SetValue(HeaderBorderBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeaderBorderBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(HeaderBorderBrushOnDisabled), typeof(Brush), typeof(AccordionItem));

        /// <summary>
        /// Gets the actual border brush of the header.
        /// </summary>
        public Brush ActualHeaderBorderBrush => (Brush)GetValue(ActualHeaderBorderBrushProperty);

        #region ActualHeaderBorderBrushProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualHeaderBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualHeaderBorderBrushPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualHeaderBorderBrush), typeof(Brush), typeof(AccordionItem),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualHeaderBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualHeaderBorderBrushProperty = ActualHeaderBorderBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualHeaderBorderBrush"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualHeaderBorderBrushPropertyProxy =
            DependencyProperty.Register("ActualHeaderBorderBrushProxy", typeof(Brush), typeof(AccordionItem),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualHeaderBorderBrushPropertyKey, e.NewValue))));

        #endregion

        #endregion

        /// <summary>
        /// Gets or sets the corner radius of the control.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        #region CornerRadiusProperty

        /// <summary>
        /// Identifies the <see cref="CornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(AccordionItem),
                new FrameworkPropertyMetadata(default(CornerRadius), new PropertyChangedCallback((d, e)
                    => SetCornerRadiuses(d, (CornerRadius)e.NewValue))));

        /// <summary>
        /// Sets the corner radius properties for header and content.
        /// </summary>
        private static void SetCornerRadiuses(DependencyObject d, CornerRadius cornerRadius)
        {
            d.SetValue(HeaderCornerRadiusPropertyKey, new CornerRadius(cornerRadius.TopLeft, cornerRadius.TopRight, 0, 0));
            d.SetValue(ContentCornerRadiusPropertyKey, new CornerRadius(0, 0, cornerRadius.BottomRight, cornerRadius.BottomLeft));
        }

        #endregion

        /// <summary>
        /// Gets the corner radius of the header.
        /// </summary>
        public CornerRadius HeaderCornerRadius => (CornerRadius)GetValue(HeaderCornerRadiusProperty);

        #region HeaderCornerRadiusProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="HeaderCornerRadius"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey HeaderCornerRadiusPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(HeaderCornerRadius), typeof(CornerRadius), typeof(AccordionItem),
                new FrameworkPropertyMetadata(default(CornerRadius)));

        /// <summary>
        /// Identifies the <see cref="HeaderCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderCornerRadiusProperty = HeaderCornerRadiusPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets the corner radius of the content.
        /// </summary>
        public CornerRadius ContentCornerRadius => (CornerRadius)GetValue(ContentCornerRadiusProperty);

        #region ContentCornerRadiusProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ContentCornerRadius"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ContentCornerRadiusPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ContentCornerRadius), typeof(CornerRadius), typeof(AccordionItem),
                new FrameworkPropertyMetadata(default(CornerRadius)));

        /// <summary>
        /// Identifies the <see cref="ContentCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentCornerRadiusProperty = ContentCornerRadiusPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets the border thickness of the content.
        /// </summary>
        public Thickness ContentBorderThickness => (Thickness)GetValue(ContentBorderThicknessProperty);

        #region ContentBorderThicknessProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ContentBorderThickness"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ContentBorderThicknessPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ContentBorderThickness), typeof(Thickness), typeof(AccordionItem),
                new FrameworkPropertyMetadata(default(Thickness)));

        /// <summary>
        /// Identifies the <see cref="ContentBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentBorderThicknessProperty = ContentBorderThicknessPropertyKey.DependencyProperty;

        /// <summary>
        /// Sets the corner radius properties for header and content.
        /// </summary>
        private static void SetContentBorderThickness(DependencyObject d, Thickness thickness)
            => d.SetValue(ContentBorderThicknessPropertyKey, new Thickness(thickness.Left, 0, thickness.Right, thickness.Bottom));

        #endregion

        /// <summary>
        /// Gets or sets the padding of the content.
        /// </summary>
        public Thickness ContentPadding
        {
            get => (Thickness)GetValue(ContentPaddingProperty);
            set => SetValue(ContentPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ContentPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentPaddingProperty =
            DependencyProperty.Register(nameof(ContentPadding), typeof(Thickness), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets a value indicating if the item is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).
        /// </summary>
        /// <remarks>If <see cref="IsAnimating"/> is <see langword="true"/> the value is reverted to the previous value.</remarks>
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="IsExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(AccordionItem),
                new PropertyMetadata(BoolBox.True, new PropertyChangedCallback((d, e) => ((AccordionItem)d).OnExpandedChanged((bool)e.NewValue)),
                    new CoerceValueCallback((d, o) => ((AccordionItem)d).IsAnimating ? d.GetValue(IsExpandedProperty) : o)));

        /// <summary>
        /// Gets or sets the duration of the control animation when it changes state.
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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(AccordionItem));

        /// <summary>
        /// Gets or sets the duration of the control animation when <see cref="IsExpanded"/> is changed.
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
        /// Gets the index of the <see cref="AccordionItem"/> when is in an <see cref="AccordionItemCollection"/>.
        /// </summary>
        public int Index { get; set; } = -1;

        /// <summary>
        /// Gets a values indicating if expanding or collapsing anination is currently executing.
        /// </summary>
        public bool IsAnimating => (bool)GetValue(IsAnimatingProperty);

        #region IsAnimatingProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="IsAnimating"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey IsAnimatingPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsAnimating), typeof(bool), typeof(AccordionItem),
                new FrameworkPropertyMetadata(BoolBox.False));

        /// <summary>
        /// Identifies the <see cref="IsAnimating"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsAnimatingProperty = IsAnimatingPropertyKey.DependencyProperty;

        #endregion

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
        /// Occurs when the collapsing or expanding animation started.
        /// </summary>
        public event EventHandler AnimationStarted;

        /// <summary>
        /// Occurs when the collapsing or expanding animation ended.
        /// </summary>
        public event EventHandler AnimationEnded;


        static AccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccordionItem),
                new FrameworkPropertyMetadata(typeof(AccordionItem)));

            IsEnabledProperty.OverrideMetadata(typeof(AccordionItem),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((AccordionItem)d).OnEnabledChanged((bool)e.NewValue))));

            BorderThicknessProperty.OverrideMetadata(typeof(AccordionItem),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => SetContentBorderThickness(d, (Thickness)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AccordionItem"/>.
        /// </summary>
        protected AccordionItem() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Collapsible collapsible = (Collapsible)Template.FindName(PartCollapsible, this);
            if (collapsible != null)
            {
                collapsible.AnimationStarted += (o, e) => OnAnimationStarted(e);
                collapsible.AnimationEnded += (o, e) => OnAnimationEnded(e);
            }
            header = (UIElement)Template.FindName(PartHeader, this);
            if (header != null)
            {
                header.MouseLeftButtonDown += (o, e) => OnHeaderMouseLeftButtonDown(e);
                header.MouseEnter += (o, e) => OnHeaderMouseEnter(e);
                header.MouseLeave += (o, e) => OnHeaderMouseLeave(e);
            }
            UpdateExpandState();
            loaded = true;
            OnVStateChanged(VStateOverride(), true);
        }

        /// <summary>
        /// Executed when the animation is started.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnAnimationStarted(EventArgs e)
        {
            SetValue(IsAnimatingPropertyKey, BoolBox.True);
            AnimationStarted?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Executed when the animation is ended.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnAnimationEnded(EventArgs e)
        {
            SetValue(IsAnimatingPropertyKey, BoolBox.False);
            AnimationEnded?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when <see cref="IsExpanded"/> is changed.
        /// </summary>
        /// <param name="isExpanded">Actual state of <see cref="IsExpanded"/>.</param>
        protected virtual void OnExpandedChanged(bool isExpanded)
        {
            UpdateExpandState();
            OnVStateChanged(VStateOverride());
            IsExpandedChanged?.Invoke(this, new ItemExpandedChangedEventArgs(Index, isExpanded));
        }

        /// <summary>
        /// Called when the mouse left button is pressed when the mouse is over the header control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnHeaderMouseLeftButtonDown(MouseButtonEventArgs e) => IsExpanded = !IsExpanded;

        /// <summary>
        /// Called when the mouse enters the header control.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnHeaderMouseEnter(MouseEventArgs e) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when the mouse leaves the header control.
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
        /// Called when the <b>v-state</b> of the control changed, is used to execute custom animations on certain contitions changing.
        /// </summary>
        /// <remarks>Is called <b>v-state</b> because is not related to the VisualState of the control.</remarks>
        /// <param name="vstate">Actual <b>v-state</b> of the control.</param>
        /// <param name="initial">Specifies if this is the first <b>v-state</b> applied to the control.</param>
        protected virtual void OnVStateChanged(string vstate, bool initial = false)
        {
            switch (vstate)
            {
                case "Normal":
                    Util.AnimateBrush(this, ActualHeaderBackgroundPropertyProxy, HeaderBackground, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualHeaderBorderBrushPropertyProxy, HeaderBorderBrush, initial ? TimeSpan.Zero : AnimationTime);
                    break;
                case "Expanded":
                    Util.AnimateBrush(this, ActualHeaderBackgroundPropertyProxy, HeaderBackgroundOnExpanded, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualHeaderBorderBrushPropertyProxy, HeaderBorderBrushOnExpanded, initial ? TimeSpan.Zero : AnimationTime);
                    break;
                case "MouseOverHeader":
                    Util.AnimateBrush(this, ActualHeaderBackgroundPropertyProxy, HeaderBackgroundOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualHeaderBorderBrushPropertyProxy, HeaderBorderBrushOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                    break;
                case "MouseOverHeaderOnExpanded":
                    Util.AnimateBrush(this, ActualHeaderBackgroundPropertyProxy, HeaderBackgroundOnMouseOverOnExpanded, initial ? TimeSpan.Zero : AnimationTime);
                    Util.AnimateBrush(this, ActualHeaderBorderBrushPropertyProxy, HeaderBorderBrushOnMouseOverOnExpanded, initial ? TimeSpan.Zero : AnimationTime);
                    break;
                case "Disabled":
                    Util.AnimateBrush(this, ActualHeaderBackgroundPropertyProxy, HeaderBackgroundOnDisabled, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualHeaderBorderBrushPropertyProxy, HeaderBorderBrushOnDisabled, TimeSpan.Zero);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Returns the string representation of a <see cref="AccordionItem"/> object.
        /// </summary>
        /// <remarks>Is possible to specify if to add or not the index at the end of the string.</remarks>
        /// <param name="addIndex">Specifies it to add or not the index at the end of the string.</param>
        /// <returns>A string that represents the object.</returns>
        protected virtual string ToString(bool addIndex) => addIndex ? base.ToString() + " " + Index.ToString() : base.ToString();

        /// <inheritdoc/>
        public override string ToString() => ToString(true);

        /// <summary>
        /// Update the visualstate to <see langword="Expanded"/> or <see langword="Collapsed"/> if the control is expanded or collapsed.
        /// </summary>
        private void UpdateExpandState() => _ = VisualStateManager.GoToState(this, IsExpanded ? "Expanded" : "Collapsed", true);
    }
}
