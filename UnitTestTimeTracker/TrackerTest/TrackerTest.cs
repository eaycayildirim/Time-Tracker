using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
using System.Collections.Generic;
using nsTrackerMock;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TrackerTest
    {
        public TrackerTest()
        {
            _tasks = new Dictionary<string, TrackerTask> { { "STUDY", new TrackerTask("STUDY") }, { "PLAY", new TrackerTask("PLAY") }, { "EAT", new TrackerTask("EAT") } };
            _tracker = new TrackerMock(_tasks);
        }

        [TestMethod]
        public void UpdatePressedButtons_OneTaskIsPressed_True()        //Needs mock to test
        {
            //Given
            var selection = "STUDY";

            //When
            _tracker.UpdateTrackerMock(selection);      //Will change

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsTrue(_tasks[selection].IsRunning());
        }

        [TestMethod]
        public void UpdateTracker_TaskIsStarted_True()
        {
            //Given
            var selection = "STUDY";

            //When
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsTrue(_tasks[selection].IsRunning());
        }

        private Dictionary<string, TrackerTask> _tasks;
        private TrackerMock _tracker;
    }
}
