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

        public bool IsFileLocked() //**
        {
            bool blnReturn = false;
            try
            {
                FileStream fs = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                fs.Close();
            }
            catch (IOException ex)
            {
                blnReturn = true;
            }
            return blnReturn;
        }

        private string _filePath;
        private char _seperator = ';';
    }
}
