using System;
using System.Collections.Generic;

namespace PetriDLL
{
    public class Environment
    {
        public int Epoch { get; set; } = 1;
        public Map Map { get; set; }

        public Random Rng { get; set; } = new Random();

        public Environment()
        {
            Console.WriteLine("Initializing env");
            Map = new Map(env: this, height: 10, width: 20);
        }

        public void PrintConsoleRepresentation()
        {
            Console.WriteLine("Epoch #" + Epoch);
            Map.PrintConsoleRepresentation();
        }

        #region Spawning
        public void Spawn(Organism organism, int x, int y)
        {
            Console.WriteLine("Spawning organism " + organism.TextRepresentation + " at " + x + ", " + y);
            Map.Tile(x, y).Spawn(organism);
        }

        public void Spawn(Organism organism, Tile tile)
        {
            Spawn(organism, tile.X, tile.Y);
        }

        public void Despawn(Organism organism)
        {
            Map.Organisms.Remove(organism);
            organism.Tile.Organisms.Remove(organism);
        }
        #endregion

        public void Tick()
        {
            Epoch += 1;

            Map.Tick();
        }

        public int Population()
        {
            return Map.Organisms.Count;
        }
   
    }
}
