using System.Collections.Generic;
using nsTracker;
using nsTrackerTask;
using nsIDatabase;

namespace nsTrackerMock
{
    public class TrackerMock : Tracker
    {
        public TrackerMock(Dictionary<string, TrackerTask> tasks, IDatabase database) : base(tasks, database)
        {
        }

        public void UpdatePressedButtonsMock(string selection)
        {
            UpdatePressedButtons(selection);
        }
    }
}
