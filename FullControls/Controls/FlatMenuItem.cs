using FullControls.Common;
using FullControls.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a selectable item inside a <see cref="Menu"/>.
    /// </summary>
    public class FlatMenuItem : MenuItem
    {
        private bool loaded = false;
        private bool abortCheckChange = false;

        /// <summary>
        /// Background brush when the item is highlighted.
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
            DependencyProperty.Register(nameof(BackgroundOnHighlight), typeof(Brush), typeof(FlatMenuItem));

        /// <summary>
        /// Background brush when the item has subitems and the popup is open.
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
            DependencyProperty.Register(nameof(BackgroundOnOpen), typeof(Brush), typeof(FlatMenuItem));

        /// <summary>
        /// Background brush when the item is disabled.
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
            DependencyProperty.Register(nameof(BackgroundOnDisabled), typeof(Brush), typeof(FlatMenuItem));

        /// <summary>
        /// Actual Background brush of the item.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBackgroundProperty =
            DependencyProperty.Register(nameof(ActualBackground), typeof(Brush), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e) => ((FlatMenuItem)d).OnActualBackgroundChanged((Brush)e.NewValue))));

        /// <summary>
        /// BorderBrush when the item is highlighted.
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
            DependencyProperty.Register(nameof(BorderBrushOnHighlight), typeof(Brush), typeof(FlatMenuItem));

        /// <summary>
        /// BorderBrush when the item has subitems and the popup is open.
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
            DependencyProperty.Register(nameof(BorderBrushOnOpen), typeof(Brush), typeof(FlatMenuItem));

        /// <summary>
        /// BorderBrush when the item is disabled.
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
            DependencyProperty.Register(nameof(BorderBrushOnDisabled), typeof(Brush), typeof(FlatMenuItem));

        /// <summary>
        /// Actual BorderBrush of the item.
        /// </summary>
        public Brush ActualBorderBrush => (Brush)GetValue(ActualBorderBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualBorderBrush"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualBorderBrushProperty =
            DependencyProperty.Register(nameof(ActualBorderBrush), typeof(Brush), typeof(FlatMenuItem));

        /// <summary>
        /// Foreground brush when the item is highlighted.
        /// </summary>
        public Brush ForegroundOnHighlight
        {
            get => (Brush)GetValue(ForegroundOnHighlightProperty);
            set => SetValue(ForegroundOnHighlightProperty, value);
        }

        #region ForegroundOnHighlight attached property

        /// <summary>
        /// Gets the value of the <see cref="ForegroundOnHighlight"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="ForegroundOnHighlight"/> attached property.</returns>
        public static Brush GetForegroundOnHighlight(ItemsControl element)
        {
            if (element != null) return (Brush)element.GetValue(ForegroundOnHighlightProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="ForegroundOnHighlight"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetForegroundOnHighlight(ItemsControl element, Brush value)
        {
            if (element != null) element.SetValue(ForegroundOnHighlightProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnHighlight"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnHighlightProperty =
            DependencyProperty.RegisterAttached(nameof(ForegroundOnHighlight), typeof(Brush), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Foreground brush when the item has subitems and the popup is open.
        /// </summary>
        public Brush ForegroundOnOpen
        {
            get => (Brush)GetValue(ForegroundOnOpenProperty);
            set => SetValue(ForegroundOnOpenProperty, value);
        }

        #region ForegroundOnOpen attached property

        /// <summary>
        /// Gets the value of the <see cref="ForegroundOnOpen"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="ForegroundOnOpen"/> attached property.</returns>
        public static Brush GetForegroundOnOpen(ItemsControl element)
        {
            if (element != null) return (Brush)element.GetValue(ForegroundOnOpenProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="ForegroundOnOpen"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetForegroundOnOpen(ItemsControl element, Brush value)
        {
            if (element != null) element.SetValue(ForegroundOnOpenProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnOpen"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnOpenProperty =
            DependencyProperty.RegisterAttached(nameof(ForegroundOnOpen), typeof(Brush), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Foreground brush when the item is disabled.
        /// </summary>
        public Brush ForegroundOnDisabled
        {
            get => (Brush)GetValue(ForegroundOnDisabledProperty);
            set => SetValue(ForegroundOnDisabledProperty, value);
        }

        #region ForegroundOnDisabled attached property

        /// <summary>
        /// Gets the value of the <see cref="ForegroundOnDisabled"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="ForegroundOnDisabled"/> attached property.</returns>
        public static Brush GetForegroundOnDisabled(ItemsControl element)
        {
            if (element != null) return (Brush)element.GetValue(ForegroundOnDisabledProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="ForegroundOnDisabled"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetForegroundOnDisabled(ItemsControl element, Brush value)
        {
            if (element != null) element.SetValue(ForegroundOnDisabledProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnDisabled"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnDisabledProperty =
            DependencyProperty.RegisterAttached(nameof(ForegroundOnDisabled), typeof(Brush), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray9, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Actual Foreground brush of the item.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualForegroundProperty =
            DependencyProperty.Register(nameof(ActualForeground), typeof(Brush), typeof(FlatMenuItem));

        #region Popup

        /// <summary>
        /// CornerRadius of the popup.
        /// </summary>
        public CornerRadius PopupCornerRadius
        {
            get => (CornerRadius)GetValue(PopupCornerRadiusProperty);
            set => SetValue(PopupCornerRadiusProperty, value);
        }

        #region PopupCornerRadius attached property

        /// <summary>
        /// Gets the value of the <see cref="PopupCornerRadius"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="PopupCornerRadius"/> attached property.</returns>
        public static CornerRadius GetPopupCornerRadius(ItemsControl element)
        {
            if (element != null) return (CornerRadius)element.GetValue(PopupCornerRadiusProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="PopupCornerRadius"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetPopupCornerRadius(ItemsControl element, CornerRadius value)
        {
            if (element != null) element.SetValue(PopupCornerRadiusProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="PopupCornerRadius"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupCornerRadiusProperty =
            DependencyProperty.RegisterAttached(nameof(PopupCornerRadius), typeof(CornerRadius), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(new CornerRadius(), FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Padding of the popup.
        /// </summary>
        public Thickness PopupPadding
        {
            get => (Thickness)GetValue(PopupPaddingProperty);
            set => SetValue(PopupPaddingProperty, value);
        }

        #region PopupPadding attached property

        /// <summary>
        /// Gets the value of the <see cref="PopupPadding"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="PopupPadding"/> attached property.</returns>
        public static Thickness GetPopupPadding(ItemsControl element)
        {
            if (element != null) return (Thickness)element.GetValue(PopupPaddingProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="PopupPadding"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetPopupPadding(ItemsControl element, Thickness value)
        {
            if (element != null) element.SetValue(PopupPaddingProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="PopupPadding"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupPaddingProperty =
            DependencyProperty.RegisterAttached(nameof(PopupPadding), typeof(Thickness), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Vertical offset of the popup if its <see cref="MenuItem.Role"/> is <see cref="MenuItemRole.TopLevelHeader"/>..
        /// </summary>
        public double TopLevelPopupVerticalOffset
        {
            get => (double)GetValue(TopLevelPopupVerticalOffsetProperty);
            set => SetValue(TopLevelPopupVerticalOffsetProperty, value);
        }

        #region TopLevelPopupVerticalOffset attached property

        /// <summary>
        /// Gets the value of the <see cref="TopLevelPopupVerticalOffset"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="TopLevelPopupVerticalOffset"/> attached property.</returns>
        public static double GetTopLevelPopupVerticalOffset(ItemsControl element)
        {
            if (element != null) return (double)element.GetValue(TopLevelPopupVerticalOffsetProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="TopLevelPopupVerticalOffset"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetTopLevelPopupVerticalOffset(ItemsControl element, double value)
        {
            if (element != null) element.SetValue(TopLevelPopupVerticalOffsetProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="TopLevelPopupVerticalOffset"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty TopLevelPopupVerticalOffsetProperty =
            DependencyProperty.RegisterAttached(nameof(TopLevelPopupVerticalOffset), typeof(double), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Horizontal offset of the popup if its <see cref="MenuItem.Role"/> is <see cref="MenuItemRole.TopLevelHeader"/>.
        /// </summary>
        public double TopLevelPopupHorizontalOffset
        {
            get => (double)GetValue(TopLevelPopupHorizontalOffsetProperty);
            set => SetValue(TopLevelPopupHorizontalOffsetProperty, value);
        }

        #region TopLevelPopupHorizontalOffset attached property

        /// <summary>
        /// Gets the value of the <see cref="TopLevelPopupHorizontalOffset"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="TopLevelPopupHorizontalOffset"/> attached property.</returns>
        public static double GetTopLevelPopupHorizontalOffset(ItemsControl element)
        {
            if (element != null) return (double)element.GetValue(TopLevelPopupHorizontalOffsetProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="TopLevelPopupHorizontalOffset"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetTopLevelPopupHorizontalOffset(ItemsControl element, double value)
        {
            if (element != null) element.SetValue(TopLevelPopupHorizontalOffsetProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="TopLevelPopupHorizontalOffset"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty TopLevelPopupHorizontalOffsetProperty =
            DependencyProperty.RegisterAttached(nameof(TopLevelPopupHorizontalOffset), typeof(double), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Vertical offset of the popup.
        /// </summary>
        public double PopupVerticalOffset
        {
            get => (double)GetValue(PopupVerticalOffsetProperty);
            set => SetValue(PopupVerticalOffsetProperty, value);
        }

        #region PopupVerticalOffset attached property

        /// <summary>
        /// Gets the value of the <see cref="PopupVerticalOffset"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="PopupVerticalOffset"/> attached property.</returns>
        public static double GetPopupVerticalOffset(ItemsControl element)
        {
            if (element != null) return (double)element.GetValue(PopupVerticalOffsetProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="PopupVerticalOffset"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetPopupVerticalOffset(ItemsControl element, double value)
        {
            if (element != null) element.SetValue(PopupVerticalOffsetProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="PopupVerticalOffset"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupVerticalOffsetProperty =
            DependencyProperty.RegisterAttached(nameof(PopupVerticalOffset), typeof(double), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Horizontal offset of the popup.
        /// </summary>
        public double PopupHorizontalOffset
        {
            get => (double)GetValue(PopupHorizontalOffsetProperty);
            set => SetValue(PopupHorizontalOffsetProperty, value);
        }

        #region PopupHorizontalOffset attached property

        /// <summary>
        /// Gets the value of the <see cref="PopupHorizontalOffset"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="PopupHorizontalOffset"/> attached property.</returns>
        public static double GetPopupHorizontalOffset(ItemsControl element)
        {
            if (element != null) return (double)element.GetValue(PopupHorizontalOffsetProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="PopupHorizontalOffset"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetPopupHorizontalOffset(ItemsControl element, double value)
        {
            if (element != null) element.SetValue(PopupHorizontalOffsetProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="PopupHorizontalOffset"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupHorizontalOffsetProperty =
            DependencyProperty.RegisterAttached(nameof(PopupHorizontalOffset), typeof(double), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

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
            DependencyProperty.Register(nameof(PopupBorderThickness), typeof(Thickness), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(PopupBorderBrush), typeof(Brush), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(PopupBackground), typeof(Brush), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(PopupAnimation), typeof(PopupAnimation), typeof(FlatMenuItem));

        /// <summary>
        /// Enables the shadow of the popup.
        /// </summary>
        public bool HasDropShadow
        {
            get => (bool)GetValue(HasDropShadowProperty);
            set => SetValue(HasDropShadowProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HasDropShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HasDropShadowProperty =
            DependencyProperty.Register(nameof(HasDropShadow), typeof(bool), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(MaxDropDownHeight), typeof(double), typeof(FlatMenuItem));

        #endregion

        #region Shadow

        /// <summary>
        /// Color of the shadow.
        /// </summary>
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register(nameof(ShadowColor), typeof(Color), typeof(FlatMenuItem));

        /// <summary>
        /// Opacity of the shadow.
        /// </summary>
        public double ShadowOpacity
        {
            get => (double)GetValue(ShadowOpacityProperty);
            set => SetValue(ShadowOpacityProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowOpacityProperty =
            DependencyProperty.Register(nameof(ShadowOpacity), typeof(double), typeof(FlatMenuItem));

        /// <summary>
        /// Radius of the shadow.
        /// </summary>
        public double ShadowRadius
        {
            get => (double)GetValue(ShadowRadiusProperty);
            set => SetValue(ShadowRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowRadiusProperty =
            DependencyProperty.Register(nameof(ShadowRadius), typeof(double), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateMarginForShadow(d))));

        /// <summary>
        /// Depth of the shadow.
        /// </summary>
        public double ShadowDepth
        {
            get => (double)GetValue(ShadowDepthProperty);
            set => SetValue(ShadowDepthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowDepth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowDepthProperty =
            DependencyProperty.Register(nameof(ShadowDepth), typeof(double), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateMarginForShadow(d))));

        /// <summary>
        /// Maintains the top and left margin to zero even if the shadow properties are changed.
        /// </summary>
        public bool PreserveTopLeft
        {
            get => (bool)GetValue(PreserveTopLeftProperty);
            set => SetValue(PreserveTopLeftProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PreserveTopLeft"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PreserveTopLeftProperty =
            DependencyProperty.Register(nameof(PreserveTopLeft), typeof(bool), typeof(FlatMenuItem),
                new PropertyMetadata(true, new PropertyChangedCallback((d, e) => CalculateMarginForShadow(d))));

        #region MarginForShadow

        /// <summary>
        /// Back margin used to display the shadow.
        /// </summary>
        public Thickness BackMarginForShadow => (Thickness)GetValue(BackMarginForShadowProperty);

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="BackMarginForShadow"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey BackMarginForShadowPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(BackMarginForShadow), typeof(Thickness), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(new Thickness()));

        /// <summary>
        /// Identifies the <see cref="BackMarginForShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackMarginForShadowProperty = BackMarginForShadowPropertyKey.DependencyProperty;

        /// <summary>
        /// Front margin used to display the shadow.
        /// </summary>
        public Thickness FrontMarginForShadow => (Thickness)GetValue(FrontMarginForShadowProperty);

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="FrontMarginForShadow"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey FrontMarginForShadowPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(FrontMarginForShadow), typeof(Thickness), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(new Thickness()));

        /// <summary>
        /// Identifies the <see cref="FrontMarginForShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FrontMarginForShadowProperty = FrontMarginForShadowPropertyKey.DependencyProperty;

        /// <summary>
        /// Calculates the margin used to display the shadow.
        /// </summary>
        private static void CalculateMarginForShadow(DependencyObject d)
        {
            double margin = (double)d.GetValue(ShadowRadiusProperty) / 2;
            double offset = (double)d.GetValue(ShadowDepthProperty);
            bool preserveTopLeft = (bool)d.GetValue(PreserveTopLeftProperty);
            d.SetValue(BackMarginForShadowPropertyKey, new Thickness(Math.Max(0, Math.Ceiling(margin - offset)),
                                                                     Math.Max(0, Math.Ceiling(margin - offset)),
                                                                     Math.Max(0, Math.Ceiling(margin + offset)),
                                                                     Math.Max(0, Math.Ceiling(margin + offset))));
            d.SetValue(FrontMarginForShadowPropertyKey, new Thickness(preserveTopLeft ? 0 : Math.Max(0, Math.Ceiling(margin - offset)),
                                                                      preserveTopLeft ? 0 : Math.Max(0, Math.Ceiling(margin - offset)),
                                                                      Math.Max(0, Math.Ceiling(margin + offset)),
                                                                      Math.Max(0, Math.Ceiling(margin + offset))));
        }

        #endregion

        #endregion

        #region CheckMark

        /// <summary>
        /// Brush of the check icon.
        /// </summary>
        public Brush CheckBrush
        {
            get => (Brush)GetValue(CheckBrushProperty);
            set => SetValue(CheckBrushProperty, value);
        }

        #region CheckBrush attached property

        /// <summary>
        /// Gets the value of the <see cref="CheckBrush"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="CheckBrush"/> attached property.</returns>
        public static Brush GetCheckBrush(ItemsControl element)
        {
            if (element != null) return (Brush)element.GetValue(CheckBrushProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="CheckBrush"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetCheckBrush(ItemsControl element, Brush value)
        {
            if (element != null) element.SetValue(CheckBrushProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="CheckBrush"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckBrushProperty =
            DependencyProperty.RegisterAttached(nameof(CheckBrush), typeof(Brush), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Brush of the check icon when the item is highlighted.
        /// </summary>
        public Brush CheckBrushOnHighlight
        {
            get => (Brush)GetValue(CheckBrushOnHighlightProperty);
            set => SetValue(CheckBrushOnHighlightProperty, value);
        }

        #region CheckBrushOnHighlight attached property

        /// <summary>
        /// Gets the value of the <see cref="CheckBrushOnHighlight"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="CheckBrushOnHighlight"/> attached property.</returns>
        public static Brush GetCheckBrushOnHighlight(ItemsControl element)
        {
            if (element != null) return (Brush)element.GetValue(CheckBrushOnHighlightProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="CheckBrushOnHighlight"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetCheckBrushOnHighlight(ItemsControl element, Brush value)
        {
            if (element != null) element.SetValue(CheckBrushOnHighlightProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="CheckBrushOnHighlight"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckBrushOnHighlightProperty =
            DependencyProperty.RegisterAttached(nameof(CheckBrushOnHighlight), typeof(Brush), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Brush of the check icon when the item has subitems and the popup is open.
        /// </summary>
        public Brush CheckBrushOnOpen
        {
            get => (Brush)GetValue(CheckBrushOnOpenProperty);
            set => SetValue(CheckBrushOnOpenProperty, value);
        }

        #region CheckBrushOnOpen attached property

        /// <summary>
        /// Gets the value of the <see cref="CheckBrushOnOpen"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="CheckBrushOnOpen"/> attached property.</returns>
        public static Brush GetCheckBrushOnOpen(ItemsControl element)
        {
            if (element != null) return (Brush)element.GetValue(CheckBrushOnOpenProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="CheckBrushOnOpen"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetCheckBrushOnOpen(ItemsControl element, Brush value)
        {
            if (element != null) element.SetValue(CheckBrushOnOpenProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="CheckBrushOnOpen"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckBrushOnOpenProperty =
            DependencyProperty.RegisterAttached(nameof(CheckBrushOnOpen), typeof(Brush), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Brush of the check icon when the item is disabled.
        /// </summary>
        public Brush CheckBrushOnDisabled
        {
            get => (Brush)GetValue(CheckBrushOnDisabledProperty);
            set => SetValue(CheckBrushOnDisabledProperty, value);
        }

        #region CheckBrushOnDisabled attached property

        /// <summary>
        /// Gets the value of the <see cref="CheckBrushOnDisabled"/> attached property from a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element from which to read the property value.</param>
        /// <returns>The value of the <see cref="CheckBrushOnDisabled"/> attached property.</returns>
        public static Brush GetCheckBrushOnDisabled(ItemsControl element)
        {
            if (element != null) return (Brush)element.GetValue(CheckBrushOnDisabledProperty);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Sets the value of the <see cref="CheckBrushOnDisabled"/> attached property to a given <see cref="ItemsControl"/>.
        /// </summary>
        /// <param name="element">The element on which to set the attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetCheckBrushOnDisabled(ItemsControl element, Brush value)
        {
            if (element != null) element.SetValue(CheckBrushOnDisabledProperty, value);
            else throw new ArgumentNullException(nameof(element));
        }

        /// <summary>
        /// Identifies the <see cref="CheckBrushOnDisabled"/> attached dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckBrushOnDisabledProperty =
            DependencyProperty.RegisterAttached(nameof(CheckBrushOnDisabled), typeof(Brush), typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray9, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        /// <summary>
        /// Actual Brush of the check icon.
        /// </summary>
        public Brush ActualCheckBrush => (Brush)GetValue(ActualCheckBrushProperty);

        /// <summary>
        /// Identifies the <see cref="ActualCheckBrush"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ActualCheckBrushProperty =
            DependencyProperty.Register(nameof(ActualCheckBrush), typeof(Brush), typeof(FlatMenuItem));

        /// <summary>
        /// Content of the icon displayed if <see cref="MenuItem.IsCheckable"/> is <see langword="true"/> and <see cref="MenuItem.IsChecked"/> is <see langword="true"/>.
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
            DependencyProperty.Register(nameof(CheckMark), typeof(object), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(CheckSize), typeof(double), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(CheckFont), typeof(FontFamily), typeof(FlatMenuItem));

        #endregion

        #region CheckType

        /// <summary>
        /// Specifies if the check type is normal or mutually exclusive.
        /// </summary>
        public CheckType CheckType
        {
            get => (CheckType)GetValue(CheckTypeProperty);
            set => SetValue(CheckTypeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckTypeProperty =
            DependencyProperty.Register(nameof(CheckType), typeof(CheckType), typeof(FlatMenuItem), new PropertyMetadata(CheckType.Check));

        /// <summary>
        /// Gets or sets the name that specifies which <see cref="MenuItem"/> are mutually exclusive.
        /// </summary>
        [DefaultValue("")]
        public string GroupName
        {
            get => (string)GetValue(GroupNameProperty);
            set => SetValue(GroupNameProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="GroupName"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register(nameof(GroupName), typeof(string), typeof(FlatMenuItem),
                new PropertyMetadata("", new PropertyChangedCallback((d, e) => ((FlatMenuItem)d).OnGroupNameChanged((string)e.NewValue, (string)e.OldValue))));

        #endregion

        #region Arrow

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
            DependencyProperty.Register(nameof(Arrow), typeof(object), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(ArrowSize), typeof(double), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(ArrowFont), typeof(FontFamily), typeof(FlatMenuItem));

        #endregion

        #region Sections margins

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
            DependencyProperty.Register(nameof(IconMargin), typeof(Thickness), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(HeaderMargin), typeof(Thickness), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(InputGestureMargin), typeof(Thickness), typeof(FlatMenuItem));

        /// <summary>
        /// Margin of the arrow.
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
            DependencyProperty.Register(nameof(ArrowMargin), typeof(Thickness), typeof(FlatMenuItem));

        /// <summary>
        /// Enables automatic alignment to fit with other items.
        /// </summary>
        public bool AlignWithOthers
        {
            get => (bool)GetValue(AlignWithOthersProperty);
            set => SetValue(AlignWithOthersProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AlignWithOthers"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlignWithOthersProperty =
            DependencyProperty.Register(nameof(AlignWithOthers), typeof(bool), typeof(FlatMenuItem), new PropertyMetadata(true));

        #endregion

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
            DependencyProperty.Register(nameof(ScrollViewerStyle), typeof(Style), typeof(FlatMenuItem));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(FlatMenuItem));


        /// <summary>
        /// Creates a new <see cref="FlatMenuItem"/>.
        /// </summary>
        static FlatMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuItem), new FrameworkPropertyMetadata(typeof(FlatMenuItem)));
            IsEnabledProperty.OverrideMetadata(typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e) => ((FlatMenuItem)d).OnEnabledChanged((bool)e.NewValue))));
            IsSubmenuOpenProperty.OverrideMetadata(typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e) => ((FlatMenuItem)d).OnSubmenuOpenChanged((bool)e.NewValue))));
            IsCheckedProperty.OverrideMetadata(typeof(FlatMenuItem),
                new FrameworkPropertyMetadata(null, new CoerceValueCallback((d, o) => ((FlatMenuItem)d).abortCheckChange ? d.GetValue(IsCheckedProperty) : o)));
        }

        /// <summary>
        /// Creates a new <see cref="FlatMenuItem"/>.
        /// </summary>
        public FlatMenuItem()
        {
            DependencyPropertyDescriptor.FromProperty(IsHighlightedProperty, typeof(FlatMenuItem))
                ?.AddValueChanged(this, (s, e) => OnHighlightChanged(IsHighlighted));
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
            Utility.AnimateBrush(this, ActualCheckBrushProperty, CheckBrush, TimeSpan.Zero);
            loaded = true;
            OnVStateChanged(VStateOverride());
        }

        /// <inheritdoc/>
        protected override DependencyObject GetContainerForItemOverride() => new FlatMenuItemContainer();

        /// <inheritdoc/>
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            if (item is FlatMenuSeparator) FlatMenuSeparator.PrepareContainer(element as FlatMenuItemContainer, item as FlatMenuSeparator);
            else if (item is FlatMenuSpace) FlatMenuSpace.PrepareContainer(element as FlatMenuItemContainer, item as FlatMenuSpace);
            else if (item is FlatMenuTitle) FlatMenuTitle.PrepareContainer(element as FlatMenuItemContainer, item as FlatMenuTitle);
            else PrepareContainer(element as FlatMenuItemContainer);
        }

        internal static void PrepareContainer(FlatMenuItemContainer container)
        {
            if (container != null)
            {
                container.PrepareContainer(false, false);
            }
        }

        /// <inheritdoc/>
        protected override void OnClick()
        {
            if (IsCheckable && CheckType == CheckType.Radio && IsChecked) abortCheckChange = true;
            base.OnClick();
            abortCheckChange = false;
        }

        /// <summary>
        /// Called when the <see cref="GroupName"/> property is changed.
        /// </summary>
        /// <param name="newValue">New <see cref="GroupName"/> value.</param>
        /// <param name="oldValue">Old <see cref="GroupName"/> value.</param>
        protected virtual void OnGroupNameChanged(string newValue, string oldValue)
        {
            if (IsCheckable && CheckType == CheckType.Radio && IsChecked) UncheckOtherItems();
        }

        /// <inheritdoc/>
        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);
            if (IsCheckable && CheckType == CheckType.Radio && IsChecked) UncheckOtherItems();
        }

        /// <summary>
        /// Unchecks other items in the same <see cref="GroupName"/>.
        /// </summary>
        private void UncheckOtherItems()
        {
            IEnumerable<FlatMenuItem> radioItems = GetCheckableRadioItems();
            if (radioItems != null)
            {
                foreach (FlatMenuItem item in radioItems)
                {
                    if (item != this && item.GroupName == GroupName)
                    {
                        item.IsChecked = false;
                    }
                }
            }
        }

#nullable enable

        /// <summary>
        /// Returns all the checkable <see cref="FlatMenuItem"/> of <see cref="FrameworkElement.Parent"/>
        /// that have <see cref="CheckType"/> setted to <see cref="CheckType.Radio"/>.
        /// </summary>
        /// <returns>List of all the checkable <see cref="FlatMenuItem"/> of <see cref="FrameworkElement.Parent"/>
        /// that have <see cref="CheckType"/> setted to <see cref="CheckType.Radio"/>.</returns>
        /// <remarks>Returns <see langword="null"/> if <see cref="FrameworkElement.Parent"/> is not an <see cref="ItemsControl"/>.</remarks>
        protected IEnumerable<FlatMenuItem>? GetCheckableRadioItems()
            => Parent is ItemsControl parent ? parent.Items.OfType<FlatMenuItem>()
            .Where((item) => item.IsCheckable && item.CheckType == CheckType.Radio && (item.DataContext == parent.DataContext || item.DataContext != DataContext)) : null;

#nullable disable

        /// <summary>
        /// Called when the <see cref="ActualBackground"/> is changed.
        /// </summary>
        /// <param name="actualBackground">Actual background brush.</param>
        protected virtual void OnActualBackgroundChanged(Brush actualBackground) { }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when the <see cref="MenuItem.IsSubmenuOpen"/> is changed.
        /// </summary>
        /// <param name="isSubmenuOpen">Actual state of <see cref="MenuItem.IsSubmenuOpen"/>.</param>
        protected virtual void OnSubmenuOpenChanged(bool isSubmenuOpen) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called when the <see cref="MenuItem.IsHighlighted"/> is changed.
        /// </summary>
        /// <param name="isHighlighted">Actual state of <see cref="MenuItem.IsHighlighted"/>.</param>
        protected virtual void OnHighlightChanged(bool isHighlighted) => OnVStateChanged(VStateOverride());

        /// <summary>
        /// Called to calculate the <b>v-state</b> of the control.
        /// </summary>
        protected virtual string VStateOverride()
        {
            if (!loaded) return "Undefined";
            if (!IsEnabled) return "Disabled";
            else if (IsSubmenuOpen) return "SubmenuOpen";
            else if (IsHighlighted) return "Highlighted";
            else return "Normal";
        }

        /// <summary>
        /// Called when the <b>v-state</b> of the control changed.
        /// </summary>
        /// <remarks>Is called <b>v-state</b> because is not related to the VisualState of the control.</remarks>
        /// <param name="vstate">Actual <b>v-state</b> of the control.</param>
        protected virtual void OnVStateChanged(string vstate)
        {
            switch (vstate)
            {
                case "Normal":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, Background, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrush, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForegroundProperty, Foreground, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualCheckBrushProperty, CheckBrush, TimeSpan.Zero);
                    break;
                case "Highlighted":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnHighlight, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnHighlight, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnHighlight, AnimationTime);
                    Utility.AnimateBrush(this, ActualCheckBrushProperty, CheckBrushOnHighlight, AnimationTime);
                    break;
                case "SubmenuOpen":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnOpen, AnimationTime);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnOpen, AnimationTime);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnOpen, AnimationTime);
                    Utility.AnimateBrush(this, ActualCheckBrushProperty, CheckBrushOnOpen, AnimationTime);
                    break;
                case "Disabled":
                    Utility.AnimateBrush(this, ActualBackgroundProperty, BackgroundOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualBorderBrushProperty, BorderBrushOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualForegroundProperty, ForegroundOnDisabled, TimeSpan.Zero);
                    Utility.AnimateBrush(this, ActualCheckBrushProperty, CheckBrushOnDisabled, TimeSpan.Zero);
                    break;
                default:
                    break;
            }
        }
    }
}
