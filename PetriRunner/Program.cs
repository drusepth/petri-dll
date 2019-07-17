using System;
using PetriDLL;

namespace PetriRunner
{
    class Program
    {
        static int MINIMUM_CREATURE_POPULATION = 10;
        static int MINIMUM_FLORA_POPULATION = 7;
        static Random rng = new Random();

        static void Main(string[] args)
        {
            PetriDLL.Environment petri_dish = new PetriDLL.Environment();

            while (true)
            {
                Console.WriteLine("Creature population: " + petri_dish.Population(typeof(Creature)));
                Console.WriteLine("Flora population: " + petri_dish.Population(typeof(Flora)));

                while (petri_dish.Population(typeof(Creature)) < MINIMUM_CREATURE_POPULATION)
                {
                    Creature slime = new Creature(petri_dish);
                    slime.TextRepresentation = 's';
                    petri_dish.Spawn(slime, petri_dish.Map.RandomTile());
                }

                while (petri_dish.Population(typeof(Flora)) < MINIMUM_FLORA_POPULATION)
                {
                    Flora seedling = new Flora(petri_dish);
                    seedling.TextRepresentation = ';';
                    petri_dish.Spawn(seedling, petri_dish.Map.RandomTile());
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
