using System;
using System.Collections.Generic;
using nsButton;
using nsTracker;
using nsCSV;

namespace TimeTrackerMain
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Button> buttons = new List<Button> { new Button() { Name = "Button 1" }, new Button() { Name = "Button 2" }, new Button() { Name = "Button 3" } };
            Tracker tracker = new Tracker(buttons);
            CSV csv = new CSV();

            tracker.Update();
            csv.WriteLogsIntoCSV();
            tracker.Update();
            csv.WriteLogsIntoCSV();
            tracker.Update();
            csv.WriteLogsIntoCSV();
            tracker.Update();
            csv.WriteLogsIntoCSV();
        }
    }
}
