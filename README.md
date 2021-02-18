<!-- icon -->

<p align="center">
  <a href="https://github.com/devpelux/fullcontrols/tree/main" title="Main branch">
    <img width="90px" align="center" alt="FullControls" src="https://raw.githubusercontent.com/devpelux/fullcontrols/main/Assets/FullControlsSimple.svg"></img>
  </a>
</p>
<h2 align="center">FullControls</h2>
<p align="center">Set of fully customizable standard controls, plus new special controls and extra functionality.</p>

<!-- badges -->

<p align="center">
  <a href="https://github.com/devpelux/fullcontrols/releases/latest" title="Latest release on GitHub">
    <img alt="Latest Release" src="https://img.shields.io/github/v/release/devpelux/fullcontrols?sort=semver"></img>
  </a>
  <a href="https://www.nuget.org/packages/FullControls" title="FullControls on NuGet">
    <img alt="Nuget Release" src="https://img.shields.io/nuget/v/fullcontrols"></img>
  </a>
  <a href="https://github.com/devpelux/fullcontrols/wiki" title="Documentation">
    <img alt="Documentation Release" src="https://img.shields.io/badge/doc:release-v1.2.4-blue"></img>
  </a>
  <a href="https://github.com/devpelux/fullcontrols/releases/latest" title="Latest release on GitHub">
    <img alt="GitHub Release Date" src="https://img.shields.io/github/release-date/devpelux/fullcontrols"></img>
  </a>
  <a href="https://www.nuget.org/packages/FullControls" title="FullControls on NuGet">
    <img alt="Nuget Downloads" src="https://img.shields.io/nuget/dt/fullcontrols"></img>
  </a>
  <a href="https://github.com/devpelux/fullcontrols/blob/main/LICENSE" title="Licensed under MIT license">
    <img alt="License" src="https://img.shields.io/github/license/devpelux/fullcontrols"></img>
  </a>
</p>
<p align="center">
  <a href="https://github.com/devpelux/fullcontrols/tree/main" title="Main branch">
    <img alt="Main-branch Release" src="https://img.shields.io/badge/main:release-v1.3.0-orange"></img>
  </a>
  <a href="https://github.com/devpelux/fullcontrols/tree/main" title="Main branch">
    <img alt="Main-branch Status" src="https://img.shields.io/badge/main:status-beta-orange"></img>
  </a>
</p>

<!-- description -->

## Full documentation

Repository wiki: [https://github.com/devpelux/fullcontrols/wiki][wiki]


## Get this package from NuGet

<table align="left">
  <tr>
    <td align="center">
      <a href="https://www.nuget.org/packages/FullControls" title="FullControls on NuGet">
        <img height="48px" alt="FullControls on NuGet" src="https://upload.wikimedia.org/wikipedia/commons/2/25/NuGet_project_logo.svg"></img>
      </a>
    </td>
    <td align="center">
      <a href="https://www.nuget.org/packages/FullControls" title="FullControls on NuGet">
        <b>FullControls</b>
      </a>
    </td>
  </tr>
</table>
<br><br><br>


## Dependencies

[<img alt=".NET 5" src="https://img.shields.io/badge/.NET-v5.0-blue"/>][net5]
<br><br>

# Overview

Here is an overview of all the features of the package.


## Controls

### Collapsible
Adds collapsing and expanding functionality to another element.
For example you can specify a Grid as collapsible Child, so the content of this Grid can be expanded or collapsed.
The collapsible works with Width and Height, so expanding means *"go from zero to full size"*, and collapsing means *"go from full size to zero"*.

### Accordion
Is a control that contains a stacked list of items.
Each item can be expanded or collapsed to reveal the content associated with that item.

### SimpleAccordionItem
This is a control that can be used within an Accordion.
It can contain everything on its Content property.
It has an header and contains a Collapsible, to make the content collapsible by clicking the header.

### ItemsControlAccordionItem
This is a control that can be used within an Accordion.
It works as an items control, so can be used to display multiple items inside.
It has an header and contains a Collapsible, to make the content collapsible by clicking the header.

### FlatContextMenu
Reworked version of the classic ContextMenu with more customizations.
For example you can change the color of the shadow or display a scroll viewer if needed.
However, it was created primarily for handling some inherited properties of FlatMenuItem.

### FlatMenu
This control was created only for handling some inherited properties of FlatMenuItem.

### FlatMenuItem
Extended version of the MenuItem with more features and customizations.
It contains also a "radio-checking" feature to make checkable items mutually exclusive.

### FlatMenuSeparator
Reworked version of the Separator with more customizations.

### FlatMenuSpace
This is a blank menu item: is made to add a blank space (without any separator line) between the items.

### FlatMenuTitle
This is an unclickable menu item that works only as SubmenuItem, it can be used to add an item that works as a title for a group of items.

### EButton
Extended version of the classic button with more customizations.

### ECheckBox
Extended version of the classic checkbox with more customizations.

### EComboBox
Extended version of the classic combobox with more customizations and features.

### EComboBoxItem
Extended version of the classic combobox item with more customizations and features.

### EPasswordBox
Reworked version of the standard password box with more features and customizations.
Is possible to add a label (or icon) and display an hint, add a button to show the password when pressed and copy the password.  
It maintains the same security of the original password box.

### ERadioButton
Extended version of the classic radiobutton with more customizations.

### ERepeatButton
Extended version of the classic repeat button with more customizations.

### ETextBox
Reworked version of the standard text box with more features and customizations.
Is possible to add a label (or icon) and display an hint, add a button to copy the text, choose if the textbox can contain only number, doubles…

### EToggleButton
Extended version of the classic toggle button with more customizations and features.

### GlassScrollBar
Reworked version of the classic scrollbar adapted to be semi-transparent and colored.

### GlassScrollViewer
This is a scroll viewer that uses the GlassScrollBars and with some new functionality, as draw the scrollbars inside the scroll viewer.

### Switcher
Button with the behaviour of a radio button.  
It can be used, for example, to switch between different section of an application.


## Special

### EWindow
Reworked version of the classic window with possibility to customize the titlebar, fuse the titlebar with the content of the window, add corner radius to the window, better handling of close, minimize, etc...

### DialogWindow
Incapsulates a Window to be displayed as dialog and, in the end, return an object as result.  
It can be used to create custom messageboxes.



<br><br>
### License
Copyright (C) 2020-2021 devpelux (Salvatore Peluso)  
Licensed under MIT license.   

[![mit](https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/MIT_logo.svg/64px-MIT_logo.svg.png)][license]





[wiki]: https://github.com/devpelux/fullcontrols/wiki "Documentation"
[license]: https://github.com/devpelux/fullcontrols/blob/main/LICENSE "Licensed under MIT license"
[net5]: https://docs.microsoft.com/dotnet/core/dotnet-five ".NET 5"
