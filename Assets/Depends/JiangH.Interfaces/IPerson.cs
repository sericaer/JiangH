using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface IPerson
    {
        string name { get; }

        Gender gender { get; }

        ISect sect { get; }

        IOffice office { get; }

        IRegion patrolRegion { get; }

        ITreasury.ChangeSet salary { get; }

        int collectAblity { get; }

        ISect willJoinInSect { get; }

        enum Gender
        {
            male,
            female
        }
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