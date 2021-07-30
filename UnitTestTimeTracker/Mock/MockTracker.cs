using System.Collections.Generic;
using nsTracker;
using nsTrackerTask;
using nsIDatabase;

namespace nsMockTracker
{
    public class MockTracker : Tracker
    {
        public MockTracker(Dictionary<string, TrackerTask> tasks, IDatabase database) : base(tasks, database)
        {
        }

        public void UpdatePressedButtonsMock(string selection)
        {
            UpdatePressedButtons(selection);
        }
    }
}
