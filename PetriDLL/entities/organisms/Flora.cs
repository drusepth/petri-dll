using PetriDLL.entities.items;
using PetriDLL.lib;
using System;

namespace PetriDLL
{
    public class Flora : Organism
    {
        // Variables to mutate
        public int TimeToMature { get; set; } = 10;
        public float PhotosynthesisEfficiency { get; set; } = 5f; // Energy to passively gain each epoch (todo when in sunlight)
        public int FoodProductionTime { get; set; } = 10;
        public float FoodProductionEnergyCost { get; set; } = 10f;
        public float FoodEnergyProvided { get; set; } = 10f;

        public Flora(Environment env)
        {
            EnergyRemaining = EnergyCapacity;
        }

        public override void Tick()
        {
            base.Tick();

            Photosynthesize();

            if (Epoch == TimeToMature)
            {
                TextRepresentation = 'T';
            }

            if (Epoch % FoodProductionTime == 0 && EnergyRemaining > FoodProductionEnergyCost && Epoch > TimeToMature)
            {
                ProduceFruit();
            }
        }

        public void Photosynthesize()
        {
            EnergyRemaining += Math.Min(EnergyCapacity, EnergyRemaining + PhotosynthesisEfficiency);
        }

        public void ProduceFruit()
        {
            EnergyRemaining -= FoodProductionEnergyCost;

            Console.WriteLine("Producing fruit");
            Food fruit = new Food {
                EnergyProvided = FoodEnergyProvided,
                TextRepresentation = 'o'
            };

            Debug.Log("Spawning a fruit", "SPAWN");
            Tile.Map.Environment.Spawn(fruit, Tile);
        }
    }
}
