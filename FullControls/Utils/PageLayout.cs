using System.Windows;

namespace FullControls.Utils
{
    /// <summary>
    /// Represents a page layout.
    /// </summary>
    public class PageLayout
    {
        /// <summary>
        /// Size of the page.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Padding of the page. (Also known as margins)
        /// </summary>
        public Thickness Padding { get; }

        /// <summary>
        /// Column width of the page.
        /// </summary>
        public double ColumnWidth => Size.Width - Padding.Left - Padding.Right;

        //todo add more properties.

        /// <summary>
        /// Initializes a new instance by specifying the page size and the page margins.
        /// </summary>
        public PageLayout(string width, string height, string leftRight, string topBottom)
        {
            LengthConverter converter = new();
            double sizeWidth = (double)converter.ConvertFromInvariantString(width)!;
            double sizeHeight = (double)converter.ConvertFromInvariantString(height)!;

            double paddingLeftRight = (double)converter.ConvertFromInvariantString(leftRight)!;
            double paddingTopBottom = (double)converter.ConvertFromInvariantString(topBottom)!;

            Size = new Size(sizeWidth, sizeHeight);
            Padding = new Thickness(paddingLeftRight, paddingTopBottom, paddingLeftRight, paddingTopBottom);
        }
    }
}
