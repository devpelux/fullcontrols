using FullControls;
using System;
using System.Collections.Generic;
using System.Linq;
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
        AccordionItemCollection accordionDarkItems = new();

        public AccordionDemo()
        {
            InitializeComponent();
            LoadAccordionDemoItems();
        }

        private void LoadAccordionDemoItems()
        {
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
            LoadAccordionItems();
            LoadAccordionDarkItems();
        }

        private void LoadAccordionItems()
        {
            ItemsControlAccordionItem accordionItem = new ItemsControlAccordionItem();
            accordionItem.ItemTemplate = (DataTemplate)FindResource("AccordionDemoItemTemplate");
            accordionItem.ItemsSource = Clone(accordionDemoItems);
            accordionItem.Header = "SHAPES";
            accordionItem.IsExpanded = false;

            ItemsControlAccordionItem accordionItem2 = new ItemsControlAccordionItem();
            accordionItem2.ItemTemplate = (DataTemplate)FindResource("AccordionDemoItemTemplate");
            accordionItem2.ItemsSource = Clone(accordionDemoItems2);
            accordionItem2.Header = "CIRCULAR SHAPES";
            accordionItem2.IsExpanded = false;

            accordionItems.Add(accordionItem);
            accordionItems.Add(accordionItem2);

            accordion.Items = accordionItems;
        }

        private void LoadAccordionDarkItems()
        {
            ItemsControlAccordionItem accordionDarkItem = new ItemsControlAccordionItem();
            accordionDarkItem.Style = (Style)FindResource("ItemsControlAccordionItemDark");
            accordionDarkItem.ItemTemplate = (DataTemplate)FindResource("AccordionDemoItemTemplateDark");
            accordionDarkItem.ItemsSource = Clone(accordionDemoItems);
            accordionDarkItem.Header = "SHAPES";
            accordionDarkItem.IsExpanded = false;

            ItemsControlAccordionItem accordionDarkItem2 = new ItemsControlAccordionItem();
            accordionDarkItem2.Style = (Style)FindResource("ItemsControlAccordionItemDark");
            accordionDarkItem2.ItemTemplate = (DataTemplate)FindResource("AccordionDemoItemTemplateDark");
            accordionDarkItem2.ItemsSource = Clone(accordionDemoItems2);
            accordionDarkItem2.Header = "CIRCULAR SHAPES";
            accordionDarkItem2.IsExpanded = false;

            accordionDarkItems.Add(accordionDarkItem);
            accordionDarkItems.Add(accordionDarkItem2);

            accordionDark.Items = accordionDarkItems;
        }

        private List<AccordionDemoItem> Clone(List<AccordionDemoItem> listToClone)
            => listToClone.Select(item => (AccordionDemoItem)item.Clone()).ToList();

        private class AccordionDemoItem : ICloneable
        {
            public string Name { get; set; }
            public string Details { get; set; }

            public AccordionDemoItem(string name, string details)
            {
                Name = name;
                Details = details;
            }

            public object Clone() => MemberwiseClone();
        }
    }
}
