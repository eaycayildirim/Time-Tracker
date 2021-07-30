using System.Collections.Generic;
using nsIDatabase;
using nsTrackerTask;

namespace nsTracker
{
    public class Tracker
    {
        public Tracker(Dictionary<string, TrackerTask> tasks, IDatabase database)
        {
            this._tasks = tasks;
            this._database = database;
        }

        public string GetFilePath()
        {
            return _database.GetDatabaseFilePath();
        }

        public void UpdateTracker(string taskKey)
        {
            if (_tasks[taskKey].IsPaused())
                _tasks[taskKey].Continue();
            else
            {
                UpdatePressedButtons(taskKey);
                _tasks[taskKey].Press();
            }
            _database.Write(_tasks[taskKey].GetProperties());
        }

        public void PauseTheTask(string taskKey)
        {
            if (_tasks[taskKey].IsRunning())
            {
                _tasks[taskKey].Pause();
                _database.Write(_tasks[taskKey].GetProperties());
            }
        }

        public bool IsTaskRunning(string taskKey)
        {
            return _tasks[taskKey].IsPressed() && _tasks[taskKey].IsRunning();
        }

        public bool IsTaskPaused(string taskKey)
        {
            return _tasks[taskKey].IsPaused();
        }

        public bool IsTaskJustStarted(string taskKey)
        {
            return _tasks[taskKey].IsPressed() && _tasks[taskKey].GetElapsedTime()=="00:00:00" ? true : false;
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

        protected void UpdatePressedButtons(string taskKey)
        {
            foreach (var item in _tasks)
            {
                if (_tasks[item.Key].IsPressed() && taskKey != item.Key)
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
