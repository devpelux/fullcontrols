using FullControls.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// Represents a selectable item inside a <see cref="Menu"/>.
    /// </summary>
    public class PolymorphicMenuItem : MenuItem
    {
        private bool loaded = false;

        /// <summary>
        /// Background color when the item is highlighted.
        /// </summary>
        public Brush BackgroundOnHighlight
        {
            get => (Brush)GetValue(BackgroundOnHighlightProperty);
            set => SetValue(BackgroundOnHighlightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnHighlight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnHighlightProperty =
            DependencyProperty.Register(nameof(BackgroundOnHighlight), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Background color when the item has subitems and the popup is open.
        /// </summary>
        public Brush BackgroundOnOpen
        {
            get => (Brush)GetValue(BackgroundOnOpenProperty);
            set => SetValue(BackgroundOnOpenProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnOpen"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnOpenProperty =
            DependencyProperty.Register(nameof(BackgroundOnOpen), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Background color when the item is disabled.
        /// </summary>
        public Brush BackgroundOnDisabled
        {
            get => (Brush)GetValue(BackgroundOnDisabledProperty);
            set => SetValue(BackgroundOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnDisabledProperty =
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Actual Background color of the item.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(PolymorphicMenuItem),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((PolymorphicMenuItem)d).OnActualBackgroundChanged((Brush)e.NewValue))));

        /// <summary>
        /// BorderBrush color when the item is highlighted.
        /// </summary>
        public Brush BorderBrushOnHighlight
        {
            get => (Brush)GetValue(BorderBrushOnHighlightProperty);
            set => SetValue(BorderBrushOnHighlightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnHighlight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnHighlightProperty =
            DependencyProperty.Register(nameof(BorderBrushOnHighlight), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// BorderBrush color when the item has subitems and the popup is open.
        /// </summary>
        public Brush BorderBrushOnOpen
        {
            get => (Brush)GetValue(BorderBrushOnOpenProperty);
            set => SetValue(BorderBrushOnOpenProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnOpen"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnOpenProperty =
            DependencyProperty.Register(nameof(BorderBrushOnOpen), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// BorderBrush color when the item is disabled.
        /// </summary>
        public Brush BorderBrushOnDisabled
        {
            get => (Brush)GetValue(BorderBrushOnDisabledProperty);
            set => SetValue(BorderBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BorderBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushOnDisabledProperty =
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Actual BorderBrush color of the item.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Foreground color when the item is highlighted.
        /// </summary>
        public Brush ForegroundOnHighlight
        {
            get => (Brush)GetValue(ForegroundOnHighlightProperty);
            set => SetValue(ForegroundOnHighlightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnHighlight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnHighlightProperty =
            DependencyProperty.Register(nameof(ForegroundOnHighlight), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Foreground color when the item has subitems and the popup is open.
        /// </summary>
        public Brush ForegroundOnOpen
        {
            get => (Brush)GetValue(ForegroundOnOpenProperty);
            set => SetValue(ForegroundOnOpenProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnOpen"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnOpenProperty =
            DependencyProperty.Register(nameof(ForegroundOnOpen), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Foreground color when the item is disabled.
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
            DependencyProperty.Register(nameof(ForegroundOnDisabled), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Actual Foreground color of the item.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Border thickness of the popup.
        /// </summary>
        public Thickness PopupBorderThickness
        {
            get => (Thickness)GetValue(PopupBorderThicknessProperty);
            set => SetValue(PopupBorderThicknessProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupBorderThicknessProperty =
            DependencyProperty.Register(nameof(PopupBorderThickness), typeof(Thickness), typeof(PolymorphicMenuItem));

        /// <summary>
        /// BorderBrush of the popup.
        /// </summary>
        public Brush PopupBorderBrush
        {
            get => (Brush)GetValue(PopupBorderBrushProperty);
            set => SetValue(PopupBorderBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupBorderBrushProperty =
            DependencyProperty.Register(nameof(PopupBorderBrush), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Background of the popup.
        /// </summary>
        public Brush PopupBackground
        {
            get => (Brush)GetValue(PopupBackgroundProperty);
            set => SetValue(PopupBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.Register(nameof(PopupBackground), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Padding of the popup.
        /// </summary>
        public Thickness PopupPadding
        {
            get => (Thickness)GetValue(PopupPaddingProperty);
            set => SetValue(PopupPaddingProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupPadding"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupPaddingProperty =
            DependencyProperty.Register(nameof(PopupPadding), typeof(Thickness), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Animation type of the popup.
        /// </summary>
        public PopupAnimation PopupAnimation
        {
            get => (PopupAnimation)GetValue(PopupAnimationProperty);
            set => SetValue(PopupAnimationProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupAnimation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupAnimationProperty =
            DependencyProperty.Register(nameof(PopupAnimation), typeof(PopupAnimation), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Enables the shadow of the popup.
        /// </summary>
        public bool EnablePopupShadow
        {
            get => (bool)GetValue(EnablePopupShadowProperty);
            set => SetValue(EnablePopupShadowProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="EnablePopupShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnablePopupShadowProperty =
            DependencyProperty.Register(nameof(EnablePopupShadow), typeof(bool), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Max height of the popup (if the height is higher, a <see cref="ScrollViewer"/> is used).
        /// </summary>
        public double MaxDropDownHeight
        {
            get => (double)GetValue(MaxDropDownHeightProperty);
            set => SetValue(MaxDropDownHeightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="MaxDropDownHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaxDropDownHeightProperty =
            DependencyProperty.Register(nameof(MaxDropDownHeight), typeof(double), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Color of the check icon.
        /// </summary>
        public Brush CheckColor
        {
            get => (Brush)GetValue(CheckColorProperty);
            set => SetValue(CheckColorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckColorProperty =
            DependencyProperty.Register(nameof(CheckColor), typeof(Brush), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Content of the icon displayed if <see cref="MenuItem.IsCheckable"/> is true and <see cref="MenuItem.IsChecked"/> is true.
        /// </summary>
        public object CheckMark
        {
            get => GetValue(CheckMarkProperty);
            set => SetValue(CheckMarkProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckMark"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckMarkProperty =
            DependencyProperty.Register(nameof(CheckMark), typeof(object), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Size of the check icon.
        /// </summary>
        public double CheckSize
        {
            get => (double)GetValue(CheckSizeProperty);
            set => SetValue(CheckSizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckSizeProperty =
            DependencyProperty.Register(nameof(CheckSize), typeof(double), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Font of the check icon.
        /// </summary>
        public FontFamily CheckFont
        {
            get => (FontFamily)GetValue(CheckFontProperty);
            set => SetValue(CheckFontProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckFont"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckFontProperty =
            DependencyProperty.Register(nameof(CheckFont), typeof(FontFamily), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Content of the arrow displayed if the item has subitems.
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
            DependencyProperty.Register(nameof(Arrow), typeof(object), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Size of the arrow.
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
            DependencyProperty.Register(nameof(ArrowSize), typeof(double), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Font of the arrow (if used a character).
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
            DependencyProperty.Register(nameof(ArrowFont), typeof(FontFamily), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Margin of the icon.
        /// </summary>
        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IconMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Margin of the shortcut hint.
        /// </summary>
        public Thickness InputGestureMargin
        {
            get => (Thickness)GetValue(InputGestureMarginProperty);
            set => SetValue(InputGestureMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="InputGestureMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty InputGestureMarginProperty =
            DependencyProperty.Register(nameof(InputGestureMargin), typeof(Thickness), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Enables automatic adjustement of margins between all items in the same popup.
        /// </summary>
        public bool AutoMargin
        {
            get => (bool)GetValue(AutoMarginProperty);
            set => SetValue(AutoMarginProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AutoMargin"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoMarginProperty =
            DependencyProperty.Register(nameof(AutoMargin), typeof(bool), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Style of the <see cref="ScrollViewer"/>.
        /// </summary>
        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ScrollViewerStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ScrollViewerStyleProperty =
            DependencyProperty.Register(nameof(ScrollViewerStyle), typeof(Style), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Duration of the item animation when it changes state.
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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(PolymorphicMenuItem));

        /// <summary>
        /// Type of the item.
        /// </summary>
        public ItemType ItemType
        {
            get => (ItemType)GetValue(ItemTypeProperty);
            set => SetValue(ItemTypeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ItemType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemTypeProperty =
            DependencyProperty.Register(nameof(ItemType), typeof(ItemType), typeof(PolymorphicMenuItem));


        /// <summary>
        /// Creates a new <see cref="PolymorphicMenuItem"/>.
        /// </summary>
        static PolymorphicMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PolymorphicMenuItem), new FrameworkPropertyMetadata(typeof(PolymorphicMenuItem)));
            IsEnabledProperty.OverrideMetadata(typeof(PolymorphicMenuItem), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((PolymorphicMenuItem)d).OnEnabledChanged((bool)e.NewValue))));
            IsSubmenuOpenProperty.OverrideMetadata(typeof(PolymorphicMenuItem), new FrameworkPropertyMetadata(
                new PropertyChangedCallback((d, e) => ((PolymorphicMenuItem)d).OnSubmenuOpenChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Creates a new <see cref="PolymorphicMenuItem"/>.
        /// </summary>
        public PolymorphicMenuItem()
        {
            DependencyPropertyDescriptor.FromProperty(IsHighlightedProperty, typeof(PolymorphicMenuItem))
                ?.AddValueChanged(this, (s, e) => OnHighlightChanged(IsHighlighted));
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            loaded = true;
            ReloadBackground();
        }

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background color.</param>
        protected virtual void OnActualBackgroundChanged(Brush actualBackground) { }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState)
        {
            ReloadBackground();
        }

        /// <summary>
        /// Called when the <see cref="MenuItem.IsSubmenuOpen"/> is changed.
        /// </summary>
        /// <param name="isSubmenuOpen">Actual state of <see cref="MenuItem.IsSubmenuOpen"/>.</param>
        protected virtual void OnSubmenuOpenChanged(bool isSubmenuOpen)
        {
            ReloadBackground();
        }

        /// <summary>
        /// Called when the <see cref="MenuItem.IsHighlighted"/> is changed.
        /// </summary>
        /// <param name="isHighlighted">Actual state of <see cref="MenuItem.IsHighlighted"/>.</param>
        protected virtual void OnHighlightChanged(bool isHighlighted)
        {
            ReloadBackground();
        }

        /// <summary>
        /// Apply the correct background to the control, based on its state.
        /// </summary>
        private void ReloadBackground()
        {
            if (!loaded) return;
            if (!IsEnabled) //Disabled state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnDisabled, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnDisabled, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnDisabled, TimeSpan.Zero);
            }
            else if (IsSubmenuOpen) //MouseOver state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnOpen, AnimationTime);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnOpen, AnimationTime);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnOpen, TimeSpan.Zero);
            }
            else if (IsHighlighted) //Highlighted state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnHighlight, AnimationTime);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnHighlight, AnimationTime);
                Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnHighlight, TimeSpan.Zero);
            }
            else //Normal state
            {
                Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
                Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            }
        }
    }
}
