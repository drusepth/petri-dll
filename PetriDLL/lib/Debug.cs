using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.lib
{
    public class Debug
    {
        public static void Log(string message, string channel = null)
        {
            List<string> active_channels = new List<string>()
            {
                null,
                "CREATURE",
                "SPAWN",
                "FOOD",
                "DEATH",
                "MAP",
                "ENVIRONMENT"
            };

            if (active_channels.IndexOf(channel) > -1)
            {
                Console.WriteLine("[" + channel + "] " + message);
            }
        }
    }
}
