using FullControls.SystemControls;
using FullControls.Utils;
using RawTimeCore;
using System;

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

        private void ButtonPlus2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Exception ex = new("Simulated Internal Error.");
            VisualizableException exx = new("Visualizable error.", ex);
            exx.ShowDialog(this);
        }
    }
}
