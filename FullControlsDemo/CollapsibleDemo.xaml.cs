using FullControls.Common;
using FullControls.SystemComponents;
using System;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per CollapsibleDemo.xaml
    /// </summary>
    public partial class CollapsibleDemo : CornerWindow
    {
        public CollapsibleDemo()
        {
            InitializeComponent();
        }

        private void Toggle_Checked(object sender, RoutedEventArgs e)
        {
            collapsible.IsExpanded = true;
        }

        private void Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            collapsible.IsExpanded = false;
        }

        private void Collapsible_AnimationStarted(object sender, EventArgs e)
        {
            toggle.ClickToggleType = ToggleType.None;
        }

        private void Collapsible_AnimationEnded(object sender, EventArgs e)
        {
            toggle.ClickToggleType = ToggleType.Complete;
        }

        private void Collapsible_IsExpandedChanged(object sender, ExpandedChangedEventArgs e)
        {
            toggle.Content = e.IsExpanded ? "Collapse" : "Expand";
        }
    }
}
