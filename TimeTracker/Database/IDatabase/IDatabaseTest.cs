using System;
using System.Collections.Generic;
using nsIDatabase;

namespace nsIDatabaseTest
{
    public class IDatabaseTest : IDatabase
    {
        public string GetDatabaseFilePath()
        {
            throw new Exception();
        }

        public string Read()
        {
            throw new Exception();
        }

        public void Write(string data)
        {
            throw new Exception();
        }

        public void Write(List<string> data)
        {
            throw new Exception();
        }
    }
}
