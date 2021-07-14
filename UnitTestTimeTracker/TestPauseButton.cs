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
            _tasks = new List<TrackerTask> { new TrackerTask("Button1"), new TrackerTask("Button2"), new TrackerTask("Button3") };
            _tracker = new TrackerMock(_tasks);
        }

        [TestMethod]
        public void TestPauseOneButton()
        {
            //Given
            int selection = 0;

            //When
            _tracker.UpdateTrackerMock(selection);
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsFalse(_tasks[selection].IsRunning());
        }

        private List<TrackerTask> _tasks;
        private TrackerMock _tracker;
    }
}
