using FullControls.SystemControls;
using System.Windows;
using System.Windows.Input;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per Home.xaml
    /// </summary>
    public partial class Home : AvalonWindow
    {
        public Home()
        {
            InitializeComponent();
        }

        private void GG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Lab() { Owner = this }.Show();
        }

        private void Info_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Info() { Owner = this }.ShowDialog();
        }

        private void Accordion_Click(object sender, RoutedEventArgs e)
        {
            new AccordionDemo() { Owner = this }.Show();
        }

        private void Collapsible_Click(object sender, RoutedEventArgs e)
        {
            new CollapsibleDemo() { Owner = this }.Show();
        }

        private void Buttons_Click(object sender, RoutedEventArgs e)
        {
            new ButtonsDemo() { Owner = this }.Show();
        }

        private void Switcher_Click(object sender, RoutedEventArgs e)
        {
            new SwitcherDemo() { Owner = this }.Show();
        }

        private void CheckBoxes_Click(object sender, RoutedEventArgs e)
        {
            new CheckBoxesDemo() { Owner = this }.Show();
        }

        private void ComboBox_Click(object sender, RoutedEventArgs e)
        {
            new ComboBoxDemo() { Owner = this }.Show();
        }

        private void ScrollViewer_Click(object sender, RoutedEventArgs e)
        {
            new GlassScrollViewerDemo() { Owner = this }.Show();
        }

        private void DialogWindow_Click(object sender, RoutedEventArgs e)
        {
            new DialogWindowDemo() { Owner = this }.Show();
        }

        private void TextBoxes_Click(object sender, RoutedEventArgs e)
        {
            new TextBoxesDemo() { Owner = this }.Show();
        }

        private void FlatMenu_Click(object sender, RoutedEventArgs e)
        {
            new FlatMenuDemo() { Owner = this }.Show();
        }

        private void BorderedGrid_Click(object sender, RoutedEventArgs e)
        {
            new BorderedGridDemo() { Owner = this }.Show();
        }

        private void Kaleidoborder_Click(object sender, RoutedEventArgs e)
        {
            new KaleidoborderDemo() { Owner = this }.Show();
        }
    }
}
