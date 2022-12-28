using JiangH.Interfaces;
using JiangH.Regions;
using JiangH.Sects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH.Sessions
{
    public partial class Session
    {
        public static class Builder
        {
            public static ISession Build()
            {

                var session = new Session();

                session.terrainMap = JiangH.Maps.TerrainMap.Builder.Build(21, 21);

                session.regions = Region.Builder.BuildCollection(session.terrainMap, 10);

                session.sects = Sect.Builder.BuildCollection(session.regions.Count()/2);

                Sect.funcGetRegions = (sect) => session.regions.Where(x => x.sect == sect);

                Random random = new Random();
                var regionStack = new Queue<IRegion>(session.regions.OrderBy(_ => random.Next(0, int.MaxValue)));
                foreach (var sect in session.sects)
                {
                    var region = regionStack.Dequeue();
                    region.sect = sect;
                }

                return session;
            }
        }
    }
}
