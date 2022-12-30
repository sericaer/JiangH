using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Entities
{
    public abstract class Entity : IEntity
    {
        public List<IComponent> components { get; } = new List<IComponent>();

        public List<IRelation> relationsFrom { get; } = new List<IRelation>();

        public List<IRelation> relationsTo { get; } = new List<IRelation>();
    }
}
