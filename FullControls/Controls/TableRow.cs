using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Windows.Markup;
using System.Windows.Media;
using FullControls.Common;
using FullControls.Core;
using System.Windows.Input;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a row of a table.
    /// </summary>
    [ContentProperty(nameof(Cells))]
    [DefaultProperty(nameof(Cells))]
    public class TableRow : Control, IIndexed
    {
        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        private bool loaded = false;
        private Grid? grid = null;

        /// <inheritdoc/>
        public int Index { get; set; } = -1;

        /// <summary>
        /// Gets the cells of the row.
        /// </summary>
        public ObservableCollection<TableCell> Cells { get; } = new();

        /// <summary>
        /// Gets or sets the background brush when the mouse is over.
        /// </summary>
        public Brush BackgroundOnMouseOver
        {
            get => (Brush)GetValue(BackgroundOnMouseOverProperty);
            set => SetValue(BackgroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(BackgroundOnMouseOver), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the background brush when the mouse is pressed.
        /// </summary>
        public Brush BackgroundOnPressed
        {
            get => (Brush)GetValue(BackgroundOnPressedProperty);
            set => SetValue(BackgroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(BackgroundOnPressed), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the background brush when <see cref="IsAlternating"/> is true.
        /// </summary>
        public Brush AlternatingBackground
        {
            get => (Brush)GetValue(AlternatingBackgroundProperty);
            set => SetValue(AlternatingBackgroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AlternatingBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlternatingBackgroundProperty =
            DependencyProperty.Register(nameof(AlternatingBackground), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the background brush when the mouse is over and <see cref="IsAlternating"/> is true.
        /// </summary>
        public Brush AlternatingBackgroundOnMouseOver
        {
            get => (Brush)GetValue(AlternatingBackgroundOnMouseOverProperty);
            set => SetValue(AlternatingBackgroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AlternatingBackgroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlternatingBackgroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(AlternatingBackgroundOnMouseOver), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the background brush when the mouse is pressed and <see cref="IsAlternating"/> is true.
        /// </summary>
        public Brush AlternatingBackgroundOnPressed
        {
            get => (Brush)GetValue(AlternatingBackgroundOnPressedProperty);
            set => SetValue(AlternatingBackgroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AlternatingBackgroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlternatingBackgroundOnPressedProperty =
            DependencyProperty.Register(nameof(AlternatingBackgroundOnPressed), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualBackground => (Brush)GetValue(ActualBackgroundProperty);

        #region ActualBackgroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualBackgroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualBackground), typeof(Brush), typeof(TableRow),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualBackgroundProperty = ActualBackgroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualBackground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualBackgroundPropertyProxy =
            DependencyProperty.Register("ActualBackgroundProxy", typeof(Brush), typeof(TableRow),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualBackgroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets or sets the background brush when the mouse is over.
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
            DependencyProperty.Register(nameof(ForegroundOnMouseOver), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the background brush when the mouse is pressed.
        /// </summary>
        public Brush ForegroundOnPressed
        {
            get => (Brush)GetValue(ForegroundOnPressedProperty);
            set => SetValue(ForegroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ForegroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(ForegroundOnPressed), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the background brush when <see cref="IsAlternating"/> is true.
        /// </summary>
        public Brush AlternatingForeground
        {
            get => (Brush)GetValue(AlternatingForegroundProperty);
            set => SetValue(AlternatingForegroundProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AlternatingForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlternatingForegroundProperty =
            DependencyProperty.Register(nameof(AlternatingForeground), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the background brush when the mouse is over and <see cref="IsAlternating"/> is true.
        /// </summary>
        public Brush AlternatingForegroundOnMouseOver
        {
            get => (Brush)GetValue(AlternatingForegroundOnMouseOverProperty);
            set => SetValue(AlternatingForegroundOnMouseOverProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AlternatingForegroundOnMouseOver"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlternatingForegroundOnMouseOverProperty =
            DependencyProperty.Register(nameof(AlternatingForegroundOnMouseOver), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the background brush when the mouse is pressed and <see cref="IsAlternating"/> is true.
        /// </summary>
        public Brush AlternatingForegroundOnPressed
        {
            get => (Brush)GetValue(AlternatingForegroundOnPressedProperty);
            set => SetValue(AlternatingForegroundOnPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AlternatingForegroundOnPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AlternatingForegroundOnPressedProperty =
            DependencyProperty.Register(nameof(AlternatingForegroundOnPressed), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets the actual background brush of the control.
        /// </summary>
        public Brush ActualForeground => (Brush)GetValue(ActualForegroundProperty);

        #region ActualForegroundProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ActualForegroundPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ActualForeground), typeof(Brush), typeof(TableRow),
                new FrameworkPropertyMetadata(default(Brush)));

        /// <summary>
        /// Identifies the <see cref="ActualForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualForegroundProperty = ActualForegroundPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ActualForeground"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ActualForegroundPropertyProxy =
            DependencyProperty.Register("ActualForegroundProxy", typeof(Brush), typeof(TableRow),
                new FrameworkPropertyMetadata(default(Brush), new PropertyChangedCallback((d, e)
                    => d.SetValue(ActualForegroundPropertyKey, e.NewValue))));

        #endregion

        /// <summary>
        /// Gets a value indicating if the row is even or odd.
        /// </summary>
        public bool IsAlternating => Index % 2 == 0;

        /// <summary>
        /// Gets or sets the brush of the cell separator.
        /// </summary>
        public Brush CellSeparatorBrush
        {
            get => (Brush)GetValue(CellSeparatorBrushProperty);
            set => SetValue(CellSeparatorBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CellSeparatorBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CellSeparatorBrushProperty =
            DependencyProperty.Register(nameof(CellSeparatorBrush), typeof(Brush), typeof(TableRow));

        /// <summary>
        /// Gets or sets the width of the cell separator.
        /// </summary>
        public double CellSeparatorWidth
        {
            get => (double)GetValue(CellSeparatorWidthProperty);
            set => SetValue(CellSeparatorWidthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CellSeparatorWidth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CellSeparatorWidthProperty =
            DependencyProperty.Register(nameof(CellSeparatorWidth), typeof(double), typeof(TableRow));

        /// <summary>
        /// Gets or sets a value indicating if the row is pressed.
        /// </summary>
        public bool IsPressed
        {
            get => (bool)GetValue(IsPressedProperty);
            set => SetValue(IsPressedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IsPressed"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsPressedProperty =
            DependencyProperty.Register(nameof(IsPressed), typeof(bool), typeof(TableRow));

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
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(TableRow));

        static TableRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TableRow),
                new FrameworkPropertyMetadata(typeof(TableRow)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TableRow"/>.
        /// </summary>
        public TableRow() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
            Cells.CollectionChanged += (s, e) => OnCellsChanged(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            grid = (Grid)Template.FindName(PartContentHost, this);
            loaded = true;
            OnVStateChanged(GetCurrentVState(), true);
            OnCellsChanged(new(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        protected virtual void OnLoaded(RoutedEventArgs e) { }

        /// <inheritdoc/>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            IsPressed = true;
        }

        /// <inheritdoc/>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            IsPressed = false;
        }

        /// <inheritdoc/>
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            IsPressed = false;
        }

        /// <summary>
        /// Called when the rows collection is changed.
        /// </summary>
        protected virtual void OnCellsChanged(NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                Grid.SetColumn(Cells[i], i);
            }

            if (grid != null)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                        grid.Children.Insert(e.NewStartingIndex, Cells[e.NewStartingIndex]);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        grid.ColumnDefinitions.RemoveAt(0);
                        grid.Children.RemoveAt(e.OldStartingIndex);
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        grid.Children[e.OldStartingIndex] = Cells[e.NewStartingIndex];
                        break;
                    case NotifyCollectionChangedAction.Move:
                        grid.Children.RemoveAt(e.OldStartingIndex);
                        grid.Children.Insert(e.NewStartingIndex, Cells[e.NewStartingIndex]);
                        break;
                    default:
                        grid.ColumnDefinitions.Clear();
                        grid.Children.Clear();
                        foreach (TableCell cell in Cells)
                        {
                            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                            grid.Children.Add(cell);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the cell values and widths for the row.
        /// Pre-existing cells are recycled.
        /// </summary>
        /// <param name="values">Values for every single cell.</param>
        /// <param name="widths">Widths for every single cell.</param>
        /// <exception cref="ArgumentException">If values and widths have different sizes.</exception>
        public void SetCells(string[] values, double[] widths)
        {
            if (values.Length != widths.Length) throw new ArgumentException("Values and widths have different sizes.");

            int i = 0;
            foreach (string value in values)
            {
                //Gets a pre-existing cell, or creates it if is needed.
                TableCell cell;
                if (i < Cells.Count) cell = Cells[i];
                else
                {
                    //Border border = new Border();
                    cell = new TableCell();
                    Cells.Add(cell);
                }

                //Sets the cell value.
                cell.Text = values[i];
                cell.Width = widths[i];
                cell.TextAlignment = (TextAlignment)HorizontalContentAlignment;
                cell.VerticalAlignment = VerticalContentAlignment;
                cell.IsHitTestVisible = false;
                cell.Focusable = false;
                cell.Margin = new(8, 0, 8, 0);

                i++;
            }

            //Other cells are removed.
            for (; i < Cells.Count; i++)
            {
                Cells.RemoveAt(i);
            }
        }

        /// <inheritdoc/>
        public VState GetCurrentVState()
        {
            if (!loaded) return VState.UNSET;
            else if (IsPressed) return VStates.PRESSED;
            else if (IsMouseOver) return VStates.MOUSE_OVER;
            else return VStates.DEFAULT;
        }

        /// <summary>
        /// Called when the current <see cref="VState"/> is changed.
        /// </summary>
        /// <param name="vstate">Current <see cref="VState"/>.</param>
        /// <param name="initial">Specifies if this is the initial <see cref="VState"/>.</param>
        protected virtual void OnVStateChanged(VState vstate, bool initial = false)
        {
            bool alt = IsAlternating;

            if (vstate == VStates.DEFAULT)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, alt ? AlternatingBackground : Background, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, alt ? AlternatingForeground : Foreground, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.MOUSE_OVER)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, alt ? AlternatingBackgroundOnMouseOver : BackgroundOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, alt ? AlternatingForegroundOnMouseOver : ForegroundOnMouseOver, initial ? TimeSpan.Zero : AnimationTime);
            }
            else if (vstate == VStates.PRESSED)
            {
                Util.AnimateBrush(this, ActualBackgroundPropertyProxy, alt ? AlternatingBackgroundOnPressed : BackgroundOnPressed, initial ? TimeSpan.Zero : AnimationTime);
                Util.AnimateBrush(this, ActualForegroundPropertyProxy, alt ? AlternatingForegroundOnPressed : ForegroundOnPressed, initial ? TimeSpan.Zero : AnimationTime);
            }
        }


        /// <summary>
        /// Control v-states.
        /// </summary>
        public static class VStates
        {
            /// <summary>
            /// Default state.
            /// </summary>
            public static readonly VState DEFAULT = new(nameof(DEFAULT), typeof(TableRow));

            /// <summary>
            /// The mouse is over the control.
            /// </summary>
            public static readonly VState MOUSE_OVER = new(nameof(MOUSE_OVER), typeof(TableRow));

            /// <summary>
            /// The control is pressed.
            /// </summary>
            public static readonly VState PRESSED = new(nameof(PRESSED), typeof(TableRow));
        }
    }
}
