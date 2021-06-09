using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using nsCSV;
using nsElapsedTime;

namespace nsLog
{
    class Log
    {
        public Log(Stopwatch stopwatch)
        {
            this._stopwatch = stopwatch;
        }

        public string ReturnTheLog(string name)
        {
            ElapsedTime elapsedTime = new ElapsedTime(_stopwatch);
            if (!_stopwatch.IsRunning)
            {
                return name + ";" + DateTime.Now + ";" + elapsedTime.ReturnElapsedTime() + "; Finished" + "\n";
            }
            else
            {
                return name + ";" + DateTime.Now + "; Started" + "\n";
            }
        }

        private Stopwatch _stopwatch;
    }
}
