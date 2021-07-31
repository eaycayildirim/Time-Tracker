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
            var selectedTask = "TEST1";

            //When
            _tracker.UpdateTracker(selectedTask);

            //Then
            Assert.IsTrue(_tracker.IsTaskRunning(selectedTask));
        }

        [TestMethod]
        public void UpdateTracker_TaskIsStopped()
        {
            //Given
            var selectedTask = "TEST1";

            //When
            _tracker.UpdateTracker(selectedTask);
            _tracker.UpdateTracker(selectedTask);

            //Then
            Assert.IsFalse(_tracker.IsTaskRunning(selectedTask));
        }

        [TestMethod]
        public void UpdateTracker_PausedTaskContinues()
        {
            //Given
            var selectedTask = "TEST1";

            //When
            _tracker.UpdateTracker(selectedTask);
            _tracker.PauseTheTask(selectedTask);
            _tracker.UpdateTracker(selectedTask);

            //Then
            Assert.IsTrue(_tracker.IsTaskRunning(selectedTask));
            Assert.IsFalse(_tracker.IsTaskPaused(selectedTask));
        }

        [TestMethod]
        public void UpdateTracker_StartTheTaskWhileOneIsRunning()
        {
            //Given
            var task1 = "TEST1";
            var task2 = "TEST2";

            //When
            _tracker.UpdateTracker(task1);
            _tracker.UpdateTracker(task2);

            //Then
            Assert.IsFalse(_tracker.IsTaskRunning(task1));
            Assert.IsTrue(_tracker.IsTaskRunning(task2));
        }

        [TestMethod]
        public void UpdateTracker_StartTheTaskWhileOneIsPaused()
        {
            //Given
            var task1 = "TEST1";
            var task2 = "TEST2";

            //When
            _tracker.UpdateTracker(task1);
            _tracker.PauseTheTask(task1);
            _tracker.UpdateTracker(task2);

            //Then
            Assert.IsFalse(_tracker.IsTaskRunning(task1));
            Assert.IsFalse(_tracker.IsTaskPaused(task1));
            Assert.IsTrue(_tracker.IsTaskRunning(task2));
        }

        [TestMethod]
        public void PauseTheTask_TaskIsPaused()
        {
            //Given
            var selectedTask = "TEST1";

            //When
            _tracker.UpdateTracker(selectedTask);
            _tracker.PauseTheTask(selectedTask);

            //Then
            Assert.IsTrue(_tracker.IsTaskPaused(selectedTask));
        }

        [TestMethod]
        public void PauseTheTask_PauseThePausedTaskDoesNothing()
        {
            //Given
            var selectedTask = "TEST1";

            //When
            _tracker.UpdateTracker(selectedTask);
            _tracker.PauseTheTask(selectedTask);
            _tracker.PauseTheTask(selectedTask);

            //Then
            Assert.IsTrue(_tracker.IsTaskPaused(selectedTask));
        }

        [TestMethod]
        public void PauseTheTask_PauseNonRunningTaskDoesNothing()
        {
            //Given
            var selectedTask = "TEST1";

            //When
            _tracker.PauseTheTask(selectedTask);

            //Then
            Assert.IsFalse(_tracker.IsTaskRunning(selectedTask));
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
