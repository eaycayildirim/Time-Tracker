using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

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
        }

        public string ReturnTheLog() //it's not working yet
        {
            string log;
            if (!_stopwatch.IsRunning)
            {
                log = this.Name + ";" + DateTime.Now + "; Finished";
            }
            else
            {
                log = this.Name + ";" + DateTime.Now + "; Started"; //+ elapsedTime
            }
            return log;
        }

        private Stopwatch _stopwatch;
    }
}
