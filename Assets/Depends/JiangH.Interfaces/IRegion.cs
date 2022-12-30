using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface IRegion
    {
        Coordinate coordinate { get; }

        public string name { get; }
        string image { get; }

        ISect sect { get; }

        TreasuryProductor productor { get; }

    }

    public class TreasuryProductor : ITreasury.IIncomeItem
    {
        public string desc { get; set; }
        public double value { get; set; }
    }

    public interface ITerrainMap : IEnumerable<KeyValuePair<Coordinate, TerrainType>>
    {
        int height { get; }
        int width { get; }

        //TerrainType this[Coordinate coord] { get;set; }
    }


}
