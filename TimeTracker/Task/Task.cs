using System;
using nsElapsedTime;
using nsButton;
using nsLog;
using System.Collections.Generic;

namespace nsTask
{
    public class Tasks
    {
        public Tasks(string nameOfTheTask)
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
            if (this._button.IsPressed)
                this._elapsedTime.Stop();
            else
                this._elapsedTime.Start();

            this._button.Press();
        }

        public List<string> GetProperties()
        {
            return new List<string> { this.Name, DateTime.Now.ToString(), _elapsedTime.ReturnElapsedTime(), GetStatus() };
        }

        private string GetStatus()
        {
            return _button.IsPressed ? "Started" : "Finished";
        }

        public string Name { get; }
        private Button _button;
        private ElapsedTime _elapsedTime;

    }
}
