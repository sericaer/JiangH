using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface ISect
    {
        string name { get; }
        IEnumerable<IRegion> regions { get; }

        IRegion location { get; set; }

        ITreasury treasury { get; }

        void OnDaysInc(int year, int month, int day);
    }
}
