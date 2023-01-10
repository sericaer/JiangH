using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface IPerson
    {
        string name { get; }

        ISect sect { get; }

        IOffice office { get; }

        IRegion patrolRegion { get; }

        ITreasury.ChangeSet salary { get; }

        int collectAblity { get; }
    }

    public interface IOffice
    {
        enum Authority
        {
            Possessor
        }

        string name { get; }
        IEnumerable<Authority> authorities { get; }
    }
}