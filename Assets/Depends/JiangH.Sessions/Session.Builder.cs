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

                Random random = new Random();

                Array values = Enum.GetValues(typeof(TerrainType));

                var session = new Session();
                session.dictTerrains = Enumerable.Range(-10, 21)
                    .SelectMany(x => Enumerable.Range(-10, 21).Select(y => new Coordinate(x, y)))
                    .ToDictionary(k => k, v => (TerrainType)values.GetValue(random.Next(values.Length)));

                session.regions = Region.Builder.BuildCollection(session.dictTerrains);

                session.sects = Sect.Builder.BuildCollection(session.regions.Count()/2);

                Sect.funcGetRegions = (sect) => session.regions.Where(x => x.sect == sect);

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
