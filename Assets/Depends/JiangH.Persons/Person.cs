using JiangH.Entities;
using JiangH.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace JiangH.Persons
{
    public partial class Person : Entity, IPerson
    {
        public string name { get; set; }
        public ISect sect => relationsFrom.SingleOrDefault(x => x.label == IRelation.Label.Member)?.to as ISect;
        public IRegion patrolRegion => relationsFrom.SingleOrDefault(x => x.label == IRelation.Label.Patrol)?.to as IRegion;

        public int collectAblity => 20;

        public ITreasury.ChangeSet salary { get; }

        public IOffice office => relationsFrom.SingleOrDefault(x => x.label == IRelation.Label.Member)?.attributes.OfType<IOffice>().SingleOrDefault();

        public ISect willJoinInSect => relationsFrom.SingleOrDefault(x => x.label == IRelation.Label.WillJoinin)?.to as ISect;

        public Person(string name)
        {
            this.name = name;
            this.salary = new ITreasury.ChangeSet(() => 1.0, () => name);
        }
    }
}
