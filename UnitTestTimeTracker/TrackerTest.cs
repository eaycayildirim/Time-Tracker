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
            int selection = 0;

            //When
            tracker.UpdatePressedButtonsMock(selection);

            //Then
            Assert.AreEqual(true, buttons[selection].IsPressed);
        }

        [TestMethod]
        public void TestPressTwoButtons()
        {
            //Given
            List<Button> buttons = new List<Button> { new Button() { Name = "Button1" }, new Button() { Name = "Button2" } };
            TrackerMock tracker = new TrackerMock(buttons);
            int firstSelection = 0;
            int secondSelection = 1;

            //When
            tracker.UpdatePressedButtonsMock(firstSelection);

            //Then
            Assert.AreEqual(true, buttons[firstSelection].IsPressed);

            //When
            tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.AreEqual(false, buttons[firstSelection].IsPressed);
            Assert.AreEqual(true, buttons[secondSelection].IsPressed);
        }
        [TestMethod]
        public void TestPressThreeButtons()
        {
            //Given
            List<Button> buttons = new List<Button> { new Button() { Name = "Button1" }, new Button() { Name = "Button2" }, new Button() { Name = "Button3" } };
            TrackerMock tracker = new TrackerMock(buttons);
            int firstSelection = 0;
            int secondSelection = 1;
            int thirdSelection = 2;

            //When
            tracker.UpdatePressedButtonsMock(firstSelection);

            //Then
            Assert.AreEqual(true, buttons[firstSelection].IsPressed);

            //When
            tracker.UpdatePressedButtonsMock(secondSelection);

            //Then
            Assert.AreEqual(false, buttons[firstSelection].IsPressed);
            Assert.AreEqual(true, buttons[secondSelection].IsPressed);

            //When
            tracker.UpdatePressedButtonsMock(thirdSelection);

            //Then
            Assert.AreEqual(false, buttons[secondSelection].IsPressed);
            Assert.AreEqual(true, buttons[thirdSelection].IsPressed);
        }
    }
}
