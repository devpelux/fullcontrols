using FullControls;
using System.Windows;

namespace FullControlsDemo
{
    public partial class MainWindow : FullWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            togglebutton.IsChecked = false;
        }
    }
}
