using JiangH.Interfaces;
using System.Collections.Generic;

namespace JiangH.Sects
{
    public partial class Sect
    {
        public static class Builder
        {
            public static IEnumerable<Sect> BuildCollection(int count)
            {
                var rslt = new List<Sect>();
                for(int i=0; i<count; i++)
                {
                    rslt.Add(new Sect($"SECT{i}"));
                }

                return rslt;
            }
        }
    }
}
