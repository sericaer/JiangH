using JiangH.Dates;
using JiangH.Interfaces;
using JiangH.Messages;
using JiangH.Messages.Interfaces;
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

        public IMessageBus messageBus { get; } = new MessageBus();

        private List<IEntity> entities { get; } = new List<IEntity>();
        private List<ISystem> systems { get; } = new List<ISystem>();

        private RelationDataBase relationDB { get; } = new RelationDataBase();
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

    class RelationDBOperationSystem : MessageIn, ISystem
    {
        public RelationDataBase relationDB { get; set; }

        public RelationDBOperationSystem()
        {
            RegisterMsg<MESSAGE_CHANGE_REGION_OWNER>(OnMessageChangeRegionOwner);
        }

        private void OnMessageChangeRegionOwner(MESSAGE_CHANGE_REGION_OWNER msg)
        {
            var oldRelation = relationDB.Where(x => x.label == IRelation.Label.Owner).SingleOrDefault(x => x.to == msg.region);
            if (oldRelation != null)
            {
                relationDB.RemoveRelation(oldRelation);
            }

            relationDB.AddRelation(msg.owner as IEntity, msg.region as IEntity, IRelation.Label.Owner);
        }
    }
}
