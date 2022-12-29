using JiangH.Interfaces;
using System;

namespace JiangH.Relations
{
    class Relation : IRelation
    {
        public Relation(IEntity from, IEntity to, IRelation.Label label)
        {
            this.from = from;
            this.to = to;
            this.label = label;
        }

        public IEntity from { get; }

        public IEntity to { get; }

        public IRelation.Label label { get; }

        public IEntity getPeer(IEntity p1)
        {
            if (from == p1)
            {
                return to;
            }
            else if (to == p1)
            {
                return from;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
