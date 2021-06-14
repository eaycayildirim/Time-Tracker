using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using nsButton;
using nsLog;
using nsIDatabaseWrite;
using nsCSV;

namespace nsTaskTracker
{
    class TaskTracker
    {
        public TaskTracker()
        {
            this._stopwatch = new Stopwatch();
            this._log = new Log();
            this._database = new CSV();
        }

        public void Track(List<Button> buttons, int selection)
        {
            string log;
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].IsPressed && selection != i)
                {
                    buttons[i].Press(_stopwatch);
                    log = buttons[i].Name + _log.ReturnTheLog(_stopwatch);
                    _database.Write(log);
                }
            }
            buttons[selection].Press(_stopwatch);
            log = buttons[selection].Name + _log.ReturnTheLog(_stopwatch);
            _database.Write(log);
        }

        private Stopwatch _stopwatch;
        private Log _log;
        private IDatabaseWrite _database;
    }
}
