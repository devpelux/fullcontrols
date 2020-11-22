using FullControls;
using System.Windows;
using System.Windows.Controls;

namespace FullControlsDemo
{
    public partial class MainWindow : Window
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
