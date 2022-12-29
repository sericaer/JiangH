using System;

namespace JiangH.Interfaces
{
    public interface IDate
    {
        int year { get; }
        int month { get; }
        int day { get;}

        void DaysInc();
    }

}
