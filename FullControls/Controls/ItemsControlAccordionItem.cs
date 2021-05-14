using FullControls.Core;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Implements an <see cref="AccordionItem"/> with header and content, where the main content is an <see cref="ItemsControl"/>.
    /// </summary>
    [ContentProperty(nameof(Items))]
    [DefaultProperty(nameof(Items))]
    [TemplatePart(Name = PartContentHost, Type = typeof(ContentPresenter))]
    public class ItemsControlAccordionItem : AccordionItem
    {
        private readonly ItemsControl itemsControl;

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        private const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Gets or sets the foreground brush when the mouse is over the control.
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
        /// Gets or sets the foreground brush when <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
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
        /// Gets or sets the foreground brush when the mouse is over the control and <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
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
        /// Gets or sets the foreground brush when the control is disabled.
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
        /// Gets the actual foreground brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualForegroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the fontweight when the mouse is over the control.
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
        /// Gets or sets the fontweight when <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
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
        /// Gets or sets the fontweight when the mouse is over the control and <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
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
        /// Gets or sets the fontweight when the control is disabled.
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
        /// Gets the actual fontweight of the control.
        /// </summary>
        public FontWeight ActualFontWeight => (FontWeight)GetValue(ActualFontWeightProperty);

        #region ActualFontWeightProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualFontWeight"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualFontWeightPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualFontWeight), typeof(FontWeight), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(default(FontWeight)));

        /// <summary>
        /// Identifies the <see cref="ActualFontWeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualFontWeightProperty = ActualFontWeightPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets or sets the vertical alignment of the header.
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
        /// Gets or sets the horizontal alignment of the header.
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

        #region Arrow

        /// <summary>
        /// Gets or sets the content of the arrow.
        /// </summary>
        public object Arrow
        {
            get => GetValue(ArrowProperty);
            set => SetValue(ArrowProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Arrow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowProperty =
            DependencyProperty.Register(nameof(Arrow), typeof(object), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets or sets the margin of the arrow.
        /// </summary>
        public Thickness ArrowMargin
        {
            get => (Thickness)GetValue(ArrowMarginProperty);
            set => SetValue(ArrowMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowMarginProperty =
            DependencyProperty.Register(nameof(ArrowMargin), typeof(Thickness), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets or sets the size of the arrow.
        /// </summary>
        public double ArrowSize
        {
            get => (double)GetValue(ArrowSizeProperty);
            set => SetValue(ArrowSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowSizeProperty =
            DependencyProperty.Register(nameof(ArrowSize), typeof(double), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets or sets the font of the arrow (if used a character).
        /// </summary>
        public FontFamily ArrowFont
        {
            get => (FontFamily)GetValue(ArrowFontProperty);
            set => SetValue(ArrowFontProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowFont"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowFontProperty =
            DependencyProperty.Register(nameof(ArrowFont), typeof(FontFamily), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets or sets the foreground brush of the arrow.
        /// </summary>
        public Brush ArrowForeground
        {
            get => (Brush)GetValue(ArrowForegroundProperty);
            set => SetValue(ArrowForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowForegroundProperty =
            DependencyProperty.Register(nameof(ArrowForeground), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets or sets the foreground brush of the arrow when the mouse is over the control.
        /// </summary>
        public Brush ArrowForegroundOnMouseOver
        {
            get => (Brush)GetValue(ArrowForegroundOnMouseOverProperty);
            set => SetValue(ArrowForegroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowForegroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(ArrowForegroundOnMouseOver), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets or sets the foreground brush of the arrow when <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public Brush ArrowForegroundOnExpanded
        {
            get => (Brush)GetValue(ArrowForegroundOnExpandedProperty);
            set => SetValue(ArrowForegroundOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowForegroundOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowForegroundOnExpandedProperty =
            DependencyProperty.Register(nameof(ArrowForegroundOnExpanded), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets or sets the foreground brush of the arrow when the mouse is over the control and <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public Brush ArrowForegroundOnMouseOverOnExpanded
        {
            get => (Brush)GetValue(ArrowForegroundOnMouseOverOnExpandedProperty);
            set => SetValue(ArrowForegroundOnMouseOverOnExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowForegroundOnMouseOverOnExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowForegroundOnMouseOverOnExpandedProperty =
            DependencyProperty.Register(nameof(ArrowForegroundOnMouseOverOnExpanded), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets or sets the foreground brush of the arrow when the control is disabled.
        /// </summary>
        public Brush ArrowForegroundOnDisabled
        {
            get => (Brush)GetValue(ArrowForegroundOnDisabledProperty);
            set => SetValue(ArrowForegroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowForegroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowForegroundOnDisabledProperty =
            DependencyProperty.Register(nameof(ArrowForegroundOnDisabled), typeof(Brush), typeof(ItemsControlAccordionItem));

        /// <summary>
        /// Gets the actual foreground brush of the arrow.
        /// </summary>
        public Brush ActualArrowForeground => (Brush)GetValue(ActualArrowForegroundProperty);

        #region ActualArrowForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualArrowForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualArrowForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualArrowForeground), typeof(Brush), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualArrowForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualArrowForegroundProperty = ActualArrowForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualArrowForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualArrowForegroundPropertyProxy =
            DependencyProperty.Register("ActualArrowForegroundProxy", typeof(Brush), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualArrowForegroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets the rotation of the arrow.
        /// </summary>
        public double ArrowRotation => (double)GetValue(ArrowRotationProperty);

        #region ArrowRotationProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ArrowRotation"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ArrowRotationPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ArrowRotation), typeof(double), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(0d));

        /// <summary>
        /// Identifies the <see cref="ArrowRotation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowRotationProperty = ArrowRotationPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ArrowRotation"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ArrowRotationPropertyProxy =
            DependencyProperty.Register("ArrowRotationProxy", typeof(double), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e)
                    => d.SetValue(ArrowRotationPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the rotation of the arrow when <see cref="AccordionItem.IsExpanded"/> is <see langword="false"/>.
        /// </summary>
        public double ArrowCollapsedRotation
        {
            get => (double)GetValue(ArrowCollapsedRotationProperty);
            set => SetValue(ArrowCollapsedRotationProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowCollapsedRotation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowCollapsedRotationProperty =
            DependencyProperty.Register(nameof(ArrowCollapsedRotation), typeof(double), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(0d));

        /// <summary>
        /// Gets or sets the rotation of the arrow when <see cref="AccordionItem.IsExpanded"/> is <see langword="true"/>.
        /// </summary>
        public double ArrowExpandedRotation
        {
            get => (double)GetValue(ArrowExpandedRotationProperty);
            set => SetValue(ArrowExpandedRotationProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ArrowExpandedRotation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArrowExpandedRotationProperty =
            DependencyProperty.Register(nameof(ArrowExpandedRotation), typeof(double), typeof(ItemsControlAccordionItem),
                new FrameworkPropertyMetadata(90d));

        #endregion

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
            SetValue(ArrowRotationPropertyProxy, IsExpanded ? ArrowExpandedRotation : ArrowCollapsedRotation);
        }

        /// <inheritdoc/>
        protected override void OnExpandedChanged(bool isExpanded)
        {
            base.OnExpandedChanged(isExpanded);
            Util.AnimateDouble(this, ArrowRotationPropertyProxy, isExpanded ? ArrowExpandedRotation : ArrowCollapsedRotation, AnimationTime);
        }

        /// <inheritdoc/>
        protected override void OnVStateChanged(string vstate)
        {
            switch (vstate)
            {
                case "Normal":
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, AnimationTime);
                    Util.AnimateBrush(this, ActualArrowForegroundPropertyProxy, ArrowForeground, AnimationTime);
                    SetValue(ActualFontWeightPropertyKey, FontWeight);
                    break;
                case "Expanded":
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnExpanded, AnimationTime);
                    Util.AnimateBrush(this, ActualArrowForegroundPropertyProxy, ArrowForegroundOnExpanded, AnimationTime);
                    SetValue(ActualFontWeightPropertyKey, FontWeightOnExpanded);
                    break;
                case "MouseOverHeader":
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOver, AnimationTime);
                    Util.AnimateBrush(this, ActualArrowForegroundPropertyProxy, ArrowForegroundOnMouseOver, AnimationTime);
                    SetValue(ActualFontWeightPropertyKey, FontWeightOnMouseOver);
                    break;
                case "MouseOverHeaderOnExpanded":
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnMouseOverOnExpanded, AnimationTime);
                    Util.AnimateBrush(this, ActualArrowForegroundPropertyProxy, ArrowForegroundOnMouseOverOnExpanded, AnimationTime);
                    SetValue(ActualFontWeightPropertyKey, FontWeightOnMouseOverOnExpanded);
                    break;
                case "Disabled":
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, ForegroundOnDisabled, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualArrowForegroundPropertyProxy, ArrowForegroundOnDisabled, TimeSpan.Zero);
                    SetValue(ActualFontWeightPropertyKey, FontWeightOnDisabled);
                    break;
                default:
                    Util.AnimateBrush(this, ActualForegroundPropertyProxy, Foreground, TimeSpan.Zero);
                    Util.AnimateBrush(this, ActualArrowForegroundPropertyProxy, Foreground, TimeSpan.Zero);
                    SetValue(ActualFontWeightPropertyKey, FontWeight);
                    break;
            }
        }

        /// <summary>
        /// Attach the <see cref="ItemsControl"/> to the <see cref="Collapsible"/> part.
        /// </summary>
        private void AttachItemsControl()
        {
            ContentPresenter contentHost = (ContentPresenter)Template.FindName(PartContentHost, this);
            if (contentHost != null) contentHost.Content = itemsControl;
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
