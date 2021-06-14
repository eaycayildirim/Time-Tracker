using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace nsButton
{
    public class Button
    {
        public string Name { get; set; }
        public bool IsPressed { get; set; }

        public void Press(Stopwatch _stopwatch)
        {
            if (!this.IsPressed)
            {
                _stopwatch.Restart();
            }
            else
            {
                _stopwatch.Stop();
            }
            IsPressed = !IsPressed;
        }
    }
}
