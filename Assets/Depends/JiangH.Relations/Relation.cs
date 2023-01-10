using JiangH.Interfaces;
using System;
using System.Collections.Generic;

namespace JiangH.Relations
{
    class Relation : IRelation
    {
        public IEntity from { get; }

        public IEntity to { get; }

        public IRelation.Label label { get; }

        public IEnumerable<object> attributes => _attributes;

        private List<object> _attributes = new List<object>();
        public Relation(IEntity from, IEntity to, IRelation.Label label, params object[] attributes)
        {
            this.from = from;
            this.to = to;
            this.label = label;

            _attributes.AddRange(attributes);
        }
    }
}
