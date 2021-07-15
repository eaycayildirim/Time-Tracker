using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
using System.Collections.Generic;
using nsTrackerMock;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TestPressButtons
    {
        public TestPressButtons()
        {
            _tasks = new Dictionary<string, TrackerTask> { { "STUDY", new TrackerTask("STUDY") }, { "PLAY", new TrackerTask("PLAY") }, { "EAT", new TrackerTask("EAT") } };
            _tracker = new TrackerMock(_tasks);
        }

        [TestMethod]
        public void TestPressOneButton()
        {
            //Given
            string selection = "STUDY";

            //When
            _tracker.UpdateTrackerMock(selection);

            //Then
            Assert.IsTrue(_tasks[selection].IsPressed());
            Assert.IsTrue(_tasks[selection].IsRunning());
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            string firstSelection = "STUDY";
            string secondSelection = "PLAY";

            //When
            _tracker.UpdateTrackerMock(firstSelection);

            //Then
            Assert.IsTrue(_tasks[firstSelection].IsPressed());
            Assert.IsTrue(_tasks[firstSelection].IsRunning());

            //When
            _tracker.UpdateTrackerMock(secondSelection);

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
            string firstSelection = "STUDY";
            string secondSelection = "PLAY";
            string thirdSelection = "EAT";

            //When
            _tracker.UpdateTrackerMock(firstSelection);

            //Then
            Assert.IsTrue(_tasks[firstSelection].IsPressed());
            Assert.IsTrue(_tasks[firstSelection].IsRunning());

            //When
            _tracker.UpdateTrackerMock(secondSelection);

            //Then
            Assert.IsFalse(_tasks[firstSelection].IsPressed());
            Assert.IsFalse(_tasks[firstSelection].IsRunning());
            Assert.IsTrue(_tasks[secondSelection].IsPressed());
            Assert.IsTrue(_tasks[secondSelection].IsRunning());

            //When
            _tracker.UpdateTrackerMock(thirdSelection);

            //Then
            Assert.IsFalse(_tasks[secondSelection].IsPressed());
            Assert.IsFalse(_tasks[secondSelection].IsRunning());
            Assert.IsTrue(_tasks[thirdSelection].IsPressed());
            Assert.IsTrue(_tasks[thirdSelection].IsRunning());
        }

        private Dictionary<string, TrackerTask> _tasks;
        private TrackerMock _tracker;
    }
}
