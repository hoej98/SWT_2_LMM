using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ladeskab
{
    public class Log : ILog
    {
        public string logFile { get; set; } // Navnet på systemets log-fil

        public Log(string logfile)
        {
            logFile = logfile;
        }

        public void writeLog(int id)
        {
            using (var writer = File.AppendText(logFile))
            {
                writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
            }
        }
    }
}
