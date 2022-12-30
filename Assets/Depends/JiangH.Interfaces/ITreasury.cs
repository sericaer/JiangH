﻿using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface ITreasury
    {
        int current { get; set; }
        int surplus { get; }

        IEnumerable<IIncomeItem> incomeItems { get; }
        IEnumerable<ISpendItem> spendItems { get; }

        interface IIncomeItem
        {
            string desc { get; }
            double value { get; }
        }

        interface ISpendItem
        {
            string desc { get; }
            double value { get; }
        }

        void OnDaysInc(int year, int month, int day);
    }
}