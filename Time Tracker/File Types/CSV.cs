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
        private List<string> list = new List<string>();
        public void Write(string data)
        {
            string filePath = "TimeTracker.csv";
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                list = new List<string>(lines);
            }

            list.Add(data);
            File.WriteAllLines(filePath, list);

        }
    }
}
