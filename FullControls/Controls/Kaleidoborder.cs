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
    /// Draws a multicolored border with a background around another element.
    /// </summary>
    public class Kaleidoborder : Decorator
    {
        //The geometries used to draw the borders and the background.
        private Geometry Border0Geometry = Geometry.Empty;
        private Geometry Border1Geometry = Geometry.Empty;
        private Geometry Border2Geometry = Geometry.Empty;
        private Geometry Border3Geometry = Geometry.Empty;
        private Geometry BackgroundGeometry = Geometry.Empty;

        //The scaled border thicknesses (rounded to the current dpi scale if UseLayoutRounding is true).
        private Thickness ScaledBorder0Thickness;
        private Thickness ScaledBorder1Thickness;
        private Thickness ScaledBorder2Thickness;
        private Thickness ScaledBorder3Thickness;
        private Thickness ScaledMaxBorderThickness;

        /// <summary>
        /// Thickness used to slightly overlap the background to fix the wpf corners issue. (This is an uniform thickness of 0.5)
        /// </summary>
        private static readonly Thickness FIX_THICKNESS = new(0.5);

        /// <summary>
        /// Gets or sets the background brush used to fill the area within the borders.
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
        /// Gets or sets the brush used to draw main border.
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
        /// Gets or sets the brush used to draw second border.
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
        /// Gets or sets the brush used to draw third border.
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
        /// Gets or sets the brush used to draw fourth border.
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
        /// Gets or sets the thickness of the main border.
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
                    | FrameworkPropertyMetadataOptions.AffectsRender, (d, e) => ((Kaleidoborder)d).UpdateMaxBorderThickness()));

        /// <summary>
        /// Gets or sets the thickness of the second border.
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
                    | FrameworkPropertyMetadataOptions.AffectsRender, (d, e) => ((Kaleidoborder)d).UpdateMaxBorderThickness()));

        /// <summary>
        /// Gets or sets the thickness of the third border.
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
                    | FrameworkPropertyMetadataOptions.AffectsRender, (d, e) => ((Kaleidoborder)d).UpdateMaxBorderThickness()));

        /// <summary>
        /// Gets or sets the thickness of the fourth border.
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
                    | FrameworkPropertyMetadataOptions.AffectsRender, (d, e) => ((Kaleidoborder)d).UpdateMaxBorderThickness()));

        /// <summary>
        /// Gets the maximum thickness taken by all the borders.
        /// </summary>
        public Thickness MaxBorderThickness => (Thickness)GetValue(MaxBorderThicknessProperty);

        #region MaxBorderThicknessProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="MaxBorderThickness"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey MaxBorderThicknessPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(MaxBorderThickness), typeof(Thickness), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(default(Thickness)));

        /// <summary>
        /// Identifies the <see cref="MaxBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaxBorderThicknessProperty = MaxBorderThicknessPropertyKey.DependencyProperty;

        #endregion

        /// <summary>
        /// Gets or sets the padding that inflates the effective size of the child by the specified thickness.<br/>
        /// This achieves the same effect as adding margin on the child.
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
        /// Gets or sets the corner radius to set the roundness of the corners.<br/>
        /// Radius values that are too large are scaled so that they smoothly blend from corner to corner.
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

        /// <summary>
        /// Gets or sets a value indicating if allow to slightly overlap the background to fix the wpf corner angles issue.
        /// </summary>
        public bool AllowBackgroundOverlapping
        {
            get => (bool)GetValue(AllowOverlapBackgroundProperty);
            set => SetValue(AllowOverlapBackgroundProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// DependencyProperty for <see cref="AllowBackgroundOverlapping" /> property.
        /// </summary>
        public static readonly DependencyProperty AllowOverlapBackgroundProperty
            = DependencyProperty.Register(nameof(AllowBackgroundOverlapping), typeof(bool), typeof(Kaleidoborder),
                new FrameworkPropertyMetadata(BoolBox.False, FrameworkPropertyMetadataOptions.AffectsArrange
                    | FrameworkPropertyMetadataOptions.AffectsRender));


        static Kaleidoborder() { }

        /// <summary>
        /// Initializes a new instance of <see cref="AccordionItem"/>.
        /// </summary>
        public Kaleidoborder() : base() { }

        /// <summary>
        /// Updates the DesiredSize of Kaleidoborder.
        /// </summary>
        /// <remarks>
        /// Kaleidoborder determines its desired size by adding the maximum space taken by all the borders to the child desired size.<br/>
        /// If there is no child, the desired size will be the maximum space taken by all the borders themselves.
        /// </remarks>
        /// <param name="constraint">Constraint size is an "upper limit" that the return value should not exceed.</param>
        /// <returns>The desired size of Kaleidoborder.</returns>
        protected override Size MeasureOverride(Size constraint)
        {
            //Calculates the correct border thickness for the 4 borders, by rounding it, if UseLayoutRounding is true.
            if (UseLayoutRounding)
            {
                DpiScale dpi = SysParams.GetDpiScale();
                ScaledBorder0Thickness = Util.RoundThickness(BorderThickness, dpi);
                ScaledBorder1Thickness = Util.RoundThickness(Border1Thickness, dpi);
                ScaledBorder2Thickness = Util.RoundThickness(Border2Thickness, dpi);
                ScaledBorder3Thickness = Util.RoundThickness(Border3Thickness, dpi);
                ScaledMaxBorderThickness = Util.RoundThickness(MaxBorderThickness, dpi);
            }
            else
            {
                ScaledBorder0Thickness = BorderThickness;
                ScaledBorder1Thickness = Border1Thickness;
                ScaledBorder2Thickness = Border2Thickness;
                ScaledBorder3Thickness = Border3Thickness;
                ScaledMaxBorderThickness = MaxBorderThickness;
            }

            //Basic size without any child (the size of the "decoration" parts: border and padding).
            Size border = ScaledMaxBorderThickness.Collapse();
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

        /// <summary>
        /// Places the child element inside all the borders (if there is a child),
        /// and generates the geometries of the borders to draw.
        /// </summary>
        /// <param name="finalSize">The size reserved for this element by the parent.</param>
        /// <returns>The actual size of Kaleidoborder, typically the same as <paramref name="finalSize"/>.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            //The whole control.
            Rect externalRect = new(finalSize);

            //Arranges the child with his available space (the space of the background minus the padding).
            Child?.Arrange(externalRect.Deflate(ScaledMaxBorderThickness).Deflate(Padding));

            //Generates the geometries of the borders and the background if there is space to draw.
            if (externalRect.HasArea())
            {
                //Calculates the rects of the borders.
                Rect internal0Rect = externalRect.Deflate(ScaledBorder0Thickness);
                Rect internal1Rect = externalRect.Deflate(ScaledBorder1Thickness);
                Rect internal2Rect = externalRect.Deflate(ScaledBorder2Thickness);
                Rect internal3Rect = externalRect.Deflate(ScaledBorder3Thickness);
                Rect backgroundRect = internal0Rect;

                //Inflates the backgroundRect with an uniform thickness to fix the wpf corners issue.
                if (AllowBackgroundOverlapping)
                {
                    backgroundRect = backgroundRect.Inflate(FIX_THICKNESS);
                    backgroundRect.Intersect(externalRect);
                }

                //Calculates the corner radiuses of the rects.
                CornerRadius externalRadius = CornerRadius;
                CornerRadius radius0 = ReduceRadiusByThickness(externalRadius, ScaledBorder0Thickness);
                CornerRadius radius1 = ReduceRadiusByThickness(externalRadius, ScaledBorder1Thickness);
                CornerRadius radius2 = ReduceRadiusByThickness(externalRadius, ScaledBorder2Thickness);
                CornerRadius radius3 = ReduceRadiusByThickness(externalRadius, ScaledBorder3Thickness);

                //Generates the geometries for the 4 borders and the background.
                Border0Geometry = GenerateBorderGeometry(new Radii(externalRect, externalRadius), new Radii(internal0Rect, radius0));
                Border1Geometry = GenerateBorderGeometry(new Radii(externalRect, externalRadius), new Radii(internal1Rect, radius1));
                Border2Geometry = GenerateBorderGeometry(new Radii(externalRect, externalRadius), new Radii(internal2Rect, radius2));
                Border3Geometry = GenerateBorderGeometry(new Radii(externalRect, externalRadius), new Radii(internal3Rect, radius3));
                BackgroundGeometry = GenerateBorderGeometry(new Radii(backgroundRect, radius0), Radii.Empty);
            }
            else
            {
                //If there is no space to draw, nothing is drawn and the geometries are cleared.
                Border0Geometry = Geometry.Empty;
                Border1Geometry = Geometry.Empty;
                Border2Geometry = Geometry.Empty;
                Border3Geometry = Geometry.Empty;
                BackgroundGeometry = Geometry.Empty;
            }

            return finalSize;
        }

        /// <summary>
        /// Draws the 4 borders and the background.
        /// </summary>
        protected override void OnRender(DrawingContext dc)
        {
            dc.DrawGeometry(Background, null, BackgroundGeometry);
            dc.DrawGeometry(BorderBrush, null, Border0Geometry);
            dc.DrawGeometry(Border1Brush, null, Border1Geometry);
            dc.DrawGeometry(Border2Brush, null, Border2Geometry);
            dc.DrawGeometry(Border3Brush, null, Border3Geometry);
        }

        /// <summary>
        /// Generates a border geometry with the specified parameters for the external and internal rect.<br/>
        /// The two rects are drawn one inside the other.<br/>
        /// The second rect will clear the first rect overlapped area to draw a border.<br/>
        /// If the two rects are the same, nothing is drawn.
        /// </summary>
        private static Geometry GenerateBorderGeometry(Radii externalRadii, Radii internalRadii)
        {
            if (!externalRadii.Equals(internalRadii))
            {
                StreamGeometry geometry = new();
                using (StreamGeometryContext context = geometry.Open())
                {
                    DrawRect(context, externalRadii);
                    DrawRect(context, internalRadii);
                }
                geometry.Freeze();
                return geometry;
            }
            return Geometry.Empty;
        }

        /// <summary>
        /// Draws a rect geometry using the specified <see cref="StreamGeometryContext"/>, with the specified <see cref="Radii"/>.
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

            //Check if the rect to draw has an area, otherwise there is nothing to draw.
            if (radii.HasArea)
            {
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
        }

        /// <summary>
        /// Updates the <see cref="MaxBorderThickness"/> property.
        /// </summary>
        private void UpdateMaxBorderThickness()
        {
            Thickness thickness0 = BorderThickness;
            Thickness thickness1 = Border1Thickness;
            Thickness thickness2 = Border2Thickness;
            Thickness thickness3 = Border3Thickness;

            //Calculates the max thickness taken by all the borders (the max for every edge).
            double left = Util.Max(thickness0.Left, thickness1.Left, thickness2.Left, thickness3.Left);
            double top = Util.Max(thickness0.Top, thickness1.Top, thickness2.Top, thickness3.Top);
            double right = Util.Max(thickness0.Right, thickness1.Right, thickness2.Right, thickness3.Right);
            double bottom = Util.Max(thickness0.Bottom, thickness1.Bottom, thickness2.Bottom, thickness3.Bottom);

            SetValue(MaxBorderThicknessPropertyKey, new Thickness(left, top, right, bottom));
        }

        /// <summary>
        /// Reduces the <see cref="System.Windows.CornerRadius"/> by removing the thickness of the angle's border.
        /// </summary>
        private static CornerRadius ReduceRadiusByThickness(CornerRadius radius, Thickness thickness)
        {
            //The corner radius remains positive.
            double topLeft = Math.Max(radius.TopLeft - Math.Max(thickness.Top, thickness.Left), 0.0);
            double topRight = Math.Max(radius.TopRight - Math.Max(thickness.Top, thickness.Right), 0.0);
            double bottomRight = Math.Max(radius.BottomRight - Math.Max(thickness.Bottom, thickness.Right), 0.0);
            double bottomLeft = Math.Max(radius.BottomLeft - Math.Max(thickness.Bottom, thickness.Left), 0.0);
            return new CornerRadius(topLeft, topRight, bottomRight, bottomLeft);
        }


        #region Radii

        /// <summary>
        /// Handles the parameters to draw a rectangle with round corners.
        /// </summary>
        internal struct Radii : IEquatable<Radii>
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

            /// <summary>
            /// Empty <see cref="Radii"/> with no area.
            /// </summary>
            public static Radii Empty { get; }

            #region Properties

            public Size TopLeftRadii { get; }
            public Size TopRightRadii { get; }
            public Size BottomRightRadii { get; }
            public Size BottomLeftRadii { get; }

            public Point LeftTop { get; }
            public Point TopLeft { get; }
            public Point TopRight { get; }
            public Point RightTop { get; }
            public Point RightBottom { get; }
            public Point BottomRight { get; }
            public Point BottomLeft { get; }
            public Point LeftBottom { get; }

            public bool HasArea { get; }

            #endregion

            /// <summary>
            /// Initializes a new <see cref="Radii"/> with a rectangle and the specified rounding corners size.
            /// </summary>
            /// <param name="rect">Base rectangle.</param>
            /// <param name="radius">Rounding size of the rectangle corners.</param>
            public Radii(Rect rect, CornerRadius radius)
            {
                //Calculates the 4 angles sizes, and fixes them to be adapted to the size of the rect.

                double topRadiuses = radius.TopLeft + radius.TopRight;
                double rightRadiuses = radius.TopRight + radius.BottomRight;
                double bottomRadiuses = radius.BottomRight + radius.BottomLeft;
                double leftRadiuses = radius.BottomLeft + radius.TopLeft;

                //Adjust the radius values to the rect sizes.
                double topLeftRadiiWidth = topRadiuses > rect.Width ? Util.Adapt(radius.TopLeft, topRadiuses, rect.Width) : radius.TopLeft;
                double topLeftRadiiHeight = leftRadiuses > rect.Height ? Util.Adapt(radius.TopLeft, leftRadiuses, rect.Height) : radius.TopLeft;
                double topRightRadiiWidth = topRadiuses > rect.Width ? Util.Adapt(radius.TopRight, topRadiuses, rect.Width) : radius.TopRight;
                double topRightRadiiHeight = rightRadiuses > rect.Height ? Util.Adapt(radius.TopRight, rightRadiuses, rect.Height) : radius.TopRight;
                double bottomRightRadiiWidth = bottomRadiuses > rect.Width ? Util.Adapt(radius.BottomRight, bottomRadiuses, rect.Width) : radius.BottomRight;
                double bottomRightRadiiHeight = rightRadiuses > rect.Height ? Util.Adapt(radius.BottomRight, rightRadiuses, rect.Height) : radius.BottomRight;
                double bottomLeftRadiiWidth = bottomRadiuses > rect.Width ? Util.Adapt(radius.BottomLeft, bottomRadiuses, rect.Width) : radius.BottomLeft;
                double bottomLeftRadiiHeight = leftRadiuses > rect.Height ? Util.Adapt(radius.BottomLeft, leftRadiuses, rect.Height) : radius.BottomLeft;

                TopLeftRadii = new Size(topLeftRadiiWidth, topLeftRadiiHeight);
                TopRightRadii = new Size(topRightRadiiWidth, topRightRadiiHeight);
                BottomRightRadii = new Size(bottomRightRadiiWidth, bottomRightRadiiHeight);
                BottomLeftRadii = new Size(bottomLeftRadiiWidth, bottomLeftRadiiHeight);

                //Calculates the angle points.

                LeftTop = new Point(rect.Left, rect.Top + TopLeftRadii.Height);
                TopLeft = new Point(rect.Left + TopLeftRadii.Width, rect.Top);

                RightTop = new Point(rect.Right, rect.Top + TopRightRadii.Height);
                TopRight = new Point(rect.Right - TopRightRadii.Width, rect.Top);

                RightBottom = new Point(rect.Right, rect.Bottom - BottomRightRadii.Height);
                BottomRight = new Point(rect.Right - BottomRightRadii.Width, rect.Bottom);

                LeftBottom = new Point(rect.Left, rect.Bottom - BottomLeftRadii.Height);
                BottomLeft = new Point(rect.Left + BottomLeftRadii.Width, rect.Bottom);

                //Remembers if the rect has area or not.

                HasArea = rect.HasArea();
            }

            /// <summary>
            /// Check if a <see cref="Radii"/> is equals to this <see cref="Radii"/>.
            /// </summary>
            /// <param name="radii"><see cref="Radii"/> to check for equality.</param>
            public bool Equals(Radii radii)
            {
                return LeftTop.Equals(radii.LeftTop)
                    && TopLeft.Equals(radii.TopLeft)
                    && TopRight.Equals(radii.TopRight)
                    && RightTop.Equals(radii.RightTop)
                    && RightBottom.Equals(radii.RightBottom)
                    && BottomRight.Equals(radii.BottomRight)
                    && BottomLeft.Equals(radii.BottomLeft)
                    && LeftBottom.Equals(radii.LeftBottom);
            }

            /// <inheritdoc/>
            public override bool Equals(object? obj) => obj is Radii radii && Equals(radii);

            /// <inheritdoc/>
            public override int GetHashCode() => HashCode.Combine(LeftTop, TopLeft, TopRight, RightTop, RightBottom, BottomRight, BottomLeft, LeftBottom);
        }

        #endregion
    }
}
