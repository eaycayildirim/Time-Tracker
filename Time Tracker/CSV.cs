using System;
using System.Collections.Generic;
using System.Text;
using nsButton;
using System.IO;

namespace nsCSV
{
    class CSV
    {
        private List<string> list = new List<string>();
        public void WriteLogsIntoCSV(string log)
        {
            string filePath = "TimeTracker.csv";
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                list = new List<string>(lines);
            }

            list.Add(log);
            File.WriteAllLines(filePath, list);

        }
    }
}
