using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
using System.Collections.Generic;
using nsTracker;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TestTracker
    {
        public TestTracker()
        {
            _tasks = new Dictionary<string, TrackerTask> { { "STUDY", new TrackerTask("STUDY") }, { "PLAY", new TrackerTask("PLAY") }, { "EAT", new TrackerTask("EAT") } };
            _tracker = new Tracker(_tasks);
        }

        [TestMethod]
        public void TestStartThePausedTask()
        {
            //Given
            string selection = "STUDY";

            //When
            _tracker.UpdateTracker(selection);
            _tracker.PauseTheTask(selection);
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsTrue(_tasks[selection].IsRunning());
        }

        [TestMethod]
        public void TestStartTaskWithoutFinishThePausedOne()
        {
            //Given
            string firstSelection = "STUDY";
            string secondSelection = "PLAY";

            //When
            _tracker.UpdateTracker(firstSelection);
            _tracker.PauseTheTask(firstSelection);
            _tracker.UpdateTracker(secondSelection);

            //Then
            Assert.IsFalse(_tasks[firstSelection].IsPressed());
            Assert.IsFalse(_tasks[firstSelection].IsRunning());
            Assert.IsTrue(_tasks[secondSelection].IsPressed());
            Assert.IsTrue(_tasks[secondSelection].IsRunning());
        }

        private Dictionary<string, TrackerTask> _tasks;
        private Tracker _tracker;
    }
}
