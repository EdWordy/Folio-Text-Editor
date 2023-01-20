using Avalonia.Controls;
using System.IO;
using System;

namespace Folio.Modules
{
    public partial class FileMenuToolbarMOD : UserControl
    {
        // singleton variables
        private static FileMenuToolbarMOD? current;
        public static FileMenuToolbarMOD? Current { get => current; set => current = value; }

        public FileMenuToolbarMOD()
        {
            // setup 1
            InitializeComponent();
            DataContext = this;

            // setup the singleton
            if (Current == null)
            {
                Current = this;
            }
            else if (Current != this)
            {
                Current = this;
            }
        }

        // Toolbar Buttons - Main
        #region
        private async void Click01(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ClearStatus();

            // save the contents of the main textbox to a .txt file

            // null check
            if (TextBoxMOD.Current.MAINTB.Text != null)
            {
                // setup message
                FILEINFO.Text = "Intializing save...";
                FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = false;

                // open a save file dialog and set input property
                SaveFileDialog saveFileDialog = new()
                {
                    DefaultExtension = "txt"
                };

                // set a path equal to a chosen file
                String filePath = await saveFileDialog.ShowAsync(MainWindow.Current);

                if (filePath != null)
                {
                    // message
                    FILEINFO.Text = "...Saving...";
                    FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = false;

                    // create a streamwriter (sw), a file,
                    // write to the file w/ sw, close sw
                    StreamWriter sw = File.CreateText(filePath.ToString());
                    sw.Write(TextBoxMOD.Current.MAINTB.Text);
                    sw.Close();

                    // msgs
                    FILEINFO.Text = "...Saved at " + filePath + "!";
                    FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = false;
                }
                else
                {
                    // message
                    FILEINFO.Text = "...Cancelled";
                    FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = true;
                }

            }
            else
            {
                // err msg
                FILEINFO.Text = "ERROR: Couldn't save file";
                FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = true;
            }

        }

        private async void Click02(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ClearStatus();

            // open a file dialog then save 

            // null check
            if (TextBoxMOD.Current.MAINTB.Text != null && TextBoxMOD.Current.MAINTB.Text == "")

            {
                // msg
                FILEINFO.Text = "Intializing open ...";

                // open a chose file dialog
                OpenFileDialog openFileDialog = new OpenFileDialog();
                // set a string[] FilePath equal to the chosen file path
                string[] FilePath = await openFileDialog.ShowAsync(MainWindow.Current);

                // if FilePath isn't null
                if (FilePath != null)
                {
                    // intro msg
                    FILEINFO.Text = "... FilePath found; reading ...";
                    // set string content equal to the file text content
                    string content = File.ReadAllText(FilePath.ToString());
                    // set content equal to the main text box
                    TextBoxMOD.Current.MAINTB.Text = content;
                    // exit msg
                    FILEINFO.Text = "... File opened!";
                }
                else
                {
                    FILEINFO.Text = "ERROR: Choose a filepath.";
                }
            }
            else
            {
                FILEINFO.Text = "ERROR: The textbox isn't empty.";
                FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = true;
            }


        }

        void Click03(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //

        }

        void Click04(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //

        }

        #endregion

        // helper methods
        #region
        public void ClearStatus()
        {
            FileMenuToolbarMOD.Current.FILEINFO.Text = "";
            FileMenuToolbarMOD.Current.AlertIcon00.IsVisible = false;
            FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = false;
        }

        #endregion
    }



}
