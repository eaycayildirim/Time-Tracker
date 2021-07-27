using System.Collections.Generic;
using nsTracker;
using nsTrackerTask;

namespace nsTrackerMock
{
    public class TrackerMock : Tracker
    {
        public TrackerMock(Dictionary<string, TrackerTask> tasks) : base(tasks)
        {
        }

        public void UpdatePressedButtonsMock(string selection)
        {
            UpdatePressedButtons(selection);
        }
    }
}
