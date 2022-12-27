using JiangH.Interfaces;
using JiangH.Regions;
using System;
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

                return session;
            }
        }
    }
}
