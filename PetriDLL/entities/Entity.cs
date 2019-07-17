using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities
{
    public abstract class Entity
    {
        public int Epoch { get; set; } = 1;

        public char TextRepresentation { get; set; } = '?';

        public Tile Tile { get; set; }

        public virtual void Tick()
        {
            Console.WriteLine("Ticking base Entity class");
            Epoch += 1;
        }

        public virtual void TransformInto(Entity new_entity)
        {
            // TODO
        }

        public void Despawn()
        {
            Tile.Map.Environment.Despawn(this);
        }
    }
}
