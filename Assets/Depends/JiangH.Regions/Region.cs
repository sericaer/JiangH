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

        public ISect sect => relationsTo.Where(x=>x.label == IRelation.Label.Owner).SingleOrDefault(x=>x.to == this)?.from as ISect;
        public IEnumerable<IPerson> patrolers => relationsTo.Where(x => x.label == IRelation.Label.Patrol).Select(x => x.from).OfType<IPerson>();
        public int collectRatio => patrolers.Sum(x => x.collectAblity);

        public ITreasury.ChangeSet productor { get; }

        public Region(Coordinate coordinate, TerrainType value)
        {
            this.coordinate = coordinate;
            this.name = $"REGIN({coordinate.x},{coordinate.y})";

            var productorValue = random.Next(10, 20);
            this.productor = new ITreasury.ChangeSet(()=> productorValue * collectRatio / 100, () => name);
        }
    }

    //public class EffectDynamic : IEffect
    //{
    //    public string desc { get; }

    //    public double value => funcCalcValue();

    //    private Func<double> funcCalcValue;

    //    public EffectDynamic(string desc, Func<double> funcCalcValue)
    //    {
    //        this.desc = desc;
    //        this.funcCalcValue = funcCalcValue;
    //    }
    //}
}
