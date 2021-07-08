using System.Collections.Generic;
using nsTracker;
using nsButton;
using nsTrackerTask;

namespace nsTrackerMock
{
    public class TrackerMock : Tracker
    {
        public TrackerMock(List<TrackerTask> tasks) : base(tasks)
        {
            this._tasks = tasks;
        }

        public void UpdateTrackerMock(int selection)
        {
            UpdateTracker(selection);
        }
        public void PauseTheTaskMock(int selection)
        {
            PauseTheTask(selection);
        }

        private List<TrackerTask> _tasks;
    }
}
