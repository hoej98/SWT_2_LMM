using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Ladeskab
{
    public interface ILog
    {
        string logFile { get; set; } // Navnet på systemets log-fil

        void writeLog(int id);
    }
}
