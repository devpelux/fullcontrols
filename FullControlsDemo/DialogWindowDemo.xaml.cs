using FullControls.SystemComponents;
using FullControls.Windows;
using System.Windows;

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

        private void Showmessage_Click(object sender, RoutedEventArgs e)
        {
            ShowMessageWindow(false);
        }

        private void Showmessagedark_Click(object sender, RoutedEventArgs e)
        {
            ShowMessageWindow(true);
        }

        private void ShowMessageWindow(bool dark)
        {
            MessageWindow.Result res = MessageWindow.GetBuilder()
                                                    .WithTitle("Message window")
                                                    .WithMessage("This is a standard message window, with a loooooooooong message.")
                                                    .WithPositive("OK")
                                                    .WithNegative("Cancel")
                                                    .WithType(MessageWindow.Type.Asterisk)
                                                    .WithOwner(this)
                                                    .WithTheme(dark ? MessageWindow.Theme.Dark : MessageWindow.Theme.Light)
                                                    .BuildAndShow();

            switch (res)
            {
                case MessageWindow.Result.Neutral:
                    result.Text = "You have chosen neutral.";
                    break;
                case MessageWindow.Result.Positive:
                    result.Text = "You have chosen positive.";
                    break;
                case MessageWindow.Result.Negative:
                    result.Text = "You have chosen negative.";
                    break;
            }
        }

        private void Result_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _ = MessageWindow.GetBuilder()
                             .WithTitle("Interstellar")
                             .WithMessage("Do not go gentle" +
                                          "\ninto that good night..." +
                                          "\nold age should burn and rave" +
                                          "\nat close of day..." +
                                          "\nrage," +
                                          "\nrage against the dying" +
                                          "\nof the light.")
                             .WithPositive("OK")
                             .WithOwner(this)
                             .BuildAndShow();
        }
    }
}
