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

        private void Switcher1_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            SV.VisibleItem = 0;
        }

        private void Switcher2_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            SV.VisibleItem = 1;
        }
    }
}
