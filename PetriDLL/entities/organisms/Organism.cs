using PetriDLL.entities;
using PetriDLL.entities.decisions.movement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL
{
    public abstract class Organism : Entity
    {
        // Variables to mutate
        public float EnergyCapacity { get; set; } = 100f;
        public float EnergyRemaining { get; set; } = 100f;
        public float MovementCost { get; set; } = 1f;
        public int MovementSpeed { get; set; } = 1; // Tiles that can be moved in a single epoch
        public MovementStyle MovementStrategy { get; set; }

        // Modifiers
        List<Trait> Traits { get; set; } = new List<Trait>();

        public override void Tick()
        {
            base.Tick();
    
            EnergyRemaining -= 1;
        }

        public void MoveTo(Tile destination)
        {
            float cost_to_move = Tile.DistanceTo(destination) * MovementCost;

            Tile.Entities.Remove(this);
            destination.Entities.Add(this);
            Tile = destination;

            EnergyRemaining -= cost_to_move;
            Console.WriteLine("Energy remaining is now " + EnergyRemaining);
        }


        public void CheckDeath()
        {
            Console.WriteLine("Energy remaining: " + EnergyRemaining);
            if (EnergyRemaining <= 0)
            {
                Console.WriteLine("Death!");
                Despawn();
            }
        }
    }
}
