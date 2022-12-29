using JiangH.Dates;
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
            public static ISession Build(GMInit gmInit)
            {
                var session = new Session();

                session.date = new Date();

                session.terrainMap = JiangH.Maps.TerrainMap.Builder.Build(gmInit.mapHeight, gmInit.mapWidth);

                session.regions = Region.Builder.BuildCollection(session.terrainMap, gmInit.regionCount);

                session.sects = Sect.Builder.BuildCollection(gmInit.sectCount);

                BuildRelationSect2Reigions(session.sects, session.regions);

                session.date.OnDaysInc = session.OnDaysInc;

                return session;
            }

            private static void BuildRelationSect2Reigions(IEnumerable<ISect> sects, IEnumerable<IRegion> regions)
            {
                Sect.funcGetRegions = (sect) => regions.Where(x => x.sectInfo != null && x.sectInfo.sect == sect);

                Random random = new Random();
                var regionStack = new Queue<IRegion>(regions.OrderBy(_ => random.Next(0, int.MaxValue)));
                foreach (var sect in sects)
                {
                    var region = regionStack.Dequeue();
                    region.sectInfo = new IRegion.SectInfo(sect);
                    region.sectInfo.isSectLocation = true;
                }
            }
        }
    }
}
