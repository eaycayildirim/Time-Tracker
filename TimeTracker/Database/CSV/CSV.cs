using System;
using System.Collections.Generic;
using System.Text;
using nsButton;
using System.IO;
using nsIDatabase;

namespace nsCSV
{
    class CSV : IDatabase
    {
        public CSV()
        {
            this._filePath = "TimeTracker.csv";
        }
        public CSV(string filePath)
        {
            this._filePath = filePath;
        }

        public void Write(string data)
        {
            File.AppendAllText(_filePath, data);
        }

        public string Read()
        {
            return "";
        }

        private string _filePath;
    }
}
