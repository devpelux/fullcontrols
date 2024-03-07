using FullControls.Attributes;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a table with rows and columns.
    /// </summary>
    [ContentProperty(nameof(Columns))]
    [DefaultProperty(nameof(Columns))]
    public class Table : Control
    {
        private readonly Grid grid = new();

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Gets the columns of the table.
        /// </summary>
        public ObservableCollection<TableColumn> Columns { get; } = new();

        /// <summary>
        /// Gets or sets a collection used to generate the content of the table rows.
        /// </summary>
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        #region ItemsSource

        /// <summary>
        /// Identifies the <see cref="ItemsSource"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(Table),
                                          new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnItemsSourceChanged)));

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((Table)d).OnItemsSourceChanged((IEnumerable)e.OldValue, (IEnumerable)e.NewValue);

        #endregion

        static Table()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Table), new FrameworkPropertyMetadata(typeof(Table)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Table"/>.
        /// </summary>
        public Table() : base()
        {
            Columns.CollectionChanged += (s, e) => OnColumnsChanged(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Template.FindName(PartContentHost, this) is Decorator contentHost) contentHost.Child = grid;
        }

        /// <summary>
        /// Called when the columns collection is changed.
        /// </summary>
        protected virtual void OnColumnsChanged(NotifyCollectionChangedEventArgs e)
        {
            grid.ColumnDefinitions.Clear();
            Columns.ToList().ForEach(c => grid.ColumnDefinitions.Add(new() { Width = c.Width }));

            //When the columns are changed, populates the table rows with the data of the items source.
            ReloadRows(ItemsSource);
        }

        /// <summary>
        /// Called when the value of ItemsSource is changed.
        /// </summary>
        protected virtual void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            //When the items source is changed, populates the table rows with the data of the items source.
            ReloadRows(newValue);
        }

        private void ReloadRows(IEnumerable itemsSource)
        {
            grid.Children.Clear();

            if (ItemsSource != null)
            {
                //Reloads the rows of the table.
                //Recycles pre-existing rows.

                //Gets the positions and the width of the columns.
                List<TableColumn> columns = Columns.ToList();
                string[] headers = columns.ConvertAll(col => col.Header).ToArray();
                string[] ids = columns.ConvertAll(col => col.Id).ToArray();

                for (int h = 0; h < headers.Length; h++)
                {
                    TextBlock t = new();
                    t.Text = headers[h];

                    //Sets the column (row is 0).
                    Grid.SetColumn(t, h);

                    grid.Children.Add(t);
                }

                IEnumerator enumerator = itemsSource.GetEnumerator();

                int r = 1, c = 0;

                grid.RowDefinitions.Clear();

                while (enumerator.MoveNext())
                {
                    object row = enumerator.Current;
                    grid.RowDefinitions.Add(new() { Height = new(32) });

                    //Gets the cells values.
                    string[] values = GetCellsValues(row, ids);

                    c = 0;

                    foreach (string value in values)
                    {
                        TextBlock t = new();
                        t.Text = value;

                        //Sets the row and column.
                        Grid.SetRow(t, r);
                        Grid.SetColumn(t, c);

                        grid.Children.Add(t);

                        c++;
                    }

                    r++;
                }
            }
        }

        /// <summary>
        /// Gets the values for each cell of a row.
        /// </summary>
        /// <param name="source">Source of the data to insert in the cells of a row.</param>
        /// <param name="ids">Ids of the cells in the row.</param>
        private static string[] GetCellsValues(object source, string[] ids)
        {
            //Gets the properties marked as table column.
            PropertyInfo[] props = source.GetType().GetProperties().Where(p => p.IsDefined(typeof(TableColumnAttribute), false)).ToArray();

            //The cell number is specified by the ids array.
            string[] cells = new string[ids.Length];

            //Gets the data to display in the cells in the correct positions basing on the ids.
            //If the id is not found, an empty string is set.
            for (int i = 0; i < ids.Length; i++)
            {
                string id = ids[i];
                PropertyInfo? prop = props.Where(p => p.GetCustomAttribute<TableColumnAttribute>(false)!.Id == id).FirstOrDefault();
                cells[i] = prop != null ? prop.GetValue(source)?.ToString() ?? "" : "";
            }

            return cells;
        }
    }
}
