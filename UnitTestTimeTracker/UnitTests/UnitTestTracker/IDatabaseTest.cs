using System;
using System.Collections.Generic;
using nsIDatabase;

namespace nsIDatabaseTest
{
    public class IDatabaseTest : IDatabase
    {
        virtual public string GetDatabaseFilePath()
        {
            throw new Exception();
        }

        virtual public string Read()
        {
            throw new Exception();
        }

        virtual public void Write(string data)
        {
            throw new Exception();
        }

        virtual public void Write(List<string> data)
        {
            throw new Exception();
        }
    }
}
