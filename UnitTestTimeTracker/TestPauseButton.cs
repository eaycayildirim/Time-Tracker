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
            _tracker.UpdatePressedButtonsMock(selection);
            _tracker.PauseTheTask(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsFalse(_tasks[selection].IsRunning());
        }
        [TestMethod]
        public void TestStartThePausedTask()
        {
            //Given
            int selection = 0;

            //When
            _tracker.UpdatePressedButtonsMock(selection);
            _tracker.PauseTheTask(selection);
            _tracker.UpdatePressedButtonsMock(selection);

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
            _tracker.UpdatePressedButtonsMock(firstSelection);
            _tracker.PauseTheTask(firstSelection);
            _tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.IsFalse(_tasks[firstSelection].IsPressed());
            Assert.IsFalse(_tasks[firstSelection].IsRunning());
            Assert.IsTrue(_tasks[secondSelection].IsPressed());
            Assert.IsTrue(_tasks[secondSelection].IsRunning());
        }

        private List<TrackerTask> _tasks;
        private TrackerMock _tracker;
    }
}
