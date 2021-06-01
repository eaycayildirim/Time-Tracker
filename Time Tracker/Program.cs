using System;
using System.Collections.Generic;
using nsButton;
using nsTracker;

namespace TimeTrackerMain
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Button> buttons = new List<Button> { new Button() { _name = "Button 1" }, new Button() { _name = "Button 2" }, new Button() { _name = "Button 3" } };
            Tracker tracker = new Tracker(buttons);

            tracker.Update();
            tracker.Update();
            tracker.Update();
            tracker.Update();

        }
    }
}
