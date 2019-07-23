using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities.decisions.movement
{
    [Serializable]
    public abstract class MovementStyle
    {
        public abstract void Move();
    }

}
