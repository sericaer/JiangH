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
        public static Func<ISect, IEnumerable<IRegion>> funcGetRegions { get; set; }

        public string name { get; set; }
        public IEnumerable<IRegion> regions => funcGetRegions(this);

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
        }
    }
}
