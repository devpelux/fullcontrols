<!-- icon -->

<p align="center">
  <img width="90px" align="center" src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/IconSimple.svg"></img>
</p>
<h1 align="center">FullControls</h1>
<p align="center">Reworked version of the wpf controls, plus new controls and features.</p>

<!-- badges -->

<p align="center">
  <img src="https://img.shields.io/github/v/release/devpelux/fullcontrols?sort=semver"></img>
  <img src="https://img.shields.io/github/v/release/devpelux/fullcontrols?include_prereleases&label=snapshot&sort=semver"></img>
  <img src="https://img.shields.io/nuget/v/fullcontrols"></img>
  <img src="https://img.shields.io/github/release-date/devpelux/fullcontrols"></img>
  <img src="https://img.shields.io/nuget/dt/fullcontrols"></img>
  <img src="https://img.shields.io/github/license/devpelux/fullcontrols"></img>
</p>
<p align="center">
  <img src="https://img.shields.io/badge/code:release-v3.0.0--beta4-red"></img>
  <img src="https://img.shields.io/badge/code:status-beta-red"></img>
</p>


<!-- description -->

# Availability
**NUGET:** https://www.nuget.org/packages/FullControls


# Dependencies
[![net6](https://img.shields.io/badge/.NET-v6.0-blue)](https://docs.microsoft.com/dotnet)
[![net7](https://img.shields.io/badge/.NET-v7.0-blue)](https://docs.microsoft.com/dotnet)


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

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/accordion_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/accordion_dark.png"/>

---

### BorderedGrid
Similar to the normal Grid, but this draws a grid with bordered cells.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/borderedgrid.png"/>

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

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/buttonsplus_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/buttonsplus_dark.png"/>

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/switcher_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/switcher_dark.png"/>

---

### CheckBoxPlus
Extended version of the classic checkbox with more customizations.

### RadioButtonPlus
Extended version of the classic radiobutton with more customizations.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/checkboxplus_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/checkboxplus_dark.png"/>

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/radiobuttonplus_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/radiobuttonplus_dark.png"/>

---

### Collapsible
Adds collapsing and expanding functionality to another element.  
For example you can specify a Grid as collapsible Child, so the content of this Grid can be expanded or collapsed.  
The collapsible works with Width and Height, so expanding means *"go from zero to full size"*, and collapsing means *"go from full size to zero"*.  
Is possible to collapse only width, only height, or both.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/collapsible.gif"/>

---

### ComboBoxPlus
Extended version of the classic combobox with more customizations and features.

### ComboBoxItemPlus
Extended version of the classic combobox item with more customizations and features.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/comboboxplus_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/comboboxplus_dark.png"/>

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

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/flatmenu_light.png"/>

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/flatmenu_dark.png"/>

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/flatmenu_selectable_light.png"/>

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/flatmenu_selectable_dark.png"/>

---

### GlassScrollBar
Reworked version of the classic scrollbar adapted to be semi-transparent and colored.

### GlassScrollViewer
This is a scroll viewer that uses the GlassScrollBars and with some new functionality, as draw the scrollbars inside the scroll viewer.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/glassscrollviewer.png"/>

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/glassscrollbar.png"/>

---

### Kaleidoborder
Draws a multicolored border with a background around another element.  
This is similar to the standard border, but allows multicolored borders.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/kaleidoborder.png"/>

---

### PasswordBoxPlus
Extended version of the standard password box with more features and customizations.  
Is possible to add a label (or icon) and display an hint, add a button to show the password when pressed and copy the password.  
It maintains the same security of the original password box.

### TextBoxPlus
Extended version of the standard text box with more features and customizations.  
Is possible to add a label (or icon) and display an hint, add a button to copy the text, choose if the textbox can contain only number, doubles…

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/textboxplus_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/textboxplus_dark.png"/>

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/passwordboxplus_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/passwordboxplus_dark.png"/>

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/passwordboxplus_peek_light.png"/> <img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/passwordboxplus_peek_dark.png"/>


## System controls
System controls and components:

### AvalonWindow
Extended version of the classic window with possibility to customize the titlebar, fuse the titlebar with the content of the window, better handling of close, minimize, etc...

### TitleBar
A fully customizable titlebar used in custom windows.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/avalonwindow.png"/>

---

### FlexWindow
Extended version of the classic window with the same features of AvalonWindow, but with support for round angles and custom shadow.  
(This window can only be minimized, is not resizable or maximizable)

### FullWindow
Extended version of the classic window with the same features of FlexWindow but resizable.  
(This uses `AllowsTransparency=True`)


## Windows
Some windows:

### MessageWindow
Standard window for messages with light and dark theme, similar to the message box.

<img src="https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Overview/messagewindow.png"/>


<!-- license -->

# License
Copyright (C) 2020-2023 devpelux (Salvatore Peluso)  
Licensed under MIT license.

[![mit](https://raw.githubusercontent.com/devpelux/fullcontrols/2.2.0/Assets/Mit.png)](https://github.com/devpelux/fullcontrols/blob/2.2.0/LICENSE)
