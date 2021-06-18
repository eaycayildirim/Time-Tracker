using System.Collections.Generic;
using nsTask;
using nsTracker;

namespace TimeTrackerMain
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tasks> tasks = new List<Tasks> { new Tasks("Button 1"), new Tasks("Button 2"), new Tasks("Button 3") };
            Tracker tracker = new Tracker(tasks);

            //tracker.Update();
            //tracker.Update();
            //tracker.Update();
            //tracker.Update();
        }
    }
}
