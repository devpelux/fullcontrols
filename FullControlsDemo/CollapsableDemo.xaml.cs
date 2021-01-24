using FullControls;
using System;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per CollapsableDemo.xaml
    /// </summary>
    public partial class CollapsableDemo : EWindow
    {
        public CollapsableDemo()
        {
            InitializeComponent();
        }

        private void Toggle_Checked(object sender, RoutedEventArgs e)
        {
            collapsable.IsExpanded = true;
        }

        private void Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            collapsable.IsExpanded = false;
        }

        private void Collapsable_AnimationStarted(object sender, EventArgs e)
        {
            toggle.ClickToggleType = ToggleType.None;
        }

        private void Collapsable_AnimationEnded(object sender, EventArgs e)
        {
            toggle.ClickToggleType = ToggleType.Complete;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            scr.Height += 10;
            scr.Width += 10;
        }
    }
}
