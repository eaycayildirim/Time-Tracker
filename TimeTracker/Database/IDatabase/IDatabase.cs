using nsIDatabaseRead;
using nsIDatabaseWrite;

namespace nsIDatabase
{
    public interface IDatabase : IDatabaseRead, IDatabaseWrite
    {
        public string GetDatabaseFilePath();
    }
}
