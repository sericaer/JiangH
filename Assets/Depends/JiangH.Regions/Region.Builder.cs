using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH.Regions
{
    partial class Region
    {
        public static class Builder
        {
            internal static IEnumerable<IRegion> BuildCollection(Dictionary<Coordinate, TerrainType> dictTerrains)
            {
                //var lookup = dictTerrains.ToLookup(x => x.Value);
                //lookup[TerrainType.Plain].Count();

                var rslt = new List<IRegion>();

                //var coord = new Coordinate(0, 0);
                //rslt.Add(new Region(coord, dictTerrains[coord]));

                //coord = new Coordinate(3, 2);
                //rslt.Add(new Region(coord, dictTerrains[coord]));

                var list = dictTerrains.ToList();

                Random random = new Random();
                for (int i = 0; i < list.Count / 100; i++)
                {
                    var index = random.Next(0, list.Count);
                    var pair = list.ElementAt(index);
                    list.RemoveAt(index);

                    rslt.Add(new Region(pair.Key, pair.Value));
                }

                return rslt;
            }
        }
    }
}
