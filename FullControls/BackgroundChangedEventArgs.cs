using System;
using System.Windows.Media;

namespace FullControls
{
    /// <summary>
    /// Data of a BackgroundChanged event.
    /// </summary>
    public class BackgroundChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Actual value of the background.
        /// </summary>
        public Brush ActualBackground { get; init; }


        /// <summary>
        /// Create a BackgroundChangedEventArgs with data of a BackgroundChanged event.
        /// </summary>
        /// <param name="actualBackground">Actual value of the background.</param>
        public BackgroundChangedEventArgs(Brush actualBackground) => ActualBackground = actualBackground;
    }
}
