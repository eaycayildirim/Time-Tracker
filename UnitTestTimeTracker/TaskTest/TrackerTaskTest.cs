using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsTrackerTask;
using nsTrackerTaskMock;
using System.Collections.Generic;
using System.Threading;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TrackerTaskTest
    {
        [TestMethod]
        public void Press_TaskIsStarted()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("TEST");

            //When
            trackerTask.Press();

            //Then
            Assert.IsTrue(trackerTask.IsPressed());
            Assert.IsTrue(trackerTask.IsRunning());
        }

        [TestMethod]
        public void Press_TaskIsStopped()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("TEST");

            //When
            trackerTask.Press();
            trackerTask.Press();

            //Then
            Assert.IsFalse(trackerTask.IsPressed());
            Assert.IsFalse(trackerTask.IsRunning());
        }

        [TestMethod]
        public void Pause_TaskIsPaused()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("TEST");

            //When
            trackerTask.Press();
            trackerTask.Pause();

            //Then
            Assert.IsTrue(trackerTask.IsPaused());
        }

        [TestMethod]
        public void Continue_PausedTaskContinues()
        {
            //Given
            TrackerTask trackerTask = new TrackerTask("TEST");

            //When
            trackerTask.Press();
            trackerTask.Pause();
            trackerTask.Continue();

            //Then
            Assert.IsTrue(trackerTask.IsPressed());
            Assert.IsTrue(trackerTask.IsRunning());
        }

        [TestMethod]
        public void GetProperties_AfterOneSecond_Started()
        {
            //Given
            TrackerTaskMock trackerTask = new TrackerTaskMock("TEST");
            var miliseconds = 1000;
            List<string> expected = new List<string> { "TEST", "00:00:01", "Started" };

            //When
            trackerTask.Press();
            Thread.Sleep(miliseconds);

            //Then
            CollectionAssert.AreEquivalent(expected, trackerTask.GetProperties());
        }

        [TestMethod]
        public void GetProperties_AfterThreeSeconds_Stopped()
        {
            //Given
            TrackerTaskMock trackerTask = new TrackerTaskMock("TEST");
            var miliseconds = 3000;
            List<string> expected = new List<string> { "TEST", "00:00:03", "Finished" };

            //When
            trackerTask.Press();
            Thread.Sleep(miliseconds);
            trackerTask.Press();

            //Then
            CollectionAssert.AreEquivalent(expected, trackerTask.GetProperties());
        }

        [TestMethod]
        public void GetProperties_AfterOneSecond_Paused()
        {
            //Given
            TrackerTaskMock trackerTask = new TrackerTaskMock("TEST");
            var miliseconds = 1000;
            List<string> expected = new List<string> { "TEST", "00:00:01", "Paused" };

            //When
            trackerTask.Press();
            Thread.Sleep(miliseconds);
            trackerTask.Pause();

            //Then
            CollectionAssert.AreEquivalent(expected, trackerTask.GetProperties());
        }

        [TestMethod]
        public void GetProperties_AfterTwoSeconds_Continues()
        {
            //Given
            TrackerTaskMock trackerTask = new TrackerTaskMock("TEST");
            var miliseconds = 2000;
            List<string> expected = new List<string> { "TEST", "00:00:02", "Started" };

            //When
            trackerTask.Press();
            Thread.Sleep(miliseconds);
            trackerTask.Pause();
            trackerTask.Continue();

            //Then
            CollectionAssert.AreEquivalent(expected, trackerTask.GetProperties());
        }
    }
}
