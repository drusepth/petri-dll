using PetriDLL.lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetriDLL.entities
{
    [Serializable]
    public abstract class Entity
    {
        public Guid Identifier { get; } = Guid.NewGuid();

        public int Epoch { get; set; } = 1;

        public char TextRepresentation { get; set; } = '?';

        public Environment Environment { get; set; }
        public Map Map { get; set; }
        public Tile Tile { get; set; }

        public virtual void Tick()
        {
            Debug.Log("Ticking base Entity class", "ENTITY");
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
