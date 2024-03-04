using FullControls.Common;
using FullControls.Controls;
using FullControls.SystemControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per AccordionDemo.xaml
    /// </summary>
    public partial class AccordionDemo : AvalonWindow
    {
        private readonly List<Shape> shapes = new();
        private readonly List<Shape> roundShapes = new();
        private readonly IndexedObservableCollection<AccordionItem> accordionItems = new();
        private readonly IndexedObservableCollection<AccordionItem> accordionDarkItems = new();

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
            ItemsControlAccordionItem accordionItem = new()
            {
                ItemTemplate = (DataTemplate)FindResource("ShapeItemTemplate"),
                ItemsSource = Clone(shapes),
                Header = "SHAPES",
                IsExpanded = true
            };

            ItemsControlAccordionItem accordionItem2 = new()
            {
                ItemTemplate = (DataTemplate)FindResource("ShapeItemTemplate"),
                ItemsSource = Clone(roundShapes),
                Header = "CIRCULAR SHAPES",
                IsExpanded = true
            };

            accordion.Items.Add(accordionItem);
            accordion.Items.Add(accordionItem2);
        }

        private void LoadAccordionDarkItems()
        {
            ItemsControlAccordionItem accordionDarkItem = new()
            {
                Style = (Style)FindResource("DarkItemsControlAccordionItem"),
                ItemTemplate = (DataTemplate)FindResource("DarkShapeItemTemplate"),
                ItemsSource = Clone(shapes),
                Header = "SHAPES",
                IsExpanded = false
            };

            ItemsControlAccordionItem accordionDarkItem2 = new()
            {
                Style = (Style)FindResource("DarkItemsControlAccordionItem"),
                ItemTemplate = (DataTemplate)FindResource("DarkShapeItemTemplate"),
                ItemsSource = Clone(roundShapes),
                Header = "CIRCULAR SHAPES",
                IsExpanded = false
            };

            accordionDark.Items.Add(accordionDarkItem);
            accordionDark.Items.Add(accordionDarkItem2);
        }

        private static List<Shape> Clone(List<Shape> listToClone)
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
