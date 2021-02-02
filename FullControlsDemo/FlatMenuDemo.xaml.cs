using FullControls;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per FlatMenuDemo.xaml
    /// </summary>
    public partial class FlatMenuDemo : EWindow
    {
        public FlatMenuDemo()
        {
            InitializeComponent();
        }

        private void EButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            itX.IsChecked = true;
        }
    }
}
