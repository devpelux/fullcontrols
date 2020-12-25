using FullControls;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace FullControlsDemo
{
    /// <summary>
    /// Demo Home window.
    /// </summary>
    public partial class Home : EWindow
    {
        int c = 0;
        readonly DoubleAnimation disableThis;


        public Home()
        {
            InitializeComponent();
            background.Visibility = Visibility.Visible;
            disableThis = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 250)))
            {
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkbox.IsChecked != true) togglebutton.IsChecked = false;
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

        private void EWindow_CloseAction(object sender, ActionEventArgs e)
        {
            if (togglebutton.IsChecked == true)
            {
                e.Cancel = true;
                disablethis.BeginAnimation(OpacityProperty, disableThis);
            }
        }
    }
}
