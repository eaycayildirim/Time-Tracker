using System;
using System.Collections.Generic;
using System.Text;
using nsButton;
using nsTaskTracker;

namespace nsTracker
{
    public class Tracker
    {
        public Tracker(List<Button>buttons)
        {
            this._buttons = buttons;
            this._tracker = new TaskTracker();
        }

        public void Update()
        {
            var selectedOption = ParseCharToInteger(SelectOption())-1;
            UpdatePressedButtons(selectedOption);
        }

        protected void UpdatePressedButtons(int selection)
        {
            _tracker.Track(_buttons, selection);
        }

        private int ParseCharToInteger(char selection)
        {
            int selectedOption = Int16.Parse(selection.ToString());
            return selectedOption;
        }
        private char SelectOption()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + _buttons[i].Name);
            }
            char selection = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return selection;
        }

        private List<Button> _buttons;
        private TaskTracker _tracker;
    }
}
