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

        public IEnumerable<IRegion> regions => relations.Where(x => x.label == IRelation.Label.Owner)
            .Select(x => x.getPeer(this))
            .OfType<IRegion>();

        public IRegion location => relations.Where(x => x.label == IRelation.Label.Location)
            .Select(x => x.getPeer(this))
            .OfType<IRegion>()
            .Single();

        public Sect(string name)
        {
            this.name = name;

            var incomeValue = random.Next(0, 10);
            var incomeItems = new List<Treasury.IncomeItem>()
            {
                new Treasury.IncomeItem(() =>
                {
                    return incomeValue;
                },
                ()=>
                {
                    return "DESC";
                })
            };

            var spendValue = random.Next(0, 10);
            var spendItems = new List<Treasury.SpendItem>()
            {
                new Treasury.SpendItem(() =>
                {
                    return spendValue;
                },
                ()=>
                {
                    return "DESC";
                })
            };

            this.components.Add(new Treasury(random.Next(30, 100), incomeItems, spendItems));
        }
    }
}
