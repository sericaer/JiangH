using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH.Sects
{
    class Treasury : IComponent, ITreasury
    {
        public int current { get; set; }

        public int surplus => (int)(incomeItems.Sum(x => x.value) - spendItems.Sum(x => x.value));

        public IEnumerable<ITreasury.IIncomeItem> incomeItems { get; }

        public IEnumerable<ITreasury.ISpendItem> spendItems { get; }

        public Treasury(int current, IEnumerable<ITreasury.IIncomeItem> incomeItems, IEnumerable<ITreasury.ISpendItem> spendItems)
        {
            this.current = current;
            this.incomeItems = incomeItems;
            this.spendItems = spendItems;
        }

        public class IncomeItem : ITreasury.IIncomeItem
        {
            public string desc => funcGetDesc();
            public double value => funcCalcValue();

            private Func<double> funcCalcValue;
            private Func<string> funcGetDesc;

            public IncomeItem(Func<double> funcCalcValue, Func<string> funcGetDesc)
            {
                this.funcCalcValue = funcCalcValue;
                this.funcGetDesc = funcGetDesc;
            }
        }

        public class SpendItem : ITreasury.ISpendItem
        {
            public string desc => funcGetDesc();
            public double value => funcCalcValue();

            private Func<double> funcCalcValue;
            private Func<string> funcGetDesc;

            public SpendItem(Func<double> funcCalcValue, Func<string> funcGetDesc)
            {
                this.funcCalcValue = funcCalcValue;
                this.funcGetDesc = funcGetDesc;
            }
        }
    }
}
