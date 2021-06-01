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
        private Stopwatch _stopwatch;
        private bool _isPressed;
        public string _name { get; set; }

        public void Press()
        {
            _isPressed = !_isPressed;
            if (this._isPressed)
            {
                _stopwatch.Start();
            }
            else
            {
                _stopwatch.Stop();
            }
        }

        public bool IsPressed()
        {
            return this._isPressed;
        }
    }
}
