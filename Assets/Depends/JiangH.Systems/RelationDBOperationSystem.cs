using JiangH.Interfaces;
using JiangH.Messages;
using System.Linq;

namespace JiangH.Systems
{
    public class RelationDBOperationSystem : MessageIn, ISystem
    {
        public IRelationDataBase relationDB { get; set; }

        public RelationDBOperationSystem(Relations.RelationDataBase relationDB)
        {
            this.relationDB = relationDB;

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
