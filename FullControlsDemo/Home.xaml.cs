using FullControls;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Demo Home window.
    /// </summary>
    public partial class Home : EWindow
    {
        int c = 0;


        public Home()
        {
            InitializeComponent();
            background.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkbox.IsChecked != true) togglebutton.IsChecked = togglebutton.IsChecked = false;
            textbox_int.TextInt = c = 0;
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            textbox_int.TextInt = c += (radiobutton2.IsChecked == true) ? 2 : 1;
        }

        private void PasswordboxClear_Click(object sender, RoutedEventArgs e)
        {
            passwordbox.Clear();
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            togglebutton.ClickToggleType = ToggleType.Complete;
        }

        private void Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            togglebutton.ClickToggleType = ToggleType.Activate;
        }
    }
}
