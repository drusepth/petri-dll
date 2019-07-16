using PetriDLL.entities.decisions.movement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL
{
    public class Creature : Organism
    {

        public Creature(Environment env)
        {
            MovementStrategy = new RandomMovement(this, env.Map);
        }

        public override void Tick()
        {
            base.Tick();

            Console.WriteLine("Moving creature...");
            MovementStrategy.Move();

            CheckDeath();
        }

        public void CheckDeath()
        {
            Console.WriteLine("Energy remaining: " + EnergyRemaining);
            if (EnergyRemaining <= 0)
            {
                Console.WriteLine("Death!");
                Die();
            }
        }

        public void Die()
        {
            Tile.Map.Environment.Despawn(this);
        }
    }
}
