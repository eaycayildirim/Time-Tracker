using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using nsCSV;

namespace nsButton
{
    public class Button
    {
        public Button()
        {
            this._stopwatch = new Stopwatch();
        }

        public string Name { get; set; }
        public bool IsPressed { get; set; }

        public void Press()
        {
            //First two lines will change

            TimeSpan ts = _stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            IsPressed = !IsPressed;
            if (this.IsPressed)
            {
                _stopwatch.Start();
                Console.WriteLine(Name + "; " + DateTime.Now + "; Started");
            }
            else
            {
                _stopwatch.Stop();
                Console.WriteLine(Name + "; " + DateTime.Now + "; " + elapsedTime + " Finished");
            }

            // This part shouldn't be here but where should it be?
            _log = ReturnTheLog(elapsedTime);
            CSV csv = new CSV();
            csv.WriteLogsIntoCSV(_log);
        }

        public string ReturnTheLog(string elapsedTime)
        {
            if (!_stopwatch.IsRunning)
            {
                _log = this.Name + ";" + DateTime.Now + " " + elapsedTime + "; Finished";
            }
            else
            {
                _log = this.Name + ";" + DateTime.Now + "; Started";
            }
            return _log;
        }

        private Stopwatch _stopwatch;
        private string _log;
    }
}
