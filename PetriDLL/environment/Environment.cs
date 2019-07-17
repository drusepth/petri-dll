using PetriDLL.entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void Spawn(Entity entity, int x, int y)
        {
            Console.WriteLine("Spawning entity " + entity.TextRepresentation + " at " + x + ", " + y);
            Map.Tile(x, y).Spawn(entity);
        }

        public void Spawn(Entity entity, Tile tile)
        {
            Spawn(entity, tile.X, tile.Y);
        }

        public void Despawn(Entity entity)
        {
            Map.Entities.Remove(entity);
            entity.Tile.Entities.Remove(entity);
        }
        #endregion

        public void Tick()
        {
            Epoch += 1;

            Map.Tick();
        }

        public int Population()
        {
            return Map.Entities.Count;
        }

        public int Population(Type type_selector)
        {
            return Map.Entities.Where(organism => organism.GetType() == type_selector).ToArray<Entity>().Count<Entity>();
        }
   
    }
}
