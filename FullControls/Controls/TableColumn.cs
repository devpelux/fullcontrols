using System.Windows;
using System.Windows.Controls;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a column of a table.
    /// </summary>
    public class TableColumn
    {
        /// <summary>
        /// Gets or sets the header of the column.
        /// </summary>
        public GridLength Width { get; set; } = GridLength.Auto;

        /// <summary>
        /// Gets or sets the header of the column.
        /// </summary>
        public string Header { get; set; } = "";

        /// <summary>
        /// Gets or sets the id of the column.
        /// </summary>
        public string Id { get; set; } = "";
    }
}
