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
            this._isPressed = false;
        }

        public string Name { get; set; }

        public void Press()
        {
            //First two lines will change

            TimeSpan ts = _stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            _isPressed = !_isPressed;
            if (this._isPressed)
            {
                _stopwatch.Start();
                Console.WriteLine(Name + "; " + DateTime.Now + "; " + elapsedTime + " Started");
            }
            else
            {
                _stopwatch.Stop();
                Console.WriteLine(Name + "; " + DateTime.Now + "; " + elapsedTime + " Finished");
            }
        }

        public bool IsPressed()
        {
            return this._isPressed;
        }

        private Stopwatch _stopwatch;
        private bool _isPressed;
    }
}
