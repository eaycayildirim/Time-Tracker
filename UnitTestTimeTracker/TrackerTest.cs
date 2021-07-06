using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
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
            List<TrackerTask> tasks = new List<TrackerTask> { new TrackerTask("Button1") } ;
            TrackerMock tracker = new TrackerMock(tasks);
            int selection = 0;

            //When
            tracker.UpdatePressedButtonsMock(selection);

            //Then
            Assert.IsTrue(tasks[selection].IsPressed());
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            List<TrackerTask> tasks = new List<TrackerTask> { new TrackerTask("Button1"), new TrackerTask("Button2") };
            TrackerMock tracker = new TrackerMock(tasks);
            int firstSelection = 0;
            int secondSelection = 1;

            //When
            tracker.UpdatePressedButtonsMock(firstSelection);

            //Then
            Assert.IsTrue(tasks[firstSelection].IsPressed());

            //When
            tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.IsFalse(tasks[firstSelection].IsPressed());
            Assert.IsTrue(tasks[secondSelection].IsPressed());
        }
        [TestMethod]
        public void TestPressThreeButtons()
        {
            //Given
            List<TrackerTask> tasks = new List<TrackerTask> { new TrackerTask("Button1"), new TrackerTask("Button2"), new TrackerTask("Button3") };
            TrackerMock tracker = new TrackerMock(tasks);
            int firstSelection = 0;
            int secondSelection = 1;
            int thirdSelection = 2;

            //When
            tracker.UpdatePressedButtonsMock(firstSelection);

            //Then
            Assert.IsTrue(tasks[firstSelection].IsPressed());

            //When
            tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.IsFalse(tasks[firstSelection].IsPressed());
            Assert.IsTrue(tasks[secondSelection].IsPressed());

            //When
            tracker.UpdatePressedButtonsMock(thirdSelection);

            //Then
            Assert.IsFalse(tasks[secondSelection].IsPressed());
            Assert.IsTrue(tasks[thirdSelection].IsPressed());
        }
    }
}
