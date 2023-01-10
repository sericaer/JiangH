using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface IRelationDataBase : IEnumerable<IRelation>
    {
        void AddRelation(IEntity from, IEntity to, IRelation.Label label, params object[] attributes);
        void RemoveRelation(IRelation relation);
    }
}