# Folio Text Editor
A simple text editor, with basic functionality.

- Current Version: 0.1.0

- Last Updated: 01 19 2023

Written in C# and developed in Visual Studio[^1] using Avalonia.

Licensed with Apache License 2.0[^2].

## INTRO:

A handy-dandy text editor, for when you need to write a few lines of text.

![The app in its current state](/Text-Editor-eg.jpg)

## FEATURES:

#### MENU TOOLBAR

1 [WIP] FILE MANAGEMENT BUTTONS: Save Text as File, Open Text File, etc.

2 [PASS] FILE STATUS UPDATES: HUD status updates on the programs functioning

3 [ ] FEATURE 3: ????

#### DOCUMENT EDITING PANE

1 [WIP] RICH TEXT FORMATTING: Tools, such as bold, and more!

2 [WIP] SIMPLE TEXT ANALYSIS: Tools such as Word Count, Reading level, etc.

3 [WIP] COMPLEX TEXT ANALYSIS: ????

#### EXTRA

1 [PASS] TEXT PARSING ENGINE: A text parsing engine for advanced text features

2 [PASS] LOG FILE: A logging file, for fine-grain debugging

##### NOTE

Most of the code is styled in a code-behind paradigm, but the parser uses a singleton-esque pattern. I.E. There is an instance of the parserMOD class in main window created on intialization, a static reference called ParserMOD.Current used to make calls on the singleton, and then the code is called in button clicks, or in some other UI control. This works as intended.

As well, the parser, for counting words, goes from specific case to general. I tried general to specific with little result.

[^1]: Visual Studio is property of Microsoft Corporation.

[^2]: Refer to LICENSE for more information on the terms and conditions of the use of the software.
