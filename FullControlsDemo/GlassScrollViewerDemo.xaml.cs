﻿using FullControls.SystemControls;
using System;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per GlassScrollViewerDemo.xaml
    /// </summary>
    public partial class GlassScrollViewerDemo : AvalonWindow
    {
        public GlassScrollViewerDemo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            v1.Text = Math.Round(gsb1.Value, 2).ToString();
            v2.Text = Math.Round(gsb2.Value, 2).ToString();
        }

        private void GlassScrollBar1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (v1 != null) v1.Text = Math.Round(e.NewValue, 2).ToString();
        }

        private void GlassScrollBar2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (v2 != null) v2.Text = Math.Round(e.NewValue, 2).ToString();
        }
    }
}
