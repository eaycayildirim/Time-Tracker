using System;
using System.Collections.Generic;
using nsIDatabase;
using nsCSV;
using nsTrackerTask;

namespace nsTracker
{
    public class Tracker
    {
        public Tracker(Dictionary<string, TrackerTask> tasks)
        {
            this._tasks = tasks;
            this._database = new CSV();
        }

        public string GetFilePath()
        {
            return _database.GetDatabaseFilePath();
        }

        public void UpdateTracker(string selection)
        {
            if (_tasks[selection].IsPaused())
                _tasks[selection].Pause();
            else
            {
                UpdatePressedButtons(selection);
                _tasks[selection].Press();
            }
            _database.Write(_tasks[selection].GetProperties());
        }

        public void PauseTheTask(string selection)
        {
            if (_tasks[selection].IsRunning())
            {
                _tasks[selection].Pause();
                _database.Write(_tasks[selection].GetProperties());
            }
        }

        public bool IsTaskJustStarted(string selection)
        {
            return _tasks[selection].IsPressed() && _tasks[selection].GetElapsedTime()=="00:00:00" ? true : false;
        }

        public string GetElapsedTime(TrackerTask task)
        {
            return task.GetElapsedTime();
        }

        public void AddTask(string task)
        {
            _tasks.Add(task, new TrackerTask(task));
        }

        public void RemoveTask(string task)
        {
            _tasks.Remove(task);
        }

        public void ClearTasks()
        {
            _tasks.Clear();
        }

        public Dictionary<string, TrackerTask> GetTasks()
        {
            return _tasks;
        }

        protected void UpdatePressedButtons(string selection)
        {
            foreach (var item in _tasks)
            {
                if (_tasks[item.Key].IsPressed() && selection != item.Key)
                {
                    _tasks[item.Key].Press();
                    _database.Write(_tasks[item.Key].GetProperties());
                }
            }
        }

        private Dictionary<string, TrackerTask> _tasks;
        private IDatabase _database;
    }
}
