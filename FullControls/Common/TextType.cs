using FullControls.Controls;

namespace FullControls.Common
{
    /// <summary>
    /// Specifies the text type allowed in a <see cref="TextBoxPlus"/>.
    /// </summary>
    public enum TextType
    {
        /// <summary>
        /// Normal string.
        /// </summary>
        Text,

        /// <summary>
        /// Only <see cref="double"/> values.
        /// </summary>
        DoubleOnly,

        /// <summary>
        /// Only <see cref="int"/> values.
        /// </summary>
        IntOnly,

        /// <summary>
        /// Only numeric chars.
        /// </summary>
        NumericOnly
    }
}
