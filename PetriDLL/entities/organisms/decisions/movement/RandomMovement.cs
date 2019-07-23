using PetriDLL.lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities.decisions.movement
{
    [Serializable]
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
 
            if (Organism.MovementCost < Organism.EnergyRemaining)
            {
                int x = Organism.Tile.X, y = Organism.Tile.Y;
                Random rng = Environment.Rng;

                Tile new_tile = Map.BoundedTile(
                    x: rng.Next(x - Organism.MovementSpeed, x + Organism.MovementSpeed + 1),
                    y: rng.Next(y - Organism.MovementSpeed, y + Organism.MovementSpeed + 1));

                Debug.Log("Moving from " + x + ", " + y + " to " + new_tile.X + ", " + new_tile.Y, "MOVEMENT");
                Organism.MoveTo(new_tile);
            }
            else
            {
                Debug.Log("Not enough energy to move creature", "MOVEMENT");
            }
        }
    }
}
