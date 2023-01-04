using System;
using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface ITreasury
    {
        int current { get; set; }
        int surplus { get; }

        IEnumerable<ChangeSet> incomeItems { get; }
        IEnumerable<ChangeSet> spendItems { get; }

        class ChangeSet
        {
            public string desc => funcGetDesc();
            public double value => funcCalcValue();

            private Func<double> funcCalcValue;
            private Func<string> funcGetDesc;

            public ChangeSet(Func<double> funcCalcValue, Func<string> funcGetDesc)
            {
                this.funcCalcValue = funcCalcValue;
                this.funcGetDesc = funcGetDesc;
            }
        }
    }
}