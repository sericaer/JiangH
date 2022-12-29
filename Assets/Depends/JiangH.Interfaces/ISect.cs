using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface ISect
    {
        string name { get; }
        IEnumerable<IRegion> regions { get; }

        IRegion location { get; }

        ITreasury treasury { get; }
    }
}
