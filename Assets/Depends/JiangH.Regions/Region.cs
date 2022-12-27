using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Regions
{
    partial class Region : IRegion
    {
        public Coordinate coordinate { get; }

        public string name { get; }

        public string image { get; }

        public Region(Coordinate coordinate, TerrainType value)
        {
            this.coordinate = coordinate;
            this.name = $"({coordinate.x}, {coordinate.y})";
        }
    }
}
