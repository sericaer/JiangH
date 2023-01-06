using System.Collections.Generic;
using System.Linq;

namespace JiangH.Interfaces
{
    public interface IRegion
    {
        Coordinate coordinate { get; }

        public string name { get; }
        string image { get; }

        ISect sect { get; }

        IEnumerable<IPerson> patrolers { get; }
        ITreasury.ChangeSet productor { get; }

        int collectRatio { get; }

    }

    //public class TreasuryProductor : ITreasury.ChangeSet
    //{
    //    public string desc { get; set; }
    //    public double value => baseValue * effects.Sum(x => x.value);

    //    public double baseValue { get; set; }
    //    public IEnumerable<IEffect> effects { get; }

    //    public TreasuryProductor(string desc, double baseValue, IEnumerable<IEffect> effects)
    //    {
    //        this.desc = desc;
    //        this.baseValue = baseValue;
    //        this.effects = effects;
    //    }
    //}

    public interface ITerrainMap : IEnumerable<KeyValuePair<Coordinate, TerrainType>>
    {
        int height { get; }
        int width { get; }

        //TerrainType this[Coordinate coord] { get;set; }
    }


    public interface IEffect
    {
        public string desc { get; }
        public double value { get; }
    }

}
