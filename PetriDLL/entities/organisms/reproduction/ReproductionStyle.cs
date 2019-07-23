using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities.organisms.reproduction
{
    [Serializable]
    public abstract class ReproductionStyle
    {
        public abstract Boolean CanReproduce();
        public abstract Boolean WillReproduce();
        public abstract Creature Reproduce();
    }
}
