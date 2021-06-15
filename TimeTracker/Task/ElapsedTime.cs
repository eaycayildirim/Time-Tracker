using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using nsLog;

namespace nsElapsedTime
{
    class ElapsedTime
    {
        public ElapsedTime()
        {
            this._stopwatch.Restart();
            Log.Write("The elapsed time is created.");
        }
        public string ReturnElapsedTime()
        {
            TimeSpan ts = _stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            return elapsedTime;
        }
        private Stopwatch _stopwatch = new Stopwatch();
    }
}
