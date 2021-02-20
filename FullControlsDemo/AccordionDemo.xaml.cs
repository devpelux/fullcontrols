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
        List<Shape> shapes = new();
        List<Shape> roundShapes = new();

        AccordionItemCollection accordionItems = new();
        AccordionItemCollection accordionDarkItems = new();

        public AccordionDemo()
        {
            InitializeComponent();
            LoadShapes();
        }

        private void LoadShapes()
        {
            shapes.Add(new Shape("Triangle", "Angles : 3"));
            shapes.Add(new Shape("Rectangle", "Angles : 4"));
            shapes.Add(new Shape("Square", "Angles : 4"));
            shapes.Add(new Shape("Pentagon", "Angles : 5"));
            shapes.Add(new Shape("Esagon", "Angles : 6"));

            roundShapes.Add(new Shape("Ellipse", "Angles : 0"));
            roundShapes.Add(new Shape("Circle", "Angles : 0"));
        }

        private void EWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAccordionItems();
            LoadAccordionDarkItems();
        }

        private void LoadAccordionItems()
        {
            ItemsControlAccordionItem accordionItem = new ItemsControlAccordionItem();
            accordionItem.ItemTemplate = (DataTemplate)FindResource("ShapeItemTemplate");
            accordionItem.ItemsSource = Clone(shapes);
            accordionItem.Header = "SHAPES";
            accordionItem.IsExpanded = true;

            ItemsControlAccordionItem accordionItem2 = new ItemsControlAccordionItem();
            accordionItem2.ItemTemplate = (DataTemplate)FindResource("ShapeItemTemplate");
            accordionItem2.ItemsSource = Clone(roundShapes);
            accordionItem2.Header = "CIRCULAR SHAPES";
            accordionItem2.IsExpanded = true;

            accordionItems.Add(accordionItem);
            accordionItems.Add(accordionItem2);

            accordion.Items = accordionItems;
        }

        private void LoadAccordionDarkItems()
        {
            ItemsControlAccordionItem accordionDarkItem = new ItemsControlAccordionItem();
            accordionDarkItem.Style = (Style)FindResource("ItemsControlAccordionItemDark");
            accordionDarkItem.ItemTemplate = (DataTemplate)FindResource("ShapeItemTemplateDark");
            accordionDarkItem.ItemsSource = Clone(shapes);
            accordionDarkItem.Header = "SHAPES";
            accordionDarkItem.IsExpanded = false;

            ItemsControlAccordionItem accordionDarkItem2 = new ItemsControlAccordionItem();
            accordionDarkItem2.Style = (Style)FindResource("ItemsControlAccordionItemDark");
            accordionDarkItem2.ItemTemplate = (DataTemplate)FindResource("ShapeItemTemplateDark");
            accordionDarkItem2.ItemsSource = Clone(roundShapes);
            accordionDarkItem2.Header = "CIRCULAR SHAPES";
            accordionDarkItem2.IsExpanded = false;

            accordionDarkItems.Add(accordionDarkItem);
            accordionDarkItems.Add(accordionDarkItem2);

            accordionDark.Items = accordionDarkItems;
        }

        private List<Shape> Clone(List<Shape> listToClone)
            => listToClone.Select(item => (Shape)item.Clone()).ToList();

        private class Shape : ICloneable
        {
            public string Name { get; set; }
            public string Details { get; set; }

            public Shape(string name, string details)
            {
                Name = name;
                Details = details;
            }

            public object Clone() => MemberwiseClone();
        }
    }
}
