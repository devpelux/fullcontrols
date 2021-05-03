using System.Windows;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// <see cref="AvalonWindow"/> with the possibility to add a <see cref="CornerRadius"/> to the angles.
    /// </summary>
    public class CornerWindow : AvalonWindow
    {
        static CornerWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CornerWindow),
                new FrameworkPropertyMetadata(typeof(CornerWindow)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CornerWindow"/>.
        /// </summary>
        public CornerWindow() : base() { }
    }
}
