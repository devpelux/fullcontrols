using FullControls;
using System.Windows;

namespace FullControlsDemo
{
    public partial class MainWindow : EWindow
    {
        int c = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            togglebutton.IsChecked = false;
            textbox.Text = $"{c = 0}";
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text = $"{c++}";
        }

        private void PasswordboxClear_Click(object sender, RoutedEventArgs e)
        {
            passwordbox.Clear();
        }
    }
}
