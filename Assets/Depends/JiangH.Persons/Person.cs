using JiangH.Entities;
using JiangH.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace JiangH.Persons
{
    public partial class Person : Entity, IPerson
    {
        public string name { get; set; }
        public ISect sect => relationsTo.Where(x => x.label == IRelation.Label.Owner).SingleOrDefault()?.from as ISect;
        public IRegion patrolRegion => relationsFrom.Where(x => x.label == IRelation.Label.Patrol).SingleOrDefault()?.to as IRegion;

        public int collectAblity => 20;

        public ITreasury.ChangeSet salary { get; }

        public Person(string name)
        {
            this.name = name;
            this.salary = new ITreasury.ChangeSet(() => 1.0, () => name);
        }
    }
}
