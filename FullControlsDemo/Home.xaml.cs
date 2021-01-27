﻿using FullControls;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per Home.xaml
    /// </summary>
    public partial class Home : EWindow
    {
        public Home()
        {
            InitializeComponent();
            background.Visibility = Visibility.Visible;
        }

        private void AccordionDemo_Click(object sender, RoutedEventArgs e)
        {
            new AccordionDemo().Show();
        }

        private void CollapsableDemo_Click(object sender, RoutedEventArgs e)
        {
            new CollapsableDemo().Show();
        }

        private void ButtonsDemo_Click(object sender, RoutedEventArgs e)
        {
            new ButtonsDemo().Show();
        }

        private void SwitcherDemo_Click(object sender, RoutedEventArgs e)
        {
            new SwitcherDemo().Show();
        }

        private void CheckboxesDemo_Click(object sender, RoutedEventArgs e)
        {
            new CheckBoxesDemo().Show();
        }

        private void ComboboxDemo_Click(object sender, RoutedEventArgs e)
        {
            new ComboBoxDemo().Show();
        }

        private void ScrollviewerDemo_Click(object sender, RoutedEventArgs e)
        {
            new GlassScrollViewerDemo().Show();
        }

        private void DialogwindowDemo_Click(object sender, RoutedEventArgs e)
        {
            new DialogWindowDemo().Show();
        }

        private void TextboxesDemo_Click(object sender, RoutedEventArgs e)
        {
            new TextBoxesDemo().Show();
        }

        private void MenuDemo_Click(object sender, RoutedEventArgs e)
        {
            new MenuDemo().Show();
        }
    }
}
