using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.lib
{
    public class Debug
    {
        public static void Log(string message, string channel = null)
        {
            Console.WriteLine("[" + channel + "] " + message);
        }
    }
}
