using nsIDatabaseTest;
using System.Collections.Generic;

namespace nsMockDatabase
{
    public class MockDatabase : IDatabaseTest
    {
        override public string GetDatabaseFilePath()
        {
            return "";
        }

        override public string Read()
        {
            return "";
        }

        override public void Write(string data)
        {
            
        }

        override public void Write(List<string> data)
        {
            
        }
    }
}
