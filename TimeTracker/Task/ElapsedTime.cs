using System;
using System.Diagnostics;
using nsLog;

namespace nsElapsedTime
{
    public class ElapsedTime
    {
        public ElapsedTime()
        {
            this._stopwatch = new Stopwatch();
            Log.Write("The elapsed time is created.");
        }
        public string ReturnElapsedTime()
        {
            TimeSpan ts = _stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            return elapsedTime;
        }

        public bool IsPaused() //**
        {
            return _stopwatch.IsRunning ? false : true;
        }

        public void Start() //**
        {
            _stopwatch.Start();
        }

        public void Restart()
        {
            _stopwatch.Restart();
        }

        public void Stop()
        {
            _stopwatch.Stop();
        }

        private Stopwatch _stopwatch;
    }
}
