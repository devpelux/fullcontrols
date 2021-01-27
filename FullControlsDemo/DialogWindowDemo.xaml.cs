using FullControls;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per DialogWindowDemo.xaml
    /// </summary>
    public partial class DialogWindowDemo : EWindow
    {
        public DialogWindowDemo()
        {
            InitializeComponent();
        }

        private void Showdialog_Click(object sender, RoutedEventArgs e)
        {
            string res = (string)new DialogWindow(new CustomMessageWindowDemo() { Owner = this }).Show();

            switch (res)
            {
                case CustomMessageWindowDemo.YES:
                    result.Text = "You have chosen yes.";
                    break;
                case CustomMessageWindowDemo.NO:
                    result.Text = "You have chosen no.";
                    break;
                case CustomMessageWindowDemo.MAYBE:
                    result.Text = "You have chosen maybe.";
                    break;
                case CustomMessageWindowDemo.WHAT:
                    result.Text = "You have chosen what?";
                    break;
                case CustomMessageWindowDemo.ABORT:
                    result.Text = "You have closed the message box.";
                    break;
            }
        }
    }
}
