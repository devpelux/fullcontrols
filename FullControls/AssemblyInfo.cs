using System.Windows;
using System.Windows.Markup;

[assembly: XmlnsPrefix("http://devpelux.github.io/fullcontrols", "fc")]
[assembly: XmlnsPrefix("http://devpelux.github.io/fullcontrols/extra", "fce")]
[assembly: XmlnsDefinition("http://devpelux.github.io/fullcontrols", "FullControls")]
[assembly: XmlnsDefinition("http://devpelux.github.io/fullcontrols/extra", "FullControls.Extra")]

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]
