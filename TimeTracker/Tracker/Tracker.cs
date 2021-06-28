﻿using System;
using System.Collections.Generic;
using nsIDatabase;
using nsCSV;
using nsTask;

namespace nsTracker
{
    public class Tracker
    {
        public Tracker(List<Tasks>tasks)
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

        private List<Tasks> _tasks;
        private IDatabase _database;
    }
}
