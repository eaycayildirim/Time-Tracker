using System;
using nsElapsedTime;
using nsButton;
using nsLog;
using System.Collections.Generic;

namespace nsTrackerTask
{
    public class TrackerTask
    {
        public TrackerTask(string nameOfTheTask)
        {
            this._button = new Button();
            this.Name = nameOfTheTask;
            this._elapsedTime = new ElapsedTime();
            Log.Write("The task is created.");
        }

        public bool IsPressed()
        {
            return this._button.IsPressed;
        }

        public bool IsRunning()
        {
            return _elapsedTime.IsRunning();
        }

        public bool IsPaused()
        {
            return !IsRunning() && IsPressed();
        }

        public void Press()
        {
            if (IsPressed())
            {
                this._elapsedTime.Stop();
                this.Status = "Finished";
            }
            else
            {
                this._elapsedTime.Restart();
                this.Status = "Started";
            }

            this._button.Press();
        }

        public void Pause()
        {
            this._elapsedTime.Stop();
            this.Status = "Paused";
        }

        public void Continue()
        {
            this._elapsedTime.Start();
            this.Status = "Continues";
        }

        public string GetElapsedTime()
        {
            return _elapsedTime.ReturnElapsedTime();
        }

        public virtual List<string> GetProperties()
        {
            return new List<string> { this.Name, DateTime.Now.ToString(), GetElapsedTime(), GetStatus() };
        }

        protected string GetStatus()
        {
            return this.Status;
        }

        public string Name { get; }
        public string Status { get; set; }

        private Button _button;
        private ElapsedTime _elapsedTime;

    }
}
