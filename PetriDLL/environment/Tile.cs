using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Map Map { get; set; }
        // TODO Z

        public List<Organism> Organisms { get; set; } = new List<Organism>();

        public Tile(int x, int y, Map back_reference)
        {
            X = x;
            Y = y;

            Map = back_reference;
        }

        public void Spawn(Organism organism)
        {
            Organisms.Add(organism);
            Map.Organisms.Add(organism);
            Console.WriteLine("Map now holds " + Map.Organisms.Count + " organisms.");
            organism.Tile = this;

            Console.WriteLine("Tile " + X + ", " + Y + " now has " + Organisms.Count + " organism(s)");
        }

        public float DistanceTo(Tile other_tile)
        {
            // todo decide tile or crow distance
            return Math.Abs(X - other_tile.X) + Math.Abs(Y - other_tile.Y);
        }
    }
}
