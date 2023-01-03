using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface IRelationDataBase : IEnumerable<IRelation>
    {
        void AddRelation(IEntity from, IEntity to, IRelation.Label label);
        void RemoveRelation(IRelation relation);
    }
}