using System.Collections.Generic;
using nsTracker;
using nsTrackerTask;
using nsIDatabase;

namespace nsTrackerTest
{
    public class TrackerTest : Tracker
    {
        public TrackerTest(Dictionary<string, TrackerTask> tasks, IDatabase database) : base(tasks, database)
        {
        }
    }
}
