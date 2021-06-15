using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using nsLog;

namespace nsButton
{
    public class Button
    {
        public Button()
        {
            Log.Write("The button is created.");
        }

        public bool IsPressed { get; set; }

        public void Press()
        {
            IsPressed = !IsPressed;
        }
    }
}
