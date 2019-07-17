using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities.items
{
    public class Food : Item
    {
        // Variables to mutate
        public float EnergyProvided { get; set; } = 10f;
        public int DecayTime { get; set; } = 10;

        public Food() { }

        public override void Tick()
        {
            base.Tick();

            CheckDeath();
        }

        private void CheckDeath()
        {
            if (Epoch > DecayTime)
            {
                Despawn();
            }
        }
    }
}
