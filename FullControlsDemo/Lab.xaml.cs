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

        int vi = 0;

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.VisibleIndex = vi;
            vi++;
            if (vi > 1) vi = 0;
        }
    }
}
