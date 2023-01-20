using Avalonia.Controls;
using Folio.Modules;

namespace Folio
{
    public partial class MainWindow : Window
    {
        // singleton variables
        private static MainWindow? current;
        public static MainWindow? Current { get => current; set => current = value; }

        public MainWindow()
        {
            // setup 1
            InitializeComponent();
            DataContext = this;

            // setup 2 - extras
            FileLoggerMOD fileLogger = new FileLoggerMOD();

            // Setup the singleton
            if (Current == null)
            {
                Current = this;
            }
            else if (Current != this)
            {
                Current = this;
            }

        }
    }
}