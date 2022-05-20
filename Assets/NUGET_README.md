![icon](https://raw.githubusercontent.com/devpelux/fullcontrols/2.0.2/Assets/IconSimple.png)


# FullControls
Reworked version of the wpf controls, plus new controls and features.

![release](https://img.shields.io/github/v/release/devpelux/fullcontrols?sort=semver)
![snapshot](https://img.shields.io/github/v/release/devpelux/fullcontrols?include_prereleases&label=snapshot&sort=semver)
![nuget](https://img.shields.io/nuget/v/fullcontrols)
![release_date](https://img.shields.io/github/release-date/devpelux/fullcontrols)
![downloads](https://img.shields.io/nuget/dt/fullcontrols)
![license](https://img.shields.io/github/license/devpelux/fullcontrols)


# Dependencies
[![net5](https://img.shields.io/badge/.NET-v5.0-blue)](https://docs.microsoft.com/dotnet)
[![net6](https://img.shields.io/badge/.NET-v6.0-blue)](https://docs.microsoft.com/dotnet)
[![wpfcoretools](https://img.shields.io/badge/WpfCoreTools-v1.5.0-blue)](https://www.nuget.org/packages/WpfCoreTools)


# Full documentation
The full documentation is available in the [repository wiki](https://github.com/devpelux/fullcontrols/wiki).


# Content
Content of the package:


## Controls
Wpf user interface controls:

### Accordion
Is a control that contains a stacked list of items.  
Each item can be expanded or collapsed to reveal the content associated with that item.

### ItemsControlAccordionItem
This is a control that can be used within an Accordion.  
It works as an items control, so can be used to display multiple items inside.  
It has an header and contains a Collapsible, to make the content collapsible by clicking the header.

### SimpleAccordionItem
This is a control that can be used within an Accordion.  
It can contain everything on its Content property.  
It has an header and contains a Collapsible, to make the content collapsible by clicking the header.

---

### BorderedGrid
Similar to the normal Grid, but this draws a grid with bordered cells.

---

### ButtonPlus
Extended version of the classic button with more customizations.

### RepeatButtonPlus
Extended version of the classic repeat button with more customizations.

### Switcher
Button with the behaviour of a radio button.  
If two switchers are in the same group, only one can be checked.

### ToggleButtonPlus
Extended version of the classic toggle button with more customizations and features.

---

### CheckBoxPlus
Extended version of the classic checkbox with more customizations.

### RadioButtonPlus
Extended version of the classic radiobutton with more customizations.

---

### Collapsible
Adds collapsing and expanding functionality to another element.  
For example you can specify a Grid as collapsible Child, so the content of this Grid can be expanded or collapsed.  
The collapsible works with Width and Height, so expanding means *"go from zero to full size"*, and collapsing means *"go from full size to zero"*.  
Is possible to collapse only width, only height, or both.

---

### ComboBoxPlus
Extended version of the classic combobox with more customizations and features.

### ComboBoxItemPlus
Extended version of the classic combobox item with more customizations and features.

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

---

### GlassScrollBar
Reworked version of the classic scrollbar adapted to be semi-transparent and colored.

### GlassScrollViewer
This is a scroll viewer that uses the GlassScrollBars and with some new functionality, as draw the scrollbars inside the scroll viewer.

---

### Kaleidoborder
Draws a multicolored border with a background around another element.  
This is similar to the standard border, but allows multicolored borders.

---

### PasswordBoxPlus
Extended version of the standard password box with more features and customizations.  
Is possible to add a label (or icon) and display an hint, add a button to show the password when pressed and copy the password.  
It maintains the same security of the original password box.

### TextBoxPlus
Extended version of the standard text box with more features and customizations.  
Is possible to add a label (or icon) and display an hint, add a button to copy the text, choose if the textbox can contain only number, doubles…

---
---


## System components
System controls and components:

### AvalonWindow
Extended version of the classic window with possibility to customize the titlebar, fuse the titlebar with the content of the window, better handling of close, minimize, etc...

### WindowTitleBar
A fully customizable titlebar used in custom windows.

---

### FlexWindow
Extended version of the classic window with the same features of AvalonWindow, but with support for round angles and custom shadow.  
(This window can only be minimized, is not resizable or maximizable)

### FullWindow
Extended version of the classic window with the same features of FlexWindow but resizable.  
(This uses `AllowsTransparency=True`)


# License
Copyright (C) 2020-2022 devpelux (Salvatore Peluso)  
Licensed under MIT license.

[![mit](https://raw.githubusercontent.com/devpelux/fullcontrols/2.0.2/Assets/Mit.png)](https://github.com/devpelux/fullcontrols/blob/2.0.2/LICENSE)
