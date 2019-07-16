using PetriDLL.entities.decisions.movement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL
{
    public abstract class Organism
    {
        public int Epoch { get; set; } = 1;

        // Variables to mutate
        public float EnergyCapacity { get; set; } = 100f;
        public float EnergyRemaining { get; set; } = 10f;
        public float MovementCost { get; set; } = 1f;
        public int MovementSpeed { get; set; } = 1; // Tiles that can be moved in a single epoch
        public MovementStyle MovementStrategy { get; set; }

        // Modifiers
        List<Trait> Traits { get; set; } = new List<Trait>();

        public char TextRepresentation { get; set; } = '?';

        public Tile Tile { get; set; }

        public virtual void Tick()
        {
            Console.WriteLine("Ticking base Organism class");
            Epoch += 1;
            EnergyRemaining -= 1;
        }

        public void MoveTo(Tile destination)
        {
            float cost_to_move = Tile.DistanceTo(destination) * MovementCost;

            Tile.Organisms.Remove(this);
            destination.Organisms.Add(this);
            Tile = destination;

            EnergyRemaining -= cost_to_move;
            Console.WriteLine("Energy remaining is now " + EnergyRemaining);
        }
    }
}
