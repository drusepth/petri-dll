using PetriDLL.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetriDLL
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Map Map { get; set; }
        // TODO Z

        public List<Entity> Entities { get; set; } = new List<Entity>();

        public Tile(int x, int y, Map back_reference)
        {
            X = x;
            Y = y;

            Map = back_reference;
        }

        public void Spawn(Entity entity)
        {
            Entities.Add(entity);
            Map.Entities.Add(entity);
            Console.WriteLine("Map now holds " + Map.Entities.Count + " entities.");
            entity.Tile = this;

            Console.WriteLine("Tile " + X + ", " + Y + " now has " + Entities.Count + " organism(s)");
        }

        public float DistanceTo(Tile other_tile)
        {
            // todo decide tile or crow distance
            return Math.Abs(X - other_tile.X) + Math.Abs(Y - other_tile.Y);
        }

        public List<Entity> EntitiesOf(Type type_selector)
        {
            return Entities.Where(organism => organism.GetType() == type_selector).ToList<Entity>();
        }
    }
}
