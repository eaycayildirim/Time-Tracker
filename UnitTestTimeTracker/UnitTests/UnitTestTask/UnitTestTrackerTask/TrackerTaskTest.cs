using System.Collections.Generic;
using nsTrackerTask;

namespace nsTrackerTaskTest
{
    public class TrackerTaskTest : TrackerTask
    {
        public TrackerTaskTest(string task) : base(task)
        {

        }

        public override List<string> GetProperties()
        {
            var list = base.GetProperties();
            return new List<string> { list[0], list[2], list[3] };
        }
    }
}
