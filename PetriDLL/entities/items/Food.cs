using PetriDLL.lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities.items
{
    [Serializable]
    public class Food : Item
    {
        // Variables to mutate
        public float EnergyProvided { get; set; } = 10f;
        public float EnergyDecay { get; set; } = 0.5f;
        public int DecayTime { get; set; } = 10;

        public Food() { }

        public override void Tick()
        {
            base.Tick();

            EnergyProvided -= EnergyDecay;

            CheckDeath();
        }

        private void CheckDeath()
        {
            if (Epoch > DecayTime || EnergyProvided <= 0f)
            {
                Debug.Log("Fruit despawn", "DEATH");
                Despawn();
            }
        }
    }
}
