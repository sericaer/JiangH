using JiangH.Interfaces;
using JiangH.Messages;
using System;

namespace JiangH.Dates
{
    public class Date : MessageOut, IDate
    {
        public int year
        {
            get
            {
                return _year;
            }
            private set
            {
                _year = value;
            }
        }

        public int month
        {
            get
            {
                return _month;
            }
            private set
            {
                _month = value;
                if (_month > 12)
                {
                    year += 1;
                    _month = 1;
                }
            }
        }

        public int day
        {
            get
            {
                return _day;
            }
            private set
            {
                if(_day == value)
                {
                    return;
                }

                _day = value;
                if (_day > 30)
                {
                    month += 1;
                    _day = 1;
                }
            }
        }

        private int _year;
        private int _month;
        private int _day;

        public Date()
        {
            year = 1;
            month = 1;
            day = 1;
        }

        public void DaysInc()
        {
            day++;

            SendMessage(new MESSAGE_DATE_INC()
            {
                day = this.day,
                month = this.month,
                year = this.year
            });
        }
    }
}
