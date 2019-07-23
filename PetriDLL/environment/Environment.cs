using PetriDLL.entities;
using PetriDLL.entities.items;
using PetriDLL.lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetriDLL
{
    [Serializable]
    public class Environment
    {
        public int Epoch { get; set; } = 1;
        public Map Map { get; set; }

        public Random Rng => new Random();

        public Environment()
        {
            Debug.Log("Initializing env", "ENVIRONMENT");
            Map = new Map(env: this, height: 10, width: 20);
        }

        public void PrintConsoleRepresentation()
        {
            Console.WriteLine("Epoch #" + Epoch);
            Map.PrintConsoleRepresentation();

            Console.WriteLine("Creature count: " + Population(typeof(Creature)));
            foreach (Creature creature in EntitiesOf(typeof(Creature))) {
                Console.WriteLine(" - Creature " + creature.Identifier + ": E" + creature.EnergyRemaining + "/" + creature.EnergyCapacity + " - " + creature.Tile.X + ", " + creature.Tile.Y);
            }
            Console.WriteLine("Flora count: " + Population(typeof(Flora)));
            Console.WriteLine("Food count: " + Population(typeof(Food)));

        }

        #region Spawning
        public void Spawn(Entity entity, int x, int y)
        {
            Debug.Log("Spawning entity " + entity.TextRepresentation + " at " + x + ", " + y, "SPAWN");
            Map.Tile(x, y).Spawn(entity);
        }

        public void Spawn(Entity entity, Tile tile)
        {
            Spawn(entity, tile.X, tile.Y);
        }

        public void Despawn(Entity entity)
        {
            Debug.Log("Despawning entity -- population = " + EntitiesOf(entity.GetType()).Count, "DEATH");

            // TODO This is hilariously thread-unsafe and also just bad in general
            int entity_index = Map.Entities.FindIndex(e => e.Identifier == entity.Identifier);
            if (entity_index > -1)
            {
                Map.Entities.RemoveAt(entity_index);
            } else
            {
                Debug.Log("Trying to despawn an entity that doesn't exist in the entity list", "ERROR");
                Map.Entities.Remove(entity);
                foreach (Organism o in Map.EntitiesOf(typeof(Organism)).FindAll(e => ((Organism)e).EnergyRemaining <= 0))
                {
                    Debug.Log("Doing a manual EnergyRemaining organism cleanup", "SMELL");
                    Map.Entities.Remove(o);
                }
            }

            Debug.Log("New population of " + entity.GetType().ToString() + " = " + EntitiesOf(entity.GetType()).Count, "DEATH");
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
            return EntitiesOf(type_selector).Count<Entity>();
        }

        public List<Entity> EntitiesOf(Type type_selector)
        {
            return Map.Entities.Where(organism => organism.GetType() == type_selector).ToList<Entity>();
        }

    }
}
