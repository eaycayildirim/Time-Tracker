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
            var list = base.GetProperties();
            return new List<string> { list[0], list[2], list[3] };
        }
    }
}
