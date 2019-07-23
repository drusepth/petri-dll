using PetriDLL.lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities.organisms.reproduction
{
    // Reproduce an entity by splitting it in half
    [Serializable]
    public class MitosisReproduction : ReproductionStyle
    {
        public Creature Creature { get; set; }
        
        // Mutatable variables
        public float EnergyRequiredToReproduce { get; set; } = 50;
        public int PercentChanceToReproduce { get; set; } = 10;
 
        public MitosisReproduction(Creature creature)
        {
            Creature = creature;
        }

        public override Boolean CanReproduce()
        {
            return Creature.EnergyRemaining > EnergyRequiredToReproduce;
        }

        public override Boolean WillReproduce()
        {
            return Chance.Percent(PercentChanceToReproduce);
        }

        public override Creature Reproduce()
        {
            Debug.Log("Splitting creature via mitosis", "REPRODUCTION");

            // TODO this DeepClone works for now but is going to be a limiting factor as data scales; we should probably
            // just hard-code the properties to clone over... oof.
            Creature clone = Creature.DeepClone<Creature>();

            // Split energy in half
            Debug.Log("Energy pre-split = " + clone.EnergyRemaining, "REPRODUCTION");
            clone.EnergyRemaining /= 2;
            Creature.EnergyRemaining /= 2;
            Debug.Log("Energy post-split = " + clone.EnergyRemaining + " / " + Creature.EnergyRemaining, "REPRODUCTION");

            // TODO mutation

            Creature.Environment.Spawn(clone, clone.Tile);

            return clone;
        }
    }
}
