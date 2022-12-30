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

        IEntity getPeer(IEntity from);

        Label label { get; }

        enum Label
        {
            Owner,
            Location,
        }
    }

    public interface ISystem
    {

    }
}
