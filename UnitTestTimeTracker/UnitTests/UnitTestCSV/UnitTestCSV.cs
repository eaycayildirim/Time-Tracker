using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using nsCSVTest;

namespace UnitTestCSV
{
    [TestClass]
    public class UnitTestCSV
    {
        public UnitTestCSV()
        {
            this._database = new CSVTest(_filePath);
        }

        [TestMethod]
        public void Write_WriteSomething()
        {
            //Given
            _database.RemoveFile();
            var expected = "Something";

            //When
            _database.Write(expected);
            var actual = File.ReadAllText(_filePath);

            //Then
            Assert.IsTrue(File.Exists(_filePath));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Write_WriteList()
        {
            //Given
            _database.RemoveFile();
            List<string> input = new List<string> { "Line1", "Line2", "Line3" };
            var expected = "Line1;Line2;Line3;\n";

            //When
            _database.Write(input);
            var actual = File.ReadAllText(_filePath);

            //Then
            Assert.IsTrue(File.Exists(_filePath));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_ReadFile()
        {
            //Given
            var input = "Something";
            _database.Write(input);
            var expected = "";

            //When
            var actual = _database.Read();

            //Then
            Assert.IsTrue(File.Exists(_filePath));
            Assert.AreEqual(expected, actual);

            //Remove
            _database.RemoveFile();
        }

        private CSVTest _database;
        private string _filePath = "TestCSV.csv";
    }
}
