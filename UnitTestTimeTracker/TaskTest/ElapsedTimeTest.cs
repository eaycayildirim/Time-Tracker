using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsElapsedTime;
using System.Diagnostics;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class ElapsedTimeTest
    {
        [TestMethod]
        public void Start_ElapsedTimeIsRunning_True()
        {
            //Given
            ElapsedTime elapsedTime = new ElapsedTime();

            //When
            elapsedTime.Start();

            //Then
            Assert.AreEqual(true, elapsedTime.IsRunning());
        }

        [TestMethod]
        public void Stop_ElapsedTimeIsRunning_False()
        {
            //Given
            ElapsedTime elapsedTime = new ElapsedTime();

            //When
            elapsedTime.Stop();

            //Then
            Assert.AreEqual(false, elapsedTime.IsRunning());
        }
    }
}
