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
            _tasks = new List<TrackerTask> { new TrackerTask("Button1"), new TrackerTask("Button2"), new TrackerTask("Button3") };
            _tracker = new TrackerMock(_tasks);
        }

        [TestMethod]
        public void TestPressOneButton()
        {
            //Given
            int selection = 0;

            //When
            _tracker.UpdatePressedButtonsMock(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsTrue(_tasks[selection].IsRunning());
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            int firstSelection = 0;
            int secondSelection = 1;

            //When
            _tracker.UpdatePressedButtonsMock(firstSelection);

            //Then
            Assert.IsTrue(_tasks[firstSelection].IsPressed());
            Assert.IsTrue(_tasks[firstSelection].IsRunning());

            //When
            _tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.IsFalse(_tasks[firstSelection].IsPressed());
            Assert.IsFalse(_tasks[firstSelection].IsRunning());
            Assert.IsTrue(_tasks[secondSelection].IsPressed());
            Assert.IsTrue(_tasks[secondSelection].IsRunning());
        }
        [TestMethod]
        public void TestPressThreeButtons()
        {
            //Given
            int firstSelection = 0;
            int secondSelection = 1;
            int thirdSelection = 2;

            //When
            _tracker.UpdatePressedButtonsMock(firstSelection);

            //Then
            Assert.IsTrue(_tasks[firstSelection].IsPressed());
            Assert.IsTrue(_tasks[firstSelection].IsRunning());

            //When
            _tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.IsFalse(_tasks[firstSelection].IsPressed());
            Assert.IsFalse(_tasks[firstSelection].IsRunning());
            Assert.IsTrue(_tasks[secondSelection].IsPressed());
            Assert.IsTrue(_tasks[secondSelection].IsRunning());

            //When
            _tracker.UpdatePressedButtonsMock(thirdSelection);

            //Then
            Assert.IsFalse(_tasks[secondSelection].IsPressed());
            Assert.IsFalse(_tasks[secondSelection].IsRunning());
            Assert.IsTrue(_tasks[thirdSelection].IsPressed());
            Assert.IsTrue(_tasks[thirdSelection].IsRunning());
        }

        private List<TrackerTask> _tasks;
        private TrackerMock _tracker;
    }
}
