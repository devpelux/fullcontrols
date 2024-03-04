using System;

namespace FullControls.Attributes
{
    /// <summary>
    /// Specifies that a property can be inserted in a table column with the specified index.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class TableColumnAttribute : Attribute
    {
        /// <summary>
        /// Id of the column.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TableColumnAttribute(string id)
        {
            Id = id;
        }
    }
}
