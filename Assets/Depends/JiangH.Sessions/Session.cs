using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Sessions
{
    partial class Session : ISession
    {
        public IDate date { get; private set; }
        public ITerrainMap terrainMap { get; private set; }
        public IEnumerable<IRegion> regions { get; private set; }
        public IEnumerable<ISect> sects { get; private set; }

    }
}
