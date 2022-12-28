using JiangH.Interfaces;
using System;
using System.Collections.Generic;

namespace JiangH.Maps
{
    public partial class TerrainMap
    {
        public static class Builder
        {
            public static ITerrainMap Build(int height, int width)
            {
                var random = new Random();

                var values = Enum.GetValues(typeof(TerrainType));

                var dict = new Dictionary<Coordinate, TerrainType>();

                for (int x = width/2*-1; x < width; x++)
                {
                    for (int y = height / 2 * -1; y < height; y++)
                    {
                        dict.Add(new Coordinate(x,y), (TerrainType)values.GetValue(random.Next(values.Length)));
                    }
                }

                var rslt = new TerrainMap(height, width, dict);

                return rslt;
            }
        }
    }
}
