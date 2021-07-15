using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
using System.Collections.Generic;
using nsTrackerMock;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TestPauseButton
    {
        public TestPauseButton()
        {
            _tasks = new Dictionary<string, TrackerTask> { { "STUDY", new TrackerTask("STUDY") }, { "PLAY", new TrackerTask("PLAY") }, { "EAT", new TrackerTask("EAT") } };
            _tracker = new TrackerMock(_tasks);
        }

        [TestMethod]
        public void TestPauseOneButton()
        {
            //Given
            string selection = "STUDY";

            //When
            _tracker.UpdateTrackerMock(selection);
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsFalse(_tasks[selection].IsRunning());
        }

        private Dictionary<string, TrackerTask> _tasks;
        private TrackerMock _tracker;
    }
}
