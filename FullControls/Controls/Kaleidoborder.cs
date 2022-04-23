using FullControls.Core;
using FullControls.Core.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfCoreTools.Extensions;

namespace FullControls.Controls
{
    /// <summary>
    /// The Kaleidoborder decorator is used to draw a multicolored border with a background around another element.
    /// </summary>
    public class Kaleidoborder : Decorator
    {
        /// <summary>
        /// The Background property defines the brush used to fill the area within the border.
        /// </summary>
        public Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="Background" /> property.
        /// </summary>
        public static readonly DependencyProperty BackgroundProperty
            = Panel.BackgroundProperty.AddOwner(typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.AffectsRender
                    | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        /// <summary>
        /// The brush for the border.
        /// </summary>
        public Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="BorderBrush" /> property.
        /// </summary>
        public static readonly DependencyProperty BorderBrushProperty
            = DependencyProperty.Register(nameof(BorderBrush), typeof(Brush), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// The brush for the border 1.
        /// </summary>
        public Brush Border1Brush
        {
            get => (Brush)GetValue(Border1BrushProperty);
            set => SetValue(Border1BrushProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="Border1Brush" /> property.
        /// </summary>
        public static readonly DependencyProperty Border1BrushProperty
            = DependencyProperty.Register(nameof(Border1Brush), typeof(Brush), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// The brush for the border 2.
        /// </summary>
        public Brush Border2Brush
        {
            get => (Brush)GetValue(Border2BrushProperty);
            set => SetValue(Border2BrushProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="Border2Brush" /> property.
        /// </summary>
        public static readonly DependencyProperty Border2BrushProperty
            = DependencyProperty.Register(nameof(Border2Brush), typeof(Brush), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// The brush for the border 3.
        /// </summary>
        public Brush Border3Brush
        {
            get => (Brush)GetValue(Border3BrushProperty);
            set => SetValue(Border3BrushProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="Border3Brush" /> property.
        /// </summary>
        public static readonly DependencyProperty Border3BrushProperty
            = DependencyProperty.Register(nameof(Border3Brush), typeof(Brush), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// The BorderThickness property defined how thick a border to draw.  The property's value is a
        /// <see cref="Thickness" /> containing values for each of the Left, Top, Right,
        /// and Bottom sides.  Values of Auto are interpreted as zero.
        /// </summary>
        public Thickness BorderThickness
        {
            get => (Thickness)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="BorderThickness" /> property.
        /// </summary>
        public static readonly DependencyProperty BorderThicknessProperty
            = DependencyProperty.Register(nameof(BorderThickness), typeof(Thickness), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure
                    | FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// The BorderThickness property defined how thick a border to draw.  The property's value is a
        /// <see cref="Thickness" /> containing values for each of the Left, Top, Right,
        /// and Bottom sides.  Values of Auto are interpreted as zero.
        /// </summary>
        public Thickness Border1Thickness
        {
            get => (Thickness)GetValue(Border2ThicknessProperty);
            set => SetValue(Border2ThicknessProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="Border1Thickness" /> property.
        /// </summary>
        public static readonly DependencyProperty Border2ThicknessProperty
            = DependencyProperty.Register(nameof(Border1Thickness), typeof(Thickness), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure
                    | FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// The BorderThickness property defined how thick a border to draw.  The property's value is a
        /// <see cref="Thickness" /> containing values for each of the Left, Top, Right,
        /// and Bottom sides.  Values of Auto are interpreted as zero.
        /// </summary>
        public Thickness Border2Thickness
        {
            get => (Thickness)GetValue(Border3ThicknessProperty);
            set => SetValue(Border3ThicknessProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="Border2Thickness" /> property.
        /// </summary>
        public static readonly DependencyProperty Border3ThicknessProperty
            = DependencyProperty.Register(nameof(Border2Thickness), typeof(Thickness), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure
                    | FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// The BorderThickness property defined how thick a border to draw.  The property's value is a
        /// <see cref="Thickness" /> containing values for each of the Left, Top, Right,
        /// and Bottom sides.  Values of Auto are interpreted as zero.
        /// </summary>
        public Thickness Border3Thickness
        {
            get => (Thickness)GetValue(Border4ThicknessProperty);
            set => SetValue(Border4ThicknessProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="Border3Thickness" /> property.
        /// </summary>
        public static readonly DependencyProperty Border4ThicknessProperty
            = DependencyProperty.Register(nameof(Border3Thickness), typeof(Thickness), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure
                    | FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets the max border thickness taken by all the borders.
        /// </summary>
        public Thickness MaxBorderThickness { get; private set; }

        /// <summary>
        /// Gets the actual border thickness.
        /// </summary>
        internal Thickness ActualBorderThickness { get; private set; }

        /// <summary>
        /// Gets the actual border 1 thickness.
        /// </summary>
        internal Thickness ActualBorder1Thickness { get; private set; }

        /// <summary>
        /// Gets the actual border 2 thickness.
        /// </summary>
        internal Thickness ActualBorder2Thickness { get; private set; }

        /// <summary>
        /// Gets the actual border 3 thickness.
        /// </summary>
        internal Thickness ActualBorder3Thickness { get; private set; }

        /// <summary>
        /// The Padding property inflates the effective size of the child by the specified thickness.  This
        /// achieves the same effect as adding margin on the child, but is present here for convenience.
        /// </summary>
        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="Padding" /> property.
        /// </summary>
        public static readonly DependencyProperty PaddingProperty
            = DependencyProperty.Register(nameof(Padding), typeof(Thickness), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure
                    | FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// The CornerRadius property allows users to control the roundness of the corners independently by
        /// setting a radius value for each corner.  Radius values that are too large are scaled so that they
        /// smoothly blend from corner to corner.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="CornerRadius" /> property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty
            = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(CornerRadius), FrameworkPropertyMetadataOptions.AffectsArrange
                    | FrameworkPropertyMetadataOptions.AffectsRender));


        static Kaleidoborder() { }

        /// <summary>
        /// Initializes a new instance of <see cref="AccordionItem"/>.
        /// </summary>
        public Kaleidoborder() : base() { }

        /// <summary>
        /// Updates DesiredSize of the Kaleidoborder.  Called by parent UIElement.  This is the first pass of layout.
        /// </summary>
        /// <remarks>
        /// Kaleidoborder determines its desired size it needs from the specified border the child: its sizing
        /// properties, margin, and requested size.
        /// </remarks>
        /// <param name="constraint">Constraint size is an "upper limit" that the return value should not exceed.</param>
        /// <returns>The Decorator's desired size.</returns>
        protected override Size MeasureOverride(Size constraint)
        {
            //Calculates the correct border thickness for the 4 borders, by rounding it, if UseLayoutRounding is true.
            if (UseLayoutRounding)
            {
                DpiScale dpi = SysParams.GetDpiScale();
                ActualBorderThickness = RoundThickness(BorderThickness, dpi);
                ActualBorder1Thickness = RoundThickness(Border1Thickness, dpi);
                ActualBorder2Thickness = RoundThickness(Border2Thickness, dpi);
                ActualBorder3Thickness = RoundThickness(Border3Thickness, dpi);
            }
            else
            {
                ActualBorderThickness = BorderThickness;
                ActualBorder1Thickness = Border1Thickness;
                ActualBorder2Thickness = Border2Thickness;
                ActualBorder3Thickness = Border3Thickness;
            }

            //Calculates the max thickness taken by all the borders (the max for every edge).
            double top = Max(ActualBorderThickness.Top, ActualBorder1Thickness.Top, ActualBorder2Thickness.Top, ActualBorder3Thickness.Top);
            double right = Max(ActualBorderThickness.Right, ActualBorder1Thickness.Right, ActualBorder2Thickness.Right, ActualBorder3Thickness.Right);
            double bottom = Max(ActualBorderThickness.Bottom, ActualBorder1Thickness.Bottom, ActualBorder2Thickness.Bottom, ActualBorder3Thickness.Bottom);
            double left = Max(ActualBorderThickness.Left, ActualBorder1Thickness.Left, ActualBorder2Thickness.Left, ActualBorder3Thickness.Left);
            MaxBorderThickness = new(top, right, bottom, left);

            //Basic size without any child (the size of the "decoration" parts: border and padding).
            Size border = MaxBorderThickness.Collapse();
            Size padding = Padding.Collapse();
            Size decorSize = border.Add(padding);

            //If there is a child, then add the size of the child inside the decorator.
            UIElement child = Child;
            if (child != null)
            {
                //Calculates the available size for the child by removing the decoration size.
                Size internalSpace = constraint.Subtract(decorSize);

                //Calculates the child's desired size basing on the internal available space.
                child.Measure(internalSpace);
                Size childSize = child.DesiredSize;

                //Adapts Kaleidoborder to the child's desired size.
                decorSize.Add(childSize);
            }

            return decorSize;
        }

        private StreamGeometry? Border0Geometry { get; set; } = null;
        private StreamGeometry? Border1Geometry { get; set; } = null;
        private StreamGeometry? Border2Geometry { get; set; } = null;
        private StreamGeometry? Border3Geometry { get; set; } = null;
        private StreamGeometry? BackgroundGeometry { get; set; } = null;

        /// <summary>
        /// Kaleidoborder computes the position of its single child and applies its child's alignments to the child.
        /// </summary>
        /// <param name="finalSize">The size reserved for this element by the parent</param>
        /// <returns>The actual ink area of the element, typically the same as finalSize</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            //Calculates the rects of the borders.
            Rect externalRect = new(finalSize);
            Rect internal0Rect = externalRect.Deflate(ActualBorderThickness);
            Rect internal1Rect = externalRect.Deflate(ActualBorder1Thickness);
            Rect internal2Rect = externalRect.Deflate(ActualBorder2Thickness);
            Rect internal3Rect = externalRect.Deflate(ActualBorder3Thickness);
            Rect backgroundRect = externalRect.Deflate(MaxBorderThickness);

            //Arranges the child with his available space.
            UIElement child = Child;
            if (child != null)
            {
                Rect childRect = backgroundRect.Deflate(Padding);
                child.Arrange(childRect);
            }

            CornerRadius radius = CornerRadius;

            ResetGeometries();
            if (externalRect.HasArea())
            {
                Border0Geometry = DrawBorderGeometry(new Radii(externalRect, radius), internal0Rect.HasArea() ? new Radii(internal0Rect, radius) : null);
                Border1Geometry = DrawBorderGeometry(new Radii(externalRect, radius), internal1Rect.HasArea() ? new Radii(internal1Rect, radius) : null);
                Border2Geometry = DrawBorderGeometry(new Radii(externalRect, radius), internal2Rect.HasArea() ? new Radii(internal2Rect, radius) : null);
                Border3Geometry = DrawBorderGeometry(new Radii(externalRect, radius), internal3Rect.HasArea() ? new Radii(internal3Rect, radius) : null);
                BackgroundGeometry = DrawBorderGeometry(new Radii(backgroundRect, radius), null);
            }

            return finalSize;
        }

        private void ResetGeometries()
        {
            Border0Geometry = null;
            Border1Geometry = null;
            Border2Geometry = null;
            Border3Geometry = null;
            BackgroundGeometry = null;
        }

        private StreamGeometry DrawBorderGeometry(Radii externalRadii, Radii? internalRadii)
        {
            StreamGeometry geometry = new();
            using (StreamGeometryContext context = geometry.Open())
            {
                DrawRect(context, externalRadii);
                if (internalRadii.HasValue) DrawRect(context, internalRadii.Value);
            }
            geometry.Freeze();
            return geometry;
        }

        /// <summary>
        /// Draw a rect geometry on the specified context, with the specified radii.
        /// </summary>
        private static void DrawRect(StreamGeometryContext context, Radii radii)
        {
            /*
                      TopLeft      TopRight
                          -------------
               LeftTop  /               \  RightTop
                       |                 |
                       |                 |
                       |                 |
            LeftBottom  \               /  RightBottom
                          -------------
                    BottomLeft      BottomRight
            */

            context.BeginFigure(radii.TopLeft, true, true);
            context.LineTo(radii.TopRight, true, false);
            context.ArcTo(radii.RightTop, radii.TopRightRadii, 0, false, SweepDirection.Clockwise, true, false);
            context.LineTo(radii.RightBottom, true, false);
            context.ArcTo(radii.BottomRight, radii.BottomRightRadii, 0, false, SweepDirection.Clockwise, true, false);
            context.LineTo(radii.BottomLeft, true, false);
            context.ArcTo(radii.LeftBottom, radii.BottomLeftRadii, 0, false, SweepDirection.Clockwise, true, false);
            context.LineTo(radii.LeftTop, true, false);
            context.ArcTo(radii.TopLeft, radii.TopLeftRadii, 0, false, SweepDirection.Clockwise, true, false);
        }

        /// <summary>
        /// In addition to the child, Kaleidoborder renders a background + border.
        /// </summary>
        protected override void OnRender(DrawingContext dc)
        {
            if (this.IsNotNull(BorderBrushProperty)) dc.DrawGeometry(BorderBrush, null, Border0Geometry);
            if (this.IsNotNull(Border1BrushProperty)) dc.DrawGeometry(Border1Brush, null, Border1Geometry);
            if (this.IsNotNull(Border2BrushProperty)) dc.DrawGeometry(Border2Brush, null, Border2Geometry);
            if (this.IsNotNull(Border3BrushProperty)) dc.DrawGeometry(Border3Brush, null, Border3Geometry);
            if (this.IsNotNull(BackgroundProperty)) dc.DrawGeometry(Background, null, BackgroundGeometry);
        }

        /// <summary>
        /// Round the <see cref="Thickness"/> with the specified <see cref="DpiScale"/>.
        /// </summary>
        private static Thickness RoundThickness(Thickness thickness, DpiScale dpi)
        {
            return new Thickness(Util.RoundLayoutValue(thickness.Left, dpi.DpiScaleX),
                                 Util.RoundLayoutValue(thickness.Top, dpi.DpiScaleY),
                                 Util.RoundLayoutValue(thickness.Right, dpi.DpiScaleX),
                                 Util.RoundLayoutValue(thickness.Bottom, dpi.DpiScaleY));
        }

        /// <summary>
        /// Returns the maximum between 4 doubles.
        /// </summary>
        private static double Max(double d1, double d2, double d3, double d4) => Math.Max(Math.Max(Math.Max(d1, d2), d3), d4);


        #region Radii

        /// <summary>
        /// Handles the parameters to draw a rectangle with round corners.
        /// </summary>
        private struct Radii
        {
            /*
                          TopLeft      TopRight
                             -------------
                  LeftTop  /               \  RightTop
                          |                 |
                          |                 |
                          |                 |
               LeftBottom  \               /  RightBottom
                             -------------
                       BottomLeft      BottomRight
             */

            public Size TopLeftRadii { get; }
            public Size TopRightRadii { get; }
            public Size BottomLeftRadii { get; }
            public Size BottomRightRadii { get; }

            public Point TopLeft { get; }
            public Point TopRight { get; }
            public Point RightTop { get; }
            public Point RightBottom { get; }
            public Point BottomRight { get; }
            public Point BottomLeft { get; }
            public Point LeftBottom { get; }
            public Point LeftTop { get; }

            /// <summary>
            /// Initializes a new <see cref="Radii"/> with a rectangle and the specified rounding corners size.
            /// </summary>
            /// <param name="rect">Base rectangle.</param>
            /// <param name="radius">Rounding size of the rectangle corners.</param>
            public Radii(Rect rect, CornerRadius radius)
            {
                TopLeftRadii = new Size(radius.TopLeft, radius.TopLeft);
                TopRightRadii = new Size(radius.TopRight, radius.TopRight);
                BottomLeftRadii = new Size(radius.BottomLeft, radius.BottomLeft);
                BottomRightRadii = new Size(radius.BottomRight, radius.BottomRight);

                TopLeft = new Point(rect.Left + radius.TopLeft, rect.Top);
                TopRight = new Point(rect.Right - radius.TopRight, rect.Top);

                RightTop = new Point(rect.Right, rect.Top + radius.TopRight);
                RightBottom = new Point(rect.Right, rect.Bottom - radius.BottomRight);

                BottomRight = new Point(rect.Right - radius.BottomRight, rect.Bottom);
                BottomLeft = new Point(rect.Left + radius.BottomLeft, rect.Bottom);

                LeftBottom = new Point(rect.Left, rect.Bottom - radius.BottomLeft);
                LeftTop = new Point(rect.Left, rect.Top + radius.TopLeft);
            }
        }

        #endregion
    }
}
