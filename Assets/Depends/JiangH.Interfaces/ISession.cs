using JiangH.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Interfaces
{
    public interface ISession
    {
        IPerson player { get; set; }
        IDate date { get; }
        ITerrainMap terrainMap { get; }
        IEnumerable<IRegion> regions { get; }
        IEnumerable<ISect> sects { get; }
        IEnumerable<IPerson> persons { get; }
        IMessageBus messageBus { get; }
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

    public class GMInit
    {
        public int mapWidth { get; internal set; }
        public int mapHeight { get; internal set; }
        public int regionCount { get; internal set; }
        public int sectCount { get; internal set; }
        public int personCount { get; internal set; }
    }
}
