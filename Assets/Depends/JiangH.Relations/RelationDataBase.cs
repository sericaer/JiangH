using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Relations
{
    public class RelationDataBase
    {
        private List<IRelation> relationItems = new List<IRelation>();
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
    }
}
