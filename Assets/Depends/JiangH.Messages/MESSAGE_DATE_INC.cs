﻿using JiangH.Interfaces;

namespace JiangH.Messages
{
    public class MESSAGE_DATE_INC : MESSAGE
    {
        public int day;
        public int year;
        public int month;
    }

    public class MESSAGE_CHANGE_REGION_OWNER : MESSAGE
    {
        public IRegion region;
        public ISect owner;
    }
}
