using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsButton;

namespace UnitTestTimeTracker
{
    [TestClass]
    public class UnitTestButton
    {
        [TestMethod]
        public void Press_TheButtonIsPressed()
        {
            //Given
            Button button = new Button();

            //When
            button.Press();

            //Then
            Assert.AreEqual(true, button.IsPressed);
        }
        [TestMethod]
        public void Press_TheButtonIsUnpressed()
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
        public void Press_TheButtonsArePressed()
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
