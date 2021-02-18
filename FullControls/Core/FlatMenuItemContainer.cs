using System.Windows;
using System.Windows.Controls;

namespace FullControls.Core
{
    /// <summary>
    /// Used to contain <see cref="FlatMenuItem"/>.
    /// </summary>
    internal class FlatMenuItemContainer : MenuItem
    {
        static FlatMenuItemContainer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuItemContainer), new FrameworkPropertyMetadata(typeof(FlatMenuItemContainer)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FlatMenuItemContainer"/>.
        /// </summary>
        internal FlatMenuItemContainer() : base() { }

        /// <summary>
        /// Prepares the container indicating if align the content with other items.
        /// </summary>
        /// <param name="alignLeft">Specifies if align with sections left to the header.</param>
        /// <param name="alignRight">Specifies if align with sections right to the header.</param>
        internal void PrepareContainer(bool alignLeft, bool alignRight)
        {
            if (alignLeft && alignRight)
            {
                Template = AlignLeftRightTemplate();
            }
            else if (alignLeft && !alignRight)
            {
                Template = AlignLeftTemplate();
            }
            else if (!alignLeft && alignRight)
            {
                Template = AlignRightTemplate();
            }
            else
            {
                Template = NoAlignTemplate();
            }
        }

        private ControlTemplate AlignLeftRightTemplate()
        {
            /*
             *  <ControlTemplate TargetType="{x:Type local:FlatMenuItemContainer}">
             *      <Grid>
             *          <Grid.ColumnDefinitions>
             *              <ColumnDefinition Width="Auto" SharedSizeGroup="MenuItemColumnGroupIcon"/>
             *              <ColumnDefinition Width="*"/> <!-- Main column -->
             *              <ColumnDefinition Width="Auto" SharedSizeGroup="MenuItemColumnGroupShortcut"/>
             *              <ColumnDefinition Width="Auto" SharedSizeGroup="MenuItemColumnGroupArrow"/>
             *          </Grid.ColumnDefinitions>
             *
             *          <ContentPresenter x:Name="HeaderHost" Grid.Column="1" ContentSource="Header"/>
             *      </Grid>
             *  </ControlTemplate>
             */

            ControlTemplate template = new ControlTemplate(typeof(FlatMenuItemContainer));

            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

            FrameworkElementFactory column0 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column0.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            column0.SetValue(DefinitionBase.SharedSizeGroupProperty, "MenuItemColumnGroupIcon");

            FrameworkElementFactory column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));

            FrameworkElementFactory column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            column2.SetValue(DefinitionBase.SharedSizeGroupProperty, "MenuItemColumnGroupShortcut");

            FrameworkElementFactory column3 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column3.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            column3.SetValue(DefinitionBase.SharedSizeGroupProperty, "MenuItemColumnGroupArrow");

            FrameworkElementFactory headerHost = new FrameworkElementFactory(typeof(ContentPresenter));
            headerHost.Name = "HeaderHost";
            headerHost.SetValue(ContentPresenter.ContentSourceProperty, "Header");
            headerHost.SetValue(Grid.ColumnProperty, 1);

            grid.AppendChild(column0);
            grid.AppendChild(column1);
            grid.AppendChild(column2);
            grid.AppendChild(column3);
            grid.AppendChild(headerHost);

            template.VisualTree = grid;

            return template;
        }

        private ControlTemplate AlignLeftTemplate()
        {
            /*
             *  <ControlTemplate TargetType="{x:Type local:FlatMenuItemContainer}">
             *      <Grid>
             *          <Grid.ColumnDefinitions>
             *              <ColumnDefinition Width="Auto" SharedSizeGroup="MenuItemColumnGroupIcon"/>
             *              <ColumnDefinition Width="*"/> <!-- Main column -->
             *          </Grid.ColumnDefinitions>
             *
             *          <ContentPresenter x:Name="HeaderHost" Grid.Column="1" ContentSource="Header"/>
             *      </Grid>
             *  </ControlTemplate>
             */

            ControlTemplate template = new ControlTemplate(typeof(FlatMenuItemContainer));

            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

            FrameworkElementFactory column0 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column0.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            column0.SetValue(DefinitionBase.SharedSizeGroupProperty, "MenuItemColumnGroupIcon");

            FrameworkElementFactory column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));

            FrameworkElementFactory headerHost = new FrameworkElementFactory(typeof(ContentPresenter));
            headerHost.Name = "HeaderHost";
            headerHost.SetValue(ContentPresenter.ContentSourceProperty, "Header");
            headerHost.SetValue(Grid.ColumnProperty, 1);

            grid.AppendChild(column0);
            grid.AppendChild(column1);
            grid.AppendChild(headerHost);

            template.VisualTree = grid;

            return template;
        }

        private ControlTemplate AlignRightTemplate()
        {
            /*
             *  <ControlTemplate TargetType="{x:Type local:FlatMenuItemContainer}">
             *      <Grid>
             *          <Grid.ColumnDefinitions>
             *              <ColumnDefinition Width="*"/> <!-- Main column -->
             *              <ColumnDefinition Width="Auto" SharedSizeGroup="MenuItemColumnGroupShortcut"/>
             *              <ColumnDefinition Width="Auto" SharedSizeGroup="MenuItemColumnGroupArrow"/>
             *          </Grid.ColumnDefinitions>
             *
             *          <ContentPresenter x:Name="HeaderHost" Grid.Column="0" ContentSource="Header"/>
             *      </Grid>
             *  </ControlTemplate>
             */

            ControlTemplate template = new ControlTemplate(typeof(FlatMenuItemContainer));

            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

            FrameworkElementFactory column0 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column0.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));

            FrameworkElementFactory column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            column1.SetValue(DefinitionBase.SharedSizeGroupProperty, "MenuItemColumnGroupShortcut");

            FrameworkElementFactory column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            column2.SetValue(DefinitionBase.SharedSizeGroupProperty, "MenuItemColumnGroupArrow");

            FrameworkElementFactory headerHost = new FrameworkElementFactory(typeof(ContentPresenter));
            headerHost.Name = "HeaderHost";
            headerHost.SetValue(ContentPresenter.ContentSourceProperty, "Header");
            headerHost.SetValue(Grid.ColumnProperty, 0);

            grid.AppendChild(column0);
            grid.AppendChild(column1);
            grid.AppendChild(column2);
            grid.AppendChild(headerHost);

            template.VisualTree = grid;

            return template;
        }

        private ControlTemplate NoAlignTemplate()
        {
            /*
             *  <ControlTemplate TargetType="{x:Type local:FlatMenuItemContainer}">
             *      <Grid>
             *          <ContentPresenter x:Name="HeaderHost" ContentSource="Header"/>
             *      </Grid>
             *  </ControlTemplate>
             */

            ControlTemplate template = new ControlTemplate(typeof(FlatMenuItemContainer));

            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

            FrameworkElementFactory headerHost = new FrameworkElementFactory(typeof(ContentPresenter));
            headerHost.Name = "HeaderHost";
            headerHost.SetValue(ContentPresenter.ContentSourceProperty, "Header");

            grid.AppendChild(headerHost);

            template.VisualTree = grid;

            return template;
        }
    }
}
