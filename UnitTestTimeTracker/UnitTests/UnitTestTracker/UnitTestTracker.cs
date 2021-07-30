using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
using System.Collections.Generic;
using nsTracker;
using nsIDatabase;
using nsMockDatabase;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class UnitTestTracker
    {
        public UnitTestTracker()
        {
            var tasks = new Dictionary<string, TrackerTask> { { "TEST1", new TrackerTask("TEST1") }, { "TEST2", new TrackerTask("TEST2") }, { "TEST3", new TrackerTask("TEST3") } };
            _tracker = new Tracker(tasks, database);
        }

        [TestMethod]
        public void UpdateTracker_TaskIsStarted()
        {
            //Given
            var selection = "TEST1";

            //When
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsTrue(_tracker.IsTaskRunning(selection));
        }

        [TestMethod]
        public void UpdateTracker_TaskIsStopped()
        {
            //Given
            var selection = "TEST1";

            //When
            _tracker.UpdateTracker(selection);
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsFalse(_tracker.IsTaskRunning(selection));
        }

        [TestMethod]
        public void UpdateTracker_PausedTaskContinues()
        {
            //Given
            var selection = "TEST1";

            //When
            _tracker.UpdateTracker(selection);
            _tracker.PauseTheTask(selection);
            _tracker.UpdateTracker(selection);

            //Then
            Assert.IsTrue(_tracker.IsTaskRunning(selection));
            Assert.IsFalse(_tracker.IsTaskPaused(selection));
        }

        [TestMethod]
        public void PauseTheTask_TaskIsPaused()
        {
            //Given
            var selection = "TEST1";

            //When
            _tracker.UpdateTracker(selection);
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsTrue(_tracker.IsTaskPaused(selection));
        }

        [TestMethod]
        public void PauseTheTask_NonRunningTaskDoesNothing()
        {
            //Given
            var selection = "TEST1";

            //When
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsFalse(_tracker.IsTaskRunning(selection));
        }

        [TestMethod]
        public void AddTask_NewTaskAdded()
        {
            //Given
            var newTask = "TEST4";
            var size = _tracker.GetTasks().Count;

            //When
            _tracker.AddTask(newTask);
            var tasks = _tracker.GetTasks();
            var newSize = tasks.Count;

            //Then
            Assert.AreEqual(newSize, size + 1);
            Assert.IsTrue(tasks.ContainsKey(newTask));
        }

        [TestMethod]
        public void RemoveTask_RemoveOneTask_True()
        {
            //Given
            var task = "TEST1";
            var size = _tracker.GetTasks().Count;

            //When
            _tracker.RemoveTask(task);
            var tasks = _tracker.GetTasks();
            var newSize = tasks.Count;

            //Then
            Assert.AreEqual(newSize, size - 1);
            Assert.IsFalse(tasks.ContainsKey(task));
        }

        [TestMethod]
        public void RemoveTask_RemoveTaskAfterClear()       //??
        {
            //Given
            var task = "TEST";

            //When
            _tracker.ClearTasks();
            var size = _tracker.GetTasks().Count;
            _tracker.RemoveTask(task);
            var tasks = _tracker.GetTasks();

            //Then
            Assert.AreEqual(tasks.Count, size);
            Assert.IsFalse(tasks.ContainsKey(task));
        }

        [TestMethod]
        public void ClearTasks_ClearTasks_True()
        {
            //Given

            //When
            _tracker.ClearTasks();
            var tasks = _tracker.GetTasks();

            //Then
            Assert.IsTrue(tasks.Count == 0);
        }

        private Tracker _tracker;
        private IDatabase database = new MockDatabase();
    }
}
