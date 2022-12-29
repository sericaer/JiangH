using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Sects
{
    partial class Sect : ISect
    {
        public static Random random = new Random();

        public static Func<ISect, IEnumerable<IRegion>> funcGetRegions { get; set; }

        public string name { get; set; }
        public IEnumerable<IRegion> regions => funcGetRegions(this);
        public ITreasury treasury { get; }

        public IRegion location
        {
            get 
            { 
                return regions.Single(x => x.sectInfo != null && x.sectInfo.isSectLocation); 
            }
            set
            {
                if(!regions.Contains(value))
                {
                    throw new Exception();
                }

                var old = regions.Single(x => x.sectInfo != null && x.sectInfo.isSectLocation);
                if(old == value)
                {
                    return;
                }

                old.sectInfo.isSectLocation = false;
                value.sectInfo.isSectLocation = true;
            }
        }

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

            this.treasury = new Treasury(random.Next(30, 100), incomeItems, spendItems);
        }
    }
}
