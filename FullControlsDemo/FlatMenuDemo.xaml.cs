﻿using FullControls.SystemControls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per FlatMenuDemo.xaml
    /// </summary>
    public partial class FlatMenuDemo : AvalonWindow
    {
        public FlatMenuDemo()
        {
            InitializeComponent();
        }

        private void EWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Minimize();
        }

        private void DuplicateAsDialog_Click(object sender, RoutedEventArgs e)
        {
            new FlatMenuDemo() { Owner = this }.ShowDialog();
        }

        private void DuplicateAsWindow_Click(object sender, RoutedEventArgs e)
        {
            new FlatMenuDemo() { Owner = this }.Show();
        }

        private void ResetLight_Click(object sender, RoutedEventArgs e)
        {
            lccm1.IsChecked = false;
            lccm2.IsChecked = true;
            lccm3.IsChecked = true;
            lccm4.IsChecked = true;

            lrcm1.IsChecked = true;
            lrcm2.IsChecked = false;
            lrcm3.IsChecked = false;
            lrcm4.IsChecked = false;
            lrcm5.IsChecked = false;
            lrcm6.IsChecked = true;
        }

        private void ResetDark_Click(object sender, RoutedEventArgs e)
        {
            dccm1.IsChecked = false;
            dccm2.IsChecked = true;
            dccm3.IsChecked = true;
            dccm4.IsChecked = true;

            drcm1.IsChecked = true;
            drcm2.IsChecked = false;
            drcm3.IsChecked = false;
            drcm4.IsChecked = false;
            drcm5.IsChecked = false;
            drcm6.IsChecked = true;
        }

        private void Gwiki_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", "https://www.github.com/devpelux/fullcontrols/wiki");
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            new Info() { Owner = this }.ShowDialog();
        }
    }
}
