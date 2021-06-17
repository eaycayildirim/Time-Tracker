using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTask;
using System.Collections.Generic;
using nsTrackerMock;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TrackerTest
    {
        [TestMethod]
        public void TestPressOneButton()
        {
            //Given
            List<Task> tasks = new List<Task> { new Task("Button1") } ;
            TrackerMock tracker = new TrackerMock(tasks);
            int selection = 0;

            //When
            tracker.UpdatePressedButtonsMock(selection);

            //Then
            Assert.IsTrue(tasks[selection].IsRunning());
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            List<Task> tasks = new List<Task> { new Task("Button1"), new Task("Button2") };
            TrackerMock tracker = new TrackerMock(tasks);
            int firstSelection = 0;
            int secondSelection = 1;

            //When
            tracker.UpdatePressedButtonsMock(firstSelection);

            //Then
            Assert.IsTrue(tasks[firstSelection].IsRunning());

            //When
            tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.IsFalse(tasks[firstSelection].IsRunning());
            Assert.IsTrue(tasks[secondSelection].IsRunning());
        }
        [TestMethod]
        public void TestPressThreeButtons()
        {
            //Given
            List<Task> tasks = new List<Task> { new Task("Button1"), new Task("Button2"), new Task("Button3") };
            TrackerMock tracker = new TrackerMock(tasks);
            int firstSelection = 0;
            int secondSelection = 1;
            int thirdSelection = 2;

            //When
            tracker.UpdatePressedButtonsMock(firstSelection);

            //Then
            Assert.IsTrue(tasks[firstSelection].IsRunning());

            //When
            tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.IsFalse(tasks[firstSelection].IsRunning());
            Assert.IsTrue(tasks[secondSelection].IsRunning());

            //When
            tracker.UpdatePressedButtonsMock(thirdSelection);

            //Then
            Assert.IsFalse(tasks[secondSelection].IsRunning());
            Assert.IsTrue(tasks[thirdSelection].IsRunning());
        }
    }
}
