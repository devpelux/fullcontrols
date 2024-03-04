using System.Windows.Controls;

namespace FullControls.Controls
{
    /// <summary>
    /// Represents a column of a table.
    /// </summary>
    public class TableColumn : Control
    {
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
