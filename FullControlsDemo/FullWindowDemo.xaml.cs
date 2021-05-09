using FullControls.SystemComponents;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per FullWindowDemo.xaml
    /// </summary>
    public partial class FullWindowDemo : FullWindow
    {
        public FullWindowDemo()
        {
            InitializeComponent();
            background.Visibility = Visibility.Visible;
        }
    }
}
