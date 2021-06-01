using System;
using System.Collections.Generic;
using System.Text;
using nsButton;

namespace nsTracker
{
    public class Tracker
    {
        public Tracker(List<Button>buttons)
        {
            this._buttons = buttons;
        }
        private List<Button> _buttons;

        private void Update()
        {
            UpdateTimer(SelectOption());
        }

        public void UpdateTimer(char selection)
        {
            int selectedOption = Int16.Parse(selection.ToString()) - 1;
            for (int i = 0; i < _buttons.Count; i++)
            {
                if(_buttons[i].IsPressed() && selectedOption != i)
                {
                    _buttons[i].Press();
                }
            }
            _buttons[selectedOption].Press();
        }

        private char SelectOption()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                Console.WriteLine((i + 1) + ") Task" + (i + 1));
            }
            char selection = Console.ReadKey().KeyChar;
            return selection;
        }
    }
}
