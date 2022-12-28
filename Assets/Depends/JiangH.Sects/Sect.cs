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

        public Sect(string name)
        {
            this.name = name;
        }
    }
}
