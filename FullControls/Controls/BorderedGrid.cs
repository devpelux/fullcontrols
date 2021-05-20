//This is the implementation of the bordered grid control seen here: https://stackoverflow.com/a/7449908/3605220

using FullControls.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FullControls.Controls
{
    /// <summary>
    /// Defines a flexible grid area that consists of columns and rows with possibility to specify borders for columns and rows.
    /// </summary>
    public class BorderedGrid : Grid
    {
        /// <summary>
        /// Gets or sets a value that specifies which grid lines to show.
        /// </summary>
        public DataGridGridLinesVisibility GridLinesVisibility
        {
            get => (DataGridGridLinesVisibility)GetValue(GridLinesVisibilityProperty);
            set => SetValue(GridLinesVisibilityProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="GridLinesVisibility"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty GridLinesVisibilityProperty =
            DependencyProperty.Register(nameof(GridLinesVisibility), typeof(DataGridGridLinesVisibility), typeof(BorderedGrid),
                new FrameworkPropertyMetadata(DataGridGridLinesVisibility.None, FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets a value that specifies if to show the border.
        /// </summary>
        public bool GridBorderVisibility
        {
            get => (bool)GetValue(GridBorderVisibilityProperty);
            set => SetValue(GridBorderVisibilityProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="GridBorderVisibility"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty GridBorderVisibilityProperty =
            DependencyProperty.Register(nameof(GridBorderVisibility), typeof(bool), typeof(BorderedGrid),
                new FrameworkPropertyMetadata(BoolBox.False, FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets the brush of the grid lines.
        /// </summary>
        public Brush GridLineBrush
        {
            get => (Brush)GetValue(GridLineBrushProperty);
            set => SetValue(GridLineBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="GridLineBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty GridLineBrushProperty =
            DependencyProperty.Register(nameof(GridLineBrush), typeof(Brush), typeof(BorderedGrid),
                new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets the thickness of the grid lines.
        /// </summary>
        public double GridLineThickness
        {
            get { return (double)GetValue(GridLineThicknessProperty); }
            set { SetValue(GridLineThicknessProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="GridLineThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty GridLineThicknessProperty =
            DependencyProperty.Register(nameof(GridLineThickness), typeof(double), typeof(BorderedGrid),
                new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsRender));


        static BorderedGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BorderedGrid),
                new FrameworkPropertyMetadata(typeof(BorderedGrid)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BorderedGrid"/>.
        /// </summary>
        public BorderedGrid() : base() { }

        /// <inheritdoc/>
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            switch (GridLinesVisibility)
            {
                case DataGridGridLinesVisibility.All:
                    DrawHorizontalLines(dc);
                    DrawVerticalLines(dc);
                    break;
                case DataGridGridLinesVisibility.Horizontal:
                    DrawHorizontalLines(dc);
                    break;
                case DataGridGridLinesVisibility.None:
                    break;
                case DataGridGridLinesVisibility.Vertical:
                    DrawVerticalLines(dc);
                    break;
                default:
                    break;
            }

            if (GridBorderVisibility) DrawBorder(dc);
        }

        #region Lines drawing

        private void DrawHorizontalLines(DrawingContext dc)
        {
            Pen pen = new(GridLineBrush, GridLineThickness);
            double halfPT = pen.Thickness / 2;

            for (int i = 1; i < RowDefinitions.Count; i++)
            {
                RowDefinition row = RowDefinitions[i];

                dc.PushGuidelineSet(GetGuidelineSet(new Point(0 - halfPT, row.Offset - halfPT),
                                                    new Point(ActualWidth - halfPT, row.Offset - halfPT)));

                dc.DrawLine(pen, new Point(0, row.Offset), new Point(ActualWidth, row.Offset));
            }
        }

        private void DrawVerticalLines(DrawingContext dc)
        {
            Pen pen = new(GridLineBrush, GridLineThickness);
            double halfPT = pen.Thickness / 2;

            for (int i = 1; i < ColumnDefinitions.Count; i++)
            {
                ColumnDefinition column = ColumnDefinitions[i];

                dc.PushGuidelineSet(GetGuidelineSet(new Point(column.Offset - halfPT, 0 - halfPT),
                                                    new Point(column.Offset - halfPT, ActualHeight - halfPT)));

                dc.DrawLine(pen, new Point(column.Offset, 0), new Point(column.Offset, ActualHeight));
            }
        }

        private void DrawBorder(DrawingContext dc)
        {
            Pen pen = new(GridLineBrush, GridLineThickness);
            double halfPT = pen.Thickness / 2;

            dc.PushGuidelineSet(GetGuidelineSet(new Point(0 - halfPT, 0 - halfPT),
                                                new Point(ActualWidth - halfPT, ActualWidth - halfPT)));

            dc.DrawRectangle(null, pen, new Rect(0, 0, ActualWidth, ActualHeight));
        }

        private static GuidelineSet GetGuidelineSet(Point a, Point b)
        {
            GuidelineSet guideline = new();

            guideline.GuidelinesX.Add(a.X);
            guideline.GuidelinesX.Add(b.X);
            guideline.GuidelinesY.Add(a.Y);
            guideline.GuidelinesY.Add(b.Y);

            return guideline;
        }

        #endregion
    }
}
