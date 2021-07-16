using System;
using System.Collections.Generic;
using System.Text;
using nsTrackerTask;

namespace nsTrackerTaskMock
{
    public class TrackerTaskMock : TrackerTask
    {
        public TrackerTaskMock(string task) : base(task)
        {
        }
        public override List<string> GetProperties()
        {
            return new List<string> { this.Name, GetElapsedTime(), GetStatusMock() };
        }
        public string GetStatusMock()
        {
            return GetStatus();
        }
    }
}
