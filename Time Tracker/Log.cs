using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using nsElapsedTime;

namespace nsLog
{
    class Log
    {
        public string ReturnTheLog(Stopwatch stopwatch)
        {
            ElapsedTime elapsedTime = new ElapsedTime(stopwatch);
            if (!stopwatch.IsRunning)
            {
                return ";" + DateTime.Now + ";" + elapsedTime.ReturnElapsedTime() + "; Finished" + "\n";
            }
            else
            {
                return ";" + DateTime.Now + "; Started" + "\n";
            }
        }
    }
}
