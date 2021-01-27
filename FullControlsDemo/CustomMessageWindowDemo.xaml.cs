using FullControls;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per CustomMessageWindowDemo.xaml
    /// </summary>
    public partial class CustomMessageWindowDemo : EWindow, IDialog
    {
        public const string YES = "CustomMessageWindowDemo.YES";
        public const string NO = "CustomMessageWindowDemo.NO";
        public const string MAYBE = "CustomMessageWindowDemo.MAYBE";
        public const string WHAT = "CustomMessageWindowDemo.WHAT";
        public const string ABORT = "CustomMessageWindowDemo.ABORT";

        private string result;


        public CustomMessageWindowDemo()
        {
            InitializeComponent();
        }

        private void EWindow_Closed(object sender, System.EventArgs e)
        {
            if (result == null) result = ABORT;
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            result = YES;
            Close();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            result = NO;
            Close();
        }

        private void maybe_Click(object sender, RoutedEventArgs e)
        {
            result = MAYBE;
            Close();
        }

        private void what_Click(object sender, RoutedEventArgs e)
        {
            result = WHAT;
            Close();
        }

        public object GetResult() => result;
    }
}
