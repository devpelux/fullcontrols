using System.Windows;

namespace FullControlsDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            togglebutton.IsChecked = false;
        }
    }
}
