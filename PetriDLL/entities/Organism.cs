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
        public int DailyEnergy { get; set; } = 100;
        public int DailyEnergyRemaining { get; set; } = 100;
        public int MovementCost { get; set; } = 1;
        public int MovementSpeed { get; set; } = 1; // Tiles moved in a single action
        public MovementStyle MovementStrategy { get; set; }

        // Modifiers
        List<Trait> Traits { get; set; } = new List<Trait>();

        public char TextRepresentation { get; set; } = '?';

        public Tile Tile { get; set; }

        public virtual void Tick()
        {
            Console.WriteLine("Ticking base Organism class");
            Epoch += 1;

            DailyEnergyRemaining = DailyEnergy;
        }
    }
}
