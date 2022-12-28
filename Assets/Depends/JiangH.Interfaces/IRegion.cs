using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface IRegion
    {
        Coordinate coordinate { get; }

        public string name { get; }
        string image { get; }

        SectInfo sectInfo { get; set; }

        public class SectInfo
        {
            public ISect sect { get; }
            public bool isSectLocation { get; set; }

            public SectInfo(ISect sect)
            {
                this.sect = sect;
                this.isSectLocation = false;
            }
        }
    }

    public interface ITerrainMap : IEnumerable<KeyValuePair<Coordinate, TerrainType>>
    {
        int height { get; }
        int width { get; }

        //TerrainType this[Coordinate coord] { get;set; }
    }


}
