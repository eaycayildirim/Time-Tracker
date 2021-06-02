using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsButton;
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
            List<Button> buttons = new List<Button> { new Button() { Name = "Button1" } };
            TrackerMock tracker = new TrackerMock(buttons);

            //When
            tracker.UpdatePressedButtons('1');

            //Then
            Assert.AreEqual(true, buttons[0].IsPressed);
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            List<Button> buttons = new List<Button> { new Button() { Name = "Button1" }, new Button() { Name = "Button2" } };
            TrackerMock tracker = new TrackerMock(buttons);

            //When
            tracker.UpdatePressedButtons('1');

            //Then
            Assert.AreEqual(true, buttons[0].IsPressed);

            //When
            tracker.UpdatePressedButtons('2');

            //Then
            Assert.AreEqual(false, buttons[0].IsPressed);
            Assert.AreEqual(true, buttons[1].IsPressed);
        }
        [TestMethod]
        public void TestPressThreeButtons()
        {
            //Given
            List<Button> buttons = new List<Button> { new Button() { Name = "Button1" }, new Button() { Name = "Button2" }, new Button() { Name = "Button3" } };
            TrackerMock tracker = new TrackerMock(buttons);

            //When
            tracker.UpdatePressedButtons('1');

            //Then
            Assert.AreEqual(true, buttons[0].IsPressed);

            //When
            tracker.UpdatePressedButtons('2');

            //Then
            Assert.AreEqual(false, buttons[0].IsPressed);
            Assert.AreEqual(true, buttons[1].IsPressed);

            //When
            tracker.UpdatePressedButtons('3');

            //Then
            Assert.AreEqual(false, buttons[1].IsPressed);
            Assert.AreEqual(true, buttons[2].IsPressed);
        }
    }
}
