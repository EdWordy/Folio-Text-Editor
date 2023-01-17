using Avalonia.Controls;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;

namespace Parchment
{







    public partial class MainWindow : Window
    {
        // singleton
        public static MainWindow? current;

        public MainWindow()
        {
            InitializeComponent();

            // instatiate the singleton
            if (current == null)
            {
                current = this;
            }
            else if (current != this)
            {
                current = this;
            }


        }

   

 
        async void ClickBTN1(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // save the content of the main textbox to a string
            if (MainWindow.current.Main.Text != null)
            {

  
                // setup
                MainWindow.current.LOGDISP.Text = "...Working...";

                // open a save file dialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExtension = "txt";

                // set a path equal to a chosen file
                String filePath = await saveFileDialog.ShowAsync(MainWindow.current);

                // null check
                if (filePath != null)
                {
                    // msg
                    MainWindow.current.LOGDISP.Text = "...Saving your file...";
                    // save the content to the chosen path
                    StreamWriter sw = File.CreateText(filePath.ToString());
                    sw.Write(MainWindow.current.Main.Text);
                    sw.Close();
                }
                else
                {
                    MainWindow.current.LOGDISP.Text = "Cancelled";
                }
            }
            else
            {
                // err msg
                MainWindow.current.LOGDISP.Text = "Error -- no input!";
            }
        }


        async void ClickBTN2(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // create a new open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // get the filepath
            string[] filePath = await openFileDialog.ShowAsync(MainWindow.current);

            string str = "";

            for (int i = 0; i < filePath.Length; i++)
            {

                str += filePath[i];
            }

            MainWindow.current.LOGDISP.Text = str;

            //if file path is
            // not null then
            if (str != null)
            {
                // open the file

                MainWindow.current.Main.Text = File.ReadAllText(str);
            }
        }

        void ClickBTN3(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }

        void ClickBTN4(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {


        }
   

        void ClickBTN5(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }

        void ClickBTN6(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }

        void ClickBTN7(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }

        void ClickBTN8(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }

    }

}