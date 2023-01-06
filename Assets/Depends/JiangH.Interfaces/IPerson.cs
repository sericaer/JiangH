namespace JiangH.Interfaces
{
    public interface IPerson
    {
        string name { get; }

        ISect sect { get; }

        IRegion patrolRegion { get; }

        ITreasury.ChangeSet salary { get; }

        int collectAblity { get; }
    }
}