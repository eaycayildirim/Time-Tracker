using System;
using System.Collections.Generic;
using System.Text;
using nsTracker;
using nsButton;

namespace nsTrackerMock
{
    public class TrackerMock : Tracker 
    {
        public TrackerMock(List<Button> buttons) : base(buttons) 
        {
            this._buttons = buttons;
        }

        //Not sure about this method.

        public void UpdatePressedButtons(char selection) 
        {
            base.UpdatePressedButtons(selection);
        }

        private List<Button> _buttons;
    }
}
