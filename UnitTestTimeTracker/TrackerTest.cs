using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsButton;
using System.Collections.Generic;
using nsTracker;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class TrackerTest
    {
        [TestMethod]
        public void TestPressOneButton()
        {
            //Given
            List<Button> buttons = new List<Button> { new Button() { _name = "Button1" } };
            Tracker tracker = new Tracker(buttons);

            //When
            tracker.UpdateTimer('1');

            //Then
            Assert.AreEqual(true, buttons[0].IsPressed());
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            List<Button> buttons = new List<Button> { new Button() { _name = "Button1" }, new Button() { _name = "Button2" } };
            Tracker tracker = new Tracker(buttons);

            //When
            tracker.UpdateTimer('1');

            //Then
            Assert.AreEqual(true, buttons[0].IsPressed());

            //When
            tracker.UpdateTimer('2');

            //Then
            Assert.AreEqual(false, buttons[0].IsPressed());
            Assert.AreEqual(true, buttons[1].IsPressed());
        }
        [TestMethod]
        public void TestPressThreeButtons()
        {
            //Given
            List<Button> buttons = new List<Button> { new Button() { _name = "Button1" }, new Button() { _name = "Button2" }, new Button() { _name = "Button3" } };
            Tracker tracker = new Tracker(buttons);

            //When
            tracker.UpdateTimer('1');

            //Then
            Assert.AreEqual(true, buttons[0].IsPressed());

            //When
            tracker.UpdateTimer('2');

            //Then
            Assert.AreEqual(false, buttons[0].IsPressed());
            Assert.AreEqual(true, buttons[1].IsPressed());

            //When
            tracker.UpdateTimer('3');

            //Then
            Assert.AreEqual(false, buttons[1].IsPressed());
            Assert.AreEqual(true, buttons[2].IsPressed());
        }
    }
}
