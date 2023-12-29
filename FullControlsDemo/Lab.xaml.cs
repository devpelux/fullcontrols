using FullControls.SystemControls;
using RawTimeCore;

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
            RawTime time = timebox.GetTime().TimeOfDayMinutes();
            timebox.SetTime(time, "HH:mm");
        }
    }
}
