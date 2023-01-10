using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using nsIDatabase;
using static System.Net.Mime.MediaTypeNames;

namespace nsCSV
{
    public class CSV : IDatabase
    {
        public CSV()
        {
            this._filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\\TimeTracker.csv";
        }
        public CSV(string filePath)
        {
            this._filePath = filePath;
        }

        public void Write(string data)
        {
            File.AppendAllText(this._filePath, data);
        }

        public void Write(List<string> list)
        {
            foreach (var item in list)
            {
                Write(item + _seperator);
            }
            Write("\n");
        }

        public string Read()
        {
            return "";
        }

        public string GetDatabaseFilePath()
        {
            return _filePath;
        }

        private string _filePath;
        private char _seperator = ';';
    }
}
