using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL
{
    public class Map
    {
        public Environment Environment { get; set; }

        public int Height { get; set; } = 5;
        public int Width  { get; set; } = 5;
        public List<List<Tile>> Tiles { get; set; } = new List<List<Tile>>();

        // Reference caches
        public List<Organism> Organisms { get; set; } = new List<Organism>();

        public Map(Environment env, int height = 5, int width = 5)
        {
            Environment = env;

            if (height != Height)
            {
                Height = height;
            }

            if (width != Width)
            {
                Width = width;
            }

            // Create the tiles
            Console.WriteLine("Initializing map with Height=" + Height + ", Width=" + Width);
            for (int y = 0; y < Height; y++)
            {
                Tiles.Add(new List<Tile>());
                for (int x = 0; x < Width; x++)
                {
                    Tiles[y].Add(new Tile(x, y, this));
                }
            }
        }

        public Tile Tile(int x, int y)
        {
            // todo bounds checking, error handling, tl;dr boring stuff
            return Tiles[y][x];
        }

        public Tile BoundedTile(int x, int y)
        {
            x = Math.Max(0, x);
            x = Math.Min(x, Width - 1);

            y = Math.Max(0, y);
            y = Math.Min(y, Height- 1);

            return Tile(x, y);
        }

        public Tile RandomTile()
        {
            return Tile(x: Environment.rng.Next(0, Width), y: Environment.rng.Next(0, Height));
        }

        public void Tick()
        {
            Console.WriteLine("Map ticking");
            foreach (Organism organism in Organisms)
            {
                organism.Tick();
            }
        }

        public void PrintConsoleRepresentation()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Tile tile = Tiles[y][x];

                    if (tile.Organisms.Count == 1)
                    {
                        Console.Write("[" + tile.Organisms[0].TextRepresentation + "]");
                    }
                    else if (tile.Organisms.Count > 1)
                    {
                        Console.Write("[" + tile.Organisms.Count + "]");
                    }
                    else
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
