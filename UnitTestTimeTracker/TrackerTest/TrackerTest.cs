using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
using nsTrackerMock;
using System.Collections.Generic;
using nsTracker;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TrackerTest
    {
        public TrackerTest()
        {
            _tasks = new Dictionary<string, TrackerTask> { { "STUDY", new TrackerTask("STUDY") }, { "PLAY", new TrackerTask("PLAY") }, { "EAT", new TrackerTask("EAT") } };
            _tracker = new Tracker(_tasks);
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

        [TestMethod]
        public void UpdateTracker_TaskIsStarted_False()
        {
            //Given
            var selection = "STUDY";

            //When
            _tracker.UpdateTracker(selection);
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsFalse(_tasks[selection].IsPressed());
            Assert.IsFalse(_tasks[selection].IsRunning());
        }

        [TestMethod]
        public void UpdateTracker_PausedTaskContinues_True()
        {
            //Given
            var selection = "STUDY";

            //When
            _tracker.UpdateTracker(selection);
            _tracker.PauseTheTask(selection);
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsTrue(_tasks[selection].IsRunning());
        }

        [TestMethod]
        public void PauseTheTask_TaskIsPaused_True()
        {
            //Given
            var selection = "STUDY";

            //When
            _tracker.UpdateTracker(selection);
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsFalse(_tasks[selection].IsRunning());
        }

        [TestMethod]
        public void PauseTheTask_NonRunningTaskDoesNothing_True()
        {
            //Given
            var selection = "STUDY";

            //When
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsFalse(_tasks[selection].IsPressed());
            Assert.IsFalse(_tasks[selection].IsRunning());
        }

        [TestMethod]
        public void AddTask_AddOneTask_True()
        {
            //Given
            var selection = "REST";

            //When
            _tracker.AddTask(selection);

            //Then
            Assert.IsTrue(_tasks.ContainsKey(selection));
        }

        [TestMethod]
        public void RemoveTask_RemoveOneTask_True()
        {
            //Given
            var selection = "REST";

            //When
            _tracker.AddTask(selection);
            _tracker.RemoveTask(selection);

            //Then
            Assert.IsFalse(_tasks.ContainsKey(selection));
        }

        [TestMethod]
        public void ClearTasks_ClearTasks_True()
        {
            //Given

            //When
            _tracker.ClearTasks();

            //Then
            Assert.IsTrue(_tasks.Count==0);
        }

        [TestMethod]
        public void UpdatePressedButtons_UnpressOneTask_True()      // ??
        {
            //Given
            _trackerMock = new TrackerMock(_tasks);
            var selectionOne = "STUDY";
            var selectionTwo = "EAT";

            //When
            _trackerMock.UpdateTracker(selectionOne);
            _trackerMock.UpdatePressedButtonsMock(selectionTwo);

            //Then
            Assert.IsFalse(_tasks[selectionOne].IsPressed());
        }

        private Dictionary<string, TrackerTask> _tasks;
        private Tracker _tracker;
        private TrackerMock _trackerMock;
    }
}
