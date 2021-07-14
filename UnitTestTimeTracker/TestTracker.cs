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
            _tasks = new List<TrackerTask> { new TrackerTask("Button1"), new TrackerTask("Button2"), new TrackerTask("Button3") };
            _tracker = new Tracker(_tasks);
        }

        [TestMethod]
        public void TestStartThePausedTask()
        {
            //Given
            int selection = 0;

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
            int firstSelection = 0;
            int secondSelection = 1;

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

        private List<TrackerTask> _tasks;
        private Tracker _tracker;
    }
}
