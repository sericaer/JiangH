using JiangH.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Relations
{
    public class RelationDataBase : IEnumerable<IRelation>
    {
        private List<IRelation> relationItems = new List<IRelation>();

        internal void RemoveRelation(IRelation relation)
        {
            relationItems.Remove(relation);

            relation.from.relationsFrom.Remove(relation);
            relation.to.relationsTo.Remove(relation);
        }

        internal void AddRelation(IEntity from, IEntity to, IRelation.Label label)
        {
            var relation = new Relation(from, to, label);
            relationItems.Add(relation);

            from.relationsFrom.Add(relation);
            to.relationsTo.Add(relation);
        }

        internal IEnumerable<IRelation> GetRelationsFrom(IEntity from)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<IRelation> GetRelationsTo(IEntity to)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)relationItems).GetEnumerator();
        }

        public IEnumerator<IRelation> GetEnumerator()
        {
            return ((IEnumerable<IRelation>)relationItems).GetEnumerator();
        }
    }
}
