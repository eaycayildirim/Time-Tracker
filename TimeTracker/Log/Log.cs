using System;

namespace nsLog
{
    class Log
    {
        public static void Write(string message)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "]: " + message);
        }
    }
}
