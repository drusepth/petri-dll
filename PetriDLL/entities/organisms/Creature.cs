using PetriDLL.entities;
using PetriDLL.entities.decisions.movement;
using PetriDLL.entities.items;
using PetriDLL.lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL
{
    public class Creature : Organism
    {
        float HungerThreshold { get; set; } = 10;
        float EnergyExtractionEfficiency { get; set; } = 90;

        public Creature(Environment env)
        {
            MovementStrategy = new RandomMovement(this, env.Map);
        }

        public override void Tick()
        {
            base.Tick();

            Debug.Log("Moving creature in tick...", "MOVEMENT");
            MovementStrategy.Move();

            CheckFood();
            CheckDeath();
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
