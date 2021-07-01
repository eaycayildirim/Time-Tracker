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

        public bool IsRunning()
        {
            return this._button.IsPressed;
        }

        public bool IsPaused() //**
        {
            return !_elapsedTime.IsRunning() && _button.IsPressed ? true : false;
        }

        public void Press()
        {
            if (this._button.IsPressed)
                this._elapsedTime.Stop();
            else
                this._elapsedTime.Restart();

            this._button.Press();
        }

        public void Pause() //**
        {
            if (!IsPaused())
                this._elapsedTime.Stop();
            else
            {
                this._elapsedTime.Start();
                this._button.Press();
            }

        }

        public string GetElapsedTime()
        {
            return _elapsedTime.ReturnElapsedTime();
        }

        public List<string> GetProperties()
        {
            return new List<string> { this.Name, DateTime.Now.ToString(), _elapsedTime.ReturnElapsedTime(), GetStatus() };
        }

        private string GetStatus()
        {
            if (!_elapsedTime.IsRunning() && _button.IsPressed)
                return "Paused";
            else if (_button.IsPressed)
                return "Started";
            else
                return "Finished";
            //return _button.IsPressed ? "Started" : "Finished";
        }

        public string Name { get; }
        private Button _button;
        private ElapsedTime _elapsedTime;

    }
}
