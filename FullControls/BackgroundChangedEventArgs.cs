using System;
using System.Windows.Media;

namespace FullControls
{
    public class BackgroundChangedEventArgs : EventArgs
    {
        public Brush ActualBackground { get; init; }


        public BackgroundChangedEventArgs(Brush actualBackground) => ActualBackground = actualBackground;
    }
}
