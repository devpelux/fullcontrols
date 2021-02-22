using System.Windows;
using System.Windows.Markup;

//Namespaces prefix
[assembly: XmlnsPrefix("http://devpelux.github.io/fullcontrols", "fc")]
[assembly: XmlnsPrefix("http://devpelux.github.io/fullcontrols/components", "fcc")]
[assembly: XmlnsPrefix("http://devpelux.github.io/fullcontrols/extra", "fce")]

//Namespaces
[assembly: XmlnsDefinition("http://devpelux.github.io/fullcontrols", "FullControls.Common")]
[assembly: XmlnsDefinition("http://devpelux.github.io/fullcontrols", "FullControls.Controls")]
[assembly: XmlnsDefinition("http://devpelux.github.io/fullcontrols", "FullControls.SystemControls")]
[assembly: XmlnsDefinition("http://devpelux.github.io/fullcontrols/components", "FullControls.Components")]
[assembly: XmlnsDefinition("http://devpelux.github.io/fullcontrols/extra", "FullControls.Extra")]

//Theme
[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]
