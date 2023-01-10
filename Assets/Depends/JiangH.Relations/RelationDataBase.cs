using JiangH.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Relations
{
    public class RelationDataBase : IRelationDataBase
    {
        private List<IRelation> relationItems = new List<IRelation>();

        public void RemoveRelation(IRelation relation)
        {
            relationItems.Remove(relation);

            relation.from.relationsFrom.Remove(relation);
            relation.to.relationsTo.Remove(relation);
        }

        public void AddRelation(IEntity from, IEntity to, IRelation.Label label, params object[] attributes)
        {
            var relation = new Relation(from, to, label, attributes);
            relationItems.Add(relation);

            from.relationsFrom.Add(relation);
            to.relationsTo.Add(relation);
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
