using JiangH.Sects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Interfaces
{
    public interface IEntity
    {
        List<IComponent> components { get; }

        List<IRelation> relationsFrom { get; }

        List<IRelation> relationsTo { get; }
    }

    public interface IRelation
    {
        IEntity from { get; }
        IEntity to { get; }

        Label label { get; }

        IEnumerable<object> attributes { get; }

        enum Label
        {
            Owner,
            Location,
            Patrol,
            Constitute,
            TakeOffice,
            Master,
            Member,
            WillJoinin,
        }
    }

    public interface ISystem
    {

    }
}
