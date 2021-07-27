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
            var tasks = new Dictionary<string, TrackerTask> { { "STUDY", new TrackerTask("STUDY") }, { "PLAY", new TrackerTask("PLAY") }, { "EAT", new TrackerTask("EAT") } };
            _tracker = new Tracker(tasks);
        }

        [TestMethod]
        public void UpdateTracker_TaskIsStarted()
        {
            //Given
            var selection = "STUDY";
            var tasks = _tracker.GetTasks();

            //When
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsTrue(tasks[selection].IsPressed());
            Assert.IsTrue(tasks[selection].IsRunning());
        }

        [TestMethod]
        public void UpdateTracker_TaskIsStopped()
        {
            //Given
            var selection = "STUDY";
            var tasks = _tracker.GetTasks();

            //When
            _tracker.UpdateTracker(selection);
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsFalse(tasks[selection].IsPressed());
            Assert.IsFalse(tasks[selection].IsRunning());
        }

        [TestMethod]
        public void UpdateTracker_PausedTaskContinues()
        {
            //Given
            var selection = "STUDY";
            var tasks = _tracker.GetTasks();

            //When
            _tracker.UpdateTracker(selection);
            _tracker.PauseTheTask(selection);
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsTrue(tasks[selection].IsPressed());
            Assert.IsTrue(tasks[selection].IsRunning());
            Assert.IsFalse(tasks[selection].IsPaused());
        }

        [TestMethod]
        public void PauseTheTask_TaskIsPaused()
        {
            //Given
            var selection = "STUDY";
            var tasks = _tracker.GetTasks();

            //When
            _tracker.UpdateTracker(selection);
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsTrue(tasks[selection].IsPaused());
        }

        [TestMethod]
        public void PauseTheTask_NonRunningTaskDoesNothing()
        {
            //Given
            var selection = "STUDY";
            var tasks = _tracker.GetTasks();

            //When
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsFalse(tasks[selection].IsPressed());
            Assert.IsFalse(tasks[selection].IsRunning());
        }

        [TestMethod]
        public void AddTask_NewTaskAdded()
        {
            //Given
            var selection = "REST";

            //When
            _tracker.AddTask(selection);
            var tasks = _tracker.GetTasks();

            //Then
            Assert.IsTrue(tasks.ContainsKey(selection));
        }

        [TestMethod]
        public void RemoveTask_RemoveOneTask_True()
        {
            //Given
            var selection = "REST";

            //When
            _tracker.AddTask(selection);
            _tracker.RemoveTask(selection);
            var tasks = _tracker.GetTasks();

            //Then
            Assert.IsFalse(tasks.ContainsKey(selection));
        }

        [TestMethod]
        public void ClearTasks_ClearTasks_True()
        {
            //Given

            //When
            _tracker.ClearTasks();
            var tasks = _tracker.GetTasks();

            //Then
            Assert.IsTrue(tasks.Count==0);
        }

        [TestMethod]
        public void UpdatePressedButtons_UnpressTheButton()
        {
            //Given
            var tasks = _tracker.GetTasks();
            _trackerMock = new TrackerMock(tasks);
            var selectionOne = "STUDY";
            var selectionTwo = "EAT";

            //When
            _trackerMock.UpdateTracker(selectionOne);
            _trackerMock.UpdatePressedButtonsMock(selectionTwo);

            //Then
            Assert.IsFalse(tasks[selectionOne].IsPressed());
        }

        private Tracker _tracker;
        private TrackerMock _trackerMock;
    }
}
