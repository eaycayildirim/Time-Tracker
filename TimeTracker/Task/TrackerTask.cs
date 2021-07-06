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
            return _elapsedTime.IsRunning() ? true : false;
        }

        public bool IsPaused()
        {
            return !IsRunning() && IsPressed() ? true : false;
        }

        public void Press()
        {
            if (IsPressed())
                this._elapsedTime.Stop();
            else
                this._elapsedTime.Restart();

            this._button.Press();
        }

        public void Pause()
        {
            if (IsPaused())         //im using IsPaused() twice
                this._elapsedTime.Start();
            else
                this._elapsedTime.Stop();
        }

        public string GetElapsedTime()
        {
            return _elapsedTime.ReturnElapsedTime();
        }

        public List<string> GetProperties()
        {
            return new List<string> { this.Name, DateTime.Now.ToString(), GetElapsedTime(), GetStatus() };
        }

        private string GetStatus()
        {
            if (IsPaused())
                return "Paused";
            else if (_button.IsPressed)
                return "Started";
            else
                return "Finished";
        }

        public string Name { get; }
        private Button _button;
        private ElapsedTime _elapsedTime;

    }
}
