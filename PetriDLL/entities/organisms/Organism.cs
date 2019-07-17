using PetriDLL.entities;
using PetriDLL.entities.decisions.movement;
using PetriDLL.lib;
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
            Debug.Log("Energy remaining after movement is now " + EnergyRemaining, "MOVEMENT");
        }

        public void CheckDeath()
        {
            if (EnergyRemaining <= 0)
            {
                Debug.Log("Creature death!", "CREATURE");
                Despawn();
            }
        }
    }
}
