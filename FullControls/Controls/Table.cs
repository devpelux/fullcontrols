using FullControls.Attributes;
using FullControls.Common;
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
    [ContentProperty(nameof(Rows))]
    [DefaultProperty(nameof(Rows))]
    public class Table : Control
    {
        private readonly ItemsControl itemsControl = new();

        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        /// <summary>
        /// Gets the columns of the table.
        /// </summary>
        public ObservableCollection<TableColumn> Columns { get; } = new();

        /// <summary>
        /// Gets the rows of the table.
        /// </summary>
        public IndexedObservableCollection<TableRow> Rows { get; } = new();

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
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Table),
                new FrameworkPropertyMetadata(typeof(Table)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Table"/>.
        /// </summary>
        public Table() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
            Columns.CollectionChanged += (s, e) => OnColumnsChanged(e);
            Rows.CollectionChanged += (s, e) => OnRowsChanged(e);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Template.FindName(PartContentHost, this) is Decorator contentHost) contentHost.Child = itemsControl;
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        protected virtual void OnLoaded(RoutedEventArgs e) { }

        /// <summary>
        /// Called when the rows collection is changed.
        /// </summary>
        protected virtual void OnRowsChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    itemsControl.Items.Insert(e.NewStartingIndex, Rows[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    itemsControl.Items.RemoveAt(e.OldStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    itemsControl.Items[e.OldStartingIndex] = Rows[e.NewStartingIndex];
                    break;
                case NotifyCollectionChangedAction.Move:
                    itemsControl.Items.RemoveAt(e.OldStartingIndex);
                    itemsControl.Items.Insert(e.NewStartingIndex, Rows[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    itemsControl.Items.Clear();
                    foreach (TableRow row in Rows) itemsControl.Items.Add(row);
                    break;
                default:
                    itemsControl.Items.Clear();
                    foreach (TableRow row in Rows) itemsControl.Items.Add(row);
                    break;
            }
        }

        /// <summary>
        /// Called when the columns collection is changed.
        /// </summary>
        protected virtual void OnColumnsChanged(NotifyCollectionChangedEventArgs e)
        {
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
            if (ItemsSource != null)
            {
                //Reloads the rows of the table.
                //Recycles pre-existing rows.

                //Gets the positions and the width of the columns.
                List<TableColumn> columns = Columns.ToList();
                double[] widths = columns.ConvertAll(col => col.Width).ToArray();
                string[] headers = columns.ConvertAll(col => col.Header).ToArray();
                string[] ids = columns.ConvertAll(col => col.Id).ToArray();

                IEnumerator enumerator = itemsSource.GetEnumerator();

                //Sets the headers.
                if (Rows.Count < 1) Rows.Add(new TableRow());
                Rows[0].SetCells(headers, widths);
                Rows[0].Height = 32;

                //Sets the table rows.
                int i = 1;
                while (enumerator.MoveNext())
                {
                    //Gets a pre-existing row, or creates it if is needed.
                    TableRow row;
                    if (i < Rows.Count) row = Rows[i];
                    else
                    {
                        row = new TableRow();
                        Rows.Add(row);
                    }

                    //Gets the cells values.
                    string[] values = GetCellsValues(enumerator.Current, ids);

                    //Sets the row cells.
                    row.SetCells(values, widths);
                    row.Height = 32;
                    i++;
                }

                //Useless rows are removed.
                for (; i < Rows.Count; i++)
                {
                    Rows.RemoveAt(i);
                }
            }
            else
            {
                Rows.Clear();
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
