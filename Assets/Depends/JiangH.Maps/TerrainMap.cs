using JiangH.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Maps
{
    partial class TerrainMap : ITerrainMap
    {
        private Dictionary<Coordinate, TerrainType> dict;

        public int height { get; }

        public int width { get; }

        public TerrainMap(int height, int width, Dictionary<Coordinate, TerrainType> dict)
        {
            this.dict = dict;
            this.height = height;
            this.width = width;
        }

        public IEnumerator<KeyValuePair<Coordinate, TerrainType>> GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
