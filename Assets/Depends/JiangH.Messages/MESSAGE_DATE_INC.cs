using JiangH.Interfaces;

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

    public class MESSAGE_ADD_PATROLER_TO_REGION : MESSAGE
    {
        public IPerson patroler;
        public IRegion region;
    }

    public class MESSAGE_REMOVE_PATROLER_FROM_REGION : MESSAGE
    {
        public IPerson patroler;
    }

    public class MESSAGE_CHANGE_PLAYER : MESSAGE
    {
        public IPerson newPlayer;
    }

    public class MESSAGE_PERSON_WILL_JOININ_SECT : MESSAGE
    {
        public IPerson person;
        public ISect sect;
    }

    public class MESSAGE_PERSON_JOININ_SECT : MESSAGE
    {
        public IPerson person;
        public ISect sect;
    }
}
