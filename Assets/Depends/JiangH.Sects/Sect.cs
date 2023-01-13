using JiangH.Entities;
using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Sects
{
    partial class Sect : Entity, ISect
    {
        public static Random random = new Random();
        public string name { get; set; }

        public ITreasury treasury => components.OfType<ITreasury>().Single();

        public IEnumerable<IRegion> regions => relationsFrom.Where(x => x.label == IRelation.Label.Owner)
            .Select(x => x.to)
            .OfType<IRegion>();

        public IRegion location => relationsTo.Where(x => x.label == IRelation.Label.Location)
            .Select(x => x.from)
            .OfType<IRegion>()
            .Single();

        public IEnumerable<IPerson> persons => relationsTo.Where(x => x.label == IRelation.Label.Member)
            .Select(x => x.from)
            .OfType<IPerson>();

        public IEnumerable<IPerson> willJoininPersons => relationsTo.Where(x => x.label == IRelation.Label.WillJoinin)
            .Select(x => x.from)
            .OfType<IPerson>();

        public ISect.IRegulation regulation { get; }

        public Sect(string name)
        {
            this.name = name;
            this.regulation = new Regulation();

            this.components.Add(new Treasury(random.Next(30, 100), regions.Select(x=>x.productor), persons.Select(x=>x.salary)));
        }
    }
}
