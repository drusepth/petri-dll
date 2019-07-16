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
        }
    }
}
