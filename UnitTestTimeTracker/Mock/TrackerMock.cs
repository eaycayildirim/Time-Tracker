using System.Collections.Generic;
using nsTracker;
using nsButton;
using nsTrackerTask;

namespace nsTrackerMock
{
    public class TrackerMock : Tracker
    {
        public TrackerMock(Dictionary<string, TrackerTask> tasks) : base(tasks)
        {
            this._tasks = tasks;
        }

        public void UpdateTrackerMock(string selection)
        {
            UpdateTracker(selection);
        }
        public void PauseTheTaskMock(string selection)
        {
            PauseTheTask(selection);
        }

        private Dictionary<string, TrackerTask> _tasks;
    }
}
