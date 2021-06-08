using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using nsButton;
using nsCSV;

namespace nsLog
{
    class Log
    {
        public Log(Stopwatch stopwatch)
        {
            this._stopwatch = stopwatch;
        }

        public void WriteTheLog(string elapsedTime, string name)
        {
            _log = ReturnTheLog(elapsedTime, name);
            CSV csv = new CSV();
            csv.Write(_log);
        }

        private string ReturnTheLog(string elapsedTime, string name)
        {
            if (!_stopwatch.IsRunning)
            {
                return name + ";" + DateTime.Now + ";" + elapsedTime + "; Finished" + "\n";
            }
            else
            {
                return name + ";" + DateTime.Now + "; Started" + "\n";
            }
        }

        private Stopwatch _stopwatch;
        private string _log;
    }
}
