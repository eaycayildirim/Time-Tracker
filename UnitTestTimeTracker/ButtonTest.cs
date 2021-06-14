using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsButton;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class ButtonTest
    {
        [TestMethod]
        public void TestPressTheButtonOnce()
        {
            //Given
            Button button = new Button();
            Stopwatch stopwatch = new Stopwatch();

            //When
            button.Press(stopwatch);

            //Then
            Assert.AreEqual(true, button.IsPressed);
        }
        [TestMethod]
        public void TestPressTheButtonTwice()
        {
            //Given
            Button button = new Button();
            Stopwatch stopwatch = new Stopwatch();

            //When
            button.Press(stopwatch);
            button.Press(stopwatch);

            //Then
            Assert.AreEqual(false, button.IsPressed);
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            Button button1 = new Button();
            Button button2 = new Button();
            Stopwatch stopwatch = new Stopwatch();

            //When
            button1.Press(stopwatch);

            //Then
            Assert.AreEqual(true, button1.IsPressed);

            button2.Press(stopwatch);

            //Then
            Assert.AreEqual(true, button2.IsPressed);
        }
    }
}
