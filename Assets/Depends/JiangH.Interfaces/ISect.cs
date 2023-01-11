using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface ISect
    {
        string name { get; }

        IEnumerable<IPerson> persons { get; }
        IEnumerable<IRegion> regions { get; }

        IRegion location { get; }

        ITreasury treasury { get; }

        IRecruitRequest recruitRequest { get; }

        IEnumerable<IPerson> willJoininPersons { get; }
        interface IRecruitRequest
        {

        }
    }
}
