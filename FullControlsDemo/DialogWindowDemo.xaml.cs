using FullControls.SystemComponents;
using System.Windows;
using WpfCoreTools;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per DialogWindowDemo.xaml
    /// </summary>
    public partial class DialogWindowDemo : AvalonWindow
    {
        public DialogWindowDemo()
        {
            InitializeComponent();
        }

        private void Showdialog_Click(object sender, RoutedEventArgs e)
        {
            string? res = new CustomMessageWindowDemo() { Owner = this }.ShowDialogForResult<string>();

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
