using System;
using System.Collections.Generic;
using System.Text;
using nsElapsedTime;
using nsButton;
using nsLog;

namespace nsTask
{
    public class Task
    {
        public Task(string nameOfTheTask)
        {
            this._button = new Button();
            this.Name = nameOfTheTask;
            this._elapsedTime = new ElapsedTime();
            Log.Write("The task is created.");
        }

        public bool IsRunning()
        {
            return this._button.IsPressed;
        }

        public void Press()
        {
            if (_button.IsPressed)
            {

            }
        }

        public string GetStatus()
        {
            if(_button.IsPressed)
                return ";" + DateTime.Now + ";" + _elapsedTime.ReturnElapsedTime() + "; Finished" + "\n";
            else
                return ";" + DateTime.Now + "; Started" + "\n";
        }

        public string Name { get; }
        private Button _button;
        private ElapsedTime _elapsedTime;

    }
}
