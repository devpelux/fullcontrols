using FullControls.SystemComponents;
using System.Windows;
using System.Windows.Input;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per Home.xaml
    /// </summary>
    public partial class Home : FlatWindow
    {
        public Home()
        {
            InitializeComponent();
            background.Visibility = Visibility.Visible;
        }

        private void Accordion_Click(object sender, RoutedEventArgs e)
        {
            new AccordionDemo().Show();
        }

        private void Collapsible_Click(object sender, RoutedEventArgs e)
        {
            new CollapsibleDemo().Show();
        }

        private void Buttons_Click(object sender, RoutedEventArgs e)
        {
            new ButtonsDemo().Show();
        }

        private void Switcher_Click(object sender, RoutedEventArgs e)
        {
            new SwitcherDemo().Show();
        }

        private void CheckBoxes_Click(object sender, RoutedEventArgs e)
        {
            new CheckBoxesDemo().Show();
        }

        private void ComboBox_Click(object sender, RoutedEventArgs e)
        {
            new ComboBoxDemo().Show();
        }

        private void ScrollViewer_Click(object sender, RoutedEventArgs e)
        {
            new GlassScrollViewerDemo().Show();
        }

        private void DialogWindow_Click(object sender, RoutedEventArgs e)
        {
            new DialogWindowDemo().Show();
        }

        private void TextBoxes_Click(object sender, RoutedEventArgs e)
        {
            new TextBoxesDemo().Show();
        }

        private void FlatMenu_Click(object sender, RoutedEventArgs e)
        {
            new FlatMenuDemo().Show();
        }

        private void Info_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Info().ShowDialog();
        }
    }
}
