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
            togglebutton.IsChecked = togglebutton.IsChecked != true;
            textbox.TextInt = c = 0;
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            textbox.TextInt = c++;
        }

        private void PasswordboxClear_Click(object sender, RoutedEventArgs e)
        {
            passwordbox.Clear();
        }
    }
}
