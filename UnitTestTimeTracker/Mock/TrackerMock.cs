using System.Collections.Generic;
using nsTracker;
using nsTrackerTask;

namespace nsTrackerMock
{
    public class TrackerMock : Tracker
    {
        public TrackerMock(Dictionary<string, TrackerTask> tasks) : base(tasks)
        {
            this._tasks = tasks;
        }

        public void UpdatePressedButtonsMock(string selection)
        {
            UpdatePressedButtons(selection);
        }

        private Dictionary<string, TrackerTask> _tasks;
    }
}
