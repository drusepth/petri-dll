﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities.decisions.movement
{
    public class RandomMovement : MovementStyle
    {
        public Environment Environment { get; set; }
        public Organism Organism { get; set; }
        public Map Map { get; set; }

        public RandomMovement(Organism organism, Map map)
        {
            Environment = map.Environment;
            Organism = organism;
            Map = map;
        }

        public override void Move() {
 
            if (Organism.MovementCost < Organism.DailyEnergyRemaining)
            {
                Console.WriteLine("Moving");

                int x = Organism.Tile.X, y = Organism.Tile.Y;
                Random rng = Environment.rng;

                Tile new_tile = Map.BoundedTile(
                    x: rng.Next(x - Organism.MovementSpeed, x + Organism.MovementSpeed + 1),
                    y: rng.Next(y - Organism.MovementSpeed, y + Organism.MovementSpeed + 1));

                Console.WriteLine("Moving from " + x + ", " + y + " to " + new_tile.X + ", " + new_tile.Y);

                // Do the move
                // todo abstract this out into tile or organism or map or something
                Organism.Tile.Organisms.Remove(Organism);
                new_tile.Organisms.Add(Organism);
                Organism.Tile = new_tile;
            } else
            {
                Console.WriteLine("Not enough energy to move creature");
            }
        }
    }
}