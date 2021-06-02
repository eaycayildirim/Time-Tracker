using System;
using System.Collections.Generic;
using System.Text;
using nsButton;
using System.IO;

namespace nsCSV
{
    class CSV : Button
    {
        private List<string> list = new List<string>();
        public void WriteLogsIntoCSV()
        {
            //it's not working yet

            string log = ReturnTheLog();
            string filePath = "TimeTracker.csv";

            list.Add(log);
            File.WriteAllLines(filePath, list);

        }
    }
}
