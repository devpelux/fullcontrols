<!-- icon -->

<p align="center">
  <a href="https://github.com/devpelux/fullcontrols" title="FullControls">
    <img width="90px" align="center" alt="FullControls" src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.0.0-rc.1/Assets/FullControlsSimple.svg"></img>
  </a>
</p>
<h2 align="center">FullControls</h2>
<p align="center">Reworked version of the most commonly used controls, plus some new special controls and extra functionality.</p>

<!-- badges -->

<p align="center">
  <a href="https://github.com/devpelux/fullcontrols/releases/latest" title="Latest release on GitHub">
    <img alt="Latest release" src="https://img.shields.io/github/v/release/devpelux/fullcontrols?sort=semver"></img>
  </a>
  <a href="https://www.nuget.org/packages/FullControls" title="FullControls on NuGet">
    <img alt="Nuget release" src="https://img.shields.io/nuget/v/fullcontrols"></img>
  </a>
  <a href="https://github.com/devpelux/fullcontrols/releases/latest" title="Latest release on GitHub">
    <img alt="GitHub release date" src="https://img.shields.io/github/release-date/devpelux/fullcontrols"></img>
  </a>
  <a href="https://www.nuget.org/packages/FullControls" title="FullControls on NuGet">
    <img alt="Nuget downloads" src="https://img.shields.io/nuget/dt/fullcontrols"></img>
  </a>
  <a href="https://github.com/devpelux/fullcontrols/blob/2.0.0-rc.1/LICENSE" title="Licensed under MIT license">
    <img alt="License" src="https://img.shields.io/github/license/devpelux/fullcontrols"></img>
  </a>
</p>
<p align="center">
  <img alt="Code release" src="https://img.shields.io/badge/code:release-v2.0.0--rc.1-yellowgreen"></img>
  <img alt="Code status" src="https://img.shields.io/badge/code:status-rc-yellowgreen"></img>
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
[<img alt=".NET 5" src="https://img.shields.io/badge/.NET-v6.0-blue"/>][net6]
<br><br>

# Overview

Here is an overview of all the features of the package.


## Controls

### Collapsible
Adds collapsing and expanding functionality to another element.  
For example you can specify a Grid as collapsible Child, so the content of this Grid can be expanded or collapsed.  
The collapsible works with Width and Height, so expanding means *"go from zero to full size"*, and collapsing means *"go from full size to zero"*.  
Is possible to collapse only width, only height, or both.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/collapsible.gif"/>

---

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

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/accordion.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/accordion_dark.png"/>

---

### BorderedGrid ![New](https://img.shields.io/badge/-NEW!-blue)
Similar to the normal Grid, but this draws a grid with bordered cells.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/borderedgrid.png"/>

---

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

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/flatcontextmenu.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/flatcontextmenu_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/flatcontextmenu_check.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/flatcontextmenu_check_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/flatcontextmenu_radiocheck.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/flatcontextmenu_radiocheck_dark.png"/>

---

### ButtonPlus
Extended version of the classic button with more customizations.

### RepeatButtonPlus
Extended version of the classic repeat button with more customizations.

### ToggleButtonPlus
Extended version of the classic toggle button with more customizations and features.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/buttonsplus.png"/> <br> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/buttonsplus_dark.png"/>

---

### Switcher
Button with the behaviour of a radio button.  
It can be used, for example, to switch between different section of an application.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/switcher.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/switcher_dark.png"/> <br>

With multiple switchers you can easily do a navigation drawer menu.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/switcher_navigation_drawer.png"/>

---

### CheckBoxPlus
Extended version of the classic checkbox with more customizations.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/checkboxplus.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/checkboxplus_dark.png"/>

---

### RadioButtonPlus
Extended version of the classic radiobutton with more customizations.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/radiobuttonplus.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/radiobuttonplus_dark.png"/>

---

### ComboBoxPlus
Extended version of the classic combobox with more customizations and features.

### ComboBoxItemPlus
Extended version of the classic combobox item with more customizations and features.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/comboboxplus.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/comboboxplus_dark.png"/>

---

### PasswordBoxPlus
Extended version of the standard password box with more features and customizations.  
Is possible to add a label (or icon) and display an hint, add a button to show the password when pressed and copy the password.  
It maintains the same security of the original password box.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/passwordboxplus.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/passwordboxplus_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/passwordboxplus_hinted.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/passwordboxplus_hinted_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/passwordboxplus_labeled.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/passwordboxplus_labeled_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/passwordboxplus_peeked.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/passwordboxplus_peeked_dark.png"/>

---

### TextBoxPlus
Extended version of the standard text box with more features and customizations.  
Is possible to add a label (or icon) and display an hint, add a button to copy the text, choose if the textbox can contain only number, doubles…

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_hinted.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_hinted_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_labeled.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_labeled_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_types.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_types_dark.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_flatcontextmenu.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/textboxplus_flatcontextmenu_dark.png"/>

---

### GlassScrollBar
Reworked version of the classic scrollbar adapted to be semi-transparent and colored.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/vertical_glassscrollbar.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/horizontal_glassscrollbar.png"/>

---

### GlassScrollViewer
This is a scroll viewer that uses the GlassScrollBars and with some new functionality, as draw the scrollbars inside the scroll viewer.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/glassscrollviewer.png"/>

---

## System components

### DialogWindow
Incapsulates a Window to be displayed as dialog and, in the end, return an object as result.  
It can be used to create custom messageboxes.

---

### WindowTitleBar
A fully customizable titlebar used in custom windows.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/titlebar.png"/> <br>
<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/titlebar_close_hovered.png"/>

---

### AvalonWindow
Extended version of the classic window with possibility to customize the titlebar, fuse the titlebar with the content of the window, better handling of close, minimize, etc...

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/avalonwindow.png"/>

### FlexWindow
Extended version of the classic window with the same features of AvalonWindow, but with support for round angles and custom shadow. (This window can only be minimized, is not resizable or maximizable)

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/flexwindow.png"/>

### FullWindow
Extended version of the classic window with the same features of FlexWindow but resizable. (This uses `AllowsTransparency=True`)

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/1.5.1/Assets/Overview/fullwindow.png"/>

### Why 3 window types instead of one (FullWindow)?
**FullWindow** requires `AllowsTransparency` set to `True` to be fully customizable, and using `AllowsTransparency` may drastically reduce the performances of the window.  
In most cases, if you don't need to resize the window, or if you don't need round angles, you can use **FlexWindow** or **AvalonWindow** respectively, that achieve the same goals without using `AllowsTransparency`.



<br><br>
### License
Copyright (C) 2020-2021 devpelux (Salvatore Peluso)  
Licensed under MIT license.   

[![mit](https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/MIT_logo.svg/64px-MIT_logo.svg.png)][license]



[wiki]: https://github.com/devpelux/fullcontrols/wiki "Documentation"
[license]: https://github.com/devpelux/fullcontrols/blob/2.0.0-rc.1/LICENSE "Licensed under MIT license"
[net5]: https://docs.microsoft.com/dotnet ".NET 5"
[net6]: https://docs.microsoft.com/dotnet ".NET 6"
