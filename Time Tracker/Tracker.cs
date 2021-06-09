using System;
using System.Collections.Generic;
using System.Text;
using nsButton;
using nsLog;
using System.Diagnostics;
using nsElapsedTime;
using nsCSV;

namespace nsTracker
{
    public class Tracker
    {
        public Tracker(List<Button>buttons)
        {
            this._buttons = buttons;
            this._stopwatch = new Stopwatch();
            this._log = new Log(_stopwatch);
            this._csv = new CSV();
        }

        public void Update()
        {
            var selectedOption = ParseCharToInteger(SelectOption())-1;
            UpdatePressedButtons(selectedOption);
        }

        protected void UpdatePressedButtons(int selection)
        {
            string log;
            for (int i = 0; i < _buttons.Count; i++)
            {
                if (_buttons[i].IsPressed && selection != i)
                {
                    _buttons[i].Press(_stopwatch);
                    log = _log.ReturnTheLog(_buttons[i].Name);
                    _csv.Write(log);
                }
            }
            _buttons[selection].Press(_stopwatch);
            log = _log.ReturnTheLog(_buttons[selection].Name);
            _csv.Write(log);
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
        private Stopwatch _stopwatch;
        private Log _log;
        private CSV _csv;
    }
}
