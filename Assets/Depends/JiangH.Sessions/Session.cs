using JiangH.Dates;
using JiangH.Interfaces;
using JiangH.Messages;
using JiangH.Relations;
using JiangH.Sects;
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
        public IEnumerable<IRegion> regions => entities.OfType<IRegion>();
        public IEnumerable<ISect> sects => entities.OfType<ISect>();

        private List<IEntity> entities { get; } = new List<IEntity>();
        private List<ISystem> systems { get; } = new List<ISystem>();

        private RelationDataBase relationDB { get; } = new RelationDataBase();

        private MessageBus messageBus { get; } = new MessageBus();
    }


    class TreasurySystem : MessageInOut, ISystem
    {
        public IEnumerable<ITreasury> items { get; set; }

        public TreasurySystem()
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
