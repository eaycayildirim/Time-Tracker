using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
using nsTrackerTaskMock;
using System.Diagnostics;
using System.Collections.Generic;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TrackerTaskTest
    {
        [TestMethod]
        public void Press_TaskIsStarted_True()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("EAT");

            //When
            trackerTask.Press();

            //Then
            Assert.IsTrue(trackerTask.IsPressed());
            Assert.IsTrue(trackerTask.IsRunning());
        }

        [TestMethod]
        public void Press_TaskIsStopped_True()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("EAT");

            //When
            trackerTask.Press();
            trackerTask.Press();

            //Then
            Assert.IsFalse(trackerTask.IsPressed());
            Assert.IsFalse(trackerTask.IsRunning());
        }

        [TestMethod]
        public void Pause_TaskIsPaused_True()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("EAT");

            //When
            trackerTask.Press();
            trackerTask.Pause();

            //Then
            Assert.IsTrue(trackerTask.IsPressed());
            Assert.IsFalse(trackerTask.IsRunning());
        }

        [TestMethod]
        public void Pause_PausedTaskContinues_True()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("EAT");

            //When
            trackerTask.Press();
            trackerTask.Pause();
            trackerTask.Pause();

            //Then
            Assert.IsTrue(trackerTask.IsPressed());
            Assert.IsTrue(trackerTask.IsRunning());
        }

        [TestMethod]
        public void IsPaused_TaskIsPaused_True()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("EAT");

            //When
            trackerTask.Press();
            trackerTask.Pause();

            //Then
            Assert.AreEqual(true, trackerTask.IsPaused());
        }

        [TestMethod]
        public void TestGetProperties()     //**??
        {
            //Given
            TrackerTaskMock trackerTask = new TrackerTaskMock("EAT");
            List<string> expected = new List<string> { "EAT", "00:00:00", "Started" };

            //When
            trackerTask.Press();

            //Then
            CollectionAssert.AreEquivalent(expected, trackerTask.GetProperties());
        }
    }
}
