using FullControls.Common;
using FullControls.SystemControls;
using System.Media;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per CustomMessageWindowDemo.xaml
    /// </summary>
    public partial class CustomMessageWindowDemo : AvalonWindow, IDialog<string>
    {
        public const string YES = "CustomMessageWindowDemo.YES";
        public const string NO = "CustomMessageWindowDemo.NO";
        public const string MAYBE = "CustomMessageWindowDemo.MAYBE";
        public const string WHAT = "CustomMessageWindowDemo.WHAT";
        public const string ABORT = "CustomMessageWindowDemo.ABORT";

        private string? result;


        public CustomMessageWindowDemo()
        {
            InitializeComponent();
        }

        private void EWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SystemSounds.Exclamation.Play();
        }

        private void EWindow_Closed(object sender, System.EventArgs e)
        {
            if (result == null) result = ABORT;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            result = YES;
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            result = NO;
            Close();
        }

        private void Maybe_Click(object sender, RoutedEventArgs e)
        {
            result = MAYBE;
            Close();
        }

        private void What_Click(object sender, RoutedEventArgs e)
        {
            result = WHAT;
            Close();
        }

        public string? GetResult() => result;
    }
}
