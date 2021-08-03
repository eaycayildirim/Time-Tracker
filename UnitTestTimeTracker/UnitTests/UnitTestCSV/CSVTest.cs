using System.IO;
using nsCSV;

namespace nsCSVTest
{
    public class CSVTest : CSV
    {
        public CSVTest(string filePath) : base(filePath)
        {
            this._filePath = filePath;
        }

        ~CSVTest()
        {
            if (File.Exists(_filePath))
                RemoveFile();
        }

        public void RemoveFile()
        {
            File.Delete(_filePath);
        }

        private string _filePath;
    }
}
