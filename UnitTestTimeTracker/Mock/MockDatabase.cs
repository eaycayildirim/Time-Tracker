using nsIDatabaseTest;

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

        //public void Write(string data)
        //{
        //    throw new Exception();
        //}

        //public void Write(List<string> data)
        //{
        //    throw new Exception();
        //}
    }
}
