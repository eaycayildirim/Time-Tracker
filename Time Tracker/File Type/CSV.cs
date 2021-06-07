using System;
using System.Collections.Generic;
using System.Text;
using nsButton;
using System.IO;
using nsIDatabaseWrite;

namespace nsCSV
{
    class CSV : IDatabaseWrite
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

        private string _filePath;
    }
}
