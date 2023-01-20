using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Folio.Modules
{
    public partial class DocuToolbarMOD : UserControl
    {
        // singleton variables
        private static DocuToolbarMOD? current;
        public static DocuToolbarMOD? Current { get => current; set => current = value; }

        public DocuToolbarMOD()
        {
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

        // buttons

        // group 1 -- rich text toggles 
        #region
        void Click11(object sender, RoutedEventArgs args)
        {

        }

        void Click12(object sender, RoutedEventArgs args)
        {

        }

        void Click13(object sender, RoutedEventArgs args)
        {

        }

        void Click14(object sender, RoutedEventArgs args)
        {

        }

        #endregion

        // misc toggle
        void Click15(object sender, RoutedEventArgs args)
        {

        }

        // group 2 -- ????)
        #region
        void Click16(object sender, RoutedEventArgs args)
        {
            // clear message bar
            FileMenuToolbarMOD.Current.ClearStatus();
            // ask parser to do some stuff
            ParserMOD.Current.CountWords();
            // msgs
            FileMenuToolbarMOD.Current.FILEINFO.Text = "Words Counted!";

        }

        void Click17(object sender, RoutedEventArgs args)
        {

        }

        void Click18(object sender, RoutedEventArgs args)
        {

        }

        void Click19(object sender, RoutedEventArgs args)
        {

        }

        #endregion

    }

}