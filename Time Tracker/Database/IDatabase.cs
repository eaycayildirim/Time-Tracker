using System;
using System.Collections.Generic;
using System.Text;
using nsIDatabaseRead;
using nsIDatabaseWrite;

namespace nsIDatabase
{
    interface IDatabase : IDatabaseRead, IDatabaseWrite
    {
    }
}
