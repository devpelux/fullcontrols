using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// Represents a pop-up menu that enables a control to expose functionality that is specific to the context of the control.
    /// </summary>
    public class FlatContextMenu : ContextMenu
    {
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
            DependencyProperty.Register(nameof(ScrollViewerStyle), typeof(Style), typeof(FlatContextMenu));

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
            DependencyProperty.Register(nameof(ShadowColor), typeof(Color), typeof(FlatContextMenu));

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
            DependencyProperty.Register(nameof(ShadowOpacity), typeof(double), typeof(FlatContextMenu));

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
            DependencyProperty.Register(nameof(ShadowRadius), typeof(double), typeof(FlatContextMenu),
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
            DependencyProperty.Register(nameof(ShadowDepth), typeof(double), typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(0d, new PropertyChangedCallback((d, e) => CalculateMarginForShadow(d))));

        #region MarginForShadow

        /// <summary>
        /// Margin used to display the shadow.
        /// </summary>
        public Thickness MarginForShadow => (Thickness)GetValue(MarginForShadowProperty);

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="MarginForShadow"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey MarginForShadowPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(MarginForShadow), typeof(Thickness), typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(new Thickness()));

        /// <summary>
        /// Identifies the <see cref="MarginForShadow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MarginForShadowProperty = MarginForShadowPropertyKey.DependencyProperty;

        /// <summary>
        /// Calculates the margin used to display the shadow.
        /// </summary>
        private static void CalculateMarginForShadow(DependencyObject d)
        {
            double margin = (double)d.GetValue(ShadowRadiusProperty) / 2;
            double offset = (double)d.GetValue(ShadowDepthProperty);
            d.SetValue(MarginForShadowPropertyKey, new Thickness(Math.Max(0, Math.Ceiling(margin - offset)),
                                                                 Math.Max(0, Math.Ceiling(margin - offset)),
                                                                 Math.Max(0, Math.Ceiling(margin + offset)),
                                                                 Math.Max(0, Math.Ceiling(margin + offset))));
        }

        #endregion

        #endregion

        #region Global properties for child elements

        /// <summary>
        /// CornerRadius of the popup and items popup.
        /// </summary>
        public CornerRadius PopupCornerRadius
        {
            get => (CornerRadius)GetValue(PopupCornerRadiusProperty);
            set => SetValue(PopupCornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupCornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupCornerRadiusProperty =
            FlatMenuItem.PopupCornerRadiusProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(new CornerRadius(), FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Padding of the popup and items popup.
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
            FlatMenuItem.PopupPaddingProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Foreground brush of the items when are highlighted.
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
            FlatMenuItem.ForegroundOnHighlightProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Foreground brush of the items when have subitems and the popup is open.
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
            FlatMenuItem.ForegroundOnOpenProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Foreground brush of the items when are disabled.
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
            FlatMenuItem.ForegroundOnDisabledProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray9, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Brush of the items check icons.
        /// </summary>
        public Brush CheckBrush
        {
            get => (Brush)GetValue(CheckBrushProperty);
            set => SetValue(CheckBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckBrushProperty =
            FlatMenuItem.CheckBrushProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Brush of the items check icons when are highlighted.
        /// </summary>
        public Brush CheckBrushOnHighlight
        {
            get => (Brush)GetValue(CheckBrushOnHighlightProperty);
            set => SetValue(CheckBrushOnHighlightProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckBrushOnHighlight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckBrushOnHighlightProperty =
            FlatMenuItem.CheckBrushOnHighlightProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Brush of the items check icons when have subitems and the popup is open.
        /// </summary>
        public Brush CheckBrushOnOpen
        {
            get => (Brush)GetValue(CheckBrushOnOpenProperty);
            set => SetValue(CheckBrushOnOpenProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckBrushOnOpen"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckBrushOnOpenProperty =
            FlatMenuItem.CheckBrushOnOpenProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray17, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Brush of the items check icons when are disabled.
        /// </summary>
        public Brush CheckBrushOnDisabled
        {
            get => (Brush)GetValue(CheckBrushOnDisabledProperty);
            set => SetValue(CheckBrushOnDisabledProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CheckBrushOnDisabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CheckBrushOnDisabledProperty =
            FlatMenuItem.CheckBrushOnDisabledProperty.AddOwner(typeof(FlatContextMenu),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray9, FrameworkPropertyMetadataOptions.Inherits));

        #endregion


        /// <summary>
        /// Creates a new <see cref="FlatContextMenu"/>.
        /// </summary>
        static FlatContextMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatContextMenu), new FrameworkPropertyMetadata(typeof(FlatContextMenu)));
        }
    }
}
