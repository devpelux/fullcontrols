﻿using FullControls.SystemControls;
using System.Diagnostics;
using System.Windows.Input;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per Info.xaml
    /// </summary>
    public partial class Info : AvalonWindow
    {
        public Info()
        {
            InitializeComponent();
            VersionCode.Text = GetVersionCode();
        }

        private void GH_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("explorer.exe", "https://www.github.com/devpelux/fullcontrols");
        }

        private void NG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("explorer.exe", "https://www.nuget.org/packages/FullControls");
        }

        private void DOC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("explorer.exe", "https://www.github.com/devpelux/fullcontrols/wiki");
        }

        private void R_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/devpelux/fullcontrols/releases/latest");
        }

        private void FullW_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new FullWindowDemo() { Owner = this }.Show();
        }

        private void FlexW_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new FlexWindowDemo() { Owner = this }.Show();
        }

        private void AvalonW_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AvalonWindowDemo() { Owner = this }.Show();
        }

        private static string GetVersionCode() => FullControls.VersionInfo.VersionCode;
    }
}
