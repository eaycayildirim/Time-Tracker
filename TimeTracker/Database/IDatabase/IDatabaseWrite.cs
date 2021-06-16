using System.Collections.Generic;

namespace nsIDatabaseWrite
{
    public interface IDatabaseWrite
    {
        void Write(string data);
        void Write(List<string> data);
    }
}
