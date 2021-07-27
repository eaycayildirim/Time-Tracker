using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using nsElapsedTime;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class ElapsedTimeTest
    {
        [TestMethod]
        public void Start_ElapsedTimeIsRunning()
        {
            //Given
            ElapsedTime elapsedTime = new ElapsedTime();
            var miliseconds = 1000;
            var actual = "00:00:01";

            //When
            elapsedTime.Start();
            Thread.Sleep(miliseconds);

            //Then
            Assert.AreEqual(elapsedTime.ReturnElapsedTime(), actual);
            Assert.IsTrue(elapsedTime.IsRunning());
        }

        [TestMethod]
        public void Restart_ElapsedTimeIsRestarted()
        {
            //Given
            ElapsedTime elapsedTime = new ElapsedTime();
            var miliseconds = 2000;
            var actual = "00:00:00";

            //When
            elapsedTime.Start();
            Thread.Sleep(miliseconds);
            elapsedTime.Restart();

            //Then
            Assert.AreEqual(elapsedTime.ReturnElapsedTime(), actual);
            Assert.IsTrue(elapsedTime.IsRunning());
        }

        [TestMethod]
        public void Stop_ElapsedTimeIsRunning()
        {
            //Given
            ElapsedTime elapsedTime = new ElapsedTime();
            var miliseconds = 3000;
            var actual = "00:00:03";

            //When
            elapsedTime.Start();
            Thread.Sleep(miliseconds);
            elapsedTime.Stop();

            //Then
            Assert.AreEqual(elapsedTime.ReturnElapsedTime(), actual);
            Assert.IsFalse(elapsedTime.IsRunning());
        }
    }
}
