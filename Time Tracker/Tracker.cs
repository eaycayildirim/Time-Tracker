﻿using System;
using System.Collections.Generic;
using System.Text;
using nsButton;
using nsCSV;

namespace nsTracker
{
    public class Tracker
    {
        public Tracker(List<Button>buttons)
        {
            this._buttons = buttons;
        }

        public void Update()
        {
            var selectedOption = SelectOption();
            UpdatePressedButtons(selectedOption);

            CSV csv = new CSV();
            var parsedSelectedOption = ParseCharToInteger(selectedOption);
            var log = _buttons[parsedSelectedOption].ReturnTheLog();
            csv.WriteLogsIntoCSV(log);
        }

        protected void UpdatePressedButtons(char selection)
        {
            int selectedOption = ParseCharToInteger(selection);
            for (int i = 0; i < _buttons.Count; i++)
            {
                if (_buttons[i].IsPressed && selectedOption != i)
                {
                    _buttons[i].Press();
                }
            }
            _buttons[selectedOption].Press();
        }

        private int ParseCharToInteger(char selection)
        {
            int selectedOption = Int16.Parse(selection.ToString()) - 1;
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
    }
}