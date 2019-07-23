using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.lib
{
    public class Chance
    {
        public static Boolean Percent(int percent_chance)
        {
            // TODO there's probably an off-by-one error somewhere here but I don't really care
            Random rng = new Random();
            return rng.Next(0, 100) <= percent_chance;
        }
    }
}
