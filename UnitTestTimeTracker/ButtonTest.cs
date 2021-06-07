using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsButton;
using System.Collections.Generic;
using nsTrackerMock;

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

            //When
            button.Press();

            //Then
            Assert.AreEqual(true, button.IsPressed);
        }
        [TestMethod]
        public void TestPressTheButtonTwice()
        {
            //Given
            Button button = new Button();

            //When
            button.Press();
            button.Press();

            //Then
            Assert.AreEqual(false, button.IsPressed);
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            Button button1 = new Button();
            Button button2 = new Button();

            //When
            button1.Press();

            //Then
            Assert.AreEqual(true, button1.IsPressed);

            button2.Press();

            //Then
            Assert.AreEqual(true, button2.IsPressed);
        }
    }
}
