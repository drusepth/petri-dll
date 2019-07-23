using PetriDLL.entities;
using PetriDLL.entities.decisions.movement;
using PetriDLL.entities.items;
using PetriDLL.entities.organisms.reproduction;
using PetriDLL.lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL
{
    [Serializable]
    public class Creature : Organism
    {
        // Variables to mutate
        float HungerThreshold { get; set; } = 10;
        float EnergyExtractionEfficiency { get; set; } = 90;

        public Creature(Environment env)
        {
            Environment = env;
            Map = env.Map;
 
            MovementStrategy = new RandomMovement(this, env.Map);
            ReproductionStrategy = new MitosisReproduction(this);
        }

        public override void Tick()
        {
            base.Tick();

            Debug.Log("Moving creature in tick...", "MOVEMENT");
            MovementStrategy.Move();

            CheckReproduction();
            CheckFood();
            CheckDeath();
        }

        private void CheckReproduction()
        {
            if (ReproductionStrategy.CanReproduce())
            {
                if (ReproductionStrategy.WillReproduce())
                {
                    ReproductionStrategy.Reproduce();
                }
            }
        }
 
        public void CheckFood()
        {
            List<Entity> food_available = Tile.EntitiesOf(typeof(Food));

            foreach (Food food in food_available.ToArray()) {
                if (EnergyRemaining + HungerThreshold > EnergyCapacity)
                {
                    Debug.Log("Food is available but creature is not hungry.", "EATING");
                    break;
                }

                // Eat it!
                Debug.Log("Eating food", "EATING");
                float energy_from_food = food.EnergyProvided * EnergyExtractionEfficiency;
                EnergyRemaining = Math.Min(EnergyRemaining + energy_from_food, EnergyCapacity);
                food.Despawn();
            }
        }
    }
}
