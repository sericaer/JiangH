using JiangH.Dates;
using JiangH.Interfaces;
using JiangH.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Sessions
{
    partial class Session : ISession
    {
        public IDate date { get; private set; }
        public ITerrainMap terrainMap { get; private set; }
        public IEnumerable<IRegion> regions { get; private set; }
        public IEnumerable<ISect> sects { get; private set; }

        private TreasuryMgr treasuaryMgr { get; } = new TreasuryMgr();
        private MessageBus messageBus { get; } = new MessageBus();

        public void OnDaysInc(int year, int month, int day)
        {
            foreach(var sect in sects)
            {
                sect.OnDaysInc(year, month, day);
            }
        }
    }

    class TreasuryMgr : MessageInOut
    {
        public IEnumerable<ITreasury> items { get; set; }

        public TreasuryMgr()
        {
            RegisterMsg<MESSAGE_DATE_INC>(OnMessageDateInc);
        }

        void OnMessageDateInc(MESSAGE_DATE_INC msg)
        {
            if(msg.day == 1)
            {
                foreach(var treasury in items)
                {
                    treasury.current += treasury.surplus;
                }
            }
        }
    }
}
