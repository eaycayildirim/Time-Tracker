using System;
using System.Collections.Generic;
using System.Text;
using nsIDatabaseRead;
using nsIDatabaseWrite;

namespace nsIDatabase
{
    public interface IDatabase : IDatabaseRead, IDatabaseWrite
    {
        public string GetDatabaseFilePath();
    }
}
