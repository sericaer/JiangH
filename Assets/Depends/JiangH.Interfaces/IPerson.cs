﻿namespace JiangH.Interfaces
{
    public interface IPerson
    {
        string name { get; }

        ISect sect { get; }

        IRegion patrolRegion { get; }
    }
}