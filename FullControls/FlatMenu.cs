﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// Represents a Windows menu control that enables you to hierarchically organize elements associated with commands and event handlers.
    /// </summary>
    public class FlatMenu : Menu
    {
        #region Global properties for child elements

        /// <summary>
        /// CornerRadius of the items popup.
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
            FlatMenuItem.PopupCornerRadiusProperty.AddOwner(typeof(FlatMenu),
                new FrameworkPropertyMetadata(new CornerRadius(), FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Padding of the items popup.
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
            FlatMenuItem.PopupPaddingProperty.AddOwner(typeof(FlatMenu),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Vertical offset of the popup if its <see cref="MenuItem.Role"/> is <see cref="MenuItemRole.TopLevelHeader"/>..
        /// </summary>
        public double TopLevelPopupVerticalOffset
        {
            get => (double)GetValue(TopLevelPopupVerticalOffsetProperty);
            set => SetValue(TopLevelPopupVerticalOffsetProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TopLevelPopupVerticalOffset"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TopLevelPopupVerticalOffsetProperty =
            FlatMenuItem.TopLevelPopupVerticalOffsetProperty.AddOwner(typeof(FlatMenu),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Horizontal offset of the popup if its <see cref="MenuItem.Role"/> is <see cref="MenuItemRole.TopLevelHeader"/>.
        /// </summary>
        public double TopLevelPopupHorizontalOffset
        {
            get => (double)GetValue(TopLevelPopupHorizontalOffsetProperty);
            set => SetValue(TopLevelPopupHorizontalOffsetProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="TopLevelPopupHorizontalOffset"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TopLevelPopupHorizontalOffsetProperty =
            FlatMenuItem.TopLevelPopupHorizontalOffsetProperty.AddOwner(typeof(FlatMenu),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Vertical offset of the popup.
        /// </summary>
        public double PopupVerticalOffset
        {
            get => (double)GetValue(PopupVerticalOffsetProperty);
            set => SetValue(PopupVerticalOffsetProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupVerticalOffset"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupVerticalOffsetProperty =
            FlatMenuItem.PopupVerticalOffsetProperty.AddOwner(typeof(FlatMenu),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Horizontal offset of the popup.
        /// </summary>
        public double PopupHorizontalOffset
        {
            get => (double)GetValue(PopupHorizontalOffsetProperty);
            set => SetValue(PopupHorizontalOffsetProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="PopupHorizontalOffset"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PopupHorizontalOffsetProperty =
            FlatMenuItem.PopupHorizontalOffsetProperty.AddOwner(typeof(FlatMenu),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.Inherits));

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
            FlatMenuItem.ForegroundOnHighlightProperty.AddOwner(typeof(FlatMenu),
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
            FlatMenuItem.ForegroundOnOpenProperty.AddOwner(typeof(FlatMenu),
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
            FlatMenuItem.ForegroundOnDisabledProperty.AddOwner(typeof(FlatMenu),
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
            FlatMenuItem.CheckBrushProperty.AddOwner(typeof(FlatMenu),
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
            FlatMenuItem.CheckBrushOnHighlightProperty.AddOwner(typeof(FlatMenu),
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
            FlatMenuItem.CheckBrushOnOpenProperty.AddOwner(typeof(FlatMenu),
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
            FlatMenuItem.CheckBrushOnDisabledProperty.AddOwner(typeof(FlatMenu),
                new FrameworkPropertyMetadata(Extra.Brushes.Gray9, FrameworkPropertyMetadataOptions.Inherits));

        #endregion


        /// <summary>
        /// Creates a new <see cref="FlatMenu"/>.
        /// </summary>
        static FlatMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenu), new FrameworkPropertyMetadata(typeof(FlatMenu)));
        }
    }
}
