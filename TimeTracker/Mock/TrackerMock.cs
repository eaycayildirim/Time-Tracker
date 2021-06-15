﻿using System.Collections.Generic;
using nsTracker;
using nsButton;
using nsTask;

namespace nsTrackerMock
{
    public class TrackerMock : Tracker 
    {
        public TrackerMock(List<Task> tasks) : base(tasks) 
        {
            this._tasks = tasks;
        }

        public void UpdatePressedButtonsMock(int selection) 
        {
            base.UpdatePressedButtons(selection);
        }

        private List<Task> _tasks;
    }
}
