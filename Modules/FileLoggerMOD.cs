using System.IO;


namespace Folio.Modules
{
    internal class FileLoggerMOD
    {
        private static FileLoggerMOD? current;
        public static FileLoggerMOD? Current { get => current; set => current = value; }


        public FileLoggerMOD()
        {             
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


        public StreamWriter LogFileOpen()
        {
            // choose the file name
            var fileName = MainWindow.Current.Title + "-Log";

            // create the logfile at the given path
            StreamWriter logfile = File.AppendText("E:/Local Repo/Logs/" + fileName + ".txt");

            // write to the stream
            logfile.Write("----------------" + "\n");

            // return the logfile
            return logfile;
        }

        public void LogFileClose(StreamWriter file)  
        {
            // close the stream
            file.Close();
        }

        public bool Log(StreamWriter file, string content) 
        {
            // write to the stream
            file.Write(content + "\n");
            // return success
            return true;
        }
    }
}
