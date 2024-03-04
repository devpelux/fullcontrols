using FullControls.Attributes;
using FullControls.Controls;
using FullControls.SystemControls;
using FullControls.Utils;
using RawTimeCore;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace FullControlsDemo
{
    /// <summary>
    /// Logica di interazione per Lab.xaml
    /// </summary>
    public partial class Lab : AvalonWindow
    {
        public Lab()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Table table = TT;

            List<LabClass> classes = new List<LabClass>();
            classes.Add(new LabClass());
            classes.Add(new LabClass());
            classes.Add(new LabClass());
            classes.Add(new LabClass());

            table.ItemsSource = classes;
        }

        public class LabClass
        {
            [TableColumn("a")]
            public string Prop1 { get; } = "AAA";

            [TableColumn("b")]
            public string Prop2 { get; } = "BBB";

            [TableColumn("c")]
            public string Prop3 { get; } = "CCC";

            [TableColumn("d")]
            public string Prop4 { get; } = "DDD";
        }
    }
}
