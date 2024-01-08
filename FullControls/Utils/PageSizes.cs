namespace FullControls.Utils
{
    /// <summary>
    /// Contains the most common page layouts.
    /// </summary>
    public class PageLayouts
    {
        /// <summary>
        /// A3 Page layout.
        /// </summary>
        public static readonly PageLayouts A3 = new("29.7cm", "42cm", "3.18cm", "2.54cm", "1.9cm", "2.54cm", "1.27cm", "1.27cm");

        /// <summary>
        /// A4 Page layout.
        /// </summary>
        public static readonly PageLayouts A4 = new("21cm", "29.7cm", "3.18cm", "2.54cm", "1.9cm", "2.54cm", "1.27cm", "1.27cm");

        /// <summary>
        /// A5 Page layout.
        /// </summary>
        public static readonly PageLayouts A5 = new("14.8cm", "21cm", "3.18cm", "2.54cm", "1.9cm", "2.54cm", "1.27cm", "1.27cm");

        //todo add more layouts.

        /// <summary>
        /// Page layout with large margins.
        /// </summary>
        public PageLayout MarginsLarge { get; }

        /// <summary>
        /// Page layout with mid margins.
        /// </summary>
        public PageLayout MarginsMid { get; }

        /// <summary>
        /// Page layout with narrow margins.
        /// </summary>
        public PageLayout MarginsNarrow { get; }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        private PageLayouts(string w, string h, string largeLR, string largeTB, string midLR, string midTB, string narrowLR, string narrowTB)
        {
            MarginsLarge = new PageLayout(w, h, largeLR, largeTB);
            MarginsMid = new PageLayout(w, h, midLR, midTB);
            MarginsNarrow = new PageLayout(w, h, narrowLR, narrowTB);
        }
    }
}
