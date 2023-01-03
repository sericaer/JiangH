using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Persons
{
    public partial class Person : IPerson, IEntity
    {
        public string name { get; set; }

        public ISect sect => relationsTo.Where(x => x.label == IRelation.Label.Owner).SingleOrDefault()?.to as ISect;

        public IRegion patrolRegion => throw new NotImplementedException();

        public List<IComponent> components { get; } = new List<IComponent>();

        public List<IRelation> relationsFrom { get; } = new List<IRelation>();

        public List<IRelation> relationsTo { get; } = new List<IRelation>();

        public Person(string name)
        {
            this.name = name;
        }
    }
}
