using FullControls.SystemComponents;
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

        private void CollapsibleDemo_Click(object sender, RoutedEventArgs e)
        {
            new CollapsibleDemo().Show();
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

        private void FlatMenuDemo_Click(object sender, RoutedEventArgs e)
        {
            new FlatMenuDemo().Show();
        }

        private void Info_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new Info().ShowDialog();
        }
    }
}
