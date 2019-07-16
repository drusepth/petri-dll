using System;
using PetriDLL;

namespace PetriRunner
{
    class Program
    {
        static int MINIMUM_PETRI_POPULATION = 5;
        static Random rng = new Random();

        static void Main(string[] args)
        {
            PetriDLL.Environment petri_dish = new PetriDLL.Environment();

            while (true)
            {
                while (petri_dish.Population() < MINIMUM_PETRI_POPULATION)
                {
                    Creature slime = new Creature(petri_dish);
                    slime.TextRepresentation = 's';
                    petri_dish.Spawn(slime, petri_dish.Map.RandomTile());
                }

                petri_dish.PrintConsoleRepresentation();
                Console.WriteLine("Press any key to tick forward in time.");
                Console.ReadKey();
                Console.WriteLine();

                petri_dish.Tick();
            }

            Console.WriteLine("All done! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
