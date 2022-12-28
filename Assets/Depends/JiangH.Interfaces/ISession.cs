using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Interfaces
{
    public interface ISession
    {
        Dictionary<Coordinate, TerrainType> dictTerrains { get; }

        ITerrainMap terrainMap { get; }

        IEnumerable<IRegion> regions { get; }

        IEnumerable<ISect> sects { get; }
    }

    public enum TerrainType
    {
        Mount,
        Plain,
        Hill,
    }

    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if(obj is Coordinate)
            {
                var peer = (Coordinate)obj;
                return peer.x == this.x && peer.y == this.y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

       
    }
}
