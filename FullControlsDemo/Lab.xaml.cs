using FullControls.Common;
using FullControls.SystemControls;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per Lab.xaml
    /// </summary>
    public partial class Lab : AvalonWindow
    {
        public Lab()
        {
            InitializeComponent();
        }

        private void ButtonPlus_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RawTime time = timebox.GetDate();
            timebox.SetDate(time);
        }

        private void ButtonPlus2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RawTime time = timebox.GetTime();
            timebox.SetTime(time);
        }
    }
}
