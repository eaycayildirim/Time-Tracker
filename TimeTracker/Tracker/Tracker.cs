﻿using System;
using System.Collections.Generic;
using nsIDatabase;
using nsCSV;
using nsTrackerTask;

namespace nsTracker
{
    public class Tracker
    {
        public Tracker(List<TrackerTask>tasks)
        {
            this._tasks = tasks;
            this._database = new CSV();
        }

        public string GetFilePath()
        {
            return _database.GetDatabaseFilePath();
        }

        public void UpdatePressedButtons(int selection)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                if(_tasks[i].IsRunning() && selection != i)
                {
                    _tasks[i].Press();
                    _database.Write(_tasks[i].GetProperties());
                }
            }
            _tasks[selection].Press();
            _database.Write(_tasks[selection].GetProperties());
        }

        public string GetElapsedTime(TrackerTask task)
        {
            return task.GetElapsedTime();
        }

        public void AddTask(TrackerTask task)
        {
            _tasks.Add(task);
        }

        public void RemoveTask(TrackerTask task)
        {
            _tasks.Remove(task);
        }

        public void ClearTasks()
        {
            _tasks.Clear();
        }

        public List<TrackerTask> GetTasks()
        {
            return _tasks;
        }

        private List<TrackerTask> _tasks;
        private IDatabase _database;
    }
}
