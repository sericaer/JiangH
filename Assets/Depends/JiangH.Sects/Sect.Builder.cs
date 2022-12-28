using JiangH.Interfaces;
using System.Collections.Generic;

namespace JiangH.Sects
{
    public partial class Sect
    {
        public static class Builder
        {
            public static IEnumerable<ISect> BuildCollection(int count)
            {
                var rslt = new List<ISect>();
                for(int i=0; i<count; i++)
                {
                    rslt.Add(new Sect($"SECT{i}"));
                }

                return rslt;
            }
        }
    }
}
