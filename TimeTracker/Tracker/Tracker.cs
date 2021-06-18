using System;
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

        public void Update(int selection)
        {
            //var selectedOption = ConvertSelectedOptionToInteger(SelectOption())-1;
            UpdatePressedButtons(selection);
        }

        protected void UpdatePressedButtons(int selection)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                if(_tasks[i].IsRunning() && selection != i)
                {
                    _tasks[i].Press();
                    _database.Write(_tasks[i].GetStatus());
                }
            }
            _tasks[selection].Press();
            _database.Write(_tasks[selection].GetStatus());
        }

        //private int ConvertSelectedOptionToInteger(char selection)
        //{
        //    int selectedOption = Int16.Parse(selection.ToString());
        //    return selectedOption;
        //}
        //private char SelectOption()
        //{
        //    for (int i = 0; i < _tasks.Count; i++)
        //    {
        //        Console.WriteLine((i + 1) + ") " + _tasks[i].Name);
        //    }
        //    char selection = Console.ReadKey().KeyChar;
        //    Console.WriteLine();
        //    return selection;
        //}

        private List<Tasks> _tasks;
        private IDatabase _database;
    }
}
