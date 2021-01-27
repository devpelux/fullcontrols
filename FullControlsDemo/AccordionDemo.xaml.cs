using FullControls;
using System.Collections.Generic;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per AccordionDemo.xaml
    /// </summary>
    public partial class AccordionDemo : EWindow
    {
        List<AccordionDemoItem> accordionDemoItems = new();
        List<AccordionDemoItem> accordionDemoItems2 = new();
        AccordionItemCollection accordionItems = new();

        public AccordionDemo()
        {
            InitializeComponent();

            accordionDemoItems.Add(new AccordionDemoItem("Triangle", "Angles : 3"));
            accordionDemoItems.Add(new AccordionDemoItem("Rectangle", "Angles : 4"));
            accordionDemoItems.Add(new AccordionDemoItem("Square", "Angles : 4"));
            accordionDemoItems.Add(new AccordionDemoItem("Pentagon", "Angles : 5"));
            accordionDemoItems.Add(new AccordionDemoItem("Esagon", "Angles : 6"));

            accordionDemoItems2.Add(new AccordionDemoItem("Ellipse", "Angles : 0"));
            accordionDemoItems2.Add(new AccordionDemoItem("Circle", "Angles : 0"));
        }

        private void EWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ItemsControlAccordionItem accordionItem = new ItemsControlAccordionItem();
            accordionItem.ItemTemplate = (DataTemplate)FindResource("AccordionDemoItemTemplate");
            accordionItem.ItemsSource = accordionDemoItems;
            accordionItem.Header = "SHAPES";
            accordionItem.IsExpanded = false;

            ItemsControlAccordionItem accordionItem2 = new ItemsControlAccordionItem();
            accordionItem2.ItemTemplate = (DataTemplate)FindResource("AccordionDemoItemTemplate");
            accordionItem2.ItemsSource = accordionDemoItems2;
            accordionItem2.Header = "CIRCULAR SHAPES";
            accordionItem2.IsExpanded = false;

            accordionItems.Add(accordionItem);
            accordionItems.Add(accordionItem2);

            accordion.Items = accordionItems;
        }


        public class AccordionDemoItem
        {
            public string Name { get; set; }
            public string Details { get; set; }

            public AccordionDemoItem(string name, string details)
            {
                Name = name;
                Details = details;
            }
        }
    }
}
