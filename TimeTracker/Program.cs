using System;
using System.Collections.Generic;
using nsTask;
using nsTracker;

namespace TimeTrackerMain
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task> { new Task("Button 1"), new Task("Button 2"), new Task("Button 3") };
            Tracker tracker = new Tracker(tasks);

            tracker.Update();
            tracker.Update();
            tracker.Update();
            tracker.Update();
        }
    }
}
