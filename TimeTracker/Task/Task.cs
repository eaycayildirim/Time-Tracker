using System;
using nsElapsedTime;
using nsButton;
using nsLog;
using System.Collections.Generic;

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
            if (this._button.IsPressed)
                this._elapsedTime.Stop();
            else
                this._elapsedTime.Start();

            this._button.Press();
        }

        public List<string> GetStatus()
        {
            if (!_button.IsPressed)
                return new List<string> { this.Name, DateTime.Now.ToString(), _elapsedTime.ReturnElapsedTime(), "Finished"};
            else
                return new List<string> { this.Name, DateTime.Now.ToString(), _elapsedTime.ReturnElapsedTime(), "Started" };
        }

        public string Name { get; }
        private Button _button;
        private ElapsedTime _elapsedTime;

    }
}
