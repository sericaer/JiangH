using JiangH.Entities;
using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Regions
{
    partial class Region : Entity, IRegion
    {
        public static Random random = new Random();
        public Coordinate coordinate { get; }

        public string name { get; }

        public string image { get; }

        public ISect sect => relationsTo.Where(x=>x.label == IRelation.Label.Owner).SingleOrDefault()?.getPeer(this) as ISect;

        public TreasuryProductor productor { get; }

        public Region(Coordinate coordinate, TerrainType value)
        {
            this.coordinate = coordinate;
            this.name = $"REGIN({coordinate.x},{coordinate.y})";

            this.productor = new TreasuryProductor()
            {
                desc = name,
                value = random.Next(0, 10)
            };
        }
    }
}
