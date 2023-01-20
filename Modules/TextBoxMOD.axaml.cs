using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Folio.Modules
{
    public partial class TextBoxMOD : UserControl
    {
        // singletone variables
        private static TextBoxMOD? current;
        public static TextBoxMOD? Current { get => current; set => current = value; }
        public TextBoxMOD()
        {
            // setup 1
            InitializeComponent();
            DataContext = this;
            // setup 2 - extras
            ParserMOD parser = new ParserMOD();
            MAINTB.Text = "";

            // setup the singleton
            if (Current == null)
            {
                Current = this;
            }
            else if (Current != this)
            {
                Current = this;
            }

            // parser
        }

    }




}






